namespace PathFindingSystem
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tamanhoDoGrid = new System.Windows.Forms.TextBox();
            this.medidorPassos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reiniciar PathFinding";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("LcdD", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bem-vindo ao PathFinding System";
            // 
            // tamanhoDoGrid
            // 
            this.tamanhoDoGrid.Location = new System.Drawing.Point(27, 165);
            this.tamanhoDoGrid.Name = "tamanhoDoGrid";
            this.tamanhoDoGrid.Size = new System.Drawing.Size(100, 20);
            this.tamanhoDoGrid.TabIndex = 2;
            this.tamanhoDoGrid.Text = "Digite aqui o tamanho do grid";
            // 
            // medidorPassos
            // 
            this.medidorPassos.AutoSize = true;
            this.medidorPassos.Font = new System.Drawing.Font("LcdD", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medidorPassos.Location = new System.Drawing.Point(32, 215);
            this.medidorPassos.Name = "medidorPassos";
            this.medidorPassos.Size = new System.Drawing.Size(64, 20);
            this.medidorPassos.TabIndex = 3;
            this.medidorPassos.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("LcdD", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 64);
            this.label2.TabIndex = 4;
            this.label2.Text = "Clique nos quadrados \r\npara criar obstáculos\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 364);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.medidorPassos);
            this.Controls.Add(this.tamanhoDoGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.update);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.draw);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameClickManager);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tamanhoDoGrid;
        private System.Windows.Forms.Label medidorPassos;
        private System.Windows.Forms.Label label2;
    }
}

