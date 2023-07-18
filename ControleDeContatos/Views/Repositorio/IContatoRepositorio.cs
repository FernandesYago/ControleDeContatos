using ControleDeContatos.Models;

namespace ControleDeContatos.Views.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
    }
}
