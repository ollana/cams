//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lab()
        {
            this.Computers = new HashSet<Computer>();
            this.ComputerLabs = new HashSet<ComputerLab>();
        }
    
        public int LabId { get; set; }
        public string TodaysClasses { get; set; }
        public string Building { get; set; }
        public string RoomNumber { get; set; }
        public int DepartmentId { get; set; }
        public int ComputerSize { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Computer> Computers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComputerLab> ComputerLabs { get; set; }
        public virtual Department Department { get; set; }
    }
}
