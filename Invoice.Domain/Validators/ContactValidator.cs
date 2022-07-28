using FluentValidation;
using InvoiceApi.Domain.Entities;

namespace InvoiceApi.Domain.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                
                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.ContactInfo)
                .NotEmpty()
                .WithMessage("O contato não pode ser vazio")

                .NotNull()
                .WithMessage("O contato não pode ser nulo")

                .MinimumLength(3)
                .WithMessage("O contato deve ter no mínimo 3 caracteres")
                
                .MaximumLength(80)
                .WithMessage("O contato deve ter no máximo 80 caracteres");

            RuleFor(x => x.ContactType)
                .NotEmpty()
                .WithMessage("O tipo do contato não pode ser vazio")

                .NotNull()
                .WithMessage("O tipo do contato não pode ser nulo");

            RuleFor(x => x.ClientId)
                .NotEmpty()
                .WithMessage("O id do cliente não pode ser vazio")

                .NotNull()
                .WithMessage("O id do cliente não pode ser nulo");
        }
    }
}
