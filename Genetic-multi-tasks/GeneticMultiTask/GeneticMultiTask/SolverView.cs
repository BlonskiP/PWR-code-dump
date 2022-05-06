using LiveCharts;
using LiveCharts.Wpf;
using Shared.AbstractClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Media;
using MultiTask;

namespace GeneticMultiTask
{
    public partial class SolverView : Form
    {
        SolverViewController controller;
        public GeneticSolver[] solvers;
        Timer timer = new Timer();
        public SolverView()
        {
            controller = new SolverViewController(this);
            InitializeComponent();
            cartesianChart1.Series = new SeriesCollection();
            cartesianChart2.Series = new SeriesCollection();
            cbxCrossoverType.SelectedIndex = 0;
            cbxMutationType.SelectedIndex = 0;
            cbxSelectionType.SelectedIndex = 0;

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Sekundy",
                LabelFormatter = value => value.ToString("F")

            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Liczba Generacji",
                LabelFormatter = value => value.ToString("F")
            });
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
            cartesianChart1.DataClick += CartesianChart1OnDataClick;

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Sekundy",
                LabelFormatter = value => value.ToString("F")

            });
            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Koszt przejazdu",
                LabelFormatter = value => value.ToString("F"),
            }) ;
            cartesianChart2.LegendLocation = LegendLocation.Bottom;
            cartesianChart2.DataClick += CartesianChart1OnDataClick;
            
        }
        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void RunUpdates()
        {
            timer.Tick += new System.EventHandler(updateChart);
            timer.Interval = 1000; //1 sec
            timer.Start();
        }
        private void updateChart(object sender, EventArgs e)
        {
           
            for (int i = 0; i < cartesianChart1.Series.Count; i++)
            {
                if (solvers[i].population[0] != null && solvers[i].bestCandidate!=null)
                {
                    cartesianChart1.Series[i].Values.Add(solvers[i].population[0].generation);
                    cartesianChart2.Series[i].Values.Add((int)solvers[i].bestCandidate.fitness);
                }
                    
            }
            cartesianChart1.Refresh();
            bool isRun = false;
            foreach(var task in controller.listTask)
            {
                if (task.time.IsRunning == true)
                {
                    isRun = true;
                }
            }
            if (!isRun) { 
                timer.Stop();
                btnStart.Enabled = true;
            };
        }

        private void btnTspLoad_Click(object sender, EventArgs e)
        {
            controller.loadTSPfile();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            cartesianChart2.Series.Clear();
            cartesianChart1.Series.Clear();
            controller.listTask.Clear();
   
            controller.RunSolution();
        }

        internal void RunChart()
        {
            cartesianChart1.Series = new SeriesCollection();
            timer = new Timer();
            for (int i = 0; i < solvers.Length; i++)
            {
                cartesianChart1.Series.Add(new LineSeries
                {
                    Title = solvers[i].SolverTitle,
                    Values = new ChartValues<int> { 0 },
                    LineSmoothness = 0,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                });
            }
            for (int i = 0; i < solvers.Length; i++)
            {
                cartesianChart2.Series.Add(new LineSeries
                {
                    Title = solvers[i].SolverTitle,
                    Values = new ChartValues<int>(),
                    LineSmoothness = 0,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                });
                
            }

            btnStart.Enabled = false;
            RunUpdates();
        }
    }
}
