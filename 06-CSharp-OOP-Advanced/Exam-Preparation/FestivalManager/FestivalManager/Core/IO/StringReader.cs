namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;

    public class StringReader : IReader
	{
		private readonly System.IO.StringReader reader;

		public StringReader(string contents)
		{
			this.reader = new System.IO.StringReader(contents);
		}

		public string ReadLine() => this.reader.ReadLine();
	}
}