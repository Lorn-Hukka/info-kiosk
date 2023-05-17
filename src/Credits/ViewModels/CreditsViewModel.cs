using InfoKiosk.Modules.Credits.Models;
using Prism.Mvvm;
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
			Creators = new List<Person>();
			Instructors = new List<Person>();
			Creators = addCreators(Creators);
			Instructors = addInstructors(Instructors);
		}

		private List<Person> addInstructors(List<Person> instructors)
		{
			throw new NotImplementedException();
		}

		private static List<Person> addCreators(List<Person> creators)
		{
			creators.Add(new Person
			{
				Name = "Bartosz",
				Surname = "Dobija",
				GitHub = "https://github.com/BartShoot",
				Email = "dobija.bartosz@gmail.com"
			});
			return creators;
		}
	}
}
