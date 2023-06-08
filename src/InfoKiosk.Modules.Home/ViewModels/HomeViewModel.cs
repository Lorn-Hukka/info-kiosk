using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace InfoKiosk.Modules.Home.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string currentTime = "01.01.1970 00:00:00";
        private string UserName;

        public string WellcomeString {
            get {

                if (UserName == null || UserName == "")
                {
                    if (DateTime.Now.Hour < 17 && DateTime.Now.Hour > 4)
                    {
                        return "Dzień Dobry!";
                    }
                    else if (DateTime.Now.Hour > 17 && DateTime.Now.Hour < 23) {
                        return "Dobry Wieczór!";
                    }
                    else
                    {
                        return "Dobranoc";
                    }
                }
                else { return "Witaj, " + UserName + "!"; }

            } 
        }

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public HomeViewModel() {

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
