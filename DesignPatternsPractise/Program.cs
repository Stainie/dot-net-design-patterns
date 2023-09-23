using Adapter;
using Autofac;
using Bridge;
using Builder;
using ChainOfResponsibility;
using Composite;
using Decorator;
using Factory;
using Factory.AbstractFactory;
using Iterator;
using Proxy;
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

        // Adapter

        var adaptee = new Adaptee() { Property = 1 };
        var adapter = new AdapteeToAdapter(adaptee);
        Console.WriteLine($"Adapter - PropertyA: {adapter.PropertyA}, PropertyB: {adapter.PropertyB}, Sum: {adapter.PropSum()}");

        // Decorator

        var decoratedService = new Service();
        var decorator = new ServiceDecorator(decoratedService);
        decorator.DoSomething();

        var cb = new ContainerBuilder();    // Using decorator with dependency injection
        cb.RegisterType<Service>().Named<IService>("decorated service");
        cb.RegisterDecorator<IService>((c, inner) => new ServiceDecorator(inner), "decorator service");

        // Proxy
        
        var proxy = new PropertyProxy<int>(1);
        proxy.Value = 2;
        Console.WriteLine(proxy.Value);

        var valueProxy = new ValueProxy(1);
        valueProxy += 2;
        Console.WriteLine(valueProxy);

        var proxyItems = new CPItems(100);
        foreach (var item in proxyItems)
        {
            item.Value++;
        }

        var proxiedClass = DynamicProxy<ProxiedClass>.As<IProxiedInterface>();
        proxiedClass.DoSomething();
        proxiedClass.SomethingElse("test");

        // Chain of responsibility

        var methodChainModel = new MethodChainModel(1, "test");
        var chainModifier = new ChainModifier(methodChainModel);
        chainModifier.Add(new ModelModifier(methodChainModel)).Handle();

        var eventHandler = new BrokerEventHandler();
        var brokerChainModel = new BrokerChainModel(eventHandler, "test", 0, 0);

        using (new QueryProp1Modifier(eventHandler, brokerChainModel))
        {
            Console.WriteLine(brokerChainModel);
        }

        Console.WriteLine(brokerChainModel);

        // Iterator

        var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));

        var tree = new BinaryTree<int>(root);
        Console.WriteLine(string.Join(",", tree.InOrderTraversal.Select(x => x.Value)));
        Console.WriteLine(string.Join(",", tree.PreorderTraversal.Select(x => x.Value)));
        Console.WriteLine(string.Join(",", tree.PostorderTraversal.Select(x => x.Value)));
    }
}