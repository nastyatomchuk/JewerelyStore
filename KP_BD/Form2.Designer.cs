
namespace KP_BD
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.jewerelyStoreDataSet1 = new KP_BD.JewerelyStoreDataSet1();
            this.jewerelyStoreDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jewerelyStoreDataSet = new KP_BD.JewerelyStoreDataSet();
            this.jewerelyStoreDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustimersAnaliseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustimersAnaliseTableAdapter = new KP_BD.JewerelyStoreDataSetTableAdapters.CustimersAnaliseTableAdapter();
            this.jewerelyStoreDataSet11 = new KP_BD.JewerelyStoreDataSet1();
            this.jewerelyStoreDataSet11BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustimersAnaliseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet11BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.CustimersAnaliseBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KP_BD.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // jewerelyStoreDataSet1
            // 
            this.jewerelyStoreDataSet1.DataSetName = "JewerelyStoreDataSet1";
            this.jewerelyStoreDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jewerelyStoreDataSet1BindingSource
            // 
            this.jewerelyStoreDataSet1BindingSource.DataSource = this.jewerelyStoreDataSet1;
            this.jewerelyStoreDataSet1BindingSource.Position = 0;
            // 
            // jewerelyStoreDataSet
            // 
            this.jewerelyStoreDataSet.DataSetName = "JewerelyStoreDataSet";
            this.jewerelyStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jewerelyStoreDataSetBindingSource
            // 
            this.jewerelyStoreDataSetBindingSource.DataSource = this.jewerelyStoreDataSet;
            this.jewerelyStoreDataSetBindingSource.Position = 0;
            // 
            // CustimersAnaliseBindingSource
            // 
            this.CustimersAnaliseBindingSource.DataMember = "CustimersAnalise";
            this.CustimersAnaliseBindingSource.DataSource = this.jewerelyStoreDataSet;
            // 
            // CustimersAnaliseTableAdapter
            // 
            this.CustimersAnaliseTableAdapter.ClearBeforeFill = true;
            // 
            // jewerelyStoreDataSet11
            // 
            this.jewerelyStoreDataSet11.DataSetName = "JewerelyStoreDataSet1";
            this.jewerelyStoreDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jewerelyStoreDataSet11BindingSource
            // 
            this.jewerelyStoreDataSet11BindingSource.DataSource = this.jewerelyStoreDataSet11;
            this.jewerelyStoreDataSet11BindingSource.Position = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustimersAnaliseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jewerelyStoreDataSet11BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource jewerelyStoreDataSet1BindingSource;
        private JewerelyStoreDataSet1 jewerelyStoreDataSet1;
        private System.Windows.Forms.BindingSource jewerelyStoreDataSetBindingSource;
        private JewerelyStoreDataSet jewerelyStoreDataSet;
        private System.Windows.Forms.BindingSource CustimersAnaliseBindingSource;
        private JewerelyStoreDataSetTableAdapters.CustimersAnaliseTableAdapter CustimersAnaliseTableAdapter;
        private System.Windows.Forms.BindingSource jewerelyStoreDataSet11BindingSource;
        private JewerelyStoreDataSet1 jewerelyStoreDataSet11;
    }
}