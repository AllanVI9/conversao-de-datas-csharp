using System;
using System.Globalization;

namespace ConversorFusoHorario
{
    public class AgendaEntrada : IAgendaEntrada
    {
        public DateTime DataHora { get; set; }
        public string Titulo { get; set; }

        private readonly IConversorHora _conversorHora;

        public AgendaEntrada(DateTime dataHora, string titulo, IConversorHora conversorHora)
        {
            DataHora = dataHora;
            Titulo = titulo;
            _conversorHora = conversorHora;
        }

        public void Imprimir(string? idFusoDestino = null)
        {
            DateTime dataConvertida = idFusoDestino != null
                ? _conversorHora.ConverterParaFusoHorario(DataHora, idFusoDestino)
                : DataHora;

            Console.WriteLine($"{dataConvertida:dd/MM/yyyy HH:mm} - {Titulo}");
        }

        public void ImprimirHora(string? idFusoDestino = null)
        {
            DateTime dataConvertida = idFusoDestino != null
                ? _conversorHora.ConverterParaFusoHorario(DataHora, idFusoDestino)
                : DataHora;

            Console.WriteLine($"{dataConvertida:HH:mm}");
        }

        public void ImprimirDia(string? idFusoDestino = null)
        {
            DateTime dataConvertida = idFusoDestino != null
                ? _conversorHora.ConverterParaFusoHorario(DataHora, idFusoDestino)
                : DataHora;

            Console.WriteLine($"{dataConvertida:dd/MM/yyyy}");
        }

        public void ImprimirDiaSemana(string? idFusoDestino = null)
        {
            DateTime dataConvertida = idFusoDestino != null
                ? _conversorHora.ConverterParaFusoHorario(DataHora, idFusoDestino)
                : DataHora;

            Console.WriteLine($"{dataConvertida:dddd}", CultureInfo.GetCultureInfo("pt-BR"));
        }
    }
}
