using FluentValidation;
using dwa.Application.Commands;

namespace dwa.Application.Validators
{
    public class CriarProdutoCommndValidator : AbstractValidator<CriarProdutoCommand>
    {
        public CriarProdutoCommndValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório");
        }
    }
}
