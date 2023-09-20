using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador_de_Notas_Fiscais.Models
{
    [Table("NotaFiscal")]
    public class NotaFiscal
    {
        [Key]
        [Column("IdNota")]
        [Display(Name = "Identificador")]
        public int IdNota { get; set; }

        [Column("Emissor")]
        [Display(Name = "Nome Emissor")]
        public string? Emissor { get; set; }

        [Column("Data")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Emissão")]
        public DateTime Data { get; set; }

        [Display(Name = "Itens da Nota")]
        public ICollection<Item>? Itens { get; set; }

    }

}
