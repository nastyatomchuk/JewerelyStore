using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_BD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "jewerelyStoreDataSet.CustimersAnalise". При необходимости она может быть перемещена или удалена.
            this.CustimersAnaliseTableAdapter.Fill(this.jewerelyStoreDataSet.CustimersAnalise);

            this.reportViewer1.RefreshReport();
        }
    }
}
