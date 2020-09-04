using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAdmin
{
    public partial class frmGame : Form
    {
        protected clsAllGames _Game;
        public delegate void LoadWorkFormDelegate(clsAllGames prGame);

        public static Dictionary<char, Delegate> _GamesForm = new Dictionary<char, Delegate>
        {
            {'N', new LoadWorkFormDelegate(frmNew.Run)},
            {'U', new LoadWorkFormDelegate(frmUsed.Run)}
        };
        public static void DispatchGameForm(clsAllGames prGame)
        {
            _GamesForm[prGame.Type].DynamicInvoke(prGame);
        }

        public frmGame()
        {
            InitializeComponent();
            lblDateModified.Enabled = false;
        }

        public void SetDetails(clsAllGames prGame)
        {
            _Game = prGame;

            DateTime lcToday = DateTime.Today;
            _Game.LastModified = lcToday;

            updateForm();
            ShowDialog();
        }

        protected virtual void updateForm()
        {
            txtGameName.Text = _Game.GameName;
            txtDescription.Text = _Game.Description;
            txtUnitPrice.Text = _Game.UnitPrice.ToString();
            txtQtyAvail.Text = _Game.QtyAvail.ToString();
            lblDateModified.Text = _Game.LastModified.ToShortDateString();
            txtGameName.Enabled = string.IsNullOrEmpty(_Game.GameName);
        }
        protected virtual void pushData()
        {
            _Game.GameName = txtGameName.Text;
            _Game.Description = txtDescription.Text;
            _Game.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            _Game.QtyAvail = int.Parse(txtQtyAvail.Text);
            _Game.LastModified = DateTime.Parse(lblDateModified.Text);
        }

        public virtual bool isValid()
        {
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();

                if (txtGameName.Enabled)
                    MessageBox.Show(await ServiceClient.InsertGameAsync(_Game));
                else
                    MessageBox.Show(await ServiceClient.UpdateGameAsync(_Game));
                Close();
            }
        }
    }
}
