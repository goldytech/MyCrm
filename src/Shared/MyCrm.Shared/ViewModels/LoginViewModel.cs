namespace MyCrm.Shared.ViewModels
{
    using System;

    using MyCrm.Helpers.Annotations;
    using MyCrm.Shared.Helpers;

    using Xamarin.Forms;

    /// <summary>
    /// The login view model.
    /// </summary>
    public class LoginViewModel : ViewModeBase
    {
        #region Declarations
        /// <summary>
        /// The user name property.
        /// </summary>
        public const string UserNameProperty = "UserName";

        /// <summary>
        /// The password property.
        /// </summary>
        public const string PasswordProperty = "Password";

        /// <summary>
        /// The login command property.
        /// </summary>
        public const string LoginCommandProperty = "LoginCommand";
        
        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigation navigation;

        private readonly IDialogService dialogService;

        /// <summary>
        /// The user name.
        /// </summary>
        private string userName;

        /// <summary>
        /// The password.
        /// </summary>
        private string password;

        /// <summary>
        /// The login command.
        /// </summary>
        private Command loginCommand;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="navigation">
        /// The navigation.
        /// </param>
        /// <param name="dialogService">the dialog service</param>
        public LoginViewModel(INavigation navigation,IDialogService dialogService)
        {
            this.navigation = navigation;
            this.dialogService = dialogService;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [NotNull]
        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.SetProperty(ref this.userName, value, UserNameProperty);
            }
        }

        /// <summary>
        /// Gets or sets the password.
       /// </summary>
       public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.SetProperty(ref this.password,value,PasswordProperty);
            }
        }

        /// <summary>
        /// Gets the login command.
        /// </summary>
        public Command LoginCommand
        {
            get
            {
                return this.loginCommand ?? (this.loginCommand = new Command(this.OnLogin, this.CanLogin));
            }
        }
       

        #endregion

        #region Private Methods

        /// <summary>
        /// The can login.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        private bool CanLogin()
        {
            return !(string.IsNullOrEmpty(this.UserName) && string.IsNullOrEmpty(this.Password));
        }

        private async void OnLogin()
        {
            if (this.UserName.Equals("afzal") && this.Password.Equals("afzal"))
            {
                await this.navigation.PopModalAsync();
            }
            else
            {
                this.dialogService.ShowAlert("Error", "Invalid Credentials");
            }
        } 
        #endregion
    }
}
