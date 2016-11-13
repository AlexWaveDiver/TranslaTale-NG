namespace TranslaTale_NG
{
    partial class frmProjectManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectManager));
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenPrj = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lsvProjects = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(50, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(625, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Manager";
            // 
            // btnOpenPrj
            // 
            this.btnOpenPrj.Location = new System.Drawing.Point(27, 105);
            this.btnOpenPrj.Name = "btnOpenPrj";
            this.btnOpenPrj.Size = new System.Drawing.Size(69, 23);
            this.btnOpenPrj.TabIndex = 1;
            this.btnOpenPrj.Text = "&Open";
            this.btnOpenPrj.UseVisualStyleBackColor = true;
            this.btnOpenPrj.Click += new System.EventHandler(this.btnOpenPrj_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(27, 76);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(69, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lsvProjects
            // 
            this.lsvProjects.Location = new System.Drawing.Point(140, 75);
            this.lsvProjects.Name = "lsvProjects";
            this.lsvProjects.Size = new System.Drawing.Size(288, 149);
            this.lsvProjects.TabIndex = 6;
            this.lsvProjects.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Project Info";
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.pbIcon.Image = global::TranslaTale_NG.Properties.Resources.ttnew_small;
            this.pbIcon.Location = new System.Drawing.Point(5, 6);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(49, 50);
            this.pbIcon.TabIndex = 8;
            this.pbIcon.TabStop = false;
            // 
            // frmProjectManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 378);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsvProjects);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnOpenPrj);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmProjectManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Manager";
            this.Load += new System.EventHandler(this.frmProjectManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenPrj;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lsvProjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbIcon;

    }
}

