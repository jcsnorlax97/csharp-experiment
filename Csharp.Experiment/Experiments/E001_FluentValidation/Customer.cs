namespace Csharp.Experiment.Experiments.E001_FluentValidation
{
    public class Customer
    {
        public string Surname { get; }
        public string Forename { get; }

        public Customer(string surname, string forename)
        {
            Surname = surname;
            Forename = forename;
        }
    }
}