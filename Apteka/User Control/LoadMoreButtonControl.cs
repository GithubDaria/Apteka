using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class LoadMoreButtonControl : UserControl
    {    public event EventHandler LoadMoreButtonClicked;
    public delegate void LoadMoreButtonClickedEventHandler(object sender, EventArgs e);

    public LoadMoreButtonControl()
    {
        InitializeComponent();

            // Subscribe to the Click event of the LoadMoreClicked button
            // Unsubscribe from the Click event if already subscribed
            LoadMoreClicked.Click -= LoadMoreClicked_Click;

            // Subscribe to the Click event of the LoadMoreClicked button
            LoadMoreClicked.Click += LoadMoreClicked_Click;
        }

    // Click event handler for LoadMoreClicked button
    private void LoadMoreClicked_Click(object sender, EventArgs e)
    {
        // Raise the custom event when the LoadMoreClicked button is clicked
        LoadMoreButtonClicked?.Invoke(this, EventArgs.Empty);
    }
    }
}
