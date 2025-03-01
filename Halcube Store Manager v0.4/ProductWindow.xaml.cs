using Halcube_Store_Manager_BLL;
using Halcube_Store_Manager_v0._2;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
    public partial class ProductWindow : Window
    {
        private readonly AppDbContext dbContext;
        public Category CategoryToEdit;
        public ProductWindow(Category categoryToEdit)
        {
            InitializeComponent();

            dbContext = new AppDbContext();

            this.CategoryToEdit = categoryToEdit;

            var ProductToEdit = dbContext.Products?.Where(product => product.CategoryId == CategoryToEdit.Id).Include("Items").ToList();

            ProductsGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("ProductName") });
            ProductsGrid.Columns.Add(new DataGridTextColumn() { Header = "Item quantity", Binding = new Binding("ItemQuantity") });
            ProductsGrid.Columns.Add(new DataGridTextColumn() { Header = "Sold items", Binding = new Binding("SoldItemQuantity") });
            ProductsGrid.Columns.Add(new DataGridTextColumn() { Header = "Price", Binding = new Binding("Price") });
            ProductsGrid.Columns.Add(new DataGridTextColumn() { Header = "Discounts", Binding = new Binding("Discounts") });
            ProductsGrid.Columns.Add(new DataGridTextColumn() { Header = "Profit", Binding = new Binding("ProductProfit") });
            var buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "X");
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(DeleteProductClick));
            ProductsGrid.Columns.Add(new DataGridTemplateColumn { Header = "Delete", CellTemplate = new DataTemplate { VisualTree = buttonFactory } });
            ProductsGrid.MouseDoubleClick += MouseDoubleClickAction;

            ProductsGrid.AutoGenerateColumns = false;
            ProductsGrid.ItemsSource = ProductToEdit;
            ProductsGrid.IsReadOnly = true;

            NameLabel.Content = categoryToEdit.CategoryName;
            CalculateArguments();
        }

        public void CalculateArguments()
        {
            var productsToEdit = dbContext.Products?
                                          .Where(product => product.CategoryId == CategoryToEdit.Id)
                                          .Include("Items")
                                          .ToList();

            if (productsToEdit == null) return;

            foreach (var prod in productsToEdit)
            {
                int soldItemQuantity = 0;
                float discounts = 0;

                var itemsToEdit = dbContext.Items?.Where(item => item.ProductId == prod.Id).ToList();

                foreach (var item in itemsToEdit)
                {
                    dbContext.Entry(item).Reload();
                    if (item.IsItemSold)
                    {
                        soldItemQuantity++;
                        discounts += item.Discount;
                    }
                }

                prod.SoldItemQuantity = soldItemQuantity;
                prod.Discounts = discounts;
                prod.ProductProfit = (float)Math.Round(soldItemQuantity * prod.Price - discounts, 2);
                
                //MessageBox.Show($"{soldItemQuantity}", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            dbContext.SaveChanges();

            var updatedProducts = dbContext.Products?.Where(product => product.CategoryId == CategoryToEdit.Id).Include("Items").ToList();
                                  
            ProductsGrid.ItemsSource = updatedProducts;
            ProductsGrid.Items.Refresh();
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow(CategoryToEdit);
            bool? Result = addProductWindow.ShowDialog();

            if (Result == true)
            {
                ProductsGrid.ItemsSource = dbContext.Products?.Where(product => product.CategoryId == CategoryToEdit.Id).Include("Items").ToList();
                ProductsGrid.Items.Refresh();
            }
        }

        private void DeleteProductClick(object sender, RoutedEventArgs e)
        {
            Product? selectedProduct = ProductsGrid.SelectedItem as Product;
            int? id = selectedProduct?.Id;

            if(selectedProduct is not null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure to remove selected product?", "Confirm removing", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Product? productToDelete = dbContext?.Products?.FirstOrDefault(p => p.Id == id);
                    dbContext?.Products?.Remove(productToDelete);

                    if (dbContext?.SaveChanges() > 0)
                    {
                        ProductsGrid.ItemsSource = dbContext.Products?.Where(product => product.CategoryId == CategoryToEdit.Id).Include("Items").ToList();
                        ProductsGrid.Items.Refresh();
                    }
                }
            }
        }

        private void MouseDoubleClickAction(object sender,RoutedEventArgs e)
        {
            Product? selectedProduct = ProductsGrid.SelectedItem as Product;

            int? id = selectedProduct?.Id;

            if (id == null) return;

            Product? productToEdit = dbContext?.Products?.FirstOrDefault(x => x.Id == id);

            ItemWindow? itemWindow = new ItemWindow(productToEdit);

            bool? result = itemWindow.ShowDialog();

            if (result == true)
            {
                CalculateArguments();
            }
        }
    }
}
