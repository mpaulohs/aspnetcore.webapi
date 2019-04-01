using dwa.Application.Behaviors;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace dwa.Application.Commands
{
    public class CriarProdutoCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemFileName { get; set; }
        public string ImagemUri { get; set; }
        public int CatalogoTipoId { get; set; }       
        public int CatalogoMarcaId { get; set; }
        public CriarProdutoCommand() { }
        public CriarProdutoCommand(string nome, string descricao, decimal preco, string imagemfilename,
            int catalogotipoid, int catalogomarcaid)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            ImagemFileName = imagemfilename;
            CatalogoTipoId = catalogotipoid;
            CatalogoMarcaId = catalogomarcaid;

        }
    }
}
