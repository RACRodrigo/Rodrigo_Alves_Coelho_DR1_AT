using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Infraestrutura.LinkedList
{
    public class AmigoRepositorio : IAmigoRepositorio
    {
        private static LinkedList<Amigo> listaAmigos = new LinkedList<Amigo>();
        private const string NOME_ARQUIVO = @".\lista_amigos.txt";

        public AmigoRepositorio()
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            if (!File.Exists(NOME_ARQUIVO))
                File.Create(NOME_ARQUIVO).Close();

            var linhas = File.ReadAllLines(NOME_ARQUIVO);

            foreach (var linha in linhas)
            {
                var info = linha.Split("|");

                var dataNascimento = DateTime.Parse(info[1]);

                var amigo = new Amigo(info[0], dataNascimento);
                listaAmigos.AddFirst(amigo);
            }
        }


        public List<Amigo> Pesquisar(string nomeOuParteNomeAmigo)
        {
            return listaAmigos.Where(x => x.NomeCompleto.ToLower().Contains(nomeOuParteNomeAmigo.ToLower()))
                                                       .OrderBy(x => x.NomeCompleto)
                                                       .ToList();
        }

        public void Adicionar(Amigo amigo)
        {
            listaAmigos.AddLast(amigo);
            File.WriteAllLines(NOME_ARQUIVO, listaAmigos.Select(amigo => amigo.ToString()));
        }
    }
}
