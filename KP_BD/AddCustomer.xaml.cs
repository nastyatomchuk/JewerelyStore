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
    /// Логика взаимодействия для AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (n_lable.Text == "")
            {
                n_lable.ToolTip = "Заполните поле";
                n_lable.BorderBrush = Brushes.Red;
            }
            else if (n_lable.Text != "")
            {
                n_lable.ToolTip = "";
                n_lable.BorderBrush = Brushes.Transparent;
                flag = true;
            }
            if (s_lable.Text == "")
            {
                s_lable.ToolTip = "Заполните поле";
                s_lable.BorderBrush = Brushes.Red;
                flag = false;
            }
            else if (s_lable.Text != "")
            {
                s_lable.ToolTip = "";
                s_lable.BorderBrush = Brushes.Transparent;
                flag = true;
            }
            if (p_lable.Text == "")
            {
                p_lable.ToolTip = "Заполните поле";
                p_lable.BorderBrush = Brushes.Red;
                flag = false;
            }
            else if (p_lable.Text != "")
            {
                p_lable.ToolTip = "";
                p_lable.BorderBrush = Brushes.Transparent;
                flag = true;
            }

            if (tel_lable.Text == "")
            {
                tel_lable.ToolTip = "Заполните поле";
                tel_lable.BorderBrush = Brushes.Red;
                flag = false;
            }
            else if (tel_lable.Text != "")
            {
                tel_lable.ToolTip = "";
                tel_lable.BorderBrush = Brushes.Transparent;
                flag = true;
            }
            if (birth_lable.Text == "")
            {
                birth_lable.ToolTip = "Заполните поле";
                birth_lable.BorderBrush = Brushes.Red;
                flag = false;
            }
            else if (birth_lable.Text != "")
            {
                birth_lable.ToolTip = "";
                birth_lable.BorderBrush = Brushes.Transparent;
                flag = true;
            }

            if (flag == true)
            {
                string t1 = n_lable.Text.Trim();
                string t2 = s_lable.Text.Trim();
                string t3 = p_lable.Text.Trim();
                string t4 = tel_lable.Text.Trim();
                string t5 = birth_lable.Text.Trim();
                DateTime tt5 = Convert.ToDateTime(t5);

                try
                {
                    Customers new_customer = new Customers() { name = t1, surname = t2, patronymic = t3, phone = t4, birthday = tt5 };
                    dc.Customers.InsertOnSubmit(new_customer);
                    dc.SubmitChanges();
                    MessageBox.Show("Покупатель добавлен");
                    this.Close();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Проверьте поля ", "Ошибка", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
