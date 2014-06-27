namespace MyCrm.Shared.Pages
{
    using MyCrm.Shared.Helpers;
    using MyCrm.Shared.ViewModels;

    using Xamarin.Forms;

    using Color = Xamarin.Forms.Color;

    /// <summary>
    /// The login page.
    /// </summary>
    public class LoginPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            this.BindingContext = new LoginViewModel(Navigation, new DialogService());
            BackgroundColor = Helpers.Color.Blue.ToFormsColor();

            var layout = new StackLayout { Padding = 10 };

            var label = new Label
            {
                Text = "Identify your self",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center, // Center the text in the blue box.
                YAlign = TextAlignment.Center, // Center the text in the blue box.
            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username" };
            username.SetBinding(Entry.TextColorProperty,LoginViewModel.UserNameProperty);
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password" };
            password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordProperty);
            layout.Children.Add(password);



            var button = new Button { Text = "Sign In", TextColor = Color.White };
            button.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandProperty);

            layout.Children.Add(button);
        }
       
    }
}


