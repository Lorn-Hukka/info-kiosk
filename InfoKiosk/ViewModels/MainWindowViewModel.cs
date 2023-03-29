using System;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;

namespace InfoKiosk.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel() 
        {
            MessageBus.Current.Listen<string>().Subscribe(m => Greeting = m);
        }

        private string _message = "Welcome to Avalonia!";
        public string Greeting 
        { 
            get => _message;
            set { this.RaiseAndSetIfChanged(ref _message, value); } 
        }
    }
}