
namespace KP_BD
{
    partial class Form1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CustimersAnaliseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JewerelyStoreDataSet = new KP_BD.JewerelyStoreDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CustimersAnaliseTableAdapter = new KP_BD.JewerelyStoreDataSetTableAdapters.CustimersAnaliseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CustimersAnaliseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JewerelyStoreDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CustimersAnaliseBindingSource
            // 
            this.CustimersAnaliseBindingSource.DataMember = "CustimersAnalise";
            this.CustimersAnaliseBindingSource.DataSource = this.JewerelyStoreDataSet;
            // 
            // JewerelyStoreDataSet
            // 
            this.JewerelyStoreDataSet.DataSetName = "JewerelyStoreDataSet";
            this.JewerelyStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CustimersAnaliseBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KP_BD.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1082, 585);
            this.reportViewer1.TabIndex = 0;
            // 
            // CustimersAnaliseTableAdapter
            // 
            this.CustimersAnaliseTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 585);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustimersAnaliseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JewerelyStoreDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CustimersAnaliseBindingSource;
        private JewerelyStoreDataSet JewerelyStoreDataSet;
        private JewerelyStoreDataSetTableAdapters.CustimersAnaliseTableAdapter CustimersAnaliseTableAdapter;
    }
}