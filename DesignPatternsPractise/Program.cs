﻿using Bridge;
using Builder;
using Composite;
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
        Console.WriteLine($"Stepwise builder - FirstProperty: {stepwiseBuilder.FirstProperty}, SecondProperty: {stepwiseBuilder.SecondProperty}, Stepwise model built");

        var functionalBuilder = new FunctionalExampleBuilder().SetProperty1("1").SetProperty2("2").Build();
        Console.WriteLine($"Functional builder - Property1: {functionalBuilder.Property1}, Property2: {functionalBuilder.Property2}, Functional model built");

        var facadeBuilder = new FacadeBuilder();
        FacadeModel facadeModel = facadeBuilder.Builder1.SetProperty1("1").SetProperty2("2").Builder2.SetProperty1("3").SetProperty2("4");
        Console.WriteLine(facadeModel);

        // Factories

        var simpleFactory = SimpleFactory.Factory.CreateNormal(1, 2);

        var asyncFactory = await  AsyncFactory.Factory.CreateAsync(1);

        var abstractFactory = new HomeAnimalFactory().CreateCat().Eat().Sleep();

        // Singletons

        var singleton = SimpleSingleton.Instance;
        var singletonWrapper = new SingletonDIWrapper(singleton);
        singletonWrapper.DoSomething(new List<string> { "1", "2", "3" });

        var singletonThread1 = Task.Factory.StartNew(() =>
        {
            Console.WriteLine($"PerThreadSingleton thread 1: {PerThreadSingleton.Instance.Id}");
        });
        var singletonThread2 = Task.Factory.StartNew(() =>
        {
            Console.WriteLine($"PerThreadSingleton thread 2: {PerThreadSingleton.Instance.Id}");
        });
        Task.WaitAll(singletonThread1, singletonThread2);

        var monostate = new Monostate
        {
            Name = "Monostate",
            Age = 1
        };
        Console.WriteLine(monostate);
        var monostate2 = new Monostate();
        Console.WriteLine(monostate2);

        // Bridge

        var vectorRenderer = new VectorRenderer();
        var triangle = new Triangle(vectorRenderer);
        Console.WriteLine(triangle);

        // Composite

        var compositeBase = new CompositeBase() { Name = "Base" };
        compositeBase.Children.Add(new Composite1() {Name = "Composite 1"});
        compositeBase.Children.Add(new Composite2() { Name = "Composite 2"});

        var compositeChild = new CompositeBase() { Name = "Child" };
        compositeChild.Children.Add(new Composite1() { Name = "Composite Child 1" });
        compositeChild.Children.Add(new Composite2() { Name = "Composite Child 2" });
        compositeBase.Children.Add(compositeChild);
        Console.WriteLine(compositeBase);
    }
}