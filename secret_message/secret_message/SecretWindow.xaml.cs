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
using System.Windows.Shapes;

namespace secret_message
{
    /// <summary>
    /// Логика взаимодействия для SecretWindow.xaml
    /// </summary>
    public partial class SecretWindow : Window
    {

        string email;
        string text;
        public SecretWindow(string secret_key, string _email)
        {
            InitializeComponent();
            for (int i = 0; i < secret_key.Length; i++)
                textBoxSecretKey.Text += secret_key[i];

            email = _email;
            text = textBoxSecretKey.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textBoxSecretKey.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("secret.text.for.you@mail.ru", "kI-UYFyip1i1");
            string from = "secret.text.for.you@mail.ru";
            string to = email;
            string subject = "Secret Key";

            try
            {
                MailMessage message = new MailMessage(from, to, subject, text);
                client.Send(message);
            }
            catch
            {
                
            }
        }
    }
}
