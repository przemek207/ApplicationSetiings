using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using System.IO.IsolatedStorage;

namespace PhoneApp1
{
    //I use that tutorial.
    //https://msdn.microsoft.com/en-us/library/cc221360(v=vs.95).aspx
    public partial class MainPage : PhoneApplicationPage
    {
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                appSettings.Add("email", "someone@contoso.com");
                tbResults.Text = "Settings stored.";
            }
            catch (ArgumentException ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void bRetrieve_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbResults.Text = "Setting retrieved: " + (string)appSettings["email"];
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {
                tbResults.Text = ex.Message;
            }
        }

        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            appSettings["email"] = "someone@fabrikam.com";
            tbResults.Text = "Changed to: " + (string)appSettings["email"];
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            appSettings.Remove("email");
            tbResults.Text = "Email deleted. Click Retrieve to confirm deletion.";
        }
    }
}