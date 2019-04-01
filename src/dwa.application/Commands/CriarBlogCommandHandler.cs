using dwa.Application.Behaviors;
using dwa.domain.AggregatesModel.CatalogoAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace dwa.Application.Commands
{
    public class CriarBlogCommandHandler : IRequestHandler<CriarBlogCommand, Response>
    {
        private readonly IBlogRepository _blogRepository;

        public CriarBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Response> Handle(CriarBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog
            {
                Nome = request.Nome,
                
            };

            var result =  await _blogRepository.AddAsync(blog);            
            return new Response(result.Id);
        }
    }   
}
