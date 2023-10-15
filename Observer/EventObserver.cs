using System.ComponentModel;

namespace Observer
{
    /*
     * Implementing the observer pattern using built-in .NET event system.
     * Has a shortcoming of potential memory leaks if the observer is not unsubscribed from the event.
     */
    public class EventObserver
    {
        public event EventHandler<EventArguments> EventHandler;

        public void InvokeEvent()
        {
            EventHandler?.Invoke(this, new EventArguments { Message = "Event Invoked"});
        }
    }

    public class EventArguments
    {
        public string Message { get; set; }
    }

    public class ObservableCollections
    {
        public BindingList<int> BindingList = new BindingList<int>();

        public void Add(int value)
        {
            BindingList.Add(value);
        }
    }
}