using Infraestrutura;
using System;
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

            var repositorio = AmigoRepositorioFabrica.Criar(TipoRepositorio.List);

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
                    Console.WriteLine("Informe o nome, ou parte do nome do amigo que deseja encontrar:");
                    var termoDePesquisa = Console.ReadLine();
                    var amigosEncontrados = repositorio.Pesquisar(termoDePesquisa)
                                                       .ToList();

                    if (amigosEncontrados.Count > 0)
                    {
                        Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de um dos amigos encontrados:");
                        for (var index = 0; index < amigosEncontrados.Count; index++)
                            Console.WriteLine($"{index} - {amigosEncontrados[index].Nome}");

                        var indexAExibir = int.Parse(Console.ReadLine());

                        if (indexAExibir < amigosEncontrados.Count)
                        {
                            var amigo = amigosEncontrados[indexAExibir];

                            Console.WriteLine("Dados da amigo");
                            Console.WriteLine($"Nome: {amigo.Nome}");
                            Console.WriteLine($"Data de nascimento: {amigo.DataNascimento:dd/MM/yyyy}");

                            var qtdeTempo = amigo.CalcularIdade();

                            if (qtdeTempo > 0)
                            {
                                Console.Write($"Este amigo foi lançado há {qtdeTempo} ano(s). {pressioneQualquerTecla}");
                            }
                            else if (qtdeTempo == 0)
                            {
                                Console.Write($"Este amigo foi lançado este ano! {pressioneQualquerTecla}");
                            }
                            else
                            {
                                Console.Write($"Este amigo ainda não foi lançado. {pressioneQualquerTecla}");
                            }
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Não foi encontrado nenhum amigo! {pressioneQualquerTecla}");
                        Console.ReadKey();
                    }
                }

                else if (opcaoEscolhida == "2")
                {
                    Console.WriteLine("Informe o nome do amigo que deseja adicionar");
                    var nomeAmigo = Console.ReadLine();

                    Console.WriteLine("Informe a data de nascimento no formato dd/MM/yyyy");
                    var inputDataLancamento = Console.ReadLine();

                    Console.WriteLine("Os dados estão corretos?");
                    Console.WriteLine($"Nome: {nomeAmigo}");
                    Console.WriteLine($"Data de nascimento: {inputDataLancamento}");
                    Console.WriteLine("1 - Sim \n2 - Não");

                    var opcaoParaAdicionar = Console.ReadLine();

                    if (opcaoParaAdicionar == "1")
                    {
                        repositorio.Adicionar(new Dominio.Amigo(nomeAmigo, DateTime.Parse(inputDataLancamento)));
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
