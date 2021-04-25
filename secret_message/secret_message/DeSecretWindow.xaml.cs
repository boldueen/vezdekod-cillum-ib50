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
using System.Windows.Shapes;

namespace secret_message
{
    /// <summary>
    /// Логика взаимодействия для DeSecretWindow.xaml
    /// </summary>
    public partial class DeSecretWindow : Window
    {
        public DeSecretWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = textBoxText.Text;
            string key = textBoxKey.Text;
            char[] vs = text.ToCharArray();
            string help_str = string.Empty;
            string a = string.Empty;
            int x = 0;
 
                



            for (int i=0; i<text.Length; i++)
            {
                a = string.Empty;
                x = 0;

                for (int j=i; j<i+2; j++)
                {
                    a += key[j];
                }

                x = Convert.ToUInt16(a);


                vs[i] -= (char)x;


            }

            foreach (char c in vs)
            {
                help_str += c;
            }

            textBoxText.Text = help_str;

        }
    }
}
