namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

		private IFestivalController festivalCоntroller;
		private ISetController setCоntroller;

        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.reader = reader;
            this.writer = writer;
        }

		public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (InvalidOperationException ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split(" ".ToCharArray().First());

            var commandType = inputArgs.First();
            var parameters = inputArgs.Skip(1).ToArray();

            if (commandType == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var festivalControllerMethod = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == commandType);

            string result;

            try
            {
                result = (string)festivalControllerMethod.Invoke(this.festivalCоntroller, new object[] { parameters });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            return result;
        }
    }
}