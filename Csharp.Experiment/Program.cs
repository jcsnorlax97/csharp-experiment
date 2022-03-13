using Csharp.Experiment.Experiments.E001_FluentValidation;

namespace Csharp.Experiment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SimulateFluentValidationExperiment();
        }

        public static void SimulateFluentValidationExperiment()
        {
            var experiment = new FluentValidationExperiment(
                new CustomerValidator(),
                new Customer(string.Empty, string.Empty));
            experiment.SimulateExperiment();
        }
    }
}