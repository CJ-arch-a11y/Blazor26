using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor26.Services.BusinessModels;
using Microsoft.ML;

namespace Blazor26.Services
{
    public class MLService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        //Constructor which uses a MLContext
        public MLService()
        {
            _mlContext = new MLContext();
        }

        public void Train(List<SalesData> data)
        {
            System.Diagnostics.Debug.WriteLine("Trainmodel Service");
            if (data == null || !data.Any())
                throw new Exception("No data to train on!");

            var dataView = _mlContext.Data.LoadFromEnumerable(data);

            var pipeline = _mlContext.Transforms
                .Concatenate("Features", nameof(SalesData.Month))
                .Append(_mlContext.Regression.Trainers.Sdca(
                    labelColumnName: "SalesAmount"));

            _model = pipeline.Fit(dataView);
        }

        public float Predict(float month)
        {
            System.Diagnostics.Debug.WriteLine("in the Predict Service");
            if (_model == null)
                throw new InvalidOperationException("Model has not been trained.");
            //Creates a prediction engine saying to expect salesdata and return prediction
            var engine = _mlContext.Model
                .CreatePredictionEngine<SalesData, SalesPrediction>(_model);

            //this is where the inference happens – pass in a month and return result.score.
            var result = engine.Predict(new SalesData
            {
                Month = month
            });

            return result.Score;
        }
    }
}
