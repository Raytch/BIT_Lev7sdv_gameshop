using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_customerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgMain : Page
    {
        private clsGenre _Genre;
        private clsAllGames _Game;

        public pgMain()
        {
            this.InitializeComponent();

        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //lstGamesList.ItemsSource = await ServiceClient.Get

            // ADD GENRE LIST/DROPDOWN TO pgMAIN, then correct method above
            // SELECTED ITEM CHANGED EVENT - getGenreGames into games list.


        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                string lcGenreName = e.Parameter.ToString();
                List<clsAllGames> List = await ServiceClient.GetGenreGamesAsync(lcGenreName);
                _Genre.GamesList = List;
                lstGames.ItemsSource = null;
                if (_Genre.GamesList != null)
                {
                    lstGames.ItemsSource = _Genre.GamesList;              
                }
                //UpdateDisplay();
            }
        }

    }
}
