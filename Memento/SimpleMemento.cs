namespace Memento
{
    public class SimpleMemento
    {
        public int StateValue { get; }

        public SimpleMemento(int stateValue)
        {
            StateValue = stateValue;
        }
    }

    public class SimpleOriginator
    {
        private int _stateValue;
        private List<SimpleMemento> _changes = new List<SimpleMemento>();
        private int _current;

        public SimpleOriginator(int stateValue)
        {
            _stateValue = stateValue;
            _changes.Add(CreateMemento());
        }

        public override string? ToString()
        {
            return $"StateValue: {_stateValue}";
        }

        public SimpleMemento CreateMemento()
        {
            return new SimpleMemento(_stateValue);
        }

        public SimpleMemento RestoreMemento(SimpleMemento memento)
        {
            if (memento == null)
            {
                return null;
            }
            _stateValue = memento.StateValue;
            _changes.Add(memento);
            return memento;
        }

        public SimpleMemento Undo()
        {
            if (_current <= 0)
            {
                return null;
            }
            var memento = _changes[--_current];
            _stateValue = memento.StateValue;
            return memento;
        }

        public SimpleMemento Redo()
        {
            if (_current + 1 >= _changes.Count)
            {
                return null;
            }
            var memento = _changes[++_current];
            _stateValue = memento.StateValue;
            return memento;
        }

        public int GetStateValue()
        {
            return _stateValue;
        }

        public SimpleMemento SetStateValue(int stateValue)
        {
            _stateValue = stateValue;
            ++_current;
            var memento = CreateMemento();
            _changes.Add(memento);
            return memento;
        }
    }
}