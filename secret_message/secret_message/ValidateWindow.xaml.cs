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
using System.Net;
using System.Net.Mail;

namespace secret_message
{
    /// <summary>
    /// Логика взаимодействия для ValidataWindow.xaml
    /// </summary>
    /// 


    //struct keys
    //{
    //    int key;
    //}

    public partial class ValidataWindow : Window
    {
        //keys[] secretKeyses = new keys();

        int[] secret_key = new int[0];

        int GetRandomInt()
        {
            Random rand = new Random();
            int sim = rand.Next(101, 999);
            return sim;
        }



        string CreateSecret(string text)
        {
            Array.Resize(ref secret_key, text.Length);

            char[] vs = text.ToCharArray();

            Random rand = new Random();
            string help_str = string.Empty;


            for (int i = 0; i < secret_key.Length; i++)
            {
                int sim = rand.Next(10, 99);
                secret_key[i] = sim;
                vs[i] += (char)sim;
            }

            foreach(char c in vs)
            {
                help_str += c;
            }



            return help_str;
        }

        string DeCreateSecret(string text, int[] secret_key)
        {
            char[] vs = text.ToCharArray();
            for (int i = 0; i < secret_key.Length; i++)
            {
                vs[i] -= (char)secret_key[i];
            }

            this.text = vs.ToString();

            return text;
        }

        int[] GetSecretKey()
        {
            return secret_key;
        }


        string email;
        string text;
        string topic;

        public ValidataWindow(string _text, string _topic, string _email)
        {
            InitializeComponent();
            email = _email;
            text = _text;
            topic = _topic;


            if (topic == "")
            {
                labelNoTopic.Visibility = Visibility.Visible;
            }

            textBoxIsEmailCorrect.Text = email;



        }

        private void buttonSendMessage_Click(object sender, RoutedEventArgs e)
        {
            string secret_text = CreateSecret(text);

            textBoxTest.Text = secret_text;



            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("secret.text.for.you@mail.ru", "kI-UYFyip1i1");
            string from = "secret.text.for.you@mail.ru";
            string to = email;
            string subject = topic;

            try
            {
                MailMessage message = new MailMessage(from, to, subject, secret_text);
                client.Send(message);
            }
            catch
            {
                textBoxIsEmailCorrect.Text = "INVALID E-MAIL";
            }




            SecretWindow scrwin = new SecretWindow(secret_text, email);

            scrwin.Show();
            Close();


        }





        private void buttonDONTSendMessage_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
