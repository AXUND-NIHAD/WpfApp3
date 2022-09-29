using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Model;
using WpfApp3.ViewModel;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel viewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel(this);
            DataContext = viewModel;
        }
        private void abc()
        {
            using (var db = new LibraryContext())
            {
                var books = db.Books.Join(db.Authors, b => b.IdAuthor, a => a.Id, (b, a) => new
                {
                    Name = b.Name,
                    Author = a.LastName + " " + a.FirstName
                }).ToList();
                foreach (var book in books)
                {
                    Txt_box1.Items.Add(book.Name);
                }
                Txt_box1.SelectedIndex = 0;

            }
        }

        //private void Txt_box2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (sender is ComboBox cb)
        //    {
        //        Txt_box2.Items.Add("A");
        //    }
        //}
    }
}
