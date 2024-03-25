
namespace Apteka
{
    partial class LoadMoreButtonControl
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
            this.LoadMoreClicked = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // LoadMoreClicked
            // 
            this.LoadMoreClicked.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.LoadMoreClicked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadMoreClicked.Location = new System.Drawing.Point(0, 0);
            this.LoadMoreClicked.Margin = new System.Windows.Forms.Padding(0);
            this.LoadMoreClicked.Name = "LoadMoreClicked";
            this.LoadMoreClicked.Size = new System.Drawing.Size(1100, 88);
            this.LoadMoreClicked.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.LoadMoreClicked.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(80)))));
            this.LoadMoreClicked.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.LoadMoreClicked.StateCommon.Border.Rounding = 5;
            this.LoadMoreClicked.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DarkGreen;
            this.LoadMoreClicked.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadMoreClicked.TabIndex = 2;
            this.LoadMoreClicked.Values.Text = "Завантажити ще";
            //this.LoadMoreClicked.Click += new System.EventHandler(this.LoadMoreClicked_Click);
            // 
            // LoadMoreButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoadMoreClicked);
            this.Name = "LoadMoreButtonControl";
            this.Size = new System.Drawing.Size(1100, 88);
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonButton LoadMoreClicked;
    }
}
