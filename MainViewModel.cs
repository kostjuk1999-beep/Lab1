using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private LissajousModel _model = new();
        private PointCollection _points;

        public double Ax { get; set; } = 100;
        public double Ay { get; set; } = 100;
        public double Fx { get; set; } = 2;
        public double Fy { get; set; } = 3;
        public double PhiX { get; set; } = 0;
        public double PhiY { get; set; } = 90;
        public double TimeStep { get; set; } = 0.01;

        public PointCollection FigurePoints
        {
            get => _points;
            set { _points = value; OnPropertyChanged(); }
        }

        public ICommand DrawCommand { get; }

        public MainViewModel()
        {
            DrawCommand = new RelayCommand(Draw);
            Draw();
        }

        private void Draw()
        {
            try
            {
                if (Ax <= 0 || Ay <= 0 || Fx <= 0 || Fy <= 0 || TimeStep <= 0)
                {
                    MessageBox.Show("Амплітуди, частоти та крок часу мають бути додатними!");
                    return;
                }

                var pointsList = _model.Calculate(Ax, Ay, Fx, Fy, PhiX, PhiY, TimeStep);
                FigurePoints = new PointCollection(pointsList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка обчислень: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}