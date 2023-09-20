using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador_de_Notas_Fiscais.Models
{


    [Table("Item")]
    public class Item
    {
        [Key]
        [Column("IdItem")]
        public int IdItem { get; set; }

        [Column("Produto")]
        public string Produto { get; set; }

        [Column("Valor")]
        public decimal Valor { get; set; }

        [ForeignKey("NotaFiscal")]
        [Column("IdNota")]
        public int IdNota { get; set; }

        public required NotaFiscal NotaFiscal { get; set; }
    }

}
