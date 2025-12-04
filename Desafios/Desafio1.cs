using System;
using TargetSistemas.Services;

namespace TargetSistemas.Desafios
{
    public static class Desafio1
    {
        public static void Executar()
        {
            var service = new VendaService();

            try
            {
                var comissoes = service.CalcularComissoes("vendas.json");

                Console.WriteLine("\n      COMISSÕES");

                foreach (var item in comissoes)
                {
                    Console.WriteLine($"{item.Key}: R$ {item.Value:F2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
