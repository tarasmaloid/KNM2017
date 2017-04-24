using System;
using System.Windows.Forms;

namespace TravelingSalesman
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            TourManager.clearCities();

            int cityAmount = rand.Next(10, 25);

            for(int i = 0; i < cityAmount; i++)
                TourManager.addCity(new City());

            Population pop = new Population(50, true);

            resultsLabel.Text = String.Empty;

            resultsLabel.Text = "Initial distance: " + pop.getFittest().getDistance().ToString("F2");

            pop = GA.evolvePopulation(pop);
            for (int i = 0; i < 100; i++)
            {
                pop = GA.evolvePopulation(pop);
            }

            resultsLabel.Text += "\nFinal distance: " + pop.getFittest().getDistance().ToString("F2");

            Tour best = pop.getFittest();

            resultsChart.Series[0].Points.Clear();

            resultsLabel.Text += "\nSolution:";

            for (int i = 0; i < best.tourSize(); i++)
            {
                resultsChart.Series[0].Points.AddXY(best.getCity(i).getX(), best.getCity(i).getY());
                resultsChart.Series[0].Points[i].Label = (i+1).ToString();
                resultsLabel.Text += "\n"+(i + 1).ToString() + "). " + best.getCity(i).getX() +"; " + best.getCity(i).getY();
            }

            resultsChart.Series[0].Points.AddXY(best.getCity(0).getX(), best.getCity(0).getY());
        }
    }
}
