namespace Proxy
{
    /*
     * We use property proxy when we want to intercept the assignment of a value to a property.
     * This is useful for extra control over the assignment of a value to a property.
     * This is substituting a property assignment override in C++.
     */
    public class PropertyProxy<T> : IEquatable<PropertyProxy<T>> where T : new()
    {
        private T value;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                Console.WriteLine($"Assigning value to {value}");
                this.value = value;
            }
        }

        public PropertyProxy(T value)
        {
            this.value = value;
        }

        public PropertyProxy() : this(default)
        {

        }

        public static implicit operator T(PropertyProxy<T> proxy)
        {
            return proxy.value;
        }

        public static implicit operator PropertyProxy<T>(T value)
        {
            return new PropertyProxy<T>(value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(obj, null)) return false;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PropertyProxy<T>)obj);
        }

        protected bool Equals(PropertyProxy<T> other)
        {
            return EqualityComparer<T>.Default.Equals(value, other.value);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(value);
        }

        bool IEquatable<PropertyProxy<T>>.Equals(PropertyProxy<T>? other)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(PropertyProxy<T> left, PropertyProxy<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PropertyProxy<T> left, PropertyProxy<T> right)
        {
            return !Equals(left, right);
        }
    }

    public class ProxyModel
    {
        private PropertyProxy<int> exampleProperty = new PropertyProxy<int>();

        public int ExampleProperty
        {
            get => exampleProperty.Value;
            set => exampleProperty.Value = value;
        }
    }
}
