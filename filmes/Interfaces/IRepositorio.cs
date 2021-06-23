using System.Collections.Generic;

namespace DIO.filmes.Interfaces
{
  public interface IRepositorio<T>
  {
    List<T> Lista();

    T retornaPorId(int id);

    void Insere(T objeto);

    void Exclui(int id);

    void Atualiza(int id, T objeto);

    int UltimoId();
  }
}