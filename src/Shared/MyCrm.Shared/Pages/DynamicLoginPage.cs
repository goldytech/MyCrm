using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrm.Shared.Pages
{
    using MyCrm.Shared.Schemas;

    using Newtonsoft.Json;

    using Xamarin.Forms;

    /// <summary>
    /// The dynamic login page.
    /// </summary>
    public class DynamicLoginPage : ContentPage
    {
        public DynamicLoginPage()
        {
            const string Json = @"{
                      'form_id': 1,
                      'form_name': 'Login',
                      'form_fields': [
                        {
                          'field_id': 1,
                          'field_title': 'UserName',
                          'field_type': 'textfield',
                          'field_value': '',
                          'field_required': true
                        },
                        {
                          'field_id': 3,
                          'field_title': 'Password',
                          'field_type': 'password',
                          'field_value': '',
                          'field_required': true
                        }
                      ]
                    }";

            var formSchema = JsonConvert.DeserializeObject<FormSchema>(Json);

            foreach (var field in formSchema.form_fields)
            {
                switch (field.field_type)
                {
                    case "textfield":
                        break;

                }
            }
        }
    }
}
