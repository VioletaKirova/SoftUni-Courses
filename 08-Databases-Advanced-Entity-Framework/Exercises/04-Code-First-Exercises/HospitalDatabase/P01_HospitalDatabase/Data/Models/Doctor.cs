namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Doctors")]
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Speciality { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
