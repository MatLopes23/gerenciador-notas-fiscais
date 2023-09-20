using Gerenciador_de_Notas_Fiscais.Models;

namespace Gerenciador_de_Notas_Fiscais.ViewModel
{
    public class NotaFiscalViewModel
    {
        public int IdNota { get; set; }

        public string? Emissor { get; set; }

        public DateTime Data { get; set; }

        public ICollection<Item>? Itens { get; set; }

        public Decimal? ValorTotal { get; set; }

        public void CalculaValorNota()
        {
            if (Itens != null && Itens.Any())
                this.ValorTotal = Itens.Sum(item => item.Valor);

            this.ValorTotal = decimal.Zero;
        }
    }
}
