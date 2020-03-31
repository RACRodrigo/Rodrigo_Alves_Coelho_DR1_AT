using System;
using Infraestrutura;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Rodrigo_Alves_Coelho_DR1_AT
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
            const string pressioneQualquerTecla = "Pressione qualquer tecla para exibir o menu principal ...";

            var repositorio = LivroRepositorioFabrica.Criar(TipoRepositorio.List);

            string opcaoEscolhida;
            do
            {
                Console.Clear();
                Console.WriteLine("Gerenciador de Aniversários de Amigos\nSelecione uma das opções abaixo:");
                Console.WriteLine("1 - Pesquisar Amigo");
                Console.WriteLine("2 - Adicionar Amigo");
                Console.WriteLine("3 - Sair");

                opcaoEscolhida = Console.ReadLine();

                if (opcaoEscolhida == "1")
                {
                    Console.WriteLine("Informe o nome, ou parte do nome do livro que deseja encontrar:");
                    var termoDePesquisa = Console.ReadLine();
                    var livrosEncontrados = repositorio.Pesquisar(termoDePesquisa)
                                                       .ToList();

                    if (livrosEncontrados.Count > 0)
                    {
                        Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de um dos livros encontrados:");
                        for (var index = 0; index < livrosEncontrados.Count; index++)
                            Console.WriteLine($"{index} - {livrosEncontrados[index].Nome}");

                        var indexAExibir = int.Parse(Console.ReadLine());

                        if (indexAExibir < livrosEncontrados.Count)
                        {
                            var livro = livrosEncontrados[indexAExibir];

                            Console.WriteLine("Dados da livro");
                            Console.WriteLine($"Nome: {livro.Nome}");
                            Console.WriteLine($"Data de lançamento: {livro.DataLancamento:dd/MM/yyyy}");

                            var qtdeTempo = livro.CalcularHaQuantosAnosFoiLancado();

                            if (qtdeTempo > 0)
                            {
                                Console.Write($"Este livro foi lançado há {qtdeTempo} ano(s). {pressioneQualquerTecla}");
                            }
                            else if (qtdeTempo == 0)
                            {
                                Console.Write($"Este livro foi lançado este ano! {pressioneQualquerTecla}");
                            }
                            else
                            {
                                Console.Write($"Este livro ainda não foi lançado. {pressioneQualquerTecla}");
                            }
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Não foi encontrado nenhum livro! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                }

                else if (opcaoEscolhida == "2")
                {
                    Console.WriteLine("Informe o nome do livro que deseja adicionar");
                    var nomeLivro = Console.ReadLine();

                    Console.WriteLine("Informe a data de lançamento no formato dd/MM/yyyy");
                    var inputDataLancamento = Console.ReadLine();

                    Console.WriteLine("Os dados estão corretos?");
                    Console.WriteLine($"Nome: {nomeLivro}");
                    Console.WriteLine($"Data de lançamento: {inputDataLancamento}");
                    Console.WriteLine("1 - Sim \n2 - Não");

                    var opcaoParaAdicionar = Console.ReadLine();

                    if (opcaoParaAdicionar == "1")
                    {
                        repositorio.Adicionar(new Dominio.Livro(nomeLivro, DateTime.Parse(inputDataLancamento)));
                        Console.WriteLine($"Dados adicionados com sucesso! {pressioneQualquerTecla}");

                    }
                    else if (opcaoParaAdicionar == "2")
                        Console.WriteLine($"Dados descartados! {pressioneQualquerTecla}");
                    else
                        Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");

                    Console.ReadKey();
                }

                else if (opcaoEscolhida != "3")
                {
                    Console.WriteLine($"Opção inválida. {pressioneQualquerTecla}");
                    Console.ReadKey();
                }


            } while (opcaoEscolhida != "3");

        }
    }
}
