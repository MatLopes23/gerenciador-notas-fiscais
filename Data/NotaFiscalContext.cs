using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gerenciador_de_Notas_Fiscais.Models;

namespace Gerenciador_de_Notas_Fiscais.Data
{
    public class NotaFiscalContext : DbContext
    {
        public NotaFiscalContext (DbContextOptions<NotaFiscalContext> options)
            : base(options)
        {
        }

        public DbSet<Gerenciador_de_Notas_Fiscais.Models.NotaFiscal> NotaFiscal { get; set; } = default!;
    }
}
