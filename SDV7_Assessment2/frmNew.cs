using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsAdmin
{
    sealed partial class frmNew : WindowsAdmin.frmGame
    {
        private frmNew()
        {
            InitializeComponent();
        }

        public static readonly frmNew Instance = new frmNew();

        public static void Run(clsAllGames prNewGame)
        {
            Instance.SetDetails(prNewGame);
        }

        protected override void updateForm()
        {
            base.updateForm();
            if (_Game.WarrantyExpiry == null)
                _Game.WarrantyExpiry = DateTime.Today.AddYears(1);
            txtWarrantyExp.Text = _Game.WarrantyExpiry.ToString();
          //  dtpWarranty.Value = _Game.WarrantyExpiry;
        }

        protected override void pushData()
        {
            base.pushData();
            _Game.WarrantyExpiry = DateTime.Parse(txtWarrantyExp.Text);
        }

    }
}
