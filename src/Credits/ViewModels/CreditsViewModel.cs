using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Credits.ViewModels
{
	public class CreditsViewModel : BindableBase
	{
		public List<string> Creators { get; }
		public CreditsViewModel()
		{
			Creators = new List<string>();
			Creators.Add("Bartosz Dobija");
			Creators.Add("Wojciech Kasolik");
			Creators.Add("Nikodem Nikiel");
			Creators.Add("Mateusz Jakobsche");
			Creators.Add("Adam Gigiewicz");
			Creators.Add("Tomasz Gancarczyk");
			Creators.Add("Łukasz Hamera");
		}
	}
}
