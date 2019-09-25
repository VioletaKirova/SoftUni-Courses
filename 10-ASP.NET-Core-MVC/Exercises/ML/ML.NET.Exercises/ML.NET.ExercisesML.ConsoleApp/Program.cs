using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;
using ML.NET.ExercisesML.ConsoleApp.DataModels;

namespace ML.NET.ExercisesML.ConsoleApp
{
    class Program
    {
        //Machine Learning model to load and use for predictions
        private static string TRAIN_DATA_FILEPATH = @"E:\SoftUni\ASP.NET-Core-MVC\ML\Data\carsbg.csv";
        private static string MODEL_FILEPATH = @"E:\SoftUni\ASP.NET-Core-MVC\ML\ML.NET.Exercises\ML.NET.ExercisesML.ConsoleApp\MLModel.zip";

        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();

            if (!File.Exists(MODEL_FILEPATH))
            {
                TrainModel();
            }

            var listOfInputs = new List<ModelInput>
            {
                new ModelInput
                {
                    Make = "VW",
                    Model = "Golf",
                    CubicCapacity = 1400,
                    FuelType = "Бензин",
                    Gear = "Ръчни",
                    HorsePower = 55,
                    Range = 270000,
                    Year = "01/01/1992"
                },
                new ModelInput
                {
                    Make = "Suzuki",
                    Model = "Grand Vitara",
                    CubicCapacity = 2000,
                    FuelType = "Дизел",
                    Gear = "Ръчни",
                    HorsePower = 109,
                    Range = 150000,
                    Year = "01/01/2002"
                },
                new ModelInput
                {
                    Make = "Lamborghini",
                    Model = "Urus",
                    CubicCapacity = 4000,
                    FuelType = "Бензин",
                    Gear = "Автоматични",
                    HorsePower = 650,
                    Range = 10,
                    Year = "01/01/2019"
                }
            };

            TestModel(MODEL_FILEPATH, listOfInputs);
        }

        private static void TrainModel()
        {
            MLContext mlContext = new MLContext(1);

            // Load Data
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: TRAIN_DATA_FILEPATH,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Build training pipeline
            var dataProcessPipeline = mlContext.Transforms.Categorical.OneHotEncoding(new[] {
                new InputOutputColumnPair("Make", "Make"),
                new InputOutputColumnPair("FuelType", "FuelType"),
                new InputOutputColumnPair("Year", "Year"),
                new InputOutputColumnPair("Gear", "Gear") })
                          .Append(mlContext.Transforms.Categorical.OneHotHashEncoding(new[]
                          {
                              new InputOutputColumnPair("Model", "Model")
                          }))
                          .Append(mlContext.Transforms.Concatenate(
                              "Features", new[]
                          {
                              "Make", "FuelType", "Year", "Gear", "Model", "HorsePower", "Range", "CubicCapacity"
                          }));

            // Set the training algorithm 
            var trainer = mlContext.Regression.Trainers.FastTreeTweedie(new FastTreeTweedieTrainer.Options()
            {
                NumberOfLeaves = 77,
                MinimumExampleCountPerLeaf = 10,
                NumberOfTrees = 500,
                LearningRate = 0.03362043f,
                Shrinkage = 2.898146f,
                LabelColumnName = "Price",
                FeatureColumnName = "Features"
            });

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            // Train Model
            ITransformer mlModel = trainingPipeline.Fit(trainingDataView);

            // Save model
            mlContext.Model.Save(mlModel, trainingDataView.Schema, MODEL_FILEPATH);
        }

        private static void TestModel(string mODEL_FILEPATH, List<ModelInput> listOfInputs)
        {
            var mlContext = new MLContext();
            var model = mlContext.Model.Load(MODEL_FILEPATH, out _);
            var predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);

            foreach (var input in listOfInputs)
            {
                var prediction = predictionEngine.Predict(input);

                Console.WriteLine($"Make: {input.Make}");
                Console.WriteLine($"Model: {input.Model}");
                Console.WriteLine($"Price: {prediction.Score} лв.");
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
