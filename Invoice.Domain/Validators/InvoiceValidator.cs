using FluentValidation;
using InvoiceApi.Domain.Entities;

namespace InvoiceApi.Domain.Validators
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                
                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.ClientId)
                .NotEmpty()
                .WithMessage("O id do cliente não pode ser vazio")

                .NotNull()
                .WithMessage("O id do cliente não pode ser nulo");

            RuleFor(x => x.SerialNumber)
                .NotEmpty()
                .WithMessage("O número de série não pode ser vazio")

                .NotNull()
                .WithMessage("O número de série não pode ser nulo");

            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("O número não pode ser vazio")

                .NotNull()
                .WithMessage("O número não pode ser nulo");

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("O status não pode ser vazio")

                .NotNull()
                .WithMessage("O status não pode ser nulo");

            RuleFor(x => x.Total)
                .NotEmpty()
                .WithMessage("O total não pode ser vazio")

                .NotNull()
                .WithMessage("O total não pode ser nulo");
        }
    }
}
