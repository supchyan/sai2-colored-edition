using System.Diagnostics;
using System.IO;
using System.Text;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using S2CE.Extensions;
using System.Text.Json;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading.Tasks;

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
            changeLog.Text = File.ReadAllText("CHANGELOG.md", Encoding.UTF8);
            
            try
            {
                AddVanillaItem();

                var reader = Directory.GetFiles("./themes/");
                foreach (var f in reader)
                {
                    AddItem(f);
                }
            } catch (Exception ex) { }

            SetListHeight();
        }

        private void Item_Selected(object sender, RoutedEventArgs e)
        {
            foreach (ListBoxItem item in appList.Items)
            {
                if (item.IsFocused) selectedTheme = item.Name;
            }
        }

        private async void Launch_ButtonClicked(object sender, RoutedEventArgs e)
        {
            launchButton.IsEnabled = false;
            launchButton.Content = "Running";
            await Task.Run(() =>
            {
                mainTheme.Apply(selectedTheme);
            });
        }
        private void Git_ButtonClicked(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/supchyan/sai2-colored-edition") { UseShellExecute = true });
        }
        private void Dis_ButtonClicked(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://discord.gg/dGF8p9UGyM") { UseShellExecute = true });
        }
        private void Window_Resized(object sender, SizeChangedEventArgs e)
        {
            SetListHeight();
        }
        void SetListHeight()
        {
            appList.Height = this.ActualHeight - launchButton.ActualHeight - this.Margin.Top - this.Margin.Bottom - appList.Margin.Top - 80;
        }
        
        void AddItem(string f)
        {
            ListBoxItem item = new ListBoxItem()
            {
                Name = f.PurifyName(),
            };

            StackPanel panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };

            item.Content = panel;

            var colors = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(f));

            foreach (var col in colors.Values)
            {
                panel.Children.Add(new Rectangle
                {
                    Fill = new SolidColorBrush(Color.FromRgb(col.toByteColor()[2], col.toByteColor()[1], col.toByteColor()[0])),
                    Width = 12,
                    Height = 12,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                });
            }

            panel.Children.Add(new TextBlock()
            {
                Text = f.PurifyName(),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0),
            });

            item.Selected += Item_Selected;
            appList.Items.Add(item);
        }
        void AddVanillaItem()
        {
            ListBoxItem vanillaItem = new ListBoxItem()
            {
                Name = "classic_sai2",
            };

            StackPanel vanillaPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };

            vanillaItem.Content = vanillaPanel;

            List<string> vanillaColors = new List<string>()
                {
                    "#C0C0C0", "#FFFFFF", "#CCCCCC", "#000000", "#BBBBBB", "#8E8E8E"
                };

            foreach (string color in vanillaColors)
            {
                vanillaPanel.Children.Add(new Rectangle
                {
                    Fill = new SolidColorBrush(Color.FromRgb(color.toByteColor()[2], color.toByteColor()[1], color.toByteColor()[0])),
                    Width = 12,
                    Height = 12,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                });
            }

            vanillaPanel.Children.Add(new TextBlock()
            {
                Text = "classic_sai2",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0),
            });

            vanillaItem.Selected += Item_Selected;

            appList.Items.Add(vanillaItem);
            appList.SelectedItem = vanillaItem;
            selectedTheme = vanillaItem.Name;
        }
    }
}
