using System;
using System.IO;
using System.Text.Json;
using TargetSistemas.Desafios.Models;

namespace TargetSistemas.Desafios.Services
{
    public class MovimentacaoService
    {
        private readonly string _arquivoMovimentacao = "movimentacao.json";

        public MovimentacaoData CarregarMovimentacoes()
        {
            if (!File.Exists(_arquivoMovimentacao))
            {
                return new MovimentacaoData();
            }

            var json = File.ReadAllText(_arquivoMovimentacao);
            return JsonSerializer.Deserialize<MovimentacaoData>(json);
        }

        public void SalvarMovimentacoes(MovimentacaoData data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_arquivoMovimentacao, json);
        }

        public Movimentacao RegistrarMovimentacao(Movimentacao movimentacao)
        {
            var data = CarregarMovimentacoes();

            movimentacao.Id = Guid.NewGuid();
            movimentacao.Data = DateTime.Now;

            data.Movimentacoes.Add(movimentacao);

            SalvarMovimentacoes(data);

            return movimentacao;
        }
    }
}
