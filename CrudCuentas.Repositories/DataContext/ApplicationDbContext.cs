using CrudCuentas.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CrudCuentas.Repositories.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }

        public DbSet<Transaccion> Transacciones { get; set; }

        public DbSet<TipoTransaccion> TiposTransacciones { get; set; }

        public DbSet<TipoCuenta> TiposCuentas { get; set; }
        public DbSet<EstadoCuenta> EstadosCuentas { get; set; }

        public DbSet<TipoDocumento> TiposDocumentos { get; set; }

    }
}
