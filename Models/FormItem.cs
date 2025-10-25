using ReactiveUI;

namespace RTC.Models
{
    public class FormItem : ReactiveObject
    {
        private string? _name; // сделать nullable
        private int _value;

        public string? Name // сделать nullable
        {
            get => _name;
            set => _name = value;
        }

        public int Value
        {
            get => _value;
            set => this.RaiseAndSetIfChanged(ref _value, value);
        }

        // Constructor
        public FormItem(string name, int value)
        {
            Name = name;
            Value = value;
        }

        // Override ToString for better display in UI
        public override string ToString()
        {
            return Name;
        }
    }
}