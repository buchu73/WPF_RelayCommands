using Remed_RelayCommand.RelayCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Remed_RelayCommand.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //default value
            this._isIncrementEnbaled = true;
            this._counter = 10;

            //Commands
            this.IncrementCommand = new SimpleRelayCommand(this.Increment, this.CanIncrement);
            this.DecrementCommand = new SimpleRelayCommand(this.Decrement);

            IncrementExtCommand = new ExtendedRelayCommand(IncrementExt, this.CanIncrementExt);
        }       

        //Data binding

        private int _counter;
        public int Counter
        {
            get { return _counter; }
            set { this.SetProperty(ref _counter, value); }
        }

        private bool _isIncrementEnbaled;
        public bool IsIncrementEnbaled
        {
            get { return _isIncrementEnbaled; }
            set { this.SetProperty(ref _isIncrementEnbaled, value); }
        }

        //Commands simple

        private bool CanIncrement()
        {
            return this.IsIncrementEnbaled;
        }

        public ICommand IncrementCommand { get; private set; }
        private void Increment()
        {
            this.Counter++;
        }

        public ICommand DecrementCommand { get; private set; }
        private void Decrement()
        {
            this.Counter--;
        }

        //Commands extended

        public ICommand IncrementExtCommand { get; private set; }
        private void IncrementExt(object? parameter)
        {
            int increment = int.Parse((string)parameter);
            this.Counter += increment;
        }

        private bool CanIncrementExt(object? parameter)
        {
            return CanIncrement();
        }
    }
}
