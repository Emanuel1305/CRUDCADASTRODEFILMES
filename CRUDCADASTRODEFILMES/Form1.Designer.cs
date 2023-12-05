namespace CRUDCADASTRODEFILMES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilmes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeries = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBlibioteca = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFilmesB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeriesB = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastros,
            this.MenuBlibioteca,
            this.MenuSair});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MenuPrincipal.Size = new System.Drawing.Size(933, 24);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuCadastros
            // 
            this.MenuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilmes,
            this.MenuSeries,
            this.MenuUsuarios});
            this.MenuCadastros.Name = "MenuCadastros";
            this.MenuCadastros.Size = new System.Drawing.Size(71, 20);
            this.MenuCadastros.Text = "Cadastros";
            // 
            // MenuFilmes
            // 
            this.MenuFilmes.Name = "MenuFilmes";
            this.MenuFilmes.Size = new System.Drawing.Size(180, 22);
            this.MenuFilmes.Text = "Filmes";
            this.MenuFilmes.Click += new System.EventHandler(this.MenuFilmes_Click);
            // 
            // MenuSeries
            // 
            this.MenuSeries.Name = "MenuSeries";
            this.MenuSeries.Size = new System.Drawing.Size(180, 22);
            this.MenuSeries.Text = "Séries";
            this.MenuSeries.Click += new System.EventHandler(this.MenuSeries_Click);
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(180, 22);
            this.MenuUsuarios.Text = "Usuários";
            this.MenuUsuarios.Click += new System.EventHandler(this.MenuUsuarios_Click);
            // 
            // MenuBlibioteca
            // 
            this.MenuBlibioteca.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFilmesB,
            this.MenuSeriesB});
            this.MenuBlibioteca.Name = "MenuBlibioteca";
            this.MenuBlibioteca.Size = new System.Drawing.Size(71, 20);
            this.MenuBlibioteca.Text = "Biblioteca";
            // 
            // MenuFilmesB
            // 
            this.MenuFilmesB.Name = "MenuFilmesB";
            this.MenuFilmesB.Size = new System.Drawing.Size(180, 22);
            this.MenuFilmesB.Text = "Filmes";
            this.MenuFilmesB.Click += new System.EventHandler(this.MenuFilmesB_Click);
            // 
            // MenuSeriesB
            // 
            this.MenuSeriesB.Name = "MenuSeriesB";
            this.MenuSeriesB.Size = new System.Drawing.Size(180, 22);
            this.MenuSeriesB.Text = "Séries";
            this.MenuSeriesB.Click += new System.EventHandler(this.MenuSeriesB_Click);
            // 
            // MenuSair
            // 
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(38, 20);
            this.MenuSair.Text = "Sair";
            this.MenuSair.Click += new System.EventHandler(this.MenuSair_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CRUDCADASTRODEFILMES.Properties.Resources.fundoinicial;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(945, 486);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Georgia", 70F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(85, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 324);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro\nFilmes\r\nSéries\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(933, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuPrincipal);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro De Filmes e Séries";
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastros;
        private System.Windows.Forms.ToolStripMenuItem MenuFilmes;
        private System.Windows.Forms.ToolStripMenuItem MenuSeries;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.ToolStripMenuItem MenuBlibioteca;
        private System.Windows.Forms.ToolStripMenuItem MenuFilmesB;
        private System.Windows.Forms.ToolStripMenuItem MenuSeriesB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

