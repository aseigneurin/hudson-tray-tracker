namespace Hudson.TrayTracker.UI
{
    partial class AuthenticationTokenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationTokenForm));
            this.TokentextBox = new System.Windows.Forms.TextBox();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.projectLabel = new DevExpress.XtraEditors.LabelControl();
            this.CausetextBox = new System.Windows.Forms.TextBox();
            this.Causelabel = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TokentextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TokentextBox, 2);
            this.TokentextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TokentextBox.Location = new System.Drawing.Point(145, 44);
            this.TokentextBox.Name = "TokentextBox";
            this.TokentextBox.Size = new System.Drawing.Size(245, 21);
            this.TokentextBox.TabIndex = 6;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.Location = new System.Drawing.Point(323, 109);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(67, 23);
            this.Cancelbutton.TabIndex = 5;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKbutton.Location = new System.Drawing.Point(242, 109);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 4;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(3, 46);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(136, 17);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Authentication Token";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.projectLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TokentextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.OKbutton, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.Cancelbutton, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.CausetextBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.Causelabel, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 135);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // projectLabel
            // 
            this.projectLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.projectLabel.Appearance.Options.UseFont = true;
            this.projectLabel.Appearance.Options.UseTextOptions = true;
            this.projectLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.projectLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.projectLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.tableLayoutPanel1.SetColumnSpan(this.projectLabel, 3);
            this.projectLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectLabel.Location = new System.Drawing.Point(3, 20);
            this.projectLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 5);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(387, 16);
            this.projectLabel.TabIndex = 0;
            this.projectLabel.Text = "Project - ";
            // 
            // CausetextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CausetextBox, 2);
            this.CausetextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CausetextBox.Location = new System.Drawing.Point(145, 71);
            this.CausetextBox.Name = "CausetextBox";
            this.CausetextBox.Size = new System.Drawing.Size(245, 21);
            this.CausetextBox.TabIndex = 7;
            // 
            // Causelabel
            // 
            this.Causelabel.Appearance.Options.UseTextOptions = true;
            this.Causelabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Causelabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Causelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Causelabel.Location = new System.Drawing.Point(3, 73);
            this.Causelabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Causelabel.Name = "Causelabel";
            this.Causelabel.Size = new System.Drawing.Size(136, 17);
            this.Causelabel.TabIndex = 8;
            this.Causelabel.Text = "Cause Text (Optional)";
            // 
            // AuthenticationTokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(393, 135);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthenticationTokenForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TokentextBox;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl projectLabel;
        private System.Windows.Forms.TextBox CausetextBox;
        private DevExpress.XtraEditors.LabelControl Causelabel;


    }
}