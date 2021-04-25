using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace secret_message
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        
        
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {

            ValidataWindow vld = new ValidataWindow(textBoxMessage.Text, textBoxTopic.Text, textBoxEmailReceive.Text);
            vld.Show();


        }

        private void textBoxMessage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            if(textBoxMessage.Text == "HERE")
            {
                textBoxMessage.Text = "";
                
            }
        }

        private void textBoxEmailReceive_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxEmailReceive.Text == "E-MAIL")
            {
                textBoxEmailReceive.Text = "";

            }
        }

        private void textBoxTopic_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxTopic.Text == "TOPIC")
            {
                textBoxTopic.Text = "";

            }
        }

        private void buttonDeSecretMes_Click(object sender, RoutedEventArgs e)
        {
            DeSecretWindow dsc = new DeSecretWindow();
            Close();
            dsc.Show();
        }
    }
}
