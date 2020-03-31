using System;

namespace Dominio
{
    public class Amigo
    {
        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public Amigo(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public string NomeCompleto()
        {
            return $"{Nome}{Sobrenome}";
        }

        public int CalcularIdade()
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }

        public override string ToString()
        {
            return $"{Nome}{Sobrenome}|{DataNascimento.Date}";
        }
    }
}
