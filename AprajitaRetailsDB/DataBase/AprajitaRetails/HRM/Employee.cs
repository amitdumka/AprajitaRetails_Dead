namespace AprajitaRetailsDB.DataBase.AprajitaRetails.HRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Attendences = new HashSet<Attendence>();
        }

        [Key]
        public int EMPID { get; set; }

        [Required]
        [StringLength(100)]
        public string EMPCode { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public int Gender { get; set; }

        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        public int EmpTypeID { get; set; }
        public int? AttendenceDeviceId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }

        public DateTime? DateOfLeaving { get; set; }

        [StringLength(100)]
        public string MobileNo { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength( 20 )]
        public string StoreCode { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendence> Attendences { get; set; }

        public virtual EmpType EmpType { get; set; }
       }
}
