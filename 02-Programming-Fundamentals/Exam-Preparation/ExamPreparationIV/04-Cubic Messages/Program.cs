using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string message = Console.ReadLine();

                if (message == "Over!")
                    break;

                int length = int.Parse(Console.ReadLine());

                string pattern = $@"^([\d]+)([A-Za-z]{{{length}}})([^A-Za-z]*)$";
                Regex regex = new Regex(pattern);
                Match matchMessage = regex.Match(message);

                if (matchMessage.Success)
                {
                    char[] encryptedMessageArr = matchMessage.Groups[2].Value.ToArray();
                    string verificationStr = "";
                    string digitPattern = @"\d*";
                    Regex digitRegex = new Regex(digitPattern);
                    MatchCollection digitMatches = digitRegex.Matches(message);

                    foreach (Match m in digitMatches)
                        verificationStr += m.Value;

                    char[] verificationArr = verificationStr.ToCharArray();
                    List<char> decryptedMessage = new List<char>();

                    foreach (var num in verificationArr)
                    {
                        int index = int.Parse(num.ToString());

                        if (index < encryptedMessageArr.Length)
                            decryptedMessage.Add(encryptedMessageArr[index]);
                        else
                            decryptedMessage.Add(' ');
                    }

                    Console.WriteLine($"{string.Join("", encryptedMessageArr)} == {string.Join("", decryptedMessage)}");
                }
            }
        }
    }
}