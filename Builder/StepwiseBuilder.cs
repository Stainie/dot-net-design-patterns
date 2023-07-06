namespace Builder
{
    /*
     * Use Stepwise builder when you have a complex object that needs to be built in steps and at exact order.
     * Extra benefit is when setting a second property depends on the first property.
    */
    public class StepwiseModel
    {
        public int FirstProperty { get; set; }
        public string? SecondProperty { get; set; }
    }

    public class StepwiseBuilder : IFirstPropertyBuilder, ISecondPropertyBuilder, IModelBuilder
    {
        private readonly StepwiseModel _stepwiseModel = new();
        public ISecondPropertyBuilder SetFirstProperty(int value)
        {
            _stepwiseModel.FirstProperty = value;
            return this;
        }

        public IModelBuilder SetSecondProperty(string? value)
        {
            _stepwiseModel.SecondProperty = value;
            return this;
        }

        public StepwiseModel Build()
        {
            return _stepwiseModel;
        }
    }

    public interface IFirstPropertyBuilder
    {
        ISecondPropertyBuilder SetFirstProperty(int value);
    }

    public interface ISecondPropertyBuilder
    {
        IModelBuilder SetSecondProperty(string? value);
    }

    public interface IModelBuilder
    {
        StepwiseModel Build();
    }
}