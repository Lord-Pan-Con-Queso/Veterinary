using FluentValidation;
using MediatR;

namespace ApplicationsServices.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                //WhenAll: Crea una tarea que se completará cuando se hayan completado todas las tareas proporcionadas.
                var validationResult = await Task.WhenAll(_validator.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(v => v.Errors).Where(x => x != null).ToList();

                if (failures.Count != 0)
                {
                    throw new Exceptions.ValidationExceptions(failures);
                }
            }
            return await next();
        }
    }
}