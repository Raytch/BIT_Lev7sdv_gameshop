using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAdmin
{
    sealed partial class frmOrders : Form
    {
        public static readonly frmOrders Instance = new frmOrders();

        private static List<clsOrders> _OrdersList;
        private static clsOrders _Order;
        private clsAllGames _Game;

        private frmOrders()
        {
            InitializeComponent();
        }
        public async void Run()
        {
            await RefreshFormFromDB();
            Show();
        }

        private async Task RefreshFormFromDB()
        {
            _OrdersList = await ServiceClient.GetOrdersAsync();
            updateDisplay();
        }

        private void updateDisplay()
        {
            lstOrders.DataSource = null;
            lstOrders.DataSource = _OrdersList;

            if (_OrdersList != null)
            {
                lblAllOrdersValue.Text = GetSumTotalAllOrders();
            }
        }

        private void updateForm()
        {
            lblOrderNo.Text = Convert.ToString(_Order.OrderNo);
            lblCustName.Text = _Order.CustName;
            lblCustPh.Text = _Order.CustPhone;
            lblOrderDate.Text = Convert.ToString(_Order.DateOrdered.ToShortDateString());
            lblGameCode.Text = Convert.ToString(_Order.GameCode);
            lblGameName.Text = _Game.GameName;
            lblDescription.Text = _Game.Description;
            lblPrice.Text = Convert.ToString(_Game.UnitPrice);
            lblQtyOrdered.Text = Convert.ToString(_Order.QtyOrdered);
            lblOrderTotal.Text = Convert.ToString(_Order.TotalOrderValue);
        }

        private string GetSumTotalAllOrders()
        {
            decimal lcGrandTotal = 0;
            foreach (clsOrders lcOrder in _OrdersList)
            {
                lcGrandTotal += lcOrder.PricePerItem * lcOrder.QtyOrdered;
            }
            return lcGrandTotal.ToString();
        }

        private async void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrders.SelectedItem != null)
            {
                clsOrders lcOrder = (clsOrders)lstOrders.SelectedItem;
                _Order = lcOrder;

                string lcOrderGameCode = Convert.ToString(lcOrder.GameCode);
                try
                {
                    clsAllGames lcGame = await ServiceClient.GetGameAsync(lcOrderGameCode as string);
                    _Game = lcGame;
                    updateForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            clsOrders lcOrder = lstOrders.SelectedItem as clsOrders;

            if (lcOrder != null && MessageBox.Show("Are you sure?", "Deleting Order",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    MessageBox.Show(await ServiceClient.DeleteOrderAsync(lcOrder.OrderNo));
                    await RefreshFormFromDB();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleing game");
                }
        }
    }
}
