using Halcube_Store_Manager_BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Logika interakcji dla klasy AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private readonly AppDbContext dbContext;
        
        Category CategoryToEdit { get; set; }


        public AddProductWindow(Category categoryToEdit)
        {
            InitializeComponent();

            dbContext = new AppDbContext();

            this.CategoryToEdit = categoryToEdit;
        }

        private void AddProductButton(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ItemQuantityBox.Text, out int ParsedItemQuantity) ||
                !float.TryParse(PriceBox.Text,out float ParsedPrice))
            {
                MessageBox.Show("Invalid number data");
                return;
            }

            if (Regex.IsMatch(ProductNameBox.Text, @"^\s*$"))
            {
                MessageBox.Show("Name can not be empty");
                return;
            }

            if (ParsedItemQuantity > 500)
            {
                MessageBox.Show("Item quantity limit is 500");
                return;
            }

                var ProductToAdd = new Product
            {
                ProductName = ProductNameBox.Text,
                ItemQuantity = ParsedItemQuantity,
                SoldItemQuantity = 0,
                Price = ParsedPrice,
                Discounts = 0,
                ProductProfit = 0,
                CategoryId = CategoryToEdit.Id
            };

            dbContext?.Products?.AddOrUpdate(ProductToAdd);
            dbContext?.SaveChanges();

            for (int i = 0; i < ProductToAdd.ItemQuantity; i++)
            {
                var ItemToAdd = new Item
                {
                    ItemName = ProductToAdd.ProductName,
                    Discount = 0,
                    IsItemSold = false,
                    ProductId = ProductToAdd.Id
                };

                dbContext?.Items?.AddOrUpdate(ItemToAdd);
            }

            dbContext?.SaveChanges();
            DialogResult = true;
        }
    }
}
