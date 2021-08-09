namespace WindowsFormsMantenedor.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }

        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [StringLength(50)]
        public string NombreCompleto { get; set; }

        [StringLength(64)]
        public string Clave { get; set; }

        public int? IdGrupoUsuario { get; set; }

        public virtual Grupos Grupos { get; set; }
    }
}
