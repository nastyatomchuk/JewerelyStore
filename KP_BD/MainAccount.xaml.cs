using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using exportWord = Microsoft.Office.Interop.Word;

namespace KP_BD
{
    /// <summary>
    /// Логика взаимодействия для MainAccount.xaml
    /// </summary>
    public partial class MainAccount : System.Windows.Window
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        private Grid[] grids;
        private Image[] images;
        private System.Windows.Controls.Label[] labels1;
        private System.Windows.Controls.Label[] labels2;
        private System.Windows.Controls.Label[] labels3;
        private int ID_seller;
        private List<Products> products1;
        private int id_category;
        private int ccount = 0;
        private bool second = false;
        private bool first = false;
        private int CountOfPages = 1;

        private double cost1;
        public MainAccount(int ID_Seller)
        {
            ID_seller = ID_Seller;

            products1 = new List<Products>();
            InitializeComponent();

            var orders = (from o in dc.Purchases select o);
            lable_orders.Text = orders.Count().ToString();
            var customers = (from c in dc.Customers select c);
            lable_customers.Text = customers.Count().ToString();
            var purchas = (from p in dc.Purchases select p);
            double m = 0;
            foreach (var pur in purchas)
            {
                m += Convert.ToDouble(pur.cost);
            }
            money.Text = m.ToString() + " бел.руб";

            if (dc.Products.Count() <= 8)
            {
                Back.Visibility = Visibility.Hidden;
                Next.Visibility = Visibility.Hidden;
            }
            grids = new Grid[] { Grid1, Grid2, Grid3, Grid4, Grid5, Grid6, Grid7, Grid8 };

            for (int ii = 0; ii < grids.Length; ii++)
                grids[ii].Visibility = Visibility.Hidden;

        }

        private void Tovary(int idishnik)
        {
            id_category = idishnik;

            grids = new Grid[] { Grid1, Grid2, Grid3, Grid4, Grid5, Grid6, Grid7, Grid8 };
            images = new Image[] { Receiver1, Receiver2, Receiver3, Receiver4, Receiver5, Receiver6, Receiver7, Receiver8 };
            labels1 = new System.Windows.Controls.Label[] { LabelName1, LabelName2, LabelName3, LabelName4, LabelName5, LabelName6, LabelName7, LabelName8 };
            labels2 = new System.Windows.Controls.Label[] { LabelGanreName1, LabelGanreName2, LabelGanreName3, LabelGanreName4, LabelGanreName5, LabelGanreName6, LabelGanreName7, LabelGanreName8 };
            labels3 = new System.Windows.Controls.Label[] { idi1, idi2, idi3, idi4, idi5, idi6, idi7, idi8 };

            System.Windows.Controls.Button[] but_add = new System.Windows.Controls.Button[] { ButtonMain1, ButtonMain2, ButtonMain3, ButtonMain4, ButtonMain5, ButtonMain6, ButtonMain7, ButtonMain8 };
            System.Windows.Controls.Button[] but_add1 = new System.Windows.Controls.Button[] { ButtonMai1, ButtonMai2, ButtonMai3, ButtonMai4, ButtonMai5, ButtonMai6, ButtonMai7, ButtonMai8 };


            for (int ii = 0; ii < grids.Length; ii++)
            {
                images[ii].Source = null;
                labels1[ii].Content = "";
                labels2[ii].Content = "";
                labels3[ii].Content = "";
                but_add[ii].Visibility = Visibility.Visible;
                but_add1[ii].Visibility = Visibility.Hidden;
            }

            if (idishnik == 0)
            {
                var products = (from p in dc.Products.AsEnumerable()
                                join g in dc.Gallery.AsEnumerable()
                                on p.id equals g.id_product
                                where g.id_productPhoto == 1
                                select new
                                {
                                    фото = g.photo,
                                    название = p.title,
                                    цена = p.cost,
                                    p.id,
                                    категория = p.category_id
                                });
                int count = products.Count();
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                if (count > 8)
                {
                    count = 8;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var ph in products)
                {
                    if (ccc < ccount + 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(ph.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        if (!(i >= 8))
                        {
                            images[i].Source = image;
                            labels1[i].Content = ph.название;
                            labels2[i].Content = ph.цена + "р.";
                            labels3[i].Content = ph.id;
                            i++;
                        }
                    }
                    ccc++;
                }
                ccount = ccount + 8;
            }
            else
            {
                var products = (from p in dc.Products.AsEnumerable()
                                join g in dc.Gallery.AsEnumerable()
                                on p.id equals g.id_product
                                where g.id_productPhoto == 1
                                join cat in dc.Categories.AsEnumerable()
                                on p.category_id equals cat.id
                                where cat.id == id_category
                                select new
                                {
                                    фото = g.photo,
                                    название = p.title,
                                    цена = p.cost,
                                    id = p.id,
                                    категория = p.category_id
                                });
                int count = products.Count();
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                if (count > 8)
                {
                    count = 8;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var ph in products)
                {
                    if (ccc < ccount + 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(ph.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        if (!(i >= 8))
                        {
                            images[i].Source = image;
                            labels1[i].Content = ph.название;
                            labels2[i].Content = ph.цена + "р.";
                            labels3[i].Content = ph.id;
                            i++;
                        }
                    }
                    ccc++;
                }
                ccount = ccount + 8;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main_grid.Visibility = Visibility.Visible;
            products.Visibility = Visibility.Hidden;
            backet.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //корзина
        {
            //вывод информации в окно Корзина
            backet_grid.ItemsSource = null;
            Customers.Items.Clear();

            main_grid.Visibility = Visibility.Hidden;
            products.Visibility = Visibility.Hidden;
            backet.Visibility = Visibility.Visible;

            backet_grid.ItemsSource = products1;  //вывод в таблицу
            var customers = from cus in dc.Customers select cus; //вывод существующих покупателей
            foreach (var c in customers)
            {
                string fullname = c.surname.Trim() + " " + c.name.Trim() + " " + c.patronymic.Trim();
                Customers.Items.Add(fullname);
            }
            //заполнение данных о продавце
            var seller = (from s in dc.Sellers where s.id == ID_seller select s).Single();
            string fio = seller.surname.Trim() + " " + seller.name.Trim() + " " + seller.patronymic.Trim();
            Selller_lable.Content = fio;
            Date_lable.Content = DateTime.Now.ToString("d"); //вывод даты
            //подсчет общей стоимости
            cost1 = 0;
            foreach (var p in products1)
            {
                cost1 += Convert.ToDouble(p.cost);
            }
            allcost.Content = cost1.ToString() + " p.";


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            main_grid.Visibility = Visibility.Hidden;
            products.Visibility = Visibility.Visible;
            backet.Visibility = Visibility.Hidden;
        }

        private void Back_GotFocus(object sender, RoutedEventArgs e)
        {
            first = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (CountOfPages > 1)
            {
                CountOfPages--;
                labSmeny.Content = CountOfPages;
                var presentations = (from p in dc.Products.AsEnumerable()
                                     join g in dc.Gallery.AsEnumerable()
                                     on p.id equals g.id_product
                                     where g.id_productPhoto == 1
                                     join cat in dc.Categories.AsEnumerable()
                                     on p.category_id equals cat.id
                                     where cat.id == id_category
                                     select new
                                     {
                                         фото = g.photo,
                                         название = p.title,
                                         цена = p.cost,
                                         id = p.id
                                     });
                if (id_category == 0)
                {
                    presentations = (from p in dc.Products.AsEnumerable()
                                     join g in dc.Gallery.AsEnumerable()
                                     on p.id equals g.id_product
                                     where g.id_productPhoto == 1
                                     select new
                                     {
                                         фото = g.photo,
                                         название = p.title,
                                         цена = p.cost,
                                         id = p.id
                                     });
                }
                else
                {
                    presentations = (from p in dc.Products.AsEnumerable()
                                     join g in dc.Gallery.AsEnumerable()
                                     on p.id equals g.id_product
                                     where g.id_productPhoto == 1
                                     join cat in dc.Categories.AsEnumerable()
                                     on p.category_id equals cat.id
                                     where cat.id == id_category
                                     select new
                                     {
                                         фото = g.photo,
                                         название = p.title,
                                         цена = p.cost,
                                         id = p.id
                                     });
                }

                grids = new Grid[] { Grid1, Grid2, Grid3, Grid4, Grid5, Grid6, Grid7, Grid8 };
                images = new Image[] { Receiver1, Receiver2, Receiver3, Receiver4, Receiver5, Receiver6, Receiver7, Receiver8 };
                labels1 = new System.Windows.Controls.Label[] { LabelName1, LabelName2, LabelName3, LabelName4, LabelName5, LabelName6, LabelName7, LabelName8 };
                labels2 = new System.Windows.Controls.Label[] { LabelGanreName1, LabelGanreName2, LabelGanreName3, LabelGanreName4, LabelGanreName5, LabelGanreName6, LabelGanreName7, LabelGanreName8 };
                labels3 = new System.Windows.Controls.Label[] { idi1, idi2, idi3, idi4, idi5, idi6, idi7, idi8 };
                int count = 8;
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var a in presentations)
                {
                    if (ccc >= ccount - 16 & ccc < ccount - 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(a.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        images[i].Source = image;
                        labels1[i].Content = a.название;
                        labels2[i].Content = a.цена + "р.";
                        labels3[i].Content = a.id;
                        i++;
                    }
                    ccc++;
                }
                ccount = ccount - 8;
            }
            Tovary(id_category);
            first = false;
            second = false;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int varr = ((dc.Products.ToList().Count() / 8) + 1);
            if ((CountOfPages > 0) && (varr > CountOfPages))
            {
                CountOfPages++;
                labSmeny.Content = CountOfPages;
                var presentations = (from p in dc.Products.AsEnumerable()
                                     join g in dc.Gallery.AsEnumerable()
                                     on p.id equals g.id_product
                                     where g.id_productPhoto == 1
                                     join cat in dc.Categories.AsEnumerable()
                                     on p.category_id equals cat.id
                                     where cat.id == id_category
                                     select new
                                     {
                                         фото = g.photo,
                                         название = p.title,
                                         цена = p.cost,
                                         id = p.id
                                     });
                if (id_category == 0)
                {
                    presentations = (from p in dc.Products.AsEnumerable()
                                     join g in dc.Gallery.AsEnumerable()
                                     on p.id equals g.id_product
                                     where g.id_productPhoto == 1
                                     select new
                                     {
                                         фото = g.photo,
                                         название = p.title,
                                         цена = p.cost,
                                         id = p.id
                                     });
                }
                else
                {
                    presentations = (from p in dc.Products.AsEnumerable()
                                     join g in dc.Gallery.AsEnumerable()
                                     on p.id equals g.id_product
                                     where g.id_productPhoto == 1
                                     join cat in dc.Categories.AsEnumerable()
                                     on p.category_id equals cat.id
                                     where cat.id == id_category
                                     select new
                                     {
                                         фото = g.photo,
                                         название = p.title,
                                         цена = p.cost,
                                         id = p.id
                                     });
                }

                grids = new Grid[] { Grid1, Grid2, Grid3, Grid4, Grid5, Grid6, Grid7, Grid8 };
                images = new Image[] { Receiver1, Receiver2, Receiver3, Receiver4, Receiver5, Receiver6, Receiver7, Receiver8 };
                labels1 = new System.Windows.Controls.Label[] { LabelName1, LabelName2, LabelName3, LabelName4, LabelName5, LabelName6, LabelName7, LabelName8 };
                labels2 = new System.Windows.Controls.Label[] { LabelGanreName1, LabelGanreName2, LabelGanreName3, LabelGanreName4, LabelGanreName5, LabelGanreName6, LabelGanreName7, LabelGanreName8 };
                labels3 = new System.Windows.Controls.Label[] { idi1, idi2, idi3, idi4, idi5, idi6, idi7, idi8 };

                int count = presentations.Count() - ccount;
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                if (count > 8)
                {
                    count = 8;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var a in presentations)
                {
                    if (ccc >= ccount & ccc < ccount + 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(a.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        images[i].Source = image;
                        labels1[i].Content = a.название;
                        labels2[i].Content = a.цена + "р.";
                        labels3[i].Content = a.id;
                        i++;
                    }
                    ccc++;
                }
                Tovary(id_category);
                ccount = ccount + 8;
            }
            first = false;
            second = false;
        }

        private void DockPanel_MouseEnter(object sender, RoutedEventArgs e) //открытие товара
        {
            try
            {
                System.Windows.Controls.Button b = (sender as System.Windows.Controls.Button);
                int id_p = Convert.ToInt32(labels3[Convert.ToInt32(b.Name[b.Name.Length - 1].ToString()) - 1].Content);
                if (id_p != 0)
                {
                    var add_product = (from p in dc.Products where p.id == id_p select p).Single();
                    Product_form product = new Product_form(add_product.id, ID_seller);
                    product.Show();
                    dc.SubmitChanges();

                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Back_GotFocus_1(object sender, RoutedEventArgs e)
        {


        }

        private void Next_GotFocus(object sender, RoutedEventArgs e)
        {
            second = true;
        }

        private void ButtonMain1_Click_1(object sender, RoutedEventArgs e) //добавление в избранное
        {
            System.Windows.Controls.Button b = (sender as System.Windows.Controls.Button);


            int id_p = Convert.ToInt32(labels3[Convert.ToInt32(b.Name[b.Name.Length - 1].ToString()) - 1].Content);
            var add_product = (from p in dc.Products where p.id == id_p select p).Single();
            //Label[] l = new Label[] {idi1, idi2, idi3, idi4, idi5, idi6, idi7, idi8, idi9, idi10, idi11, idi12, idi13, idi14, idi15, idi16 };
            System.Windows.Controls.Button[] but_add = new System.Windows.Controls.Button[] { ButtonMai1, ButtonMai2, ButtonMai3, ButtonMai4, ButtonMai5, ButtonMai6, ButtonMai7, ButtonMai8 };
            but_add[Convert.ToInt32(b.Name[b.Name.Length - 1].ToString()) - 1].Visibility = Visibility.Visible;

            products1.Add(add_product);

        }

        private void ButtonMai1_Click(object sender, RoutedEventArgs e)//удаление из избранного
        {
            System.Windows.Controls.Button b = (sender as System.Windows.Controls.Button);

            int id_p = Convert.ToInt32(labels3[Convert.ToInt32((sender as System.Windows.Controls.Button).Name[(sender as System.Windows.Controls.Button).Name.Length - 1].ToString()) - 1].Content);
            var add_product = (from p in dc.Products where p.id == id_p select p).Single();

            System.Windows.Controls.Button[] but_add = new System.Windows.Controls.Button[] { ButtonMain1, ButtonMain2, ButtonMain3, ButtonMain4, ButtonMain5, ButtonMain6, ButtonMain7, ButtonMain8 };
            but_add[Convert.ToInt32(b.Name[b.Name.Length - 1].ToString()) - 1].Visibility = Visibility.Visible;
            System.Windows.Controls.Button[] but_add1 = new System.Windows.Controls.Button[] { ButtonMai1, ButtonMai2, ButtonMai3, ButtonMai4, ButtonMai5, ButtonMai6, ButtonMai7, ButtonMai8 };
            but_add1[Convert.ToInt32(b.Name[b.Name.Length - 1].ToString()) - 1].Visibility = Visibility.Hidden;

            products1.Remove(add_product);
        }

        private void Customers_SelectionChanged(object sender, SelectionChangedEventArgs e) //выбор покупателя и начисление ему скидки
        {
            try
            {
                if (Customers.SelectedItem != null)
                {
                    string customer_fio = Customers.SelectedItem.ToString();
                    string[] str = customer_fio.Split(' ');

                    var customer = (from c in dc.Customers where c.surname == str[0] where c.name == str[1] where c.patronymic == str[2] select c).Single();

                    DateTime now = DateTime.Now;
                    DateTime birth = Convert.ToDateTime(customer.birthday);
                    //начисление скидки в день рождение
                    double discount = 0;
                    if (now.Day == birth.Day & now.Month == birth.Month)
                    {
                        System.Windows.MessageBox.Show("Начислена скидка в честь дня рождения покупателя");
                        discount = cost1 - (cost1 * 10) / 100;
                        Discount.Content = "10 %";
                        sum.Text = discount.ToString() + " p.";
                    }
                    else
                    {
                        int s = 0;
                        var pur = from pu in dc.Purchases where pu.customer_id == customer.id select pu;
                        foreach (var pp in pur)
                        {
                            s += pp.cost;
                        }
                        if (s >= 1000)
                        {
                            System.Windows.MessageBox.Show("Начислена скидка по совершению покупок на общую сумма более 1000");
                            discount = cost1 - (cost1 * 10) / 100;
                            Discount.Content = "10 %";
                            sum.Text = discount.ToString() + " p.";
                        }
                        else if (s >= 2000)
                        {
                            System.Windows.MessageBox.Show("Начислена скидка по совершению покупок на общую сумма более 2000");
                            discount = cost1 - (cost1 * 20) / 100;
                            Discount.Content = "10 %";
                            sum.Text = discount.ToString() + " p.";
                        }
                        else if (s >= 3000)
                        {
                            System.Windows.MessageBox.Show("Начислена скидка по совершению покупок на общую сумма более 3000");
                            discount = cost1 - (cost1 * 30) / 100;
                            Discount.Content = "10 %";
                            sum.Text = discount.ToString() + " p.";
                        }
                        else
                        {
                            sum.Text = cost1.ToString() + " p.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        
        private void Button_Click_4(object sender, RoutedEventArgs e) //вызов окна для добавления нового покупателя
        {
            white.Background = new SolidColorBrush(Colors.WhiteSmoke);
            white.Opacity = 0.5;
            AddCustomer cust = new AddCustomer();
            cust.ShowDialog();
            white.Background = new SolidColorBrush(Colors.Transparent);
            white.Opacity = 1;

            Customers.Items.Clear();
            var customers = from cus in dc.Customers select cus; //вывод существующих покупателей
            foreach (var c in customers)
            {
                string fullname = c.surname.Trim() + " " + c.name.Trim() + " " + c.patronymic.Trim();
                Customers.Items.Add(fullname);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string[] s;
            int d = 0;
            if (Discount.Content == null)
                d = 0;
            else
            {
                s = Discount.Content.ToString().Split(' ');
                d = Convert.ToInt32(s[0]);
            }

            string customer_fio = Customers.SelectedItem.ToString();
            string[] str = customer_fio.Split(' ');

            var customer = (from c in dc.Customers where c.surname == str[0] where c.name == str[1] where c.patronymic == str[2] select c).Single();

            foreach (var prod in products1)
            {
                Purchases purchas = new Purchases() { date = DateTime.Now, product_id = prod.id, seller_id = ID_seller, discount = d, cost = prod.cost, customer_id = customer.id };
                dc.Purchases.InsertOnSubmit(purchas);
                dc.SubmitChanges();
            }
            System.Windows.MessageBox.Show("Закaз оформлен");


            exportWord.Application app = new exportWord.Application();
            Document doc = app.Documents.Add();
            Range r = doc.Range();
            int rows = products1.Count + 7;
            exportWord.Table t = doc.Tables.Add(r, rows, 7);
            // t.Borders.Enable = 1;
            t.AllowAutoFit = true;

            foreach (Row row in t.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    if (cell.RowIndex == 1 & cell.ColumnIndex == 3)
                    {
                        cell.Range.Text = "JewerelyStore";
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    }
                    if (cell.RowIndex == 2 & cell.ColumnIndex == 3)
                    {
                        cell.Range.Text = "Товарный чек от " + DateTime.Now.ToString("d");
                        cell.Range.Bold = 20;
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    }
                    if (cell.RowIndex == 3 & cell.ColumnIndex == 1)
                    {
                        cell.Range.Text = "№";
                        cell.Column.AutoFit();
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }
                    if (cell.RowIndex == 3 & cell.ColumnIndex == 2)
                    {
                        cell.Range.Text = "Наименование";
                        cell.Column.AutoFit();
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }
                    if (cell.RowIndex == 3 & cell.ColumnIndex == 3)
                    {
                        cell.Range.Text = "Материал";
                        cell.Column.AutoFit();
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }
                    if (cell.RowIndex == 3 & cell.ColumnIndex == 4)
                    {
                        cell.Range.Text = "Вес";
                        cell.Column.AutoFit();
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }
                    if (cell.RowIndex == 3 & cell.ColumnIndex == 5)
                    {
                        cell.Range.Text = "Цена";
                        cell.Column.AutoFit();
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }

                }
            }
            Products[] p = products1.ToArray();
            int k = 0;
            int l = k;
            for (int i = 4; i < t.Rows.Count; i++)
            {
                if (k < p.Length)
                {
                    for (int j = 0; j < t.Columns.Count; j++)
                    {
                        l = k;
                        if (j == 1)
                        {
                            l++;
                            t.Cell(i, j).Range.Text = l.ToString();
                        }
                        if (j == 2)
                        {
                            t.Cell(i, j).Range.Text = p[k].title.ToString();
                        }
                        if (j == 3)
                        {
                            t.Cell(i, j).Range.Text = p[k].material.ToString();
                        }
                        if (j == 4)
                        {
                            t.Cell(i, j).Range.Text = p[k].weight.ToString();
                        }
                        if (j == 5)
                        {
                            t.Cell(i, j).Range.Text = p[k].cost.ToString();
                        }
                        t.Cell(i, j).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;


                    }
                    k++;
                }
                else break;
                t.Cell(i + 1, 1).Range.Text = "Всего: ";
                t.Cell(i + 1, 2).Range.Text = allcost.Content.ToString();
                t.Cell(i + 1, 3).Range.Text = " ";
                t.Cell(i + 2, 1).Range.Text = "Со скидкой: ";
                t.Cell(i + 2, 2).Range.Text = sum.Text.ToString();
                t.Cell(i + 2, 3).Range.Text = " ";
                t.Cell(i + 3, 1).Range.Text = "Продавец: ";
                t.Cell(i + 3, 2).Range.Text = Selller_lable.Content.ToString();
                t.Cell(i + 3, 3).Range.Text = "__________________";
                t.Cell(i + 4, 1).Range.Text = "Покупатель: ";
                t.Cell(i + 4, 2).Range.Text = Customers.Text.ToString();
                t.Cell(i + 4, 3).Range.Text = "__________________";
            }

            app.Visible = true;

        }  //печать документа

        private void Button_Click_1(object sender, RoutedEventArgs e) //вызов окна добавления товара
        {
            Product_form p = new Product_form(0, ID_seller);
            p.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Form1 r = new Form1();
            r.ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Form2 r = new Form2();
            r.ShowDialog();
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)//выборка все
        {
            ccount = 0;
            id_category = 0;
            Tovary(0);
        }

        private void TreeViewItem_MouseDoubleClick_1(object sender, MouseButtonEventArgs e) //выборка кольца
        {
            ccount = 0;
            id_category = 1;
            Tovary(1);
        }

        private void TreeViewItem_MouseDoubleClick_2(object sender, MouseButtonEventArgs e) //выбока серьги
        {
            ccount = 0;
            id_category = 2;
            Tovary(2);
        }

        private void TreeViewItem_MouseDoubleClick_3(object sender, MouseButtonEventArgs e) //выборка браслеты
        {
            ccount = 0;
            id_category = 4;
            Tovary(4);
        }

        private void TreeViewItem_MouseDoubleClick_4(object sender, MouseButtonEventArgs e) //выборка подвески
        {
            ccount = 0;
            id_category = 5;
            Tovary(5);
        }

        private void TreeViewItem_MouseDoubleClick_5(object sender, MouseButtonEventArgs e) //выборка цепи
        {
            ccount = 0;
            id_category = 6;
            Tovary(6);
        }

        private void TreeViewItem_MouseDoubleClick_6(object sender, MouseButtonEventArgs e) //выборка пирсинк
        {
            ccount = 0;
            id_category = 7;
            Tovary(7);
        }

        private void TreeViewItem_MouseDoubleClick_7(object sender, MouseButtonEventArgs e) //справка
        {
            string s = "file://c:\\ссс.chm";
            System.Windows.Forms.Help.ShowHelp(null, s);
        }

        private void TreeViewItem_MouseDoubleClick_8(object sender, MouseButtonEventArgs e)//вывод серебряных изделий
        {
            grids = new Grid[] { Grid1, Grid2, Grid3, Grid4, Grid5, Grid6, Grid7, Grid8 };
            images = new Image[] { Receiver1, Receiver2, Receiver3, Receiver4, Receiver5, Receiver6, Receiver7, Receiver8 };
            labels1 = new System.Windows.Controls.Label[] { LabelName1, LabelName2, LabelName3, LabelName4, LabelName5, LabelName6, LabelName7, LabelName8 };
            labels2 = new System.Windows.Controls.Label[] { LabelGanreName1, LabelGanreName2, LabelGanreName3, LabelGanreName4, LabelGanreName5, LabelGanreName6, LabelGanreName7, LabelGanreName8 };
            labels3 = new System.Windows.Controls.Label[] { idi1, idi2, idi3, idi4, idi5, idi6, idi7, idi8 };

            System.Windows.Controls.Button[] but_add = new System.Windows.Controls.Button[] { ButtonMain1, ButtonMain2, ButtonMain3, ButtonMain4, ButtonMain5, ButtonMain6, ButtonMain7, ButtonMain8 };
            System.Windows.Controls.Button[] but_add1 = new System.Windows.Controls.Button[] { ButtonMai1, ButtonMai2, ButtonMai3, ButtonMai4, ButtonMai5, ButtonMai6, ButtonMai7, ButtonMai8 };


            for (int ii = 0; ii < grids.Length; ii++)
            {
                images[ii].Source = null;
                labels1[ii].Content = "";
                labels2[ii].Content = "";
                labels3[ii].Content = "";
                but_add[ii].Visibility = Visibility.Visible;
                but_add1[ii].Visibility = Visibility.Hidden;
            }

            if (id_category == 0)
            {
                var products = (from p in dc.Products.AsEnumerable()
                                where p.material.Trim() == "Серебро"
                                join g in dc.Gallery.AsEnumerable()
                                on p.id equals g.id_product
                                where g.id_productPhoto == 1
                                select new
                                {
                                    фото = g.photo,
                                    название = p.title,
                                    цена = p.cost,
                                    id = p.id,
                                    категория = p.category_id
                                });
                int count = products.Count();
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                if (count > 8)
                {
                    count = 8;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var ph in products)
                {
                    if (ccc < ccount + 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(ph.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        if (!(i >= 8))
                        {
                            images[i].Source = image;
                            labels1[i].Content = ph.название;
                            labels2[i].Content = ph.цена + "р.";
                            labels3[i].Content = ph.id;
                            i++;
                        }
                    }
                    ccc++;
                }
                ccount = ccount + 8;
            }
            else
            {
                var products = (from p in dc.Products.AsEnumerable()
                                where p.material.Trim() == "Серебро"
                                join g in dc.Gallery.AsEnumerable()
                                on p.id equals g.id_product
                                where g.id_productPhoto == 1
                                join cat in dc.Categories.AsEnumerable()
                                on p.category_id equals cat.id
                                where cat.id == id_category
                                select new
                                {
                                    фото = g.photo,
                                    название = p.title,
                                    цена = p.cost,
                                    id = p.id,
                                    категория = p.category_id
                                });
                int count = products.Count();
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                if (count > 8)
                {
                    count = 8;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var ph in products)
                {
                    if (ccc < ccount + 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(ph.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        if (!(i >= 8))
                        {
                            images[i].Source = image;
                            labels1[i].Content = ph.название;
                            labels2[i].Content = ph.цена + "р.";
                            labels3[i].Content = ph.id;
                            i++;
                        }
                    }
                    ccc++;
                }
                ccount = ccount + 8;
            }
        } 

        private void TreeViewItem_MouseDoubleClick_9(object sender, MouseButtonEventArgs e)//вывод золотых изделий
        {
            grids = new Grid[] { Grid1, Grid2, Grid3, Grid4, Grid5, Grid6, Grid7, Grid8 };
            images = new Image[] { Receiver1, Receiver2, Receiver3, Receiver4, Receiver5, Receiver6, Receiver7, Receiver8 };
            labels1 = new System.Windows.Controls.Label[] { LabelName1, LabelName2, LabelName3, LabelName4, LabelName5, LabelName6, LabelName7, LabelName8 };
            labels2 = new System.Windows.Controls.Label[] { LabelGanreName1, LabelGanreName2, LabelGanreName3, LabelGanreName4, LabelGanreName5, LabelGanreName6, LabelGanreName7, LabelGanreName8 };
            labels3 = new System.Windows.Controls.Label[] { idi1, idi2, idi3, idi4, idi5, idi6, idi7, idi8 };

            System.Windows.Controls.Button[] but_add = new System.Windows.Controls.Button[] { ButtonMain1, ButtonMain2, ButtonMain3, ButtonMain4, ButtonMain5, ButtonMain6, ButtonMain7, ButtonMain8 };
            System.Windows.Controls.Button[] but_add1 = new System.Windows.Controls.Button[] { ButtonMai1, ButtonMai2, ButtonMai3, ButtonMai4, ButtonMai5, ButtonMai6, ButtonMai7, ButtonMai8 };


            for (int ii = 0; ii < grids.Length; ii++)
            {
                images[ii].Source = null;
                labels1[ii].Content = "";
                labels2[ii].Content = "";
                labels3[ii].Content = "";
                but_add[ii].Visibility = Visibility.Visible;
                but_add1[ii].Visibility = Visibility.Hidden;
            }

            if (id_category == 0)
            {
                var products = (from p in dc.Products.AsEnumerable()
                                where p.material.Trim() == "Золото"
                                join g in dc.Gallery.AsEnumerable()
                                on p.id equals g.id_product
                                where g.id_productPhoto == 1
                                select new
                                {
                                    фото = g.photo,
                                    название = p.title,
                                    цена = p.cost,
                                    id = p.id,
                                    категория = p.category_id
                                });
                int count = products.Count();
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                if (count > 8)
                {
                    count = 8;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var ph in products)
                {
                    if (ccc < ccount + 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(ph.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        if (!(i >= 8))
                        {
                            images[i].Source = image;
                            labels1[i].Content = ph.название;
                            labels2[i].Content = ph.цена + "р.";
                            labels3[i].Content = ph.id;
                            i++;
                        }
                    }
                    ccc++;
                }
                ccount = ccount + 8;
            }
            else
            {
                var products = (from p in dc.Products.AsEnumerable()
                                where p.material.Trim() == "Золото"
                                join g in dc.Gallery.AsEnumerable()
                                on p.id equals g.id_product
                                where g.id_productPhoto == 1
                                join cat in dc.Categories.AsEnumerable()
                                on p.category_id equals cat.id
                                where cat.id == id_category
                                select new
                                {
                                    фото = g.photo,
                                    название = p.title,
                                    цена = p.cost,
                                    id = p.id,
                                    категория = p.category_id
                                });
                int count = products.Count();
                int i = 0;
                for (int j = 0; j < 8; j++)
                {
                    grids[j].Visibility = Visibility.Hidden;
                }
                if (count > 8)
                {
                    count = 8;
                }
                for (int j = 0; j < count; j++)
                {
                    grids[j].Visibility = Visibility.Visible;
                }
                int ccc = 0;
                foreach (var ph in products)
                {
                    if (ccc < ccount + 8)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(ph.фото.ToArray())) //выгрузка фото из бд
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        if (!(i >= 8))
                        {
                            images[i].Source = image;
                            labels1[i].Content = ph.название;
                            labels2[i].Content = ph.цена + "р.";
                            labels3[i].Content = ph.id;
                            i++;
                        }
                    }
                    ccc++;
                }
                ccount = ccount + 8;
            }
        }
    }
}