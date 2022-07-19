using FluentValidation;
using InvoiceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Domain.Validators
{
    public class ProductValidate : AbstractValidator<Product>
    {
        public ProductValidate()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                
                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")

                .NotNull()
                .WithMessage("O nome não pode ser nulo")
                
                .MinimumLength(3)
                .WithMessage("O nome pode conter no mínimo 3 caracteres")
                
                .MaximumLength(80)
                .WithMessage("O nome pode conter no máximo 80 caracteres");

            RuleFor(x => x.UnitValue)
                .NotEmpty()
                .WithMessage("O valor unitário não pode ser vazio")

                .NotNull()
                .WithMessage("O valor unitário não pode ser nulo");
        }
    }
}
