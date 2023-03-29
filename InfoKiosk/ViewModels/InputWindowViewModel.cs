using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.ViewModels
{
    public class InputWindowViewModel : ViewModelBase
    {
        public void DawajCommand()
        {
            MessageBus.Current.SendMessage("Dawaj");
        }
        public void KlikajCommand()
        {
            MessageBus.Current.SendMessage("Klikaj");
        }
    }
}
