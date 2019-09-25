namespace CookWithMeRecommendation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.ML;
    using Microsoft.ML.Trainers;

    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var modelFile = "CookWithMeModel.zip";
            TrainModel("data.csv", modelFile);

            var testModelData = new List<UserRecipe>
            {
                new UserRecipe { UserId = "58bea8e3-1246-41bc-b611-49168068be4a", RecipeId = "027097b2-8221-4cdf-99a8-27f87a7cbff5" }, // vegan and recipe with chicken
                new UserRecipe { UserId = "58bea8e3-1246-41bc-b611-49168068be4a", RecipeId = "037e947e-e118-43b6-8efa-0676b1cdd279" }, // vegan and recipe with milk
                new UserRecipe { UserId = "58bea8e3-1246-41bc-b611-49168068be4a", RecipeId = "049357e6-f8fd-4464-a21e-5f650db03303" }, // vegan and recipe without animal products

                new UserRecipe { UserId = "e125494a-b0a6-4140-9552-aa160b15822c", RecipeId = "027097b2-8221-4cdf-99a8-27f87a7cbff5" }, // vegetarian and recipe with chicken
                new UserRecipe { UserId = "e125494a-b0a6-4140-9552-aa160b15822c", RecipeId = "037e947e-e118-43b6-8efa-0676b1cdd279" }, // vegetarian and recipe with milk

                new UserRecipe { UserId = "22c3976a-e05a-4ebe-a284-9a8497cefcd2", RecipeId = "027097b2-8221-4cdf-99a8-27f87a7cbff5" }, // pescetarian and recipe with chicken
                new UserRecipe { UserId = "22c3976a-e05a-4ebe-a284-9a8497cefcd2", RecipeId = "86139316-a386-4433-9102-3631a750b912" }, // pescetarian and recipe with fish

                new UserRecipe { UserId = "f7393158-7462-4c2e-867d-d607f6429128", RecipeId = "037e947e-e118-43b6-8efa-0676b1cdd279" }, // dairy free and recipe with milk
                new UserRecipe { UserId = "f7393158-7462-4c2e-867d-d607f6429128", RecipeId = "049357e6-f8fd-4464-a21e-5f650db03303" }, // dairy free and recipe without milk

                new UserRecipe { UserId = "34574afc-bf46-4fc7-a1a2-acc7ae7327a4", RecipeId = "027097b2-8221-4cdf-99a8-27f87a7cbff5" }, // omnivore and recipe with chicken
                new UserRecipe { UserId = "34574afc-bf46-4fc7-a1a2-acc7ae7327a4", RecipeId = "049357e6-f8fd-4464-a21e-5f650db03303" }, // omnivore and recipe without milk
            };

            TestModel(modelFile, testModelData);
        }

        private static void TrainModel(string inputFile, string modelFile)
        {
            // Create MLContext to be shared across the model creation workflow objects
            var context = new MLContext();

            // Load data
            IDataView trainingDataView = context.Data.LoadFromTextFile<UserRecipe>(
                inputFile,
                hasHeader: true,
                separatorChar: ',');

            // Build & train model
            IEstimator<ITransformer> estimator = context.Transforms.Conversion
                .MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: nameof(UserRecipe.UserId)).Append(
                    context.Transforms.Conversion.MapValueToKey(outputColumnName: "recipeIdEncoded", inputColumnName: nameof(UserRecipe.RecipeId)));
            var options = new MatrixFactorizationTrainer.Options
            {
                LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "recipeIdEncoded",
                LabelColumnName = nameof(UserRecipe.Label),
                Alpha = 0.1,
                Lambda = 0.5,
                NumberOfIterations = 50,
            };

            var trainerEstimator = estimator.Append(context.Recommendation().Trainers.MatrixFactorization(options));
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            // Save model
            context.Model.Save(model, trainingDataView.Schema, modelFile);
        }

        private static void TestModel(string modelFile, IEnumerable<UserRecipe> testModelData)
        {
            var context = new MLContext();
            var model = context.Model.Load(modelFile, out _);
            var predictionEngine = context.Model.CreatePredictionEngine<UserRecipe, UserRecipeScore>(model);
            foreach (var testInput in testModelData)
            {
                var prediction = predictionEngine.Predict(testInput);
                Console.WriteLine($"User: {testInput.UserId}, Recipe: {testInput.RecipeId}, Score: {prediction.Score}");
            }
        }
    }
}
