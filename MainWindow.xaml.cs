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

namespace sudokuGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int inputNumber;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtNumber.Text) < 9)
            {
                inputNumber = Convert.ToInt32(txtNumber.Text);
                inputNumber += 1;
                txtNumber.Text = Convert.ToString(inputNumber);
            }
        }
        
        /* MÁSIK MEGOLDÁS:  
        
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            int meret = int.Parse(txtMeret.Text);
            if (meret > 4)
            {
                txtMeret.Text = (meret - 1).ToString();
            }
        }  */
        
//--------------------------------------------------------------------------------------------------      

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {          
                if (Convert.ToInt32(txtNumber.Text) > 4)
                {
                    inputNumber = Convert.ToInt32(txtNumber.Text);
                    inputNumber--;
                    txtNumber.Text = Convert.ToString(inputNumber);
                }            
        }
        
        /* MÁSIK MEGOLDÁS 
        
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
             int meret = int.Parse(txtMeret.Text);
            if (meret < 9)
            {
                txtMeret.Text = (meret + 1).ToString();
            }
        }   */
        

//------------------------------------------------------------------------------------------------------------------------

        private void txtKezdoAllapot_TextChanged(object sender, TextChangedEventArgs e)
        {
           lblHossz.Content = string.Format($"Hossz: {txtKezdoAllapot.Text.Length}");
        }
        
//-----------------------------------------------------------------------------------------------

        private void btnEllenorzes_Click(object sender, RoutedEventArgs e)
        {
            int meret = int.Parse(txtMeret.Text);
            int hossz = txtKezdoAllapot.Text.Length;
            if (meret * meret == hossz)
            {
                MessageBox.Show("A feladvány megfelelő hosszúságú!");
            }
            else if (meret * meret > hossz)
            {
                MessageBox.Show(string.Format($"A feladvány rövid: kell még {meret * meret - hossz} számjegy!"));
            }
            else
            {
                MessageBox.Show($"A feladvány hosszú: törlendő { hossz - meret - meret} számjegy!);
            }
            
            
            
            
        }
        
        
        }
    }
}
