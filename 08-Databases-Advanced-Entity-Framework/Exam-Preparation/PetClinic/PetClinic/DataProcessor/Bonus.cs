namespace PetClinic.DataProcessor
{
    using System.Linq;

    using Data;

    public class Bonus
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
            var vet = context.Vets.FirstOrDefault(v => v.PhoneNumber == phoneNumber);

            string result = string.Empty;

            if (vet == null)
            {
                result = $"Vet with phone number {phoneNumber} not found!";
            }
            else
            {
                string oldProfession = vet.Profession;

                vet.Profession = newProfession;

                context.Vets.Update(vet);
                context.SaveChanges();

                result = $"{vet.Name}'s profession updated from {oldProfession} to {newProfession}.";
            }

            return result;
        }
    }
}
