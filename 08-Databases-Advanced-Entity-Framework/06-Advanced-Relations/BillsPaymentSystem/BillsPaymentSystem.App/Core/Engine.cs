﻿namespace BillsPaymentSystem.App.Core
{
    using System;

    using Data;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputParams = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                {
                    string result = this.commandInterpreter.Read(inputParams, context);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
