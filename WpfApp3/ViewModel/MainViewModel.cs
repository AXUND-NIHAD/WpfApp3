using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp3.Model;
using WpfApp3.View;

namespace WpfApp3.ViewModel
{
    public class MainViewModel
    {
        private MainWindow mw { get; set; }
        public MainViewModel(MainWindow mw)
        {
            this.mw = mw;
            Start();
        }
        private void Start()
        {
            using (var db = new LibraryContext()) { _book = (from Book in db.Books select Book).ToList(); }
            mw.Txt_box1.SelectionChanged += Txt_box_SelectionChanged;
            mw.Txt_box2.SelectionChanged += Txt_box_SelectionChanged;
        }
        private  void abc()
        {
            mw.Txt_box2.Items.Clear();
            using (var db = new LibraryContext())
            {
                var autors = (from author in db.Authors
                              select author).ToList();
                foreach (var item in autors)
                {
                    mw.Txt_box2.Items.Add(item.Id+" "+ item.FirstName + item.LastName);
                }
              
                mw.Txt_box2.SelectedIndex = 0;
                ListAdd("Author", 0);
            }
        }
        private void AddPress()
        {
            mw.Txt_box2.Items.Clear();
            using (var db = new LibraryContext())
            {
                var press1 = (from Press in db.Presses select Press).ToList();
                foreach (var item in press1)
                    mw.Txt_box2.Items.Add(item.Id + " " + item.Name);
                

                mw.Txt_box2.SelectedIndex = 0;
                ListAdd("Press", 0);
            }
        }
        private void AddCategory()
        {
            mw.Txt_box2.Items.Clear();
            using (var db = new LibraryContext())
            {
                var cat = (from Category in db.Categories select Category).ToList();
                foreach (var item in cat)
                    mw.Txt_box2.Items.Add(item.Id + " " + item.Name);


                mw.Txt_box2.SelectedIndex = 0;
                ListAdd("Category", 0);
            }
        }
        private void Txt_box1(string ItemName)
        {
            switch (ItemName)
            {
                case "Author":
                    abc();
                    break;
                case "Press":
                    AddPress();
                    break;
                case "Category":
                    AddCategory();
                    break;
                case "Theme":
                    AddTheme();
                    break;
                default:
                    break;
            }
        }

        private void AddTheme()
        {
            mw.Txt_box2.Items.Clear();
            using (var db = new LibraryContext())
            {
                var cat = (from Theme in db.Themes select Theme).ToList();
                foreach (var item in cat)
                    mw.Txt_box2.Items.Add(item.Id + " " + item.Name);

                mw.Txt_box2.SelectedIndex = 0;
                ListAdd("Theme", 0);
            }
        }

        private void ListAdd(List<Book> bk)
        {
            mw.list_box.Items.Clear();
            foreach (var item in bk)
            {
                mw.list_box.Items.Add(new UserControl1(item));
            }
        }
        private List<Book> _book { get; set; }
        private void ListAdd(string name,int index )
        {
            //mw.Txt_box2.Items.Clear();
            using (var db = new LibraryContext())
            {
                try
                {
                    switch (name)
                    {
                        case "Author":
                            List<Book> books = (from Book in db.Books where Book.IdAuthor == _book[index].Id select Book ).ToList();
                            ListAdd(books);
                            break;
                        case "Press":
                            List<Book> books1 = (from Book in db.Books where Book.IdPress == _book[index].Id select Book).ToList();
                            ListAdd(books1);
                            break;
                        case "Category":
                            List<Book> books2 = (from Book in db.Books where Book.IdCategory == _book[index].Id select Book).ToList();
                            ListAdd(books2);
                            break;
                        case "Theme":
                            List<Book> books3 = (from Book in db.Books where Book.IdThemes == _book[index].Id select Book).ToList();
                            ListAdd(books3);
                            break;
                        default:
                            break;
                    }
                }
                catch{}
            }
        }
        public  void Txt_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox cb)
            {
                switch (cb.Tag)
                {
                    case "1":
                        mw.Txt_box2.Items.Clear();
                        var selectionItem = e.AddedItems[0] as ComboBoxItem;
                        Txt_box1(selectionItem.Content.ToString());
                        break;
                    case "2":
                        string name = mw.Txt_box1.Text;
                        switch (name)
                        {
                            case "Author":
                                ListAdd(name, cb.SelectedIndex);
                                break;
                            case "Press":
                                ListAdd(name, cb.SelectedIndex);
                                break;
                            case "Category":
                                ListAdd(name, cb.SelectedIndex);
                                break;
                            case "Theme":
                                ListAdd(name,cb.SelectedIndex);
                                break;
                            default:

                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
