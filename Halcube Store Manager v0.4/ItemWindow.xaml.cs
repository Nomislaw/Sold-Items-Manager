using Halcube_Store_Manager_BLL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Halcube_Store_Manager_v0._2
{
    /// <summary>
    /// Logika interakcji dla klasy ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        private readonly AppDbContext dbContext;
        public Product ProductToEdit { get; set; }


        public ItemWindow(Product productToEdit)
        {
            InitializeComponent();

            dbContext = new AppDbContext();
            this.ProductToEdit = productToEdit;

            var ItemToEdit = dbContext?.Items?.Where(item => item.ProductId == ProductToEdit.Id).ToList();

            ItemsGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new Binding("ItemName") });
            ItemsGrid.Columns.Add(new DataGridCheckBoxColumn
            {
                Header = "Is item sold",
                Binding = new Binding("IsItemSold")
                {
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                }

            });

            var textBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            textBoxFactory.SetBinding(TextBox.TextProperty, new Binding("Discount"));
            textBoxFactory.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(DiscountToTextBox));
            ItemsGrid.Columns.Add(new DataGridTemplateColumn { Header = "Discount", CellTemplate = new DataTemplate { VisualTree = textBoxFactory } });

            ItemsGrid.AutoGenerateColumns = false;
            ItemsGrid.ItemsSource = ItemToEdit;
            ItemsGrid.IsReadOnly = false;

            ItemsGrid.CellEditEnding += IsAvaibleChange;

            LabelName.Content = productToEdit.ProductName;
            LabelPrice.Content = $"Price: {productToEdit.Price}";
        }


        private void DiscountToTextBox(object sender, RoutedEventArgs e)
        {

            var textBox = sender as TextBox;

            var selectedItem = ItemsGrid.SelectedItem as Item;

            if (selectedItem != null)
            {
                int id = selectedItem.Id;

                if (textBox != null)
                {
                    if (!float.TryParse(textBox.Text, out float parsedNewValue))
                    {
                        textBox.Text = "0";
                    }
                    else if(parsedNewValue<0 || parsedNewValue > ProductToEdit.Price || selectedItem.IsItemSold == false)
                    {
                        textBox.Text = "0";
                        parsedNewValue = 0;
                    }
                    else
                    {
                        Item itemToChange = dbContext?.Items?.FirstOrDefault(item => item.Id == id);

                        if (itemToChange != null)
                        {
                            itemToChange.Discount = parsedNewValue;
                        }
                    }
                }
            }
        }

        private void IsAvaibleChange(object sender,DataGridCellEditEndingEventArgs e)
        {
            if (e.Column is DataGridCheckBoxColumn && e.Row.Item is Item item)
            {
                var checkBox = e.EditingElement as CheckBox;

                var selectedItem = ItemsGrid.SelectedItem as Item;
                int id = selectedItem.Id;

                if (checkBox != null)
                {
                    bool newValue = checkBox.IsChecked ?? false;

                    item.IsItemSold = newValue;

                    Item itemToChange = dbContext?.Items?.FirstOrDefault(item => item.Id == id);

                    if (itemToChange != null)
                    {
                        itemToChange.IsItemSold = newValue;
                        if(newValue == false)
                        {
                            itemToChange.Discount = 0;
                        }
                    }

                }
            }
        }
        
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbContext?.SaveChanges();
            DialogResult = true;
        }
    }

}
