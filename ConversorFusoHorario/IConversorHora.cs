using System;

namespace ConversorFusoHorario
{
    /// <summary>
    /// Interface para conversão de datas e horários entre diferentes fusos horários.
    /// </summary>
    public interface IConversorHora
    {
        /// <summary>
        /// Converte uma data/hora para o fuso horário de destino informado.
        /// </summary>
        /// <param name="dataHora">Data e hora original.</param>
        /// <param name="idFusoDestino">ID do fuso horário de destino.</param>
        /// <returns>Data e hora convertida para o fuso horário de destino.</returns>
        DateTime ConverterParaFusoHorario(DateTime dataHora, string idFusoDestino);

        /// <summary>
        /// Obtém o ID do fuso horário correspondente à data/hora informada (em formato string).
        /// </summary>
        /// <param name="dataHoraStr">Data e hora em formato string.</param>
        /// <returns>ID do fuso horário correspondente.</returns>
        string ObterFusoHorarioDaData(string dataHoraStr);
    }
}
