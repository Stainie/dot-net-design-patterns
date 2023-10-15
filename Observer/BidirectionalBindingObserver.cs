using JetBrains.Annotations;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Observer
{
    public class ObserverModelA : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ObserverModelB : INotifyPropertyChanged
    {
        private string displayName;

        public string DisplayName
        {
            get => displayName;
            set
            {
                if (displayName == value) return;
                displayName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }

    public sealed class BidirectionalBindingObserver : IDisposable
    {
        private bool disposed;

        public BidirectionalBindingObserver(INotifyPropertyChanged first, Expression<Func<object>> firstProperty,
            INotifyPropertyChanged second, Expression<Func<object>> secondProperty)
        {
            if (firstProperty.Body is MemberExpression firstExpr &&
                secondProperty.Body is MemberExpression secondExpr)
            {
                if (firstExpr.Member is PropertyInfo firstProp &&
                                       secondExpr.Member is PropertyInfo secondProp)
                {
                    first.PropertyChanged += (sender, args) =>
                    {
                        if (args.PropertyName == firstProp.Name)
                        {
                            secondProp.SetValue(second, firstProp.GetValue(first));
                        }
                    };

                    second.PropertyChanged += (sender, args) =>
                    {
                        if (args.PropertyName == secondProp.Name)
                        {
                            firstProp.SetValue(first, secondProp.GetValue(second));
                        }
                    };
                }
            }
        }

        public void Dispose()
        {
            disposed = true;
        }
    }
}
