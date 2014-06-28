using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrm.Shared.Pages
{
    using System.Dynamic;
    using System.Linq;

    using MyCrm.Shared.Schemas;
    using MyCrm.Shared.ViewModels;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Xamarin.Forms;

    /// <summary>
    /// The dynamic login page.
    /// </summary>
    public class DynamicLoginPage : ContentPage
    {
        public DynamicLoginPage()
        {
           
            //var jobj = new JObject();
            //jobj.Add();
            const string Json = @"{
                      'form_id': 1,
                      'form_name': 'Login',
                      'form_fields': [
                        {
                          'field_id': 1,
                          'field_title': 'UserName',
                          'field_type': 'textfield',
                          'field_value': 'afzal',
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
            dynamic formdatabindingObject = new ExpandoObject();
         //   var formFields = formdatabindingObject as IDictionary<string, object>;

            var formFields = new Dictionary<string, object>();

            // preparing the data binding object for the form
            foreach (var field in formSchema.form_fields)
            {
                formFields[field.field_title] = field.field_value;
            }

            var bindingcontext = new GenericViewModel { FormData = formFields };
            this.BindingContext = bindingcontext.FormData;
            
            // now create the controls
            Label label; // for label
            Entry textbox; // for textbox

            var stackLayout = new StackLayout { VerticalOptions = LayoutOptions.StartAndExpand, Padding = new Thickness(10) };

            foreach (var field in formSchema.form_fields)
            {
                switch (field.field_type)
                {
                    case "textfield":
                        // generate the label and text box
                        label = new Label { Text = field.field_title };
                        stackLayout.Children.Add(label);
                        textbox = new Entry();
                        textbox.SetBinding(Entry.TextProperty, string.Format("[{0}]", field.field_title));
                        stackLayout.Children.Add(textbox);
                        break;
                    case "password":
                        label = new Label { Text = field.field_title };
                        stackLayout.Children.Add(label);
                        textbox = new Entry {IsPassword = true};
                        textbox.SetBinding(Entry.TextProperty, string.Format("[{0}]", field.field_title));
                        stackLayout.Children.Add(textbox);
                        break;
                }
            }
            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) =>
            {
                var form = (IDictionary<string,object>)BindingContext;

                var requiredFields = formSchema.form_fields.Where(f => f.field_required).Select(x => x.field_title);

                foreach (var requiredField in requiredFields)
                {
                    object value = null;
                    form.TryGetValue(requiredField, out value);
                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        this.DisplayAlert("Error", string.Format("{0} is required field",requiredField), "Ok", null);  
                        return;
                    }
                    
                }

                // Convert the data and pass it to web api

                var datatobeSubmitted = JsonConvert.SerializeObject(form, Formatting.Indented);
                this.DisplayAlert("Success", datatobeSubmitted, "Ok", null);
            };

            stackLayout.Children.Add(saveButton);

            this.Content = stackLayout;

        }
    }
}
