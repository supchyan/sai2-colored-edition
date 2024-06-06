using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using S2CE.Extensions;

namespace S2CE.Components
{
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
        }
        public string? selectedTheme { get; private set; }
        MainTheme mainTheme = new();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            username.Text = $"{WindowsIdentity.GetCurrent().Name.Split('\\')[1]}!";
            
            changeLog.Text = "dfsdfsdf";

            var reader = Directory.GetFiles("./themes/");

            // vanilla sai2 theme
            try
            {
                ListBoxItem vanilla = new ListBoxItem()
                {
                    Name = "classic_sai2",
                    Content = "classic_sai2",
                };

                vanilla.Selected += Item_Selected;
                appList.Items.Add(vanilla);
                appList.SelectedItem = vanilla;
                selectedTheme = vanilla.Name;

            } catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }

            foreach (var f in reader)
            {
                try
                {
                    var item = new ListBoxItem()
                    {
                        Name = f.PurifyName(),
                        Content = f.PurifyName(),
                    };
                    item.Selected += Item_Selected;
                    appList.Items.Add(item);
                }
                catch { }
            }

            SetListHeight();
        }

        private void Item_Selected(object sender, RoutedEventArgs e)
        {
            foreach (ListBoxItem item in appList.Items)
            {
                if (item.IsFocused) selectedTheme = item.Name;
            }
        }

        private void launchButton_Click(object sender, RoutedEventArgs e)
        {
            mainTheme.Apply(selectedTheme);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //gitStyle
        }

        private void Window_Resized(object sender, SizeChangedEventArgs e)
        {
            SetListHeight();
        }
        void SetListHeight()
        {
            appList.Height = this.ActualHeight - launchButton.ActualHeight - this.Margin.Top - this.Margin.Bottom - appList.Margin.Top - 80;
        }
    }
}
