namespace SoftJail.DataProcessor
{
    using System;
    using System.Linq;

    using Data;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner = context.Prisoners
                .FirstOrDefault(p => p.Id == prisonerId);

            string result = string.Empty;

            if (prisoner.ReleaseDate == null)
            {
                result = $"Prisoner {prisoner.FullName} is sentenced to life";
            }
            else
            {
                prisoner.ReleaseDate = DateTime.Now;
                prisoner.Cell = null;

                context.Prisoners.Update(prisoner);
                context.SaveChanges();

                result = $"Prisoner {prisoner.FullName} released";
            }

            return result;
        }
    }
}
