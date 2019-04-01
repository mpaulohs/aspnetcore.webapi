using dwa.Application.Behaviors;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace dwa.Application.Commands
{
    public class CriarBlogCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
       
        public CriarBlogCommand() { }
        public CriarBlogCommand(string nome)
        {
            Nome = nome;          
        }
    }
}
