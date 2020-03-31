using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutura
{
    public interface IAmigoRepositorio
    {
        void Adicionar(Amigo amigo);
        List<Amigo> Pesquisar(string nomeOuParteNomeAmigo);
    }
}