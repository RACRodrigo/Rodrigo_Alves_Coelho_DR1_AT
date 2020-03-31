using Dominio;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace Infraestrutura.List
{
    public class AmigoRepositorio : IAmigoRepositorio
    {
        private static List<Amigo> listaAmigos = new List<Amigo>();
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
                listaAmigos.Add(amigo);
            }
        }

        public List<Amigo> Pesquisar(string nomeOuParteNomeAmigo)
        {
            return listaAmigos.Where(x => x.Nome.ToLower().Contains(nomeOuParteNomeAmigo.ToLower()))
                                                       .ToList();
        }

        public void Adicionar(Amigo amigo)
        {
            listaAmigos.Add(amigo);
            File.WriteAllLines(NOME_ARQUIVO, listaAmigos.Select(amigo => amigo.ToString()));
        }
    }
}
