using Microsoft.Win32;

namespace Dotnet8Testing
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            // code for creating registry key

            using (RegistryKey regEntry = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MySoft\\MyLocation"))
            {
                regEntry?.SetValue("MyKey", "TestValue");
            }

            var regValue = string.Empty;

            using (var regEntry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MySoft\\MyLocation"))
            {
                if (regEntry != null)
                {
                    if (regEntry == null) return;
                    var value = regEntry.GetValue("MyKey");
                    regValue = value == null ? string.Empty : value.ToString();
                }
            }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
