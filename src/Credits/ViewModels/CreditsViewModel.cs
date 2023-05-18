using InfoKiosk.Modules.Credits.Models;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Credits.Modules.ViewModels
{
	public class CreditsViewModel : BindableBase
	{
		public List<Person> Creators { get; }
		public List<Person> Instructors { get; }
		public CreditsViewModel()
		{
			QRCodeGenerator qrGenerator = new QRCodeGenerator();
			Creators = new List<Person>();
			Instructors = new List<Person>();
			Creators = addCreators(Creators, qrGenerator);
			Instructors = addInstructors(Instructors, qrGenerator);
		}

		private List<Person> addInstructors(List<Person> instructors, QRCodeGenerator qrGenerator)
		{
			instructors.Add(
				new Person("Łukasz", "Hamera", "https://github.com/LucasHamera", "lhamera@ath.bielsko.pl", qrGenerator));
			instructors.Add(
				new Person("Tomasz", "Gancarczyk", "", "tgan@ath.bielsko.pl", qrGenerator));
			return instructors;
		}

		private static List<Person> addCreators(List<Person> creators, QRCodeGenerator qrGenerator)
		{
			creators.Add(
				new Person("Bartosz", "Dobija", "https://github.com/BartShoot", "dobija.bartosz@gmail.com", qrGenerator));
			creators.Add(
				new Person("Wojciech", "Kasolik", "https://github.com/Lorn-Hukka", "", qrGenerator));
			creators.Add(
				new Person("Nikodem", "Nikiel", "https://github.com/VeliverX", "", qrGenerator));
			creators.Add(
				new Person("Mateusz", "Jakobsche", "https://github.com/MateuszJakobsche", "", qrGenerator));
			creators.Add(
				new Person("Adam", "Gigiewicz", "https://github.com/AdamGigiewicz", "", qrGenerator));
			return creators;
		}
	}
}
