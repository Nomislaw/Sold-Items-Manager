using Halcube_Store_Manager_BLL;
using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;




namespace Halcube_Store_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private readonly AppDbContext? dbContext;

        public MainWindow()
        {
            InitializeComponent();

            dbContext = new AppDbContext();

            var competitionsToGrid = dbContext?.Competitions?.Include("Categories").ToList();

            CompetitionsGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("Name")});
            CompetitionsGrid.Columns.Add(new DataGridTextColumn() { Header = "City", Binding = new Binding("City")});
            CompetitionsGrid.Columns.Add(new DataGridTextColumn() { Header = "Country", Binding = new Binding("Country")});
            CompetitionsGrid.Columns.Add(new DataGridTextColumn() { Header = "Profit", Binding = new Binding("Profit")});
            CompetitionsGrid.Columns.Add(new DataGridTextColumn() { Header = "Start Date", Binding = new Binding("StartDate") { StringFormat = "dd/MM/yyyy" } });
            CompetitionsGrid.Columns.Add(new DataGridTextColumn() { Header = "End Date", Binding = new Binding("EndDate") { StringFormat = "dd/MM/yyyy" } });

            var buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "X");
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(DeleteCompetitionClick));
            CompetitionsGrid.Columns.Add(new DataGridTemplateColumn{Header = "Delete",CellTemplate = new DataTemplate{VisualTree = buttonFactory}});

            CompetitionsGrid.MouseDoubleClick += MouseDoubleClickAction;
            CompetitionsGrid.AutoGenerateColumns = false;
            CompetitionsGrid.ItemsSource = competitionsToGrid;
            CompetitionsGrid.IsReadOnly = true;
            CalculateProfit();
        }

        public void CalculateProfit()
        {
            var competitionsToGrid = dbContext?.Competitions?.Include("Categories").ToList();
        
            if (competitionsToGrid == null) return;

            foreach (var competition in competitionsToGrid)
            {
                float profit = 0;
                var categoryList = dbContext?.Categories?.Where(category => category.CompetitionId == competition.Id).ToList();

                if (categoryList != null)
                {
                    foreach (var category in categoryList)
                    {
                        var productList = dbContext?.Products?.Where(product => product.CategoryId == category.Id).ToList();
                        if (productList != null)
                        {
                            foreach (var product in productList)
                            {
                                dbContext?.Entry(product).Reload();
                                profit += product.ProductProfit;
                            }
                        }
                    }
                }

                competition.Profit = (float)Math.Round(profit,2);
            }

            dbContext?.SaveChanges();
            CompetitionsGrid.ItemsSource = competitionsToGrid;
            CompetitionsGrid.Items.Refresh();
        }

        private void AddCompetitionClick(object sender, RoutedEventArgs e)
        {
            var addCompetitionWindow = new AddCompetitionWindow();
            bool? result = addCompetitionWindow.ShowDialog();

            if (result == true)
            {
                dbContext?.SaveChanges();
                CompetitionsGrid.ItemsSource = dbContext?.Competitions?.Include("Categories").ToList();
                CompetitionsGrid.Items.Refresh();
            }
        }

        private void EditCompetitionClick(object sender, RoutedEventArgs e)
        {
            Competition? selectedCompetition = CompetitionsGrid.SelectedItem as Competition;

            if (selectedCompetition == null) return;

            var addCompetitionWindow = new AddCompetitionWindow(selectedCompetition);
            bool? result = addCompetitionWindow.ShowDialog();

            if (result == true)
            {
                dbContext?.SaveChanges();
                CompetitionsGrid.ItemsSource = dbContext?.Competitions?.Include("Categories").ToList();
                CompetitionsGrid.Items.Refresh();
            }
        }

        private void DeleteCompetitionClick(object sender, RoutedEventArgs e)
        {
            Competition? selectedCompetition = CompetitionsGrid.SelectedItem as Competition;

            int? id = selectedCompetition?.Id;

            if (selectedCompetition is not null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to remove selected competition?", "Confirm removing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Competition? competitionToRemove = dbContext?.Competitions?.FirstOrDefault(x => x.Id == id);

                    if (competitionToRemove == null) return;

                    dbContext?.Competitions?.Remove(competitionToRemove);

                    dbContext?.SaveChanges();
                    CompetitionsGrid.ItemsSource = dbContext?.Competitions?.Include("Categories").ToList();
                    CompetitionsGrid.Items.Refresh();
                }
            }
        }

        private void MouseDoubleClickAction(object sender, RoutedEventArgs e)
        {
            Competition? selectedCompetition = CompetitionsGrid.SelectedItem as Competition;

            int? id = selectedCompetition?.Id;

            if (id == null) return;

            Competition? competitionToEdit = dbContext?.Competitions?.FirstOrDefault(x => x.Id == id);

            CategoryWindow? categoryWindow = new CategoryWindow(competitionToEdit);

            bool? result = categoryWindow.ShowDialog();

            if (result == true)
            {
                var updatedCompetitions = dbContext?.Competitions?.Include("Categories").ToList();
                CompetitionsGrid.ItemsSource = updatedCompetitions;
                CompetitionsGrid.Items.Refresh();
                CalculateProfit();
            }
        }

        private void ClearAllDataClick(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to clear all your data?", "Confirm clearing", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(messageBoxResult == MessageBoxResult.Yes)
            {
                dbContext?.Competitions?.RemoveRange(dbContext?.Competitions?.ToList());
                dbContext?.Products?.RemoveRange(dbContext?.Products?.ToList());
                dbContext?.Categories?.RemoveRange(dbContext?.Categories?.ToList());
                dbContext?.Items?.RemoveRange(dbContext?.Items?.ToList());
                dbContext?.SaveChanges();

                CompetitionsGrid.ItemsSource = dbContext?.Competitions?.Include("Categories").ToList();
                CompetitionsGrid.Items.Refresh();
            }
        }

        private void SaveToYaml_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog d = new SaveFileDialog()
                {
                    FileName = "DataExport",
                    DefaultExt = ".yaml", 
                    Filter = "YAML files|*.yaml|All files|*.*" 
                };

                if (d.ShowDialog() == true)
                {
                    using (StreamWriter sw = new StreamWriter(d.FileName))
                    {
                        var competitionList = dbContext?.Competitions?.Include("Categories").ToList();

                        if (competitionList != null && competitionList.Any())
                        {
                            foreach (var competition in competitionList)
                            {
                                var categoryList = dbContext?.Categories?.Where(category => category.CompetitionId == competition.Id).ToList();

                                string startDate = "1970-01-01";
                                string endDate = "1970-01-01";
        
                                if (!competition.StartDate.Equals(""))
                                {
                                    startDate = $"{competition.StartDate.Value.Year}-{competition.StartDate.Value.Month}-{competition.StartDate.Value.Day}";
                                }

                                if (!competition.EndDate.Equals(""))
                                {
                                    endDate = $"{competition.EndDate.Value.Year}-{competition.EndDate.Value.Month}-{competition.EndDate.Value.Day}";
                                }

                                sw.WriteLine($"- Name: {competition.Name}");
                                sw.WriteLine($"  City: {competition.City}");
                                sw.WriteLine($"  Country: {competition.Country}");
                                sw.WriteLine($"  Profit: {competition.Profit.ToString(CultureInfo.InvariantCulture)}");
                                sw.WriteLine($"  StartDate: {startDate}");
                                sw.WriteLine($"  EndDate: {endDate}");
                                sw.WriteLine("  Categories:");

                                foreach (var category in categoryList)
                                {
                                    var productList = dbContext?.Products?.Where(product => product.CategoryId == category.Id).ToList();

                                    sw.WriteLine($"    - CategoryName: {category.CategoryName}");
                                    sw.WriteLine("      Products:");

                                    foreach (var product in productList)
                                    {
                                        var itemList = dbContext?.Items?.Where(item => item.ProductId == product.Id).ToList();

                                        sw.WriteLine($"        - ProductName: {product.ProductName}");
                                        sw.WriteLine($"          ItemQuantity: {product.ItemQuantity}");
                                        sw.WriteLine($"          SoldItemQuantity: {product.SoldItemQuantity}");
                                        sw.WriteLine($"          Price: {product.Price.ToString(CultureInfo.InvariantCulture)}");
                                        sw.WriteLine($"          Discounts: {product.Discounts.ToString(CultureInfo.InvariantCulture)}");
                                        sw.WriteLine($"          ProductProfit: {product.ProductProfit.ToString(CultureInfo.InvariantCulture)}");
                                        sw.WriteLine("          Items:");

                                        foreach (var item in itemList)
                                        {
                                            sw.WriteLine($"            - ItemName: {item.ItemName}");
                                            sw.WriteLine($"              Discount: {item.Discount.ToString(CultureInfo.InvariantCulture)}");
                                            sw.WriteLine($"              IsItemSold: {item.IsItemSold.ToString().ToLower()}"); 
                                        }
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Export data to YAML successful", "Information");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void LoadDataFromYaml_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    OpenFileDialog d = new OpenFileDialog()
                    {
                        FileName = "DataExport",
                        DefaultExt = ".yaml", 
                        Filter = "YAML files|*.yaml|All files|*.*" 
                    };

                    if (d.ShowDialog() == true)
                    {
                        string yamlContent = File.ReadAllText(d.FileName);

                        var deserializer = new DeserializerBuilder().Build();

                        var competitions = deserializer.Deserialize<List<Competition>>(yamlContent);                      

                        foreach (var competition in competitions)
                        {
                            dbContext?.Competitions?.Add(competition);
                        }

                        dbContext?.SaveChanges();


                        CompetitionsGrid.ItemsSource = dbContext?.Competitions?.Include("Categories").ToList();
                        CompetitionsGrid.Items.Refresh();

                        MessageBox.Show("Data import from YAML successful", "Information");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Deserialization error: {ex.Message}\n{ex.StackTrace}", "Error");
                }
            }
        }



    }
}