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

namespace KP_BD
{
    /// <summary>
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public profile()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (login_textBox.Text == "")
            {
                login_textBox.ToolTip = "Заполните поле";
                login_textBox.BorderBrush = Brushes.Red;
            }
            else if (login_textBox.Text != "")
            {
                login_textBox.ToolTip = "";
                login_textBox.BorderBrush = Brushes.Transparent;
                flag = true;
            }
            if (password_textBox1.Password == "")
            {
                password_textBox1.ToolTip = "Заполните поле";
                password_textBox1.BorderBrush = Brushes.Red;
                flag = false;
            }
            else if (password_textBox1.Password != "")
            {
                password_textBox1.ToolTip = "";
                password_textBox1.BorderBrush = Brushes.Transparent;
                flag = true;
            }

            if (flag == true)
            {
                try
                {
                    Sellers sel = (from t in dc.Sellers
                                    where t.login == login_textBox.Text & t.password == password_textBox1.Password
                                    select t).Single();


                    MainAccount m = new MainAccount(sel.id);
                    m.Show();
                    this.Close();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Проверьте поля или зарегистрируйтесь", "Пользователь не найден", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (on.Visibility == Visibility.Visible)
            {
                off.Visibility = Visibility.Visible;
                t_p.Text = password_textBox1.Password;
                t_p.Visibility = Visibility.Visible;
                on.Visibility = Visibility.Hidden;
                password_textBox1.Visibility = Visibility.Hidden;
            }
            else
            {
                off.Visibility = Visibility.Hidden;
                password_textBox1.Password = t_p.Text;
                t_p.Visibility = Visibility.Hidden;
                on.Visibility = Visibility.Visible;
                password_textBox1.Visibility = Visibility.Visible;
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
