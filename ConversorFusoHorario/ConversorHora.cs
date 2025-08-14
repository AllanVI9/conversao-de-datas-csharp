using System;

namespace ConversorFusoHorario
{
    public class ConversorHora : IConversorHora
    {
        public DateTime ConverterParaFusoHorario(DateTime dataHora, string idFusoDestino)
        {
            TimeZoneInfo tzDestino = TimeZoneInfo.FindSystemTimeZoneById(idFusoDestino);
            return TimeZoneInfo.ConvertTime(dataHora, tzDestino);
        }

        public string ObterFusoHorarioDaData(string dataHoraStr)
        {
            if (DateTime.TryParse(dataHoraStr, out DateTime dataHora))
            {
                if (dataHora.Kind == DateTimeKind.Local)
                    return TimeZoneInfo.Local.Id;
                else if (dataHora.Kind == DateTimeKind.Utc)
                    return TimeZoneInfo.Utc.Id;
                else
                    return "Unspecified";
            }
            else
            {
                throw new ArgumentException("Data inválida: não foi possível converter a string para DateTime.");
            }
        }
    }
}
