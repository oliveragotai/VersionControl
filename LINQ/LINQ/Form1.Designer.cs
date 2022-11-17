
namespace LINQ
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
            this.listCountries = new System.Windows.Forms.ListBox();
            this.txtCountryFilter = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listCountries
            // 
            this.listCountries.FormattingEnabled = true;
            this.listCountries.Location = new System.Drawing.Point(12, 38);
            this.listCountries.Name = "listCountries";
            this.listCountries.Size = new System.Drawing.Size(262, 485);
            this.listCountries.TabIndex = 0;
            this.listCountries.SelectedIndexChanged += new System.EventHandler(this.listCountries_SelectedIndexChanged);
            // 
            // txtCountryFilter
            // 
            this.txtCountryFilter.Location = new System.Drawing.Point(13, 13);
            this.txtCountryFilter.Name = "txtCountryFilter";
            this.txtCountryFilter.Size = new System.Drawing.Size(261, 20);
            this.txtCountryFilter.TabIndex = 1;
            this.txtCountryFilter.TextChanged += new System.EventHandler(this.txtCountryFilter_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(280, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 485);
            this.dataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 535);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtCountryFilter);
            this.Controls.Add(this.listCountries);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listCountries;
        private System.Windows.Forms.TextBox txtCountryFilter;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

