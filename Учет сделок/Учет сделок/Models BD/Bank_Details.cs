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
    
    public partial class Bank_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bank_Details()
        {
            this.Company = new HashSet<Company>();
        }
    
        public int ID_Bank_Details { get; set; }
        public string INN { get; set; }
        public string PPC { get; set; }
        public string BIC { get; set; }
        public string Payment_Account { get; set; }
        public string Correspondent_Account { get; set; }
        public string OGRN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Company { get; set; }
    }
}
