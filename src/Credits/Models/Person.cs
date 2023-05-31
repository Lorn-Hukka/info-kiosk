namespace InfoKiosk.Modules.Credits.Models
{
    public class Person
    {
        public string Name { get; }
        public string Surname { get; }
        public string GitHub { get; }
        public string Email { get; }

        public Person(string name, string surname, string gitHub, string email)
        {
            Name = name;
            Surname = surname;
            GitHub = gitHub;
            Email = email;
        }
    }
}
