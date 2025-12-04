using System.Text.Json;
using TargetSistemas.Models;

namespace TargetSistemas.Services
{
    public class VendaService
    {
        public Dictionary<string, double> CalcularComissoes(string caminhoJson)
        {
            string json = LerArquivo(caminhoJson);
            var dados = Desserializar(json);

            if (dados.vendas == null || dados.vendas.Count == 0)
                throw new Exception("Nenhuma venda encontrada no JSON.");

            return SomarComissoes(dados);
        }

        private string LerArquivo(string caminho)
        {
            try
            {
                return File.ReadAllText(caminho);
            }
            catch (FileNotFoundException)
            {
                throw new Exception($"Arquivo não encontrado: {caminho}");
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Sem permissão para acessar o arquivo.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ler o arquivo: {ex.Message}");
            }
        }

        private VendasRoot Desserializar(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<VendasRoot>(json)
                       ?? throw new Exception("Falha ao desserializar JSON.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao converter JSON: {ex.Message}");
            }
        }

        private Dictionary<string, double> SomarComissoes(VendasRoot dados)
        {
            var total = new Dictionary<string, double>();

            foreach (var venda in dados.vendas)
            {
                double comissao = CalcularComissao(venda.valor);

                if (!total.ContainsKey(venda.vendedor))
                    total[venda.vendedor] = 0;

                total[venda.vendedor] += comissao;
            }

            return total;
        }

        private double CalcularComissao(double valor)
        {
            if (valor < 100)
                return 0;

            if (valor < 500)
                return valor * 0.01;

            return valor * 0.05;
        }
    }
}
