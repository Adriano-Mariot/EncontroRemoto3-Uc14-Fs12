using CapituloApi.Contexts;
using CapituloApi.Interfaces;
using CapituloApi.Models;

namespace CapituloApi.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly CapituloContext _capituloContext;
        public LivroRepository(CapituloContext context) 
        {
            _capituloContext= context;
        }

        public List<Livro> ler()
        {
            return _capituloContext.Livros.ToList();
        }

        public Livro BuscarPorId(int Id)
        {
            return _capituloContext.Livros.Find(Id);
        }

        public void Cadastrar(Livro livro)
        {
            _capituloContext.Livros.Add(livro);
            _capituloContext.SaveChanges();
        }

        public void Atualizar(int Id, Livro livro)
        {
            Livro livrobuscado = _capituloContext.Livros.Find(Id);
            if (livrobuscado != null)
            {
                livrobuscado.Titulo=livro.Titulo;
                livrobuscado.QuantidadePaginas=livro.QuantidadePaginas;
                livro.Disponivel=livro.Disponivel;
            }

            _capituloContext.Livros.Update(livrobuscado);
            _capituloContext.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Livro livro = _capituloContext.Livros.Find(Id);
            _capituloContext.Remove(livro);
            _capituloContext.SaveChanges();
        }
    }
}
