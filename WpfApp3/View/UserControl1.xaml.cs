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

namespace WpfApp3.View
{

    public partial class UserControl1 : UserControl
    {
        public UserControl1(Book bk)
        {
            InitializeComponent();
            bookadd(bk);
        }
        private void bookadd(Book bk) { 
            ID.Content = bk.Id;
            Name.Content = bk.Name;
            Author_ID.Content = bk.IdAuthor;
            Page.Content = bk.Pages;
        }
    }
}
