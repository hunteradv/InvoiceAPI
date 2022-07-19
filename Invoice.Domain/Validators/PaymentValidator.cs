using FluentValidation;
using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Domain.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                
                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia")

                .NotNull()
                .WithMessage("A descrição não pode ser nula")
                
                .MinimumLength(3)
                .WithMessage("A descrição deve conter no mínimo 3 caracteres")

                .MinimumLength(80)
                .WithMessage("A descrição deve conter no máximo 80 caracteres");

            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("O valor não pode ser vazio")

                .NotNull()
                .WithMessage("O valor não pode ser nulo");

            RuleFor(x => x.PaymentType)
                .NotEmpty()
                .WithMessage("O tipo do pagamento não pode ser vazio")

                .NotNull()
                .WithMessage("O valor não pode ser nulo");

            RuleFor(x => x.InvoiceId)
                .NotEmpty()
                .WithMessage("O id da nota não pode ser vazio")

                .NotNull()
                .WithMessage("O id da nota não pode ser nulo");
        }
    }
}
