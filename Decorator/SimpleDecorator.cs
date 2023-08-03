namespace Decorator
{
    public interface IService
    {
        public void DoSomething();
    }

    public class Service : IService
    {
        public void DoSomething()
        {
            Console.WriteLine("Service");
        }

    }

    public class ServiceDecorator : IService
    {
        private readonly IService _service;

        public ServiceDecorator(IService service)
        {
            _service = service;
        }

        public void DoSomething()
        {
            Console.WriteLine("ServiceDecorator started");
            _service.DoSomething();
            Console.WriteLine("ServiceDecorator finished");
        }
    }
}