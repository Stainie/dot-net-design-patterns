namespace Builder
{
    /*
     * Functional Builder pattern is well-suited for scenarios where you want to construct an object using a functional or declarative style.
     * It leverages functional composition and immutable data structures to build objects in a concise and expressive manner
     */
    public class FunctionalModel
    {
        public string? Property1, Property2;
    }

    public abstract class FunctionalBuilder<TModel, TSelf> // TModel represents the model we are building, TSelf represents the builder itself
        where TSelf : FunctionalBuilder<TModel, TSelf>
        where TModel : new()
    {
        private readonly List<Func<TModel, TModel>> _actions = new(); // two generic parameters to make it fluent - affecting the model, and returning the reference to said model

        private TSelf AddAction(Action<TModel> action)
        {
            _actions.Add(m =>
            {
                action(m);
                return m;
            });
            return (TSelf)this;
        }

        public TSelf Do(Action<TModel> action) => AddAction(action);

        public TModel Build() => _actions.Aggregate(new TModel(), (model, action) => action(model));
    }

    public sealed class FunctionalExampleBuilder : FunctionalBuilder<FunctionalModel, FunctionalExampleBuilder>
    {
        public FunctionalExampleBuilder SetProperty1(string? value) => Do(m => m.Property1 = value);
        public FunctionalExampleBuilder SetProperty2(string? value) => Do(m => m.Property2 = value);
    }
}
