
namespace Apteka
{
    partial class RecieptsLabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProductName = new System.Windows.Forms.Label();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductName
            // 
            this.ProductName.AutoSize = true;
            this.ProductName.BackColor = System.Drawing.Color.Transparent;
            this.ProductName.Font = new System.Drawing.Font("Verdana", 20F);
            this.ProductName.Location = new System.Drawing.Point(46, 27);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(201, 32);
            this.ProductName.TabIndex = 15;
            this.ProductName.Text = "Назва товару";
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.CodeLabel.Font = new System.Drawing.Font("Verdana", 20F);
            this.CodeLabel.Location = new System.Drawing.Point(320, 27);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(171, 32);
            this.CodeLabel.TabIndex = 16;
            this.CodeLabel.Text = "Код товару";
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.BackColor = System.Drawing.Color.Transparent;
            this.CostLabel.Font = new System.Drawing.Font("Verdana", 20F);
            this.CostLabel.Location = new System.Drawing.Point(762, 27);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(76, 32);
            this.CostLabel.TabIndex = 17;
            this.CostLabel.Text = "Ціна";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.BackColor = System.Drawing.Color.Transparent;
            this.CountLabel.Font = new System.Drawing.Font("Verdana", 20F);
            this.CountLabel.Location = new System.Drawing.Point(551, 27);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(138, 32);
            this.CountLabel.TabIndex = 18;
            this.CountLabel.Text = "Кількість";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Verdana", 50F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, -11);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.MaximumSize = new System.Drawing.Size(50, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 80);
            this.label4.TabIndex = 19;
            this.label4.Text = "+";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.label4);
            this.kryptonPanel1.Location = new System.Drawing.Point(911, 13);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(65, 65);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.LimeGreen;
            this.kryptonPanel1.TabIndex = 20;
            this.kryptonPanel1.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.label5);
            this.kryptonPanel2.Location = new System.Drawing.Point(1016, 13);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(60, 65);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.Tomato;
            this.kryptonPanel2.TabIndex = 21;
            this.kryptonPanel2.Click += new System.EventHandler(this.decrementButton_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Verdana", 50F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, -11);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.MaximumSize = new System.Drawing.Size(50, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 80);
            this.label5.TabIndex = 19;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.decrementButton_Click);
            // 
            // RecieptsLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.CostLabel);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.CodeLabel);
            this.Controls.Add(this.CountLabel);
            this.Name = "RecieptsLabel";
            this.Size = new System.Drawing.Size(1125, 93);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductName;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.Label label5;
    }
}
