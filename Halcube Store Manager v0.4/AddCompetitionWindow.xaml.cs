using Halcube_Store_Manager_BLL;
using System.Text.RegularExpressions;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Halcube_Store_Manager
{
    /// <summary>
    /// Logika interakcji dla klasy AddCompetitionWindow.xaml
    /// </summary>
    public partial class AddCompetitionWindow : Window
    {
        private readonly AppDbContext dbContext;
        public Competition? competitionToAdd { get; set; }

        public bool? IsEditMode { get; set; }

        public AddCompetitionWindow()
        {
            InitializeComponent();

            dbContext = new AppDbContext();

            this.competitionToAdd = new Competition { 
                Profit = 0
            };

            IsEditMode = false;
        }

        public AddCompetitionWindow(Competition competition)
        {
            InitializeComponent();

            dbContext = new AppDbContext();

            this.competitionToAdd = competition;

            NameBox.Text = competition.Name;
            CityBox.Text = competition.City;
            CountryBox.Text = competition.Country;
            StartDateBox.SelectedDate = competition.StartDate;
            EndDateBox.SelectedDate = competition.EndDate;

            IsEditMode = true;
        }


        private void AddCompetitionButton(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(NameBox.Text, @"^\s*$") ||
              Regex.IsMatch(CityBox.Text, @"^\s*$") ||
              Regex.IsMatch(CountryBox.Text, @"^\s*$") ||
              Regex.IsMatch(StartDateBox.Text, @"^\s*$") ||
              Regex.IsMatch(EndDateBox.Text, @"^\s*$"))
            {
                MessageBox.Show("Empty data");
                return;
            }

            this.competitionToAdd.Name = NameBox.Text;
            this.competitionToAdd.City = CityBox.Text;
            this.competitionToAdd.Country = CountryBox.Text;
            this.competitionToAdd.StartDate = StartDateBox.SelectedDate;
            this.competitionToAdd.EndDate = EndDateBox.SelectedDate;


            dbContext?.Competitions?.AddOrUpdate(this.competitionToAdd);
            dbContext?.SaveChanges();
            DialogResult = true;
        }
    }


}
