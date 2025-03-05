using System.Data.Entity;

namespace Halcube_Store_Manager_BLL
{
    public class AppDbContext : DbContext
    {
        //Tutaj ustawiamy parametry połączenia
        string ConnectionParameters = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\szymo\\OneDrive\\Dokumenty\\Projekty\\Halcube Store Manager v0.4\\BLL\\Database1.mdf\";Integrated Security=True";
        public DbSet<Competition>? Competitions { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Item>? Items { get; set; }

        public AppDbContext()
        {
            Database.Connection.ConnectionString = ConnectionParameters;
        }
    }
}
