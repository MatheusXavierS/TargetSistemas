using System;
using System.Collections.Generic;
using TargetSistemas.Desafios.Models;
using TargetSistemas.Desafios.Services;

namespace TargetSistemas.Desafios
{
    public class Desafio2
    {
        public static void Executar()
        {
            var estoqueService = new EstoqueService();
            var movService = new MovimentacaoService();

            var produtos = estoqueService.CarregarEstoque();

            Console.Write("Código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = produtos.Find(p => p.codigoProduto == codigo);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }

            Console.Write("Quantidade movimentada (positivo = entrada / negativo = saída): ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Motivo da movimentação: ");
            string motivo = Console.ReadLine();

            produto.estoque += quantidade;

            var novaMov = new Movimentacao
            {
                CodigoProduto = produto.codigoProduto,
                Quantidade = quantidade,
                DescricaoMovimentacao = motivo
            };

            movService.RegistrarMovimentacao(novaMov);
            estoqueService.SalvarEstoque(produtos);

            Console.WriteLine("\nMovimentação registrada!");
            Console.WriteLine($"Produto: {produto.codigoProduto} - {produto.descricaoProduto}");
            Console.WriteLine($"ID da Movimentação: {novaMov.Id}");
            Console.WriteLine($"Motivo: {motivo}");
            Console.WriteLine($"Estoque Atual: {produto.estoque}");
        }
    }
}
