using Builder;
using Factory;
using Factory.AbstractFactory;
using Singleton;

namespace DesignPatternsPractise;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Builders

        var builder = new SimpleBuilder("root").AddChild("child1").AddChild("child2");
        Console.WriteLine($"Builder - {builder}");

        var stepwiseBuilder = new StepwiseBuilder().SetFirstProperty(1).SetSecondProperty("2").Build();
        Console.WriteLine($"Stepwise builder - FirstProperty: {stepwiseBuilder.FirstProperty}, SecondProperty: {stepwiseBuilder.SecondProperty}, Stepwise model built \n");

        var functionalBuilder = new FunctionalExampleBuilder().SetProperty1("1").SetProperty2("2").Build();
        Console.WriteLine($"Functional builder - Property1: {functionalBuilder.Property1}, Property2: {functionalBuilder.Property2}, Functional model built \n");

        var facadeBuilder = new FacadeBuilder();
        FacadeModel facadeModel = facadeBuilder.Builder1.SetProperty1("1").SetProperty2("2").Builder2.SetProperty1("3").SetProperty2("4");
        Console.WriteLine(facadeModel);

        // Factories

        var simpleFactory = SimpleFactory.Factory.CreateNormal(1, 2);

        var asyncFactory = await  AsyncFactory.Factory.CreateAsync(1);

        var abstractFactory = new HomeAnimalFactory().CreateCat().Eat().Sleep();

        // Singletons

        var monostate = new Monostate
        {
            Name = "Monostate",
            Age = 1
        };
        Console.WriteLine(monostate);
        var monostate2 = new Monostate();
        Console.WriteLine(monostate2);
    }
}