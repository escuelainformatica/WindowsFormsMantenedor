namespace WindowsFormsMantenedor.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int IdCompania { get; set; }

        public virtual Companias Companias { get; set; }
    }
}
