namespace Observer
{
    /*
     * Implementing observer pattern using interfaces requires a lot of boilerplate code.
     * However, it eliminates the risk of memory leaks.
     */
    public class Event
    {
    }

    public class EventExample1 : Event
    {
        public string Message { get; set; }
    }

    public class EventModel : IObservable<Event>
    {
        private readonly HashSet<Subscription> subscriptions = new HashSet<Subscription>();
        public IDisposable Subscribe(IObserver<Event> observer)
        {
            var subscription = new Subscription(this, observer);
            subscriptions.Add(subscription);
            return subscription;
        }

        public void FireEvent()
        {
            foreach (var subscription in subscriptions)
            {
                subscription.Observer.OnNext(new EventExample1 { Message = "Hello from interface implemented event" });
            }
        }

        private class Subscription : IDisposable
        {
            private readonly EventModel model;
            public readonly IObserver<Event> Observer;

            public Subscription(EventModel model, IObserver<Event> observer)
            {
                this.model = model;
                this.Observer = observer;
            }
            public void Dispose()
            {
                model.subscriptions.Remove(this);
            }
        }
    }

    public class EventSubscriber : IObserver<Event>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Event completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Event error: {error.Message}");
        }

        public void OnNext(Event value)
        {
            if (value is EventExample1 eventExample1)
            {
                Console.WriteLine(eventExample1.Message);
            }
        }
    }
}
