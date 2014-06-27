using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrm.Shared.Helpers
{
   public interface IDialogService
   {
       void ShowAlert(string title, string message);
   }
}
