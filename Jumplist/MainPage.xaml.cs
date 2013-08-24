using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Jumplist.Repository;

namespace Jumplist
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            allPersons.ItemsSource = DataRepository.GroupedPersons;
        }

        private void AddItemClick(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AddItem.xaml", UriKind.Relative));
        }
    }
}