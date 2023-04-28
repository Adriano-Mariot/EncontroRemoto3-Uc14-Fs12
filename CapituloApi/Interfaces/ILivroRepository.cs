using CapituloApi.Models;

namespace CapituloApi.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> ler();
        Livro BuscarPorId(int Id);

        void Cadastrar(Livro livro);

        void Atualizar(int Id, Livro livro);

        void Deletar(int Id);

    }
}
