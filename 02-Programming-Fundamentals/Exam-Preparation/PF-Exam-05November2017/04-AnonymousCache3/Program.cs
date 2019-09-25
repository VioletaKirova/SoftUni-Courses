using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_AnonymousCache3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var allDataSets = new Dictionary<string, List<DataSet>>();
            var cache = new Dictionary<string, List<DataSet>>();
            var dataSetsBySum = new Dictionary<string, long>();

            while (input != "thetinggoesskrra")
            {
                string[] inputParts = input.Split(new char[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputParts.Length == 1)
                {
                    string dataSet = inputParts[0];

                    if (!allDataSets.ContainsKey(dataSet))
                    {
                        allDataSets.Add(dataSet, new List<DataSet>());
                    }

                    if (cache.ContainsKey(dataSet))
                    {
                        allDataSets[dataSet].AddRange(cache[dataSet]);
                        cache.Remove(dataSet);
                    }
                }
                else
                {
                    string dataKey = inputParts[0];
                    int dataSize = int.Parse(inputParts[1]);
                    string dataSet = inputParts[2];

                    if (!allDataSets.ContainsKey(dataSet))
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache.Add(dataSet, new List<DataSet>());                           
                        }

                        DataSet newDataSet = new DataSet();
                        newDataSet.Key = dataKey;
                        newDataSet.Size = dataSize;

                        cache[dataSet].Add(newDataSet);
                    }
                    else
                    {
                        DataSet currentDataSet = new DataSet();
                        currentDataSet.Key = dataKey;
                        currentDataSet.Size = dataSize;

                        allDataSets[dataSet].Add(currentDataSet);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var dataSet in allDataSets)
            {
                long sum = 0;

                foreach (var v in dataSet.Value)
                {
                    sum += v.Size;
                }

                dataSetsBySum.Add(dataSet.Key, sum);
            }

            foreach (var dataSet in allDataSets.OrderByDescending(x => dataSetsBySum[x.Key]))
            {
                Console.WriteLine($"Data Set: {dataSet.Key}, Total Size: {dataSetsBySum[dataSet.Key]}");

                foreach (var d in dataSet.Value)
                {
                    Console.WriteLine($"$.{d.Key}");
                }

                break;
            }
        }
    }

    class DataSet
    {
        public string Key { get; set; }
        public int Size { get; set; }
    }
}