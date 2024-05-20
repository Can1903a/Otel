namespace Otel
{
    partial class PersonelGiris
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
            System.Windows.Forms.PictureBox pictureboxGeri;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelGiris));
            this.PTCtxt = new System.Windows.Forms.TextBox();
            this.Psifretxt = new System.Windows.Forms.TextBox();
            this.btnPersonel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureboxGeri = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureboxGeri
            // 
            pictureboxGeri.Image = ((System.Drawing.Image)(resources.GetObject("pictureboxGeri.Image")));
            pictureboxGeri.Location = new System.Drawing.Point(12, 12);
            pictureboxGeri.Name = "pictureboxGeri";
            pictureboxGeri.Size = new System.Drawing.Size(68, 65);
            pictureboxGeri.TabIndex = 1;
            pictureboxGeri.TabStop = false;
            pictureboxGeri.Click += new System.EventHandler(this.pictureboxGeri_Click);
            // 
            // PTCtxt
            // 
            this.PTCtxt.Location = new System.Drawing.Point(189, 110);
            this.PTCtxt.Name = "PTCtxt";
            this.PTCtxt.Size = new System.Drawing.Size(120, 20);
            this.PTCtxt.TabIndex = 2;
            // 
            // Psifretxt
            // 
            this.Psifretxt.Location = new System.Drawing.Point(189, 174);
            this.Psifretxt.Name = "Psifretxt";
            this.Psifretxt.Size = new System.Drawing.Size(120, 20);
            this.Psifretxt.TabIndex = 2;
            this.Psifretxt.UseSystemPasswordChar = true;
            // 
            // btnPersonel
            // 
            this.btnPersonel.BackColor = System.Drawing.Color.SeaShell;
            this.btnPersonel.Location = new System.Drawing.Point(189, 236);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.Size = new System.Drawing.Size(120, 40);
            this.btnPersonel.TabIndex = 3;
            this.btnPersonel.Text = "Giriş Yap";
            this.btnPersonel.UseVisualStyleBackColor = false;
            this.btnPersonel.Click += new System.EventHandler(this.btnPersonel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(124, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Şifre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(124, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "TC";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Turquoise;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 334);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(494, 49);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // PersonelGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPersonel);
            this.Controls.Add(this.Psifretxt);
            this.Controls.Add(this.PTCtxt);
            this.Controls.Add(pictureboxGeri);
            this.Name = "PersonelGiris";
            this.Text = "PersonelGiris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonelGiris_FormClosing);
            this.Load += new System.EventHandler(this.PersonelGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PTCtxt;
        private System.Windows.Forms.TextBox Psifretxt;
        private System.Windows.Forms.Button btnPersonel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}