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
            pictureboxGeri = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).BeginInit();
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
            // 
            // PTCtxt
            // 
            this.PTCtxt.Location = new System.Drawing.Point(318, 121);
            this.PTCtxt.Name = "PTCtxt";
            this.PTCtxt.Size = new System.Drawing.Size(100, 20);
            this.PTCtxt.TabIndex = 2;
            // 
            // Psifretxt
            // 
            this.Psifretxt.Location = new System.Drawing.Point(318, 191);
            this.Psifretxt.Name = "Psifretxt";
            this.Psifretxt.Size = new System.Drawing.Size(100, 20);
            this.Psifretxt.TabIndex = 2;
            // 
            // btnPersonel
            // 
            this.btnPersonel.Location = new System.Drawing.Point(318, 266);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.Size = new System.Drawing.Size(100, 23);
            this.btnPersonel.TabIndex = 3;
            this.btnPersonel.Text = "button1";
            this.btnPersonel.UseVisualStyleBackColor = true;
            this.btnPersonel.Click += new System.EventHandler(this.btnPersonel_Click);
            // 
            // PersonelGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPersonel);
            this.Controls.Add(this.Psifretxt);
            this.Controls.Add(this.PTCtxt);
            this.Controls.Add(pictureboxGeri);
            this.Name = "PersonelGiris";
            this.Text = "PersonelGiris";
            this.Load += new System.EventHandler(this.PersonelGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureboxGeri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PTCtxt;
        private System.Windows.Forms.TextBox Psifretxt;
        private System.Windows.Forms.Button btnPersonel;
    }
}