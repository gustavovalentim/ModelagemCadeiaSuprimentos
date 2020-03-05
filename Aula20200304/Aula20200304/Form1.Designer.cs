namespace Aula20200304
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOi = new System.Windows.Forms.Button();
            this.btnModelo2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOi
            // 
            this.btnOi.Location = new System.Drawing.Point(116, 58);
            this.btnOi.Name = "btnOi";
            this.btnOi.Size = new System.Drawing.Size(75, 23);
            this.btnOi.TabIndex = 0;
            this.btnOi.Text = "Oi";
            this.btnOi.UseVisualStyleBackColor = true;
            this.btnOi.Click += new System.EventHandler(this.btnOi_Click);
            // 
            // btnModelo2
            // 
            this.btnModelo2.Location = new System.Drawing.Point(116, 106);
            this.btnModelo2.Name = "btnModelo2";
            this.btnModelo2.Size = new System.Drawing.Size(75, 23);
            this.btnModelo2.TabIndex = 1;
            this.btnModelo2.Text = "Modelo2";
            this.btnModelo2.UseVisualStyleBackColor = true;
            this.btnModelo2.Click += new System.EventHandler(this.btnModelo2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnModelo2);
            this.Controls.Add(this.btnOi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOi;
        private System.Windows.Forms.Button btnModelo2;
    }
}

