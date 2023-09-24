using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography.X509Certificates;

namespace Mediator
{
    public class Actor
    {
        protected EventBroker broker;

        public Actor(EventBroker broker)
        {
            this.broker = broker;
        }
    }

    public class ActorA : Actor
    {
        public void DoSomething()
        {
            broker.Publish(new ActorEvent1 { action1 = 1 });
            broker.Publish(new ActorEvent2 { action2 = true });
        }
        public ActorA(EventBroker broker) : base(broker)
        {
            broker.OfType<ActorEvent1>().Subscribe(e =>
            {
                if (e.action1 == 1)
                {
                    System.Console.WriteLine("ActorA: Action1 is 1");
                }
            });

            broker.OfType<ActorEvent2>().Subscribe(e =>
            {
                if (e.action2)
                {
                    System.Console.WriteLine("ActorA: Action2 is true");
                }
            });
        }
    }

    public class ActorB : Actor
    {
        public void DoSomething()
        {
            broker.Publish(new ActorEvent1 { action1 = 2 });
            broker.Publish(new ActorEvent2 { action2 = false });
        }
        public ActorB(EventBroker broker) : base(broker)
        {
            broker.OfType<ActorEvent1>().Subscribe(e =>
            {
                if (e.action1 == 2)
                {
                    System.Console.WriteLine("ActorB: Action1 is 2");
                }
            });

            broker.OfType<ActorEvent2>().Subscribe(e =>
            {
                if (!e.action2)
                {
                    System.Console.WriteLine("ActorB: Action2 is false");
                }
            });
        }
    }

    public class ActorEvent
    {
        public string Name { get; set; }
    }

    public class ActorEvent1 : ActorEvent
    {
        public int action1 { get; set; }
    }

    public class ActorEvent2 : ActorEvent
    {
        public bool action2 { get; set; }
    }

    public class EventBroker : IObservable<ActorEvent>
    {
        Subject<ActorEvent> subscriptions = new Subject<ActorEvent>();
        public IDisposable Subscribe(IObserver<ActorEvent> observer)
        {
            subscriptions.Subscribe(observer);
            return null;
        }

        public void Publish(ActorEvent ae)
        {
            subscriptions.OnNext(ae);
        }
    }
}