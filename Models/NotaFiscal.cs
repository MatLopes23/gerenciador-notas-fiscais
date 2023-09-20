using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador_de_Notas_Fiscais.Models
{
    [Table("NotaFiscal")]
    public class NotaFiscal
    {
        [Key]
        [Column("IdNota")]
        public int IdNota { get; set; }

        [Column("Emissor")]
        public string? Emissor { get; set; }

        [Column("Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public required ICollection<Item> Itens { get; set; }
    }

}
