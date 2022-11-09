using FluentValidation.Results;

namespace ApplicationsServices.Exceptions
{
    //Captura los errores de validación
    //La validación verifica si los datos son correctos o no, les da el visto bueno si todo está bien.
    public class ValidationExceptions : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationExceptions() : base("Existen uno o más errores de validación.")
        {
            Errors = new List<string>();
        }
        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
