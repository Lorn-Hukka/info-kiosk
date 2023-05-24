using InfoKiosk.Modules.Credits.Models;

namespace InfoKiosk.Modules.Credits.ViewModels
{
    public class PersonViewModel
    {
        public string Name { get; }
        public string Surname { get; }
        public string GitHub { get; }
        public string Email { get; }

        public PersonViewModel(Person person): this(person.Name, person.Surname, person.GitHub, person.Email)
        {
            
        }

        public PersonViewModel(string name, string surname, string github, string email)
        {
            Name = name;
            Surname = surname;
            GitHub = github;
            Email = email;
        }
    }
}
