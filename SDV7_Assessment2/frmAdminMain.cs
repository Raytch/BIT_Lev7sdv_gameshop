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
    sealed partial class frmAdminMain : Form
    {
        private clsGenre _Genre;
        public static readonly frmAdminMain _instance = new frmAdminMain();
        private static Dictionary<string, frmAdminMain> _GameFormList = new Dictionary<string, frmAdminMain>();

        private frmAdminMain()
        {
            InitializeComponent();
        }

        public void frmAdminMain_Load(object sender, EventArgs e)
        {
            updateDisplay();
        }

        public static void Run(string prGenreName)
        {
            frmAdminMain lcMainForm;
            if (string.IsNullOrEmpty(prGenreName) || 
                !_GameFormList.TryGetValue(prGenreName, out lcMainForm))
            {
                lcMainForm = new frmAdminMain();
                if (string.IsNullOrEmpty(prGenreName))
                    lcMainForm.SetDetails(new clsGenre());
                else
                {
                    _GameFormList.Add(prGenreName, lcMainForm);
                    lcMainForm.refreshFormFromDB(prGenreName);
                }
            }
            else
            {
                lcMainForm.Show();
                lcMainForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prGenreName)
        {
            SetDetails(await ServiceClient.GetGenreAsync(prGenreName)); 
        }

        public void SetDetails(clsGenre prGenre)
        {
            _Genre = prGenre;
            lblGenreName.Enabled = string.IsNullOrEmpty(_Genre.GenreName);
            updateForm();
            updateDisplay();
            Show();
        }

        public async void updateDisplay()
        {
            string lcGenreName = _Genre.GenreName;
            List<clsAllGames> List = await ServiceClient.GetGenreGamesAsync(lcGenreName);
            _Genre.GamesList = List;

            lstGames.DataSource = null;
            if (_Genre.GamesList != null)
                lstGames.DataSource = _Genre.GamesList;
        }

        private void updateForm()
        {
            lblGenreName.Text = _Genre.GenreName;
            lblDescription.Text = _Genre.Description;
        }

        public void pushData()
        {
            _Genre.GenreName = lblGenreName.Text;
            _Genre.Description = lblDescription.Text;
        }

        private void lstGames_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;
            lcKey = Convert.ToString(lstGames.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmGame.DispatchGameForm(lstGames.SelectedValue as clsAllGames);
                    updateDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                string lcReply = new InputBox(clsAllGames.FACTORY_PROMPT).Answer;
                if (!string.IsNullOrEmpty(lcReply))  // not cancelled?
                {
                    clsAllGames lcGame = clsAllGames.NewGame(lcReply[0]);
                    if (lcGame != null) // valid artwork created
                    {
                        lcGame.GenreGenreName = _Genre.GenreName; 
                        frmGame.DispatchGameForm(lcGame);
                        if (!string.IsNullOrEmpty(lcGame.GameName))  //not cancelled?
                        {
                            refreshFormFromDB(_Genre.GenreName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //return ex.GetBaseException().Message;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnDeleteItem_Click(object sender, EventArgs e)
        {
            clsAllGames lcGame = lstGames.SelectedItem as clsAllGames;

            if (lcGame != null && MessageBox.Show("Are you sure?", "Deleting Game",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    MessageBox.Show(await ServiceClient.DeleteGameAsync(lcGame.Code));
                    refreshFormFromDB(lcGame.GenreGenreName as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleting artist");
                }
        }

    }
}
