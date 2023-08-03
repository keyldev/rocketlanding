using mvvm_rocketlanding.Core;
using mvvm_rocketlanding.MVVM.Models;
using mvvm_rocketlanding.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace mvvm_rocketlanding.MVVM.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        #region RelayCommands
        public RelayCommand StartGame { get; set; }
        public RelayCommand StopGame { get; set; }
        public RelayCommand ShowGraphs { get; set; }
        #endregion
        #region Properties
        private string _fuelMass;

        public string FuelMass
        {
            get { return _fuelMass; }
            set { _fuelMass = value; NotifyPropertyChanged(); }
        }
        private string _rocketMass;

        public string RocketMass
        {
            get { return _rocketMass; }
            set { _rocketMass = value; NotifyPropertyChanged(); }
        }
        private string _startHeight;

        public string StartHeight
        {
            get { return _startHeight; }
            set { _startHeight = value; NotifyPropertyChanged(); }
        }
        private string _maxEndSpeed;

        public string MaxEndSpeed
        {
            get { return _maxEndSpeed; }
            set { _maxEndSpeed = value; NotifyPropertyChanged(); }
        }

        private float _thrust;

        public float Thrust
        {
            get { return _thrust; }
            set { _thrust = value; NotifyPropertyChanged(); }
        }
        private string _timeFinal;

        public string TimeFinal
        {
            get { return _timeFinal; }
            set { _timeFinal = value; NotifyPropertyChanged(); }
        }
        private float _timeFinalValue;

        public float TimeFinalValue
        {
            get { return _timeFinalValue; }
            set { _timeFinalValue = value; NotifyPropertyChanged(); }
        }

        #endregion

        #region FinalProperties
        private string _finalHeight;

        public string FinalHeight
        {
            get { return _finalHeight; }
            set { _finalHeight = value; NotifyPropertyChanged(); }
        }
        private string _velocityFinal;

        public string VelocityFinal
        {
            get { return _velocityFinal; }
            set { _velocityFinal = value; NotifyPropertyChanged(); }
        }
        private string _freeFallFinal;

        public string FreeFallFinal
        {
            get { return _freeFallFinal; }
            set { _freeFallFinal = value; NotifyPropertyChanged(); }
        }
        private string _thrustFinal;

        public string ThrustFinal
        {
            get { return _thrustFinal; }
            set { _thrustFinal = value; NotifyPropertyChanged(); }
        }
        private string _fuelFinal;

        public string FuelFinal
        {
            get { return _fuelFinal; }
            set { _fuelFinal = value; NotifyPropertyChanged(); }
        }
        private float _finalHeightValue;

        public float FinalHeightValue
        {
            get { return _finalHeightValue; }
            set { _finalHeightValue = value; NotifyPropertyChanged(); }
        }
        private float _freeFallValue;

        public float FreeFallValue
        {
            get { return _freeFallValue; }
            set { _freeFallValue = value; }
        }
        private float _velocityFinalValue;

        public float VelocityFinalValue
        {
            get { return _velocityFinalValue; }
            set { _velocityFinalValue = value; NotifyPropertyChanged(); }
        }
        private float _thrustFinalValue;

        public float ThurstFinalValue
        {
            get { return _thrustFinalValue; }
            set { _thrustFinalValue = value; NotifyPropertyChanged(); }
        }
        private float _fuelFinalValue;

        public float FuelFinalValue
        {
            get { return _fuelFinalValue; }
            set { _fuelFinalValue = value; NotifyPropertyChanged(); }
        }
        private string _newFuelFinal;

        public string NewFuelFinal
        {
            get { return _newFuelFinal; }
            set { _newFuelFinal = value; NotifyPropertyChanged(); }
        }

        #endregion


        private string _loggerText;

        public string LoggerText
        {
            get { return _loggerText; }
            set { _loggerText = value; NotifyPropertyChanged(); }
        }

        #region Variables
        private static float R = 1737000;//радиус луны в м
        private static float G = 0.000000000066743f;
        private static float M = 7.35e22f;//масса луны в кг
        private float Mass = 6000;//Масса корабля
        private float KPD = 300;//удельная тяга
        private float fuel = 30000;//Масса топлива
        private float newFuel = 0; // топливо кг/с
        private float g = 0;
        private float trust = 0;
        private float a = 0;
        private float height = 1000;
        private float velosity = 0;
        private float acceleration = 0;
        private float timescale = 0;
        private float time = 0;
        private int maxEndSpeed = -5;

        List<Point> lst_velocity = new List<Point>();
        List<Point> lst_accel = new List<Point>();
        List<Point> lst_fuel = new List<Point>();
        List<Point> lst_height = new List<Point>();

        private DispatcherTimer ds;

        private GraphicsViewModel _graphicsView;

        public GraphicsViewModel GraphicsView
        {
            get { return _graphicsView; }
            set { _graphicsView = value; NotifyPropertyChanged(); }
        }

        private RocketLandingViewModel _rocketLandingVM;

        public RocketLandingViewModel RocketLandingVM
        {
            get { return _rocketLandingVM; }
            set { _rocketLandingVM = value; NotifyPropertyChanged(); }
        }
        private object _contentView;

        public object ContentView
        {
            get { return _contentView; }
            set { _contentView = value; NotifyPropertyChanged(); }
        }

        private object _additionalView;

        public object AdditionalView
        {
            get { return _additionalView; }
            set { _additionalView = value; NotifyPropertyChanged(); }
        }

        #endregion
        public MainWindowViewModel()
        {
            LoggerText += LoggerModel.setLog("Конструктор", "инициализирован");

            FuelMass = fuel.ToString();
            RocketMass = Mass.ToString();
            StartHeight = height.ToString();
            MaxEndSpeed = maxEndSpeed.ToString();

            LoggerText += LoggerModel.setLog("Данные по умолчанию", "инициализированы");

            RocketLandingVM = new RocketLandingViewModel();
            ContentView = RocketLandingVM;

            StartGame = new RelayCommand(o =>
            {
                LoggerText += LoggerModel.setLog("StartGame", "нажат");

                timescale = 1;
                height = float.Parse(StartHeight);
                Mass = float.Parse(RocketMass);
                KPD = 2500; //
                fuel = float.Parse(FuelMass);
                time = 0;
                maxEndSpeed = int.Parse(MaxEndSpeed);
                // Размеры канваса (#fix)
                RocketLandingVM.GameWindowHeight = int.Parse(StartHeight);

                //
                LoggerText += LoggerModel.setLog("Значения", "инициализированы");

                ds = new DispatcherTimer();
                ds.Tick += new EventHandler(rocketLand);
                ds.Interval = new TimeSpan(0, 0, 0, 0, 500);
                ds.Start();

                LoggerText += LoggerModel.setLog("Таймер", "запущен");

            });
            StopGame = new RelayCommand(o =>
            {
                LoggerText += LoggerModel.setLog("Игра", "остановлена");
                ds.Stop();
            });
            //test

            GraphicsView = new GraphicsViewModel();
            GraphicsView.ChartAccelCreate("График ускорения");
            GraphicsView.ChartHeightCreate("График высоты");
            GraphicsView.ChartVelocityCreate("График скорости");
            GraphicsView.ChartFuelCreate("График расхода топлива");

            AdditionalView = GraphicsView;
            //ContentView = GraphicsView;
            //
            ShowGraphs = new RelayCommand(o =>
            {
                GraphicsView = new GraphicsViewModel();
                LoggerText += LoggerModel.setLog("Графики", "успешно отрисованы");

                //
                GraphicsView.ChartAccelCreate("График ускорения");
                GraphicsView.SetAccelPoints(lst_accel);
                LoggerText += LoggerModel.setLog("График ускорения", "успешно отрисован");
                //
                GraphicsView.ChartHeightCreate("График высоты");
                GraphicsView.SetHeightPoints(lst_height);
                LoggerText += LoggerModel.setLog("График высоты", "успешно отрисован");
                //
                GraphicsView.ChartVelocityCreate("График скорости");
                GraphicsView.SetVelocityPoints(lst_velocity);
                LoggerText += LoggerModel.setLog("График скорости", "успешно отрисован");
                //
                GraphicsView.ChartFuelCreate("График расхода топлива");
                GraphicsView.SetFuelPoints(lst_fuel);
                LoggerText += LoggerModel.setLog("График расхода топлива", "успешно отрисован");
                ContentView = GraphicsView;
                AdditionalView = RocketLandingVM;
            });
        }

        private void rocketLand(object sender, EventArgs e)
        {


           /* var window = Application.Current.MainWindow;
            window.KeyDown += KeyPressed;
            void KeyPressed(object senders, KeyEventArgs eb)
            {
                if (eb.Key == Key.W)
                    trust++;
                else if (eb.Key == Key.S)
                    trust++;
            }*/
           
            trust = (float)Thrust * 4000;// * 400000;
            float dt = 0.5f * timescale;
            time += dt;
            RocketLandingVM.RocketPosition = height;
            if (fuel > 0)
            {
                fuel -= trust / KPD * dt;
                newFuel = trust / KPD * dt;
                if (fuel < 0) fuel = 0;
                g = G * M / ((R + height) * (R + height)); // const g
                a = trust / (Mass + fuel);
            }
            else
            {
                a = 0;
            }
            acceleration = a - g;
            height += velosity * dt + acceleration * dt * dt / 2;
            velosity += acceleration * dt;

            try
            {
                lst_velocity.Add(new Point(time, velosity));
                lst_accel.Add(new Point(time, acceleration));
                lst_fuel.Add(new Point(time, newFuel));
                lst_height.Add(new Point(time, height));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //test real time graphics update
            GraphicsView.SetAccelPoints(lst_accel);
            GraphicsView.SetHeightPoints(lst_height);
            GraphicsView.SetVelocityPoints(lst_velocity);
            GraphicsView.SetFuelPoints(lst_fuel);
            //
            if (height <= 0)
            {
                //velosity < -maxEndSpeed
                if (velosity < -5)
                {
                    InfoWindowView info = new InfoWindowView("Вы проиграли :(");
                    info.Show();
                    ds.Stop();
                }
                else
                {
                    InfoWindowView info = new InfoWindowView("Вы победили!");

                    info.Show();
                    ds.Stop();
                }
                velosity = 0;
                height = 0;
            }
            FinalHeight = $"Высота: {height} м";
            FinalHeightValue = height;
            VelocityFinal = $"Скорость: {velosity} м/с";
            VelocityFinalValue = velosity;
            FreeFallFinal = $"Ускорение свободного падения: {g} м/с2";
            FreeFallValue = g;
            ThrustFinal = $"Тяга: {acceleration} м/с2";
            FuelFinal = $"Топливо: {fuel} кг";
            TimeFinal = $"Время: {time} с";
            TimeFinalValue = time;
            NewFuelFinal = $"Расход топлива(кг/с): {newFuel}";

            LoggerText += LoggerModel.setLog(FinalHeight, "успешно");
            LoggerText += LoggerModel.setLog(VelocityFinal, "успешно");
            LoggerText += LoggerModel.setLog(FreeFallFinal, "успешно");
            LoggerText += LoggerModel.setLog(ThrustFinal, "успешно");
            LoggerText += LoggerModel.setLog(FuelFinal, "успешно");


        }


    }
}
