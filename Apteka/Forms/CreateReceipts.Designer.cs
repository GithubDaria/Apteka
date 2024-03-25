
namespace Apteka
{
    partial class CreateReceipts
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
            this.TopBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.AddProductPage = new System.Windows.Forms.Label();
            this.SellersPage = new System.Windows.Forms.Label();
            this.RecieptsPageButton = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ReceiptsList = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.flowLayoutPanenl = new System.Windows.Forms.FlowLayoutPanel();
            this.ConfirmButton = new System.Windows.Forms.Label();
            this.kryptonGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.SellerCodeTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SellerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FullPriceLabel = new System.Windows.Forms.Label();
            this.TopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptsList.Panel)).BeginInit();
            this.ReceiptsList.Panel.SuspendLayout();
            this.ReceiptsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).BeginInit();
            this.kryptonGroup2.Panel.SuspendLayout();
            this.kryptonGroup2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(80)))));
            this.TopBar.Controls.Add(this.label1);
            this.TopBar.Controls.Add(this.AddProductPage);
            this.TopBar.Controls.Add(this.SellersPage);
            this.TopBar.Controls.Add(this.RecieptsPageButton);
            this.TopBar.Controls.Add(this.label5);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(1488, 54);
            this.TopBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Товари";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AddProductPage
            // 
            this.AddProductPage.AutoSize = true;
            this.AddProductPage.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProductPage.ForeColor = System.Drawing.Color.White;
            this.AddProductPage.Location = new System.Drawing.Point(210, 12);
            this.AddProductPage.Margin = new System.Windows.Forms.Padding(3, 0, 70, 0);
            this.AddProductPage.Name = "AddProductPage";
            this.AddProductPage.Size = new System.Drawing.Size(159, 25);
            this.AddProductPage.TabIndex = 1;
            this.AddProductPage.Text = "Додати товар";
            this.AddProductPage.Click += new System.EventHandler(this.AddProductPage_Click);
            // 
            // SellersPage
            // 
            this.SellersPage.AutoSize = true;
            this.SellersPage.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellersPage.ForeColor = System.Drawing.Color.White;
            this.SellersPage.Location = new System.Drawing.Point(413, 12);
            this.SellersPage.Margin = new System.Windows.Forms.Padding(3, 0, 70, 0);
            this.SellersPage.Name = "SellersPage";
            this.SellersPage.Size = new System.Drawing.Size(136, 25);
            this.SellersPage.TabIndex = 2;
            this.SellersPage.Text = "Працівники";
            this.SellersPage.Click += new System.EventHandler(this.SellersPage_Click);
            // 
            // RecieptsPageButton
            // 
            this.RecieptsPageButton.AutoSize = true;
            this.RecieptsPageButton.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecieptsPageButton.ForeColor = System.Drawing.Color.White;
            this.RecieptsPageButton.Location = new System.Drawing.Point(594, 12);
            this.RecieptsPageButton.Margin = new System.Windows.Forms.Padding(3, 0, 70, 0);
            this.RecieptsPageButton.Name = "RecieptsPageButton";
            this.RecieptsPageButton.Size = new System.Drawing.Size(64, 25);
            this.RecieptsPageButton.TabIndex = 3;
            this.RecieptsPageButton.Text = "Чеки";
            this.RecieptsPageButton.Click += new System.EventHandler(this.RecieptsPageButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1281, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 70, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Створити чек";
            // 
            // ReceiptsList
            // 
            this.ReceiptsList.Location = new System.Drawing.Point(32, 76);
            this.ReceiptsList.Name = "ReceiptsList";
            // 
            // ReceiptsList.Panel
            // 
            this.ReceiptsList.Panel.Controls.Add(this.flowLayoutPanenl);
            this.ReceiptsList.Size = new System.Drawing.Size(1424, 697);
            this.ReceiptsList.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ReceiptsList.StateCommon.Border.Rounding = 10;
            this.ReceiptsList.TabIndex = 4;
            // 
            // flowLayoutPanenl
            // 
            this.flowLayoutPanenl.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanenl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanenl.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanenl.Name = "flowLayoutPanenl";
            this.flowLayoutPanenl.Size = new System.Drawing.Size(1416, 689);
            this.flowLayoutPanenl.TabIndex = 0;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.AutoSize = true;
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(80)))));
            this.ConfirmButton.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmButton.Location = new System.Drawing.Point(757, 38);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Padding = new System.Windows.Forms.Padding(40);
            this.ConfirmButton.Size = new System.Drawing.Size(481, 128);
            this.ConfirmButton.TabIndex = 13;
            this.ConfirmButton.Text = "Підтвердити чек";
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // kryptonGroup2
            // 
            this.kryptonGroup2.Location = new System.Drawing.Point(32, 779);
            this.kryptonGroup2.Name = "kryptonGroup2";
            // 
            // kryptonGroup2.Panel
            // 
            this.kryptonGroup2.Panel.Controls.Add(this.FullPriceLabel);
            this.kryptonGroup2.Panel.Controls.Add(this.label2);
            this.kryptonGroup2.Panel.Controls.Add(this.SellerCodeTextBox);
            this.kryptonGroup2.Panel.Controls.Add(this.SellerLabel);
            this.kryptonGroup2.Panel.Controls.Add(this.ConfirmButton);
            this.kryptonGroup2.Size = new System.Drawing.Size(1424, 204);
            this.kryptonGroup2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroup2.StateCommon.Border.Rounding = 10;
            this.kryptonGroup2.TabIndex = 5;
            // 
            // SellerCodeTextBox
            // 
            this.SellerCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SellerCodeTextBox.Location = new System.Drawing.Point(402, 110);
            this.SellerCodeTextBox.MaximumSize = new System.Drawing.Size(200, 40);
            this.SellerCodeTextBox.MinimumSize = new System.Drawing.Size(250, 50);
            this.SellerCodeTextBox.Name = "SellerCodeTextBox";
            this.SellerCodeTextBox.Size = new System.Drawing.Size(250, 50);
            this.SellerCodeTextBox.StateCommon.Back.Color1 = System.Drawing.Color.LightGray;
            this.SellerCodeTextBox.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.SellerCodeTextBox.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.SellerCodeTextBox.StateCommon.Border.Rounding = 5;
            this.SellerCodeTextBox.StateCommon.Content.Color1 = System.Drawing.SystemColors.ActiveCaptionText;
            this.SellerCodeTextBox.StateCommon.Content.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.SellerCodeTextBox.StateCommon.Content.Padding = new System.Windows.Forms.Padding(4, 7, -1, -1);
            this.SellerCodeTextBox.TabIndex = 15;
            // 
            // SellerLabel
            // 
            this.SellerLabel.AutoSize = true;
            this.SellerLabel.BackColor = System.Drawing.Color.Transparent;
            this.SellerLabel.Font = new System.Drawing.Font("Verdana", 30F);
            this.SellerLabel.Location = new System.Drawing.Point(68, 112);
            this.SellerLabel.Name = "SellerLabel";
            this.SellerLabel.Size = new System.Drawing.Size(308, 48);
            this.SellerLabel.TabIndex = 14;
            this.SellerLabel.Text = "Код продавця";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 30F);
            this.label2.Location = new System.Drawing.Point(68, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 48);
            this.label2.TabIndex = 16;
            this.label2.Text = "Сума:";
            // 
            // FullPriceLabel
            // 
            this.FullPriceLabel.AutoSize = true;
            this.FullPriceLabel.BackColor = System.Drawing.Color.Transparent;
            this.FullPriceLabel.Font = new System.Drawing.Font("Verdana", 30F);
            this.FullPriceLabel.Location = new System.Drawing.Point(404, 38);
            this.FullPriceLabel.Name = "FullPriceLabel";
            this.FullPriceLabel.Size = new System.Drawing.Size(142, 48);
            this.FullPriceLabel.TabIndex = 17;
            this.FullPriceLabel.Text = "Сума:";
            // 
            // CreateReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 997);
            this.Controls.Add(this.TopBar);
            this.Controls.Add(this.kryptonGroup2);
            this.Controls.Add(this.ReceiptsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateReceipts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateReceipts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateReceipts_FormClosed);
            this.Load += new System.EventHandler(this.CreateReceipts_Load);
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptsList.Panel)).EndInit();
            this.ReceiptsList.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptsList)).EndInit();
            this.ReceiptsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).EndInit();
            this.kryptonGroup2.Panel.ResumeLayout(false);
            this.kryptonGroup2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).EndInit();
            this.kryptonGroup2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AddProductPage;
        private System.Windows.Forms.Label SellersPage;
        private System.Windows.Forms.Label RecieptsPageButton;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup ReceiptsList;
        private System.Windows.Forms.Label ConfirmButton;
        private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup2;
        private System.Windows.Forms.Label SellerLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox SellerCodeTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanenl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FullPriceLabel;
    }
}