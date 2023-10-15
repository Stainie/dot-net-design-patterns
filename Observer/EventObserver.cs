namespace Observer
{
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
}