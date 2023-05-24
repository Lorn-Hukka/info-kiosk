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
                new Person("Bartosz", "Dobija", "https://github.com/BartShoot", "dobija.bartosz@gmail.com")
            };
            var instructors = new List<Person>
            {
				new Person("Łukasz", "Hamera", "https://github.com/LucasHamera", "lhamera@ath.bielsko.pl")
            };

            Creators = ConvertToViewModels(creators);
            Instructors = ConvertToViewModels(instructors);
        }

        private List<PersonViewModel> ConvertToViewModels(List<Person> people)
        {
            return people.Select(ConvertToViewModel).ToList();
        }

        private PersonViewModel ConvertToViewModel(Person person)
        {
            return new PersonViewModel(person);
        }
    }
}
