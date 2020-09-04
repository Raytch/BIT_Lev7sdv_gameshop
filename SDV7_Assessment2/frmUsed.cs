using System;

namespace WindowsAdmin
{
    sealed partial class frmUsed : frmGame
    {
        private frmUsed()
        {
            InitializeComponent();
        }

        public static readonly frmUsed Instance = new frmUsed();

        public static void Run(clsAllGames prUsedGame)
        {
            Instance.SetDetails(prUsedGame);
        }

        protected override void updateForm()
        {
            base.updateForm();
            cboCondition.SelectedItem = _Game.GameCondition; //.ToString();
            nupAge.Value = Convert.ToDecimal(_Game.Age);
        }

        protected override void pushData()
        {
            base.pushData();

            _Game.GameCondition = cboCondition.SelectedItem.ToString();
            _Game.Age = Convert.ToInt32(nupAge.Value);
        }
    }
}
