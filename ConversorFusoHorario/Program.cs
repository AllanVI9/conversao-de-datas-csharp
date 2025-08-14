using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConversorFusoHorario
{
    class Program
    {
        static List<IAgendaEntrada> compromissos = new List<IAgendaEntrada>();
        static IConversorHora conversorHora = new ConversorHora();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1 - Adicionar compromisso");
                Console.WriteLine("2 - Exibir compromissos do dia (com região de fuso)");
                Console.WriteLine("3 - Exibir todos (com região de fuso)"); 
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": AdicionarCompromisso(); break;
                    case "2": ExibirPorDia(); break;
                    case "3": ExibirTodos(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        static void AdicionarCompromisso()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            DateTime dataHora;
            while (true)
            {
                Console.Write("Data e hora (dd/MM/yyyy HH:mm): ");
                string entrada = Console.ReadLine().Trim();  

                bool sucesso = DateTime.TryParseExact(
                    entrada,
                    "dd/MM/yyyy HH:mm",
                    new CultureInfo("pt-BR"),  
                    DateTimeStyles.None,
                    out dataHora
                );

                if (sucesso)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Formato inválido. Use: dd/MM/yyyy HH:mm (ex: 14/08/2025 15:00)");
                    Console.ResetColor();
                }
            }

            var compromisso = new AgendaEntrada(dataHora, titulo, conversorHora);
            compromissos.Add(compromisso);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Compromisso adicionado com sucesso!");
            Console.ResetColor();
        }

        static bool FusoHorarioEhValido(string idFuso)
        {
            try
            {
                TimeZoneInfo.FindSystemTimeZoneById(idFuso);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void ExibirPorDia()
        {
            string fusoDestino;
            while (true)
            {
                Console.Write("Fuso para exibição: ");
                fusoDestino = Console.ReadLine();

                if (!FusoHorarioEhValido(fusoDestino))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Fuso horário inválido. Digite um ID válido (ex: E. South America Standard Time).");
                    Console.ResetColor();
                }
                else break;
            }

            DateTime dataFiltro;
            while (true)
            {
                Console.Write("Data (dd/MM/yyyy): ");
                string entrada = Console.ReadLine();

                bool sucesso = DateTime.TryParseExact(
                    entrada,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dataFiltro
                );

                if (sucesso) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Formato inválido. Use: dd/MM/yyyy");
                Console.ResetColor();
            }

            Console.WriteLine($"\n Compromissos no dia {dataFiltro:dd/MM/yyyy} ({fusoDestino}):");

            foreach (var c in compromissos)
            {
                DateTime ajustado = conversorHora.ConverterParaFusoHorario(c.DataHora, fusoDestino);
                if (ajustado.Date == dataFiltro.Date)
                {
                    c.Imprimir(fusoDestino);
                }
            }
        }

        static void ExibirTodos()
        {
            string fusoDestino;
            while (true)
            {
                Console.Write("Fuso para exibição: ");
                fusoDestino = Console.ReadLine();

                if (!FusoHorarioEhValido(fusoDestino))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Fuso horário inválido. Exemplo válido: E. South America Standard Time");
                    Console.ResetColor();
                }
                else break;
            }

            Console.WriteLine($"\n Todos os compromissos ({fusoDestino}):");

            foreach (var c in compromissos)
            {
                c.Imprimir(fusoDestino);
            }
        }
    }
}
