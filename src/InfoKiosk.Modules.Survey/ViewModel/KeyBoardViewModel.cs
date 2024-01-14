using InfoKiosk.Modules.Navigation.Services;
using InfoKiosk.Modules.Survey.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Modules.Survey.ViewModel
{
    public class KeyBoardViewModel
    {
        private readonly INavigator _navigator;

        public KeyBoardViewModel(INavigator navigator)
        {
            _navigator = navigator;

        }
    }
}
