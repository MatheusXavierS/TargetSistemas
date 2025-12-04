using System;
using System.Globalization;

namespace TargetSistemas.Desafios
{
    public static class Desafio3
    {
        public static void Executar()
        {
            Console.Write("Valor original: ");
            double valor = double.Parse(Console.ReadLine());

            DateTime vencimento;
            string inputData;

            while (true)
            {
                Console.Write("Data de vencimento (dd/MM/yyyy): ");
                inputData = Console.ReadLine();

                bool ok = DateTime.TryParseExact(
                    inputData,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out vencimento
                );

                if (ok)
                    break;

                Console.WriteLine("Data inválida! Digite novamente no formato dd/MM/yyyy. Ex.: 01/12/2025\n");
            }

            int diasAtraso = (DateTime.Today - vencimento).Days;

            if (diasAtraso < 0)
            {
                Console.WriteLine("Pagamento antes do vencimento. Sem juros.");
                return;
            }

            double juros = valor * 0.025 * diasAtraso;

            Console.WriteLine($"\nDias em atraso: {diasAtraso}");
            Console.WriteLine($"Juros total: R$ {juros:F2}");
            Console.WriteLine($"Valor final: R$ {(valor + juros):F2}");
        }
    }
}
