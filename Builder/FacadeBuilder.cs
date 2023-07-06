namespace Builder
{
    /*
     * The Facade Builder pattern is used when you want to provide a simplified interface or entry point to a complex subsystem or set of related classes.
     * It aims to simplify the usage and interaction with the subsystem by encapsulating its complexity behind a single facade object
     */
    public class FacadeModel
    {
        public string? builder1property1, builder1property2;

        public string? builder2property1, builder2property2;

        public override string ToString()
        {
            return $"{nameof(builder1property1)}: {builder1property1}, {nameof(builder1property2)}: {builder1property2}, {nameof(builder2property1)}: {builder2property1}, {nameof(builder2property2)}: {builder2property2}, Facade model built";
        }
    }
    public class FacadeBuilder
    {
        protected FacadeModel Model = new();

        public FacadeBuilder1 Builder1 => new(Model);
        public FacadeBuilder2 Builder2 => new(Model);

        public static implicit operator FacadeModel(FacadeBuilder facadeBuilder)
        {
            return facadeBuilder.Model;
        }
    }

    public class FacadeBuilder1 : FacadeBuilder
    {
        public FacadeBuilder1(FacadeModel model)
        {
            this.Model = model;
        }

        public FacadeBuilder1 SetProperty1(string? value)
        {
            Model.builder1property1 = value;
            return this;
        }

        public FacadeBuilder1 SetProperty2(string? value)
        {
            Model.builder1property2 = value;
            return this;
        }
    }

    public class FacadeBuilder2 : FacadeBuilder
    {
        public FacadeBuilder2(FacadeModel model)
        {
            this.Model = model;
        }

        public FacadeBuilder2 SetProperty1(string? value)
        {
            Model.builder2property1 = value;
            return this;
        }

        public FacadeBuilder2 SetProperty2(string? value)
        {
            Model.builder2property2 = value;
            return this;
        }
    }
}
