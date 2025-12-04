using System;

namespace TargetSistemas.Desafios.Models
{
    public class Movimentacao
    {
        public Guid Id { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
    }
}
