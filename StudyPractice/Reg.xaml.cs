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


namespace StudyPractice
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void TB_Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BN_Auth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void BN_Reg_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var login = TB_Login.Text;
                var password = TB_Password.Text;

                try
                {
                    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) && string.IsNullOrEmpty(TB_FIO.Text) || string.IsNullOrEmpty(DP_DateBirth.SelectedDate.Value.ToString()))
                    {
                        
                    }
                    else
                    {
                        User _newUser = new User { Name = TB_FIO.Text, Login = login, Password = password, DateOfBirth = DP_DateBirth.SelectedDate.Value, PhoneNumber = Convert.ToInt32(TB_PhoneNumber.Text), Email = TB_Email.Text, Role = "Администратор" };
                        db.Users.Add(_newUser);
                        db.SaveChanges();
                        MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new Auth());
                    }
                }
                catch(Exception ex) { MessageBox.Show("Заполните логин, пароль, фио и дату рождения для регистрации!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Error); }     
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TB_FIO_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_FIO.Text = "";
        }

        private void TB_Email_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Email.Text = "";
        }

        private void TB_PhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_PhoneNumber.Text = "";
        }

        private void TB_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Login.Text = "";
        }

        private void TB_Password_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Password.Text = "";
        }
    }
}
