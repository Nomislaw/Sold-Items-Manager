using Halcube_Store_Manager_BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Halcube_Store_Manager
{
    /// <summary>
    /// Logika interakcji dla klasy ProductWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        private readonly AppDbContext dbContext;
        public Competition? competitionToEdit;
        public CategoryWindow(Competition? competitionToEdit)
        {
            InitializeComponent();

            Closing += CategoryWindowClosing;

            dbContext = new AppDbContext();

            this.competitionToEdit = competitionToEdit;

            var categoryToEdit = dbContext.Categories?.Where(category => category.CompetitionId == competitionToEdit.Id).Include("Products").ToList();

            CategoriesGrid.Columns.Add(new DataGridTextColumn() {Header = "Category", Binding = new Binding("CategoryName"), Width = 100 });
            var buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "X");
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(DeleteCategoryClick));
            CategoriesGrid.Columns.Add(new DataGridTemplateColumn { Header = "Delete", CellTemplate = new DataTemplate { VisualTree = buttonFactory } });
            CategoriesGrid.MouseDoubleClick += MouseDoubleClickAction;
            CategoriesGrid.AutoGenerateColumns = false;
            CategoriesGrid.ItemsSource = categoryToEdit;
            CategoriesGrid.IsReadOnly = true;

            NameLabel.Content = competitionToEdit.Name;
        }

        private void CategoryWindowClosing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult == null) 
            {
                DialogResult = true;
            }
        }

        private void AddCategoryClick(object sender, RoutedEventArgs e)
        {

            if(!Regex.IsMatch(CategoryNameBox.Text, @"^\s*$"))
            {
                Category? categoryToAdd = new Category
                {
                    CategoryName = CategoryNameBox.Text,
                    CompetitionId = competitionToEdit.Id
                };

                dbContext?.Categories?.Add(categoryToAdd);
                dbContext?.SaveChanges();
                CategoriesGrid.ItemsSource = dbContext?.Categories?.Where(category => category.CompetitionId == competitionToEdit.Id).Include("Products").ToList();
                CategoriesGrid.Items.Refresh();
            }
        }

        private void DeleteCategoryClick(object sender, RoutedEventArgs e)
        {
            Category? selectedCategory = CategoriesGrid.SelectedItem as Category;
            int? id = selectedCategory?.Id;

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to remove selected category?", "Confirm removing", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Category? categoryToDelete = dbContext?.Categories?.FirstOrDefault(c => c.Id == id);
                dbContext?.Categories?.Remove(categoryToDelete);

                if (dbContext?.SaveChanges() > 0)
                {
                    CategoriesGrid.ItemsSource = dbContext.Categories?.Where(category => category.CompetitionId == competitionToEdit.Id).Include("Products").ToList();
                    CategoriesGrid.Items.Refresh();
                }
            }
        }

        private void MouseDoubleClickAction(object sender, RoutedEventArgs e)
        {
            Category? selectedCategory = CategoriesGrid.SelectedItem as Category;

            int? id = selectedCategory?.Id;

            if (id == null) return;

            Category? categoryToEdit = dbContext?.Categories?.FirstOrDefault(x => x.Id == id);

            ProductWindow? productWindow = new ProductWindow(categoryToEdit);

            bool? result = productWindow.ShowDialog();

            if (result == true)
            {
                categoryToEdit = dbContext?.Categories?.FirstOrDefault(s => s.Id == id);
                CategoriesGrid.ItemsSource = dbContext.Categories?.Where(category => category.CompetitionId == competitionToEdit.Id).Include("Products").ToList();
                CategoriesGrid.Items.Refresh();

            }
        }
    }
}
