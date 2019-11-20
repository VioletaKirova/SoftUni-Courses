namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PatientMedicaments")]
    public class PatientMedicament
    {
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey(nameof(MedicamentId))]
        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
    }
}
