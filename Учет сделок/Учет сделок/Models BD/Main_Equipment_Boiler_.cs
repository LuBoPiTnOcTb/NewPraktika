//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Учет_сделок.Models_BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Main_Equipment_Boiler_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Main_Equipment_Boiler_()
        {
            this.Contract = new HashSet<Contract>();
            this.Fuel = new HashSet<Fuel>();
        }
    
        public int ID_Equipment { get; set; }
        public string Stamp { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public string Unit_Of_Measurement { get; set; }
        public int Quantity { get; set; }
        public string Service { get; set; }
        public Nullable<decimal> PowerSumm { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fuel> Fuel { get; set; }
    }
}
