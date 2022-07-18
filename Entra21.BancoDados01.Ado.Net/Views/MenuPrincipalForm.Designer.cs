namespace Entra21.BancoDados01.Ado.Net.Views
{
    partial class MenuPrincipalForm
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
            this.buttonTiposdePersonagens = new System.Windows.Forms.Button();
            this.buttonPersonagens = new System.Windows.Forms.Button();
            this.buttonEditoras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTiposdePersonagens
            // 
            this.buttonTiposdePersonagens.Location = new System.Drawing.Point(407, 51);
            this.buttonTiposdePersonagens.Name = "buttonTiposdePersonagens";
            this.buttonTiposdePersonagens.Size = new System.Drawing.Size(186, 155);
            this.buttonTiposdePersonagens.TabIndex = 0;
            this.buttonTiposdePersonagens.Text = "Tipos de personagens";
            this.buttonTiposdePersonagens.UseVisualStyleBackColor = true;
            this.buttonTiposdePersonagens.Click += new System.EventHandler(this.buttonTiposdePersonagens_Click);
            // 
            // buttonPersonagens
            // 
            this.buttonPersonagens.Location = new System.Drawing.Point(216, 51);
            this.buttonPersonagens.Name = "buttonPersonagens";
            this.buttonPersonagens.Size = new System.Drawing.Size(185, 155);
            this.buttonPersonagens.TabIndex = 1;
            this.buttonPersonagens.Text = "Personagens";
            this.buttonPersonagens.UseVisualStyleBackColor = true;
            this.buttonPersonagens.Click += new System.EventHandler(this.buttonPersonagens_Click);
            // 
            // buttonEditoras
            // 
            this.buttonEditoras.Location = new System.Drawing.Point(12, 51);
            this.buttonEditoras.Name = "buttonEditoras";
            this.buttonEditoras.Size = new System.Drawing.Size(198, 155);
            this.buttonEditoras.TabIndex = 2;
            this.buttonEditoras.Text = "Editoras";
            this.buttonEditoras.UseVisualStyleBackColor = true;
            this.buttonEditoras.Click += new System.EventHandler(this.buttonEditoras_Click);
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 279);
            this.Controls.Add(this.buttonEditoras);
            this.Controls.Add(this.buttonPersonagens);
            this.Controls.Add(this.buttonTiposdePersonagens);
            this.Name = "MenuPrincipalForm";
            this.Text = "MenuPrincipalForm";
            this.Load += new System.EventHandler(this.MenuPrincipalForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTiposdePersonagens;
        private System.Windows.Forms.Button buttonPersonagens;
        private System.Windows.Forms.Button buttonEditoras;
    }
}