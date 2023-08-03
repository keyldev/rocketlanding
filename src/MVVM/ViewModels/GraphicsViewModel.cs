using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using mvvm_rocketlanding.Core;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
namespace mvvm_rocketlanding.MVVM.ViewModels
{
    class GraphicsViewModel : ObservableObject
    {

        public IList<DataPoint> PointsMinusVelocity { get; private set; }
        public IList<DataPoint> PointsMinusAccel { get; private set; }
        public IList<DataPoint> PointsMinusHeight { get; private set; }
        public IList<DataPoint> PointsMinusFuel { get; private set; }

        public GraphicsViewModel()
        {
        }
        public PlotModel VelocityModel { get; private set; }
        public PlotModel HeightModel { get; private set; }
        public PlotModel FuelModel { get; private set; }
        public PlotModel AccelModel { get; private set; }
        public void SetVelocityPoints(List<Point> points)
        {
            PointsMinusVelocity.Clear();
            foreach (Point p in points)
            {
                if (p.Y == 0)
                {
                    this.PointsMinusVelocity.Add(new DataPoint(p.X, p.Y));
                }
                else
                {
                    this.PointsMinusVelocity.Add(new DataPoint(p.X, p.Y));
                }
            }
            this.VelocityModel.ResetAllAxes();
            this.VelocityModel.InvalidatePlot(true);

        }
        public void ChartVelocityCreate(string name)
        {
            VelocityModel = new PlotModel { Title = name };
            
            VelocityModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Время (сек)" });
            VelocityModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Скорость (м/с)" });


            PointsMinusVelocity = new List<DataPoint>();

            VelocityModel.Series.Add(new FunctionSeries
            {
                Color = OxyColors.Blue,
                ItemsSource = PointsMinusVelocity,
                StrokeThickness = 1f
            });
            //MyModel.Series.Add(new AreaSeries
            //{
            //    Color = OxyColors.Blue,
            //    ItemsSource = PointsMinus,
            //    StrokeThickness = 0.1f
            //});
        }
        public void SetHeightPoints(List<Point> points)
        {
            PointsMinusHeight.Clear();
            foreach (Point p in points)
            {
                if (p.Y == 0)
                {
                    this.PointsMinusHeight.Add(new DataPoint(p.X, p.Y));
                }
                else
                {
                    this.PointsMinusHeight.Add(new DataPoint(p.X, p.Y));
                }
            }
            this.HeightModel.ResetAllAxes();
            this.HeightModel.InvalidatePlot(true);

        }
        public void ChartHeightCreate(string name)
        {
            HeightModel = new PlotModel { Title = name };

            HeightModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Время (сек)" });
            HeightModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Высота (метры)" });


            PointsMinusHeight = new List<DataPoint>();

            HeightModel.Series.Add(new FunctionSeries
            {
                Color = OxyColors.Blue,
                ItemsSource = PointsMinusHeight,
                StrokeThickness = 1f
            });
            //MyModel.Series.Add(new AreaSeries
            //{
            //    Color = OxyColors.Blue,
            //    ItemsSource = PointsMinus,
            //    StrokeThickness = 0.1f
            //});
        }
        public void SetAccelPoints(List<Point> points)
        {
            PointsMinusAccel.Clear();
            foreach (Point p in points)
            {
                if (p.Y == 0)
                {
                    this.PointsMinusAccel.Add(new DataPoint(p.X, p.Y));
                }
                else
                {
                    this.PointsMinusAccel.Add(new DataPoint(p.X, p.Y));
                }
            }
            this.AccelModel.ResetAllAxes();
            this.AccelModel.InvalidatePlot(true);

        }
        public void ChartAccelCreate(string name)
        {
            AccelModel = new PlotModel { Title = name };

            AccelModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Время (сек)" });
            AccelModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Ускорение (м/с2)" });


            PointsMinusAccel = new List<DataPoint>();

            AccelModel.Series.Add(new FunctionSeries
            {
                Color = OxyColors.Blue,
                ItemsSource = PointsMinusAccel,
                StrokeThickness = 1f
            });
            //MyModel.Series.Add(new AreaSeries
            //{
            //    Color = OxyColors.Blue,
            //    ItemsSource = PointsMinus,
            //    StrokeThickness = 0.1f
            //});
        }
        public void SetFuelPoints(List<Point> points)
        {
            PointsMinusFuel.Clear();
            foreach (Point p in points)
            {
                if (p.Y == 0)
                {
                    this.PointsMinusFuel.Add(new DataPoint(p.X, p.Y));
                }
                else
                {
                    this.PointsMinusFuel.Add(new DataPoint(p.X, p.Y));
                }
            }
            this.FuelModel.ResetAllAxes();
            this.FuelModel.InvalidatePlot(true);

        }
        public void ChartFuelCreate(string name)
        {
            FuelModel = new PlotModel { Title = name };

            FuelModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Время (сек)" });
            FuelModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Расход топлива (кг/с)" });


            PointsMinusFuel = new List<DataPoint>();

            FuelModel.Series.Add(new FunctionSeries
            {
                Color = OxyColors.Blue,
                ItemsSource = PointsMinusFuel,
                StrokeThickness = 1f
            }) ;
            //MyModel.Series.Add(new AreaSeries
            //{
            //    Color = OxyColors.Blue,
            //    ItemsSource = PointsMinus,
            //    StrokeThickness = 0.1f
            //});
        }
    }
}
