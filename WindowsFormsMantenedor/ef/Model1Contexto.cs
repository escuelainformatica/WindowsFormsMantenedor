using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsMantenedor.ef
{
    public partial class Model1Contexto : DbContext
    {
        public Model1Contexto()
            : base("name=Model1Contexto")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Companias> Companias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Companias>()
                .Property(e => e.Compania)
                .IsUnicode(false);

            modelBuilder.Entity<Companias>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Companias)
                .HasForeignKey(e => e.IdCompania)
                .WillCascadeOnDelete(false);
        }
    }
}
