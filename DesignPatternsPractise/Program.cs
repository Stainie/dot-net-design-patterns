using Builder;

namespace DesignPatternsPractise;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = new SimpleBuilder("root");
        builder.AddChild("child1").AddChild("child2");
        Console.WriteLine($"Builder - {builder.ToString()}");

        var stepwiseBuilder = new StepwiseBuilder().SetFirstProperty(1).SetSecondProperty("2").Build();
        Console.WriteLine($"Stepwise builder - FirstProperty: {stepwiseBuilder.FirstProperty}, SecondProperty: {stepwiseBuilder.SecondProperty}, Stepwise model built \n");

        var functionalBuilder = new FunctionalExampleBuilder().SetProperty1("1").SetProperty2("2").Build();
        Console.WriteLine($"Functional builder - Property1: {functionalBuilder.Property1}, Property2: {functionalBuilder.Property2}, Functional model built \n");

        var facadeBuilder = new FacadeBuilder();
        FacadeModel facadeModel = facadeBuilder.Builder1.SetProperty1("1").SetProperty2("2").Builder2.SetProperty1("3").SetProperty2("4");
        Console.WriteLine(facadeModel);
    }
}