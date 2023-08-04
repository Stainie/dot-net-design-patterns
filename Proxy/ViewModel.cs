using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /*
     * ViewModel is used for MVVM architecture, where we want to have a separation between the model, logic and the view.
     */
    public record Model // Used record in this case, but it can be a class if any extra functionality is needed
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        private readonly Model _model;

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public int Value
        {
            get => _model.Value;
            set
            {
                _model.Value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        // Extra decorator can be added to the value getter / setter to have more control over the value

        public ViewModel(Model model)
        {
            _model = model;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
