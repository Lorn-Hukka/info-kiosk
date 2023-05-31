using InfoKiosk.Modules.Credits.Models;
using Prism.Mvvm;

namespace InfoKiosk.Modules.Credits.ViewModels
{
    public class CreditsViewModel : BindableBase
    {
        public List<PersonViewModel> Creators { get; }
		public List<PersonViewModel> Instructors { get; }
		public CreditsViewModel()
        {
            var creators = new List<Person>
            {
                new Person("Bartosz", "Dobija", "https://github.com/BartShoot", "dobija.bartosz@gmail.com"),
				new Person("Wojciech", "Kasolik", "https://github.com/Lorn-Hukka", ""),
				new Person("Nikodem", "Nikiel", "https://github.com/VeliverX", ""),
				new Person("Mateusz", "Jakobsche", "https://github.com/MateuszJakobsche", ""),
				new Person("Adam", "Gigiewicz", "https://github.com/AdamGigiewicz", "")
			};
            var instructors = new List<Person>
            {
				new Person("Łukasz", "Hamera", "https://github.com/LucasHamera", "lhamera@ath.bielsko.pl"),
				new Person("Tomasz", "Gancarczyk", "", "tgan@ath.bielsko.pl")
			};

            Creators = ConvertToViewModels(creators);
            Instructors = ConvertToViewModels(instructors);
        }

        private List<PersonViewModel> ConvertToViewModels(List<Person> people)
        {
			people.Sort((x, y) => string.Compare(x.Surname, y.Surname));
			return people.Select(ConvertToViewModel).ToList();
        }

        private PersonViewModel ConvertToViewModel(Person person)
        {
            return new PersonViewModel(person);
        }
    }
}