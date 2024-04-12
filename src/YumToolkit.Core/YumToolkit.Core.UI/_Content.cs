using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _Content : _Globals {
        List<string> oldThemesList { get; set; } = new List<string>();
        List<string> ThemesList { get; set; } = new List<string>();
        public List<string> pubThemesList => ThemesList;

        
        public string[] Dots = ["⠋","⠙","⠸","⠴","⠦","⠇"];
        public int DotsPosition { get; set; }

        public string NextPageOperator { get; set; } = "->";
        public string SelectedNextPageOperator { get; set; } = "-->";
        public string Selector { get; set; } = "** ";
        public string EmptySelector { get; set; } = "* ";

        public int MenuSize { get; set; }
        public int Selection { get; set; }
        public int IndexSelection => Selection + minIndex;

        public int Page, MaxPage, minIndex;
        public List<string> MenuContent { get; set; } = new List<string>();

        const int ThemesCap = 5;

        void ReadThemes() {
            MenuContent.Clear();
            ThemesList = Directory.GetFiles(path.ThemesFolder).ToList();
            ThemesList.Sort(); // Sorting themes alphabetically 
        }
        public void UpdateContentMenu() {
            if(!OperatingSystem.IsWindows()) { return; }
            
            ReadThemes();

            if(ThemesList.Count > minIndex + ThemesCap) {
                for(int i = minIndex; i < minIndex + ThemesCap; i++) {
                    MenuContent.Add($"{Path.GetFileNameWithoutExtension(ThemesList[i])}");
                }
            } else {
                for(int i = minIndex; i < ThemesList.Count; i++) {
                    MenuContent.Add($"{Path.GetFileNameWithoutExtension(ThemesList[i])}");
                }
            }

            MenuContent.Add(NextPageOperator);
            MenuContent.Add("Restore theme to 'default'");
            MenuContent.Add("Visit project's GitHub page");
            MenuContent.Add($"Exit {Console.Title}");

            MenuSize = MenuContent.Count - 1;


            if(Selection < 0) Selection = MenuSize;
            if(Selection > MenuSize) Selection = 0;

            drawing.UpdateUI = true;
        }
        public void InvokeListUpdate() {
            UpdateContentMenu();
            UpdatePages();
            oldThemesList = ThemesList;
        }
        public void UpdatePages() {
            MaxPage = 0;
            foreach(var i in ThemesList) {
                if(ThemesList.IndexOf(i) % ThemesCap == 0) { 
                    if(ThemesList.IndexOf(i) != 0) MaxPage++;
                }
            }
            CheckPagesOverload();
        }
        public void CheckPagesOverload() {
            if(Page > MaxPage) {
                Page--;
                minIndex -= ThemesCap;
                InvokeListUpdate();
            } 
        }
        public void GoToNextPage() {
            Selection = 0;
            if(Page < MaxPage) { Page++; minIndex += ThemesCap;}
            else { Page = 0; minIndex = 0; }
        }
        public _Content() {
            CheckPagesOverload();
            InvokeListUpdate();
        }
    }
}