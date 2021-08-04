namespace WindowsFormsMantenedor.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Companias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Companias()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Compania { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Companias companias &&
                   Id == companias.Id;
        }

        public static bool operator ==(Companias comp1, Companias comp2) 
        {
            return comp1.Id==comp2.Id;
        }
        public static bool operator !=(Companias comp1, Companias comp2)
        {
            return comp1.Id != comp2.Id;
        }

    }
}
