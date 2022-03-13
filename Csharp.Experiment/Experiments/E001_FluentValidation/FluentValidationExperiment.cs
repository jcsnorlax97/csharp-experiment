using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Csharp.Experiment.Experiments.E001_FluentValidation
{
    public class FluentValidationExperiment : IExperiment
    {
        private readonly AbstractValidator<Customer> _customerValidator;
        private readonly Customer _customer;

        public FluentValidationExperiment(AbstractValidator<Customer> customerValidator, Customer customer)
        {
            _customerValidator = customerValidator;
            _customer = customer;
        }

        public void SimulateExperiment()
        {
            var validator = new CustomerValidator();

            ValidationResult results = _customerValidator.Validate(_customer);

            bool isSuccess = results.IsValid;
            IEnumerable<ValidationFailure> failures = results.Errors;

            Console.WriteLine($"Success: '{isSuccess}'");
            Console.WriteLine($"Failures: ");
            foreach (var failure in failures)
            {
                Console.WriteLine(failure.ToString());
            }
        }
    }
}