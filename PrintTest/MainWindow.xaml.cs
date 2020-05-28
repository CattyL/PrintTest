using System;
using System.Collections.Generic;
using System.Data;
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
using Captain.NetCore.Database;

namespace PrintTest
{
    //参考
    //https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.controls.printdialog.printvisual?redirectedfrom=MSDN&view=netcore-3.1#System_Windows_Controls_PrintDialog_PrintVisual_System_Windows_Media_Visual_System_String_
    //https://social.msdn.microsoft.com/Forums/officeapps/zh-CN/82881771-20d2-4b5d-bd9c-81ba0f0cab9b/35831383821996819979wpf2345429616251712136024212358132459020040?forum=wpfzhchs
    //https://www.cnblogs.com/s0611163/p/10147705.html

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 需要打印预览的控件
        /// </summary>
        private FrameworkElement _element;

        public MainWindow()
        {
            InitializeComponent();
            initListView();
        }

        public void initListView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("index");
            dt.Columns.Add("serialNumber");
            dt.Columns.Add("bookName");
            dt.Columns.Add("bookType");
            dt.Columns.Add("author");
            dt.Columns.Add("publishingCompany");
            dt.Columns.Add("price");
            dt.Columns.Add("stock");

            for (int i = 0; i < 20; i++)
            {
                dt.Rows.Add(i, 123456, "testBook" + i, "Math", "qiaobus", "shanghai", "just a book", new Random().Next(0, 100) + i);
            }
            listView.DataContext = dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(this.border, "");
            }
        }

        

        
    }

    internal class Book
    {
        private int _index;
        private int _serialNumber;
        private string _bookName;
        private string _bookType;
        private string _author;
        private string _publishingCompany;
        private string _price;
        private string _stock;

        public Book(int index, int serialNumber, string bookName, string bookType, string author, string publishingCompany, string price, string stock)
        {
            this._index = index;
            this._serialNumber = serialNumber;
            this._bookName = bookName;
            this._bookType = bookType;
            this._author = author;
            this._publishingCompany = publishingCompany;
            this._price = price;
            this._stock = stock;
        }
    }
}
