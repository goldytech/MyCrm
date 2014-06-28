using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrm.Shared.ViewModels
{
   public class GenericViewModel :ViewModeBase
    {
       public GenericViewModel()
       {
           
       }

       private IDictionary<string,object> formData;

       public IDictionary<string,object> FormData
       {
           get { return formData; }
           set
           {
               formData = value;
               this.OnPropertyChanged("FormData");
           }
       }
        

    }
}
