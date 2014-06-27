using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrm.Shared.Helpers
{
    using Xamarin.Forms;

    /// <summary>
    /// The dialog service.
    /// </summary>
    public class DialogService : Page, IDialogService
    {
        public void ShowAlert(string title, string message)
        {
            this.DisplayAlert(title, message, "Ok", null);
        }
    }
}
