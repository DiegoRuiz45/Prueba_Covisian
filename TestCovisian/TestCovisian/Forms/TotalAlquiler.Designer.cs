

namespace TestCovisian.Forms
{
    partial class TotalAlquiler
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
        /// 
        //private System.Windows.Forms.Label lbDiario;
        //private System.Windows.Forms.Label lbMensual;
        //private System.Windows.Forms.Timer timer;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbMensual = new System.Windows.Forms.Label();
            this.lbDiario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ALQUILERES MENSUALES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "ALQUILERES DIARIOS";
            // 
            // timer
            // 
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbMensual
            // 
            this.lbMensual.AutoSize = true;
            this.lbMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensual.Location = new System.Drawing.Point(207, 190);
            this.lbMensual.Name = "lbMensual";
            this.lbMensual.Size = new System.Drawing.Size(26, 29);
            this.lbMensual.TabIndex = 2;
            this.lbMensual.Text = "0";
            // 
            // lbDiario
            // 
            this.lbDiario.AutoSize = true;
            this.lbDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiario.Location = new System.Drawing.Point(598, 190);
            this.lbDiario.Name = "lbDiario";
            this.lbDiario.Size = new System.Drawing.Size(26, 29);
            this.lbDiario.TabIndex = 3;
            this.lbDiario.Text = "0";
            // 
            // TotalAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbDiario);
            this.Controls.Add(this.lbMensual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TotalAlquiler";
            this.Text = "TotalAlquiler";
            this.Load += new System.EventHandler(this.ClienteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbMensual;
        private System.Windows.Forms.Label lbDiario;
    }
}