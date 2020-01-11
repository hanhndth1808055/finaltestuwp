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
using FinalTest.Models;
using FinalTest.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalTest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchContactPage : Page
    {
        private SQLitePhoneContactService _service;
        public PhoneContact phoneContact;
        public SearchContactPage()
        {
            this.InitializeComponent();
            this._service = new SQLitePhoneContactService();
        }

        private void SearchContact_Clicked(object sender, RoutedEventArgs e)
        {
            if (Name.Text != null)
            {
                phoneContact = _service.Search(Name.Text);
                if (phoneContact != null)
                {
                    Name.Text = phoneContact.Name;
                    PhoneNumber.Text = phoneContact.PhoneNumber;
                }
                else
                {
                    PhoneNumber.Text = "Contact not found.";
                }
            }
        }

        private void Back_Clicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FinalPracticalExam));
        }

        private void DeleteContact_Clicked(object sender, RoutedEventArgs e)
        {
            if (phoneContact != null)
            {
                if (_service.Delete(phoneContact.Id))
                {
                    Messages.Text = "Delete successfully!";
                }
                else
                {
                    Messages.Text = "Delete unsuccessfully!";
                }
            }
        }

        private void EditContact_Clicked(object sender, RoutedEventArgs e)
        {
            if (phoneContact != null && Name.Text != null && PhoneNumber.Text != null)
            {
                phoneContact.Name = Name.Text;
                phoneContact.PhoneNumber = PhoneNumber.Text;
                
                if (_service.Update(phoneContact) != null)
                {
                    Messages.Text = "Edit successfully!";
                }
                else
                {
                    Messages.Text = "Edit unsuccessfully!";
                }
            }
        }
    }
}
