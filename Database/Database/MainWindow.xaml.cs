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
using System.Data.OleDb;

namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\CharacterDatabase.mdb;Persist Security Info=True");

            InitializeComponent();
        }

        private void _Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\t" + read[1].ToString() + "\t "  +  read[2].ToString() + "\n";
            }
            View.Text = data;
            cn.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand cm = new OleDbCommand("SELECT [Names].* FROM[Names]", cn);
            cn.Open();
            OleDbDataReader read = cm.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\t" + read[1].ToString() + "\t " + read[2].ToString() + "\n";
            }
            View.Text = data;
            cn.Close();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

   
    }
}
