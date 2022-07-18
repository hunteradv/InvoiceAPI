using FluentValidation;
using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Domain.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
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
                .WithMessage("A descriçao deve ter no mínimo 3 caracteres")
                
                .MaximumLength(80)
                .WithMessage("A descrição deve ter no máximo 80 caracteres");

            RuleFor(x => x.UnitValue)
                .NotEmpty()
                .WithMessage("O valor unitário não pode ser vazio")

                .NotNull()
                .WithMessage("O valor uniário não pode ser nulo");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("A quantidade não pode ser vazia")

                .NotNull()
                .WithMessage("A quantidade não pode ser nula");

            RuleFor(x => x.TotalItem)
                .NotEmpty()
                .WithMessage("O total do item não pode ser vazio")

                .NotNull()
                .WithMessage("O total do item não pode ser nulo");

            RuleFor(x => x.InvoiceId)
                .NotEmpty()
                .WithMessage("O id da nota não pode ser vazio")

                .NotNull()
                .WithMessage("O id da nota não pode ser nulo");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("O id do produto não pode ser vazio")

                .NotNull()
                .WithMessage("O id do produto não pode ser nulo");
        }
    }
}
