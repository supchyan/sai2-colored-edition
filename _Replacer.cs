namespace yum2_theme_toolkit {
    public class _Replacer {
        public _Replacer(string search, string replace) {
            Search = search;
            Replace = replace;
        }
        public string Search { get; }
        public string Replace { get; }
    }
}