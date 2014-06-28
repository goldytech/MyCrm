namespace MyCrm.Shared
{
   

    using MyCrm.Shared.Pages;

    using Xamarin.Forms;

    public class App
    {
        /// <summary>
        /// The get main page.
        /// </summary>
        /// <returns>
        /// The <see cref="Page"/>.
        /// </returns>
        public static Xamarin.Forms.Page GetMainPage()
        {
            return new DynamicLoginPage();
        }
    }
}
