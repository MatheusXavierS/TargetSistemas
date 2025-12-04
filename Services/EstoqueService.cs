using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TargetSistemas.Desafios.Models;

namespace TargetSistemas.Desafios.Services
{
    public class EstoqueService
    {
        private readonly string _caminhoEstoque = "estoque.json";

        public List<Produto> CarregarEstoque()
        {
            try
            {
                string json = File.ReadAllText(_caminhoEstoque);
                var root = JsonSerializer.Deserialize<EstoqueRoot>(json);
                return root?.estoque ?? new List<Produto>();
            }
            catch
            {
                Console.WriteLine("Erro ao carregar estoque.");
                return new List<Produto>();
            }
        }

        public void SalvarEstoque(List<Produto> produtos)
        {
            try
            {
                var root = new EstoqueRoot { estoque = produtos };
                string json = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_caminhoEstoque, json);
            }
            catch
            {
                Console.WriteLine("Erro ao salvar estoque.");
            }
        }
    }
}
