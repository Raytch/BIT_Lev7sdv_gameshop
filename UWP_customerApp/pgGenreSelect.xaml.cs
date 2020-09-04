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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_customerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgGenreSelect : Page
    {
        private clsGenre _Genre;
        

        public pgGenreSelect()
        {
            this.InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cboGenre.ItemsSource = await ServiceClient.GetGenreNamesAsync();
            }
            catch (Exception ex)
            {
                txbMessages.Text = ex.GetBaseException().Message;
            }
        }

        private void cboGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateForm();
        }

        private async void updateForm()
        {
            _Genre = await ServiceClient.GetGenreAsync(cboGenre.SelectedItem as string);
            txbDescription.Text = _Genre.Description;
        }



        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (cboGenre.SelectedItem != null)
            {
                Frame.Navigate(typeof(pgMain), cboGenre.SelectedItem);
            }
        }


        // OK_CLICK
    }
}
