namespace P01.Stream_Progress
{
    using System;

    public class Program
    {
        static void Main()
        {
            IStreamable musicFile = new Music("Nasko Mentata", "Menta", 333333, 56565);
            IStreamable file = new File("Failche", 2222, 5555);

            StreamProgressInfo musicFileStreamProgressInfo = new StreamProgressInfo(musicFile);
            StreamProgressInfo fileStreamProgressInfo = new StreamProgressInfo(file);

            Console.WriteLine(musicFileStreamProgressInfo.CalculateCurrentPercent());
            Console.WriteLine(fileStreamProgressInfo.CalculateCurrentPercent());
        }
    }
}
