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
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.Object = new HashSet<Object>();
        }
    
        public int ID_Company { get; set; }
        public int ID_Bank_Details { get; set; }
        public string Title_Company { get; set; }
        public string Address_Company { get; set; }
        public string Number_Phone { get; set; }
        public string Director { get; set; }
    
        public virtual Bank_Details Bank_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Object> Object { get; set; }
    }
}
