using FluentValidation;
using InvoiceApi.Domain.Entities;

namespace InvoiceApi.Domain.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
            
                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula")
                
                .MinimumLength(3)
                .WithMessage("O primeiro nome deve ter no mínimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O primeiro nome deve ter no máximo 80 caracteres");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula")

                .MinimumLength(3)
                .WithMessage("O segundo nome deve ter no mínimo 3 caracteres")

                .MaximumLength(200)
                .WithMessage("O segundo nome deve ter no máximo 200 caracteres");
        }
    }
}
