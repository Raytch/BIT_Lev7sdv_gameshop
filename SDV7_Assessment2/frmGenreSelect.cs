using System;
using System.Windows.Forms;

namespace WindowsAdmin
{
    public partial class frmGenreSelect : Form
    {
        private clsGenre _Genre;

        public frmGenreSelect()
        {
            InitializeComponent();
        }

        private void frmGenreSelect_Load(object sender, EventArgs e)
        {
            updateDisplay();
        }
        public async void updateDisplay()
        {
            try
            {
                cboGenre.DataSource = null;
                cboGenre.DataSource = await ServiceClient.GetGenreNamesAsync();

                if (cboGenre.DataSource != null)
                {
                    updateForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error getting genre names");
            }
        }

        private void btnViewGames_Click(object sender, EventArgs e)
        {
            string lcKey;
            lcKey = Convert.ToString(cboGenre.SelectedItem);

            if (lcKey != null)
                try
                {
                    frmAdminMain.Run(cboGenre.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }
        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            //frmOrders lcOrdersForm = new frmOrders();
            try
            {
                frmOrders.Instance.Run();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }
        private async void updateForm()
        {
            _Genre = await ServiceClient.GetGenreAsync(cboGenre.SelectedItem as string);
            lblDescription.Text = _Genre.Description;
        }

        private void cboGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateForm();
        }

    }
}
