using YumToolkit.Global;

namespace YumToolkit.Core.UI {
    class _Watcher : _Globals {
        FileSystemWatcher tw = new FileSystemWatcher("./themes");

        void FilesRenamed(object sender, RenamedEventArgs e) {
            content.InvokeListUpdate();
        }

        void FilesCreated(object sender, FileSystemEventArgs e) {
            content.InvokeListUpdate();
        }

        void FilesDeleted(object sender, FileSystemEventArgs e) {
            content.InvokeListUpdate();
        }

        void FilesChanged(object sender, FileSystemEventArgs e) {
            content.InvokeListUpdate();
        }
        public _Watcher() {
            tw.Changed += FilesChanged;
            tw.Created += FilesCreated;
            tw.Deleted += FilesDeleted;
            tw.Renamed += FilesRenamed;
            tw.Filter = "*.json";
            tw.IncludeSubdirectories = true;
            tw.EnableRaisingEvents = true;
            tw.NotifyFilter =
              NotifyFilters.Attributes
            | NotifyFilters.CreationTime
            | NotifyFilters.DirectoryName
            | NotifyFilters.FileName
            | NotifyFilters.LastAccess
            | NotifyFilters.LastWrite
            | NotifyFilters.Security
            | NotifyFilters.Size;
        }
    }
}