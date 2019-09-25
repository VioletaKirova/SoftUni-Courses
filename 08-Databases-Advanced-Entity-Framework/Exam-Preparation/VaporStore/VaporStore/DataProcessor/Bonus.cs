namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;

    using Data;

	public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return $"User {username} not found";
            }

            var emails = context.Users.Select(u => u.Email).ToArray();

            if (emails.Contains(newEmail))
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;
            context.SaveChanges();

            string result = $"Changed {username}'s email successfully";

            return result;
        }
	}
}
