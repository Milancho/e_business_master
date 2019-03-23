using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_business_webapi.Models;
using Microsoft.ML;
using Microsoft.ML.Runtime.Data;

namespace e_business_master_code
{
    public static class BinaryClassification
    {
        public static string dataPath = "customer-data-2.txt";
        
        public static CustomerPrediction MakePrediction(CustomerDataMiningModel customer)
        {
            Console.WriteLine("Binary Classification");

            // STEP 2: Create a ML.NET environment  
            var mlContext = new MLContext();

            var reader = mlContext.Data.TextReader(new TextLoader.Arguments()
            {
                Separator = ",",
                HasHeader = true,
                Column = new[]
                {
                    new TextLoader.Column("EducationId", DataKind.R4, 0),
                    new TextLoader.Column("Gender", DataKind.R4, 1),
                    new TextLoader.Column("MaritalStatus", DataKind.R4, 2),
                    new TextLoader.Column("Age", DataKind.R4, 3),
                    new TextLoader.Column("Label", DataKind.R4, 4)
                }
            });

            var fullData = reader.Read(dataPath);

            //4. Split the set on Train and Test data  
            (IDataView trainingDataView, IDataView testingDataView) = mlContext.Clustering.TrainTestSplit(fullData, testFraction: 0.3);

            //5. BinaryClassification needed since we have Survived or Not survived labels
            var trainer = mlContext.BinaryClassification.Trainers.StochasticDualCoordinateAscent(labelColumn: "Label", featureColumn: "Features");


            // STEP 3: Transform your data and add a learner
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training.
            // Add a learning algorithm to the pipeline. e.g.(What type of iris is this?)
            // Convert the Label back into original text (after converting to number in step 3)
            var dataProcessPipeline = mlContext.Transforms.Concatenate("Features", "EducationId", "Gender", "MaritalStatus", "Age")
                .Append(trainer);

            var trainedModel = dataProcessPipeline.Fit(trainingDataView);

            //7. Check agains the testing data and evaluate to get the accuracy.
            var predictions = trainedModel.Transform(testingDataView);
            var metrics = mlContext.BinaryClassification.Evaluate(predictions, label: "Label", score: "Score");
            Console.WriteLine("Accuracy: " + metrics.Accuracy);

            var predictionFunction = trainedModel.MakePredictionFunction<CustomerDataMiningModel, CustomerPrediction>(mlContext);
            var prediction = predictionFunction.Predict(customer);

            var type = "Лош";
            if (prediction.IsGoodClient) type = "Добар";
            Console.WriteLine(customer.Name + $" is: {type}");

            return new CustomerPrediction()
            {
                IsGoodClient = prediction.IsGoodClient,
                Score = (float)metrics.Accuracy
            };
        }
    }
}
