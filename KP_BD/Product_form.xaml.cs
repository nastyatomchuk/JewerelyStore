using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KP_BD
{
    /// <summary>
    /// Логика взаимодействия для Product_form.xaml
    /// </summary>
    public partial class Product_form : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        private int id_product;
        private int id_category;
        private int id_sell;
        private System.Windows.Controls.Image[] images;

        public Product_form(int id2, int isel)
        {
            id_sell = isel;

            InitializeComponent();
            
            if (id2 == 0)
            {
                button1.Content = "Добавить";
            }
            else
            {
                button1.Content = "Сохранить";
                id_product = id2;

                var kolzo = (from h in dc.Products.AsEnumerable()
                             where h.id == id2
                             select new
                             {
                                 id = h.id,
                                 Нзавние = h.title,
                                 Материал = h.material,
                                 Вес = h.weight,
                                 Вставки = h.inserts,
                                 Артикул = h.vendor_code,
                                 Проба = h.sample,
                                 Цена = h.cost,
                                 Размер = h.size,
                                 кат = h.category_id
                             }).Single();

                images = new System.Windows.Controls.Image[] { image1, image2, image3 };
                var phot = (from g in dc.Gallery.AsEnumerable() where g.id_product == id_product select g);
                int k = 0;
                foreach (var ph in phot)
                {

                    var image = new BitmapImage();
                    using (var mem = new MemoryStream(ph.photo.ToArray()))
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
                    images[k].Source = image;
                    k++;
                }


                title.Text = kolzo.Нзавние.Trim();
                weight.Text = kolzo.Вес.ToString().Trim();


                var cat = (from ca in dc.Categories where ca.id == kolzo.кат select ca).Single();

                category.Text = cat.name.Trim();

                if (kolzo.Материал.Trim() == "Серебро")
                    material.Text = "Серебро";
                else material.Text = "Золото";

                if (kolzo.Вставки == true)
                    inserts.IsChecked = true;
                else inserts.IsChecked = false;
                sample.Text = kolzo.Проба.ToString().Trim();
                ventor_code.Text = kolzo.Артикул.ToString().Trim();
                cost.Text = kolzo.Цена.ToString().Trim();
                size.Text = kolzo.Размер.ToString().Trim();
            }
        }

        private void image1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog(); //загрузка фото на форму
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            BitmapImage im;
            if (openDialog.ShowDialog() == true)
            {
                im = new BitmapImage(new Uri(openDialog.FileName));
                image1.Source = im;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult s = MessageBox.Show("Товар будет безвозвратно удален", "Удаление", MessageBoxButton.OK);
            if (s == MessageBoxResult.OK)
            {
                

                int category_id = id_category;
                var k = dc.Products.Single(x => x.id == Convert.ToInt32(id_product));

                var gal = from g in dc.Gallery where g.id_product == id_product select g;

                foreach (var g in gal)
                {
                    dc.Gallery.DeleteOnSubmit(g);
                    dc.SubmitChanges();
                }

                dc.Products.DeleteOnSubmit(k);
                dc.SubmitChanges();

                MainAccount ma = new MainAccount(id_sell);
                ma.Show();
                this.Close();
            }
            else
            {
                
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            //валидация полей  
            {
                if (title.Text == "")
                {
                    title.ToolTip = "Заполните поле";
                    title.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (title.Text != "")
                {
                    title.ToolTip = "";
                    title.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
                if (cost.Text == "")
                {
                    cost.ToolTip = "Заполните поле";
                    cost.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (cost.Text != "")
                {
                    cost.ToolTip = "";
                    cost.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
                if (material.Text == "")
                {
                    material.ToolTip = "Заполните поле";
                    material.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (material.Text != "")
                {
                    material.ToolTip = "";
                    material.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
                if (ventor_code.Text == "")
                {
                    ventor_code.ToolTip = "Заполните поле";
                    ventor_code.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (ventor_code.Text != "")
                {
                    ventor_code.ToolTip = "";
                    ventor_code.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
                if (sample.Text == "")
                {
                    sample.ToolTip = "Заполните поле";
                    sample.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (sample.Text != "")
                {
                    sample.ToolTip = "";
                    sample.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
                if (weight.Text == "")
                {
                    weight.ToolTip = "Заполните поле";
                    weight.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (weight.Text != "")
                {
                    weight.ToolTip = "";
                    weight.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
                if (size.Text == "")
                {
                    size.ToolTip = "Заполните поле";
                    size.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (size.Text != "")
                {
                    size.ToolTip = "";
                    size.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
                if (category.Text == "")
                {
                    category.ToolTip = "Заполните поле";
                    category.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                else if (category.Text != "")
                {
                    category.ToolTip = "";
                    category.BorderBrush = System.Windows.Media.Brushes.Transparent;
                    flag = true;
                }
            }
            if (flag == true)
            {
                try
                {
                    string t = title.Text.Trim();
                    string m = material.Text.Trim();
                    double w = int.Parse(weight.Text.Trim());
                    bool i;
                    if (inserts.IsChecked == true)
                        i = true;
                    else
                        i = false;
                    string vc = ventor_code.Text.Trim();
                    int s = int.Parse(sample.Text.Trim());
                    int category_id = id_category;
                    int c = Convert.ToInt32(cost.Text.ToString().Trim());
                    int sz = Convert.ToInt32(size.Text.Trim());

                    int categiry = 0;
                    var cat = (from ca in dc.Categories where ca.name == category.Text.Trim() select ca).Single();
                    categiry = cat.id;

                    if (button1.Content == "Добавить")
                    {
                        Products product = new Products() { title = t, weight = w, material = m, inserts = i, vendor_code = vc, sample = s, category_id = categiry, cost = c, size = sz };
                        dc.Products.InsertOnSubmit(product);
                        dc.SubmitChanges();
                        images = new System.Windows.Controls.Image[] { image1, image2, image3 };
                        try
                        {
                            for (int j = 0; j < 3; j++) //загрузка фото с формы в бд
                            {
                                if (j == 0)
                                {
                                    MemoryStream stream = new MemoryStream();
                                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                                    encoder.Frames.Add(BitmapFrame.Create((BitmapImage)images[j].Source));
                                    encoder.Save(stream);
                                    Gallery g = new Gallery() { id_product = product.id, photo = stream.ToArray(), id_productPhoto = 1 };
                                    dc.Gallery.InsertOnSubmit(g);
                                    dc.SubmitChanges();
                                }
                                else
                                {
                                    MemoryStream stream = new MemoryStream();
                                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                                    encoder.Frames.Add(BitmapFrame.Create((BitmapImage)images[j].Source));
                                    encoder.Save(stream);
                                    Gallery g = new Gallery() { id_product = product.id, photo = stream.ToArray(), id_productPhoto = 0 };
                                    dc.Gallery.InsertOnSubmit(g);
                                    dc.SubmitChanges();
                                }
                            }
                            MessageBox.Show("Товар добавлен, база данных обновлена");
                            MainAccount ma = new MainAccount(id_sell);
                            ma.Show();
                            this.Close();

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Выберите 3 картинки");
                        }
                    }
                    else
                    {
                        Products f = new Products() { title = t, weight = w, material = m, inserts = i, vendor_code = vc, sample = s, category_id = categiry, cost = c, size = sz };
                        var h = (from p in dc.GetTable<Products>() where p.id == id_product select p).Single();
                        h.title = f.title;
                        h.weight = f.weight;
                        h.material = f.material;
                        h.inserts = f.inserts;
                        h.category_id=f.category_id;
                        h.vendor_code = f.vendor_code;
                        h.sample = f.sample;
                        h.cost = f.cost;
                        h.size = f.size;
                        dc.SubmitChanges();

                        var gal = (from gg in dc.GetTable<Gallery>() where gg.id_product == h.id select gg).AsEnumerable();
                        int k = 0;

                        foreach (var ga in gal)
                        {
                            MemoryStream stream = new MemoryStream();
                            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create((BitmapImage)images[k].Source));
                            encoder.Save(stream);

                            Gallery g = new Gallery() { id_product = id_product, photo = stream.ToArray() };
                            ga.photo = g.photo;
                            dc.SubmitChanges();
                            k++;
                        }

                        MessageBox.Show("Изменения сохранены, база данных обновлена");

                        MainAccount ma = new MainAccount(id_sell);
                        ma.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Неверный формат размера");
                }

            }
            else if (flag == false)
            {
                MessageBox.Show("ой, ошибка валидации полей");
            }

        }
         //хз что это\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openDialog = new OpenFileDialog();
        //    openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
        //    BitmapImage im;
        //    if (openDialog.ShowDialog() == true)
        //    {
        //        im = new BitmapImage(new Uri(openDialog.FileName));
        //        image1.Source = im;
        //    }

        //    MemoryStream stream = new MemoryStream();
        //    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create((BitmapImage)image1.Source));
        //    encoder.Save(stream);
        //    Gallery g = new Gallery() {  id_product = 2, photo = stream.ToArray() };
        //    dc.Gallery.InsertOnSubmit(g);
        //    dc.SubmitChanges();
        //}

        private void image2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image i = new System.Windows.Controls.Image();
            System.Windows.Controls.Image i2 = sender as System.Windows.Controls.Image;

            i.Source = image1.Source;
            image1.Source = i2.Source;
            i2.Source = i.Source;
        }
    }
}
