using FluentValidation;
using InvoiceApi.Domain.Entities;

namespace InvoiceApi.Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Number)
                .NotNull()
                .WithMessage("O nome não pode ser nulo")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio");

            RuleFor(x => x.District)
                .NotNull()
                .WithMessage("O bairro não pode ser nulo")

                .NotEmpty()
                .WithMessage("O bairro não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("O bairro deve ter no mínimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O bairro deve ter no máximo 80 caracteres");

            RuleFor(x => x.City)
                .NotNull()
                .WithMessage("A cidade não pode ser nula")

                .NotEmpty()
                .WithMessage("A cidade não pode ser vazia")

                .MinimumLength(3)
                .WithMessage("A cidade deve ter no mínimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("A cidade deve ter no máximo 80 caracteres");

            RuleFor(x => x.State)
                .NotNull()
                .WithMessage("O estado não pode ser nulo")

                .NotEmpty()
                .WithMessage("O estado não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("O estado deve ter no mínimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O estado deve ter no máximo 80 caracteres");

            RuleFor(x => x.Country)
                .NotNull()
                .WithMessage("O país não pode ser nulo")

                .NotEmpty()
                .WithMessage("O país não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("O país deve ter no mínimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O país deve ter no máximo 80 caracteres");

            RuleFor(x => x.ClientId)
                .NotNull()
                .WithMessage("O bairro não pode ser nulo")

                .NotEmpty()
                .WithMessage("O bairro não pode ser vazio");
        }
    }
}
