
namespace Apteka
{
    partial class ProductsLayoutInList
    {
        public string PRoductName
        {
            get { return productName.Text; }
            set { productName.Text = value; }
        }

        public string ProductCode
        {
            get { return productCode.Text; }
            set { productCode.Text = value; }
        }

        public string ProductCost
        {
            get { return productCost.Text; }
            set { productCost.Text = value; }
        }
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
            this.ProductDataHolder = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.NotinStockLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.AddToRecieptButton = new System.Windows.Forms.Label();
            this.MinusPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.productName = new System.Windows.Forms.Label();
            this.PlusPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.productCost = new System.Windows.Forms.Label();
            this.productCode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataHolder.Panel)).BeginInit();
            this.ProductDataHolder.Panel.SuspendLayout();
            this.ProductDataHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinusPanel)).BeginInit();
            this.MinusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlusPanel)).BeginInit();
            this.PlusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductDataHolder
            // 
            this.ProductDataHolder.Location = new System.Drawing.Point(0, 0);
            this.ProductDataHolder.Name = "ProductDataHolder";
            // 
            // ProductDataHolder.Panel
            // 
            this.ProductDataHolder.Panel.Controls.Add(this.NotinStockLabel);
            this.ProductDataHolder.Panel.Controls.Add(this.CountLabel);
            this.ProductDataHolder.Panel.Controls.Add(this.AddToRecieptButton);
            this.ProductDataHolder.Panel.Controls.Add(this.MinusPanel);
            this.ProductDataHolder.Panel.Controls.Add(this.productName);
            this.ProductDataHolder.Panel.Controls.Add(this.PlusPanel);
            this.ProductDataHolder.Panel.Controls.Add(this.productCost);
            this.ProductDataHolder.Panel.Controls.Add(this.productCode);
            this.ProductDataHolder.Panel.Controls.Add(this.pictureBox1);
            this.ProductDataHolder.Panel.Click += new System.EventHandler(this.ProductDataHolder_Click);
            this.ProductDataHolder.Size = new System.Drawing.Size(270, 330);
            this.ProductDataHolder.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ProductDataHolder.StateCommon.Border.Rounding = 5;
            this.ProductDataHolder.StateCommon.Border.Width = 0;
            this.ProductDataHolder.TabIndex = 1;
            this.ProductDataHolder.Click += new System.EventHandler(this.ProductDataHolder_Click);
            // 
            // NotinStockLabel
            // 
            this.NotinStockLabel.AutoSize = true;
            this.NotinStockLabel.BackColor = System.Drawing.Color.Transparent;
            this.NotinStockLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotinStockLabel.Location = new System.Drawing.Point(51, 116);
            this.NotinStockLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.NotinStockLabel.Name = "NotinStockLabel";
            this.NotinStockLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.NotinStockLabel.Size = new System.Drawing.Size(163, 23);
            this.NotinStockLabel.TabIndex = 25;
            this.NotinStockLabel.Text = "Немає в наявності";
            this.NotinStockLabel.Visible = false;
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.BackColor = System.Drawing.Color.Transparent;
            this.CountLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountLabel.Location = new System.Drawing.Point(90, 263);
            this.CountLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.CountLabel.Size = new System.Drawing.Size(22, 28);
            this.CountLabel.TabIndex = 24;
            this.CountLabel.Text = "1";
            this.CountLabel.Visible = false;
            // 
            // AddToRecieptButton
            // 
            this.AddToRecieptButton.AutoSize = true;
            this.AddToRecieptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(80)))));
            this.AddToRecieptButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToRecieptButton.ForeColor = System.Drawing.Color.White;
            this.AddToRecieptButton.Location = new System.Drawing.Point(91, 280);
            this.AddToRecieptButton.Name = "AddToRecieptButton";
            this.AddToRecieptButton.Padding = new System.Windows.Forms.Padding(6);
            this.AddToRecieptButton.Size = new System.Drawing.Size(158, 30);
            this.AddToRecieptButton.TabIndex = 4;
            this.AddToRecieptButton.Text = "Додати до чеку";
            this.AddToRecieptButton.Click += new System.EventHandler(this.AddToRecieptButton_Click);
            // 
            // MinusPanel
            // 
            this.MinusPanel.Controls.Add(this.label5);
            this.MinusPanel.Location = new System.Drawing.Point(196, 263);
            this.MinusPanel.Name = "MinusPanel";
            this.MinusPanel.Size = new System.Drawing.Size(55, 47);
            this.MinusPanel.StateCommon.Color1 = System.Drawing.Color.Tomato;
            this.MinusPanel.TabIndex = 23;
            this.MinusPanel.Visible = false;
            this.MinusPanel.Click += new System.EventHandler(this.DecrementCount_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 30F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, -2);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.MaximumSize = new System.Drawing.Size(50, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 48);
            this.label5.TabIndex = 19;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.DecrementCount_Click);
            // 
            // productName
            // 
            this.productName.AutoSize = true;
            this.productName.BackColor = System.Drawing.Color.Transparent;
            this.productName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productName.Location = new System.Drawing.Point(15, 242);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(54, 18);
            this.productName.TabIndex = 1;
            this.productName.Text = "Назва";
            // 
            // PlusPanel
            // 
            this.PlusPanel.Controls.Add(this.label4);
            this.PlusPanel.Location = new System.Drawing.Point(137, 263);
            this.PlusPanel.Name = "PlusPanel";
            this.PlusPanel.Size = new System.Drawing.Size(64, 47);
            this.PlusPanel.StateCommon.Color1 = System.Drawing.Color.LimeGreen;
            this.PlusPanel.TabIndex = 22;
            this.PlusPanel.Visible = false;
            this.PlusPanel.Click += new System.EventHandler(this.IncrementCount_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 30F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, -2);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.MaximumSize = new System.Drawing.Size(50, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 48);
            this.label4.TabIndex = 19;
            this.label4.Text = "+";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.IncrementCount_Click);
            // 
            // productCost
            // 
            this.productCost.AutoSize = true;
            this.productCost.BackColor = System.Drawing.Color.Transparent;
            this.productCost.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productCost.Location = new System.Drawing.Point(4, 282);
            this.productCost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.productCost.Name = "productCost";
            this.productCost.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.productCost.Size = new System.Drawing.Size(65, 28);
            this.productCost.TabIndex = 3;
            this.productCost.Text = "20.20";
            // 
            // productCode
            // 
            this.productCode.AutoSize = true;
            this.productCode.BackColor = System.Drawing.Color.Transparent;
            this.productCode.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.productCode.Location = new System.Drawing.Point(135, 221);
            this.productCode.Name = "productCode";
            this.productCode.Size = new System.Drawing.Size(99, 12);
            this.productCode.TabIndex = 2;
            this.productCode.Text = "Код товару 0123";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(42, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 188);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ProductDataHolder_Click);
            // 
            // ProductsLayoutInList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProductDataHolder);
            this.Name = "ProductsLayoutInList";
            this.Size = new System.Drawing.Size(273, 333);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataHolder.Panel)).EndInit();
            this.ProductDataHolder.Panel.ResumeLayout(false);
            this.ProductDataHolder.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataHolder)).EndInit();
            this.ProductDataHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MinusPanel)).EndInit();
            this.MinusPanel.ResumeLayout(false);
            this.MinusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlusPanel)).EndInit();
            this.PlusPanel.ResumeLayout(false);
            this.PlusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroup ProductDataHolder;
        private System.Windows.Forms.Label productName;
        private System.Windows.Forms.Label productCost;
        private System.Windows.Forms.Label AddToRecieptButton;
        private System.Windows.Forms.Label productCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel MinusPanel;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel PlusPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label NotinStockLabel;
    }
}
