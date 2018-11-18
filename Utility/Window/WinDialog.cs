using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

using Microsoft.WindowsAPICodePack.Dialogs;

namespace Utility.Window
{
    /*
        using library
        - microsoft.windowsapicodepack.dll (reference)
        - microsoft.windowsapicodepack.shell.dll (reference)
    */

    /// <summary>
    /// Window Folder Dialogue API (better)
    /// </summary>
    public class WinDialog
    {
        private static bool isAvailable
        { 
            get
            {
                if (Environment.OSVersion.Version.Major >= 6)
                    return true;
                else
                    return false;
            }
        }

        public static string OpenBetterFolderDialog(string title, string initialpath = null)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.Title = title;
                dialog.IsFolderPicker = true;
                dialog.RestoreDirectory = true;

                if (string.IsNullOrEmpty(initialpath))
                    dialog.InitialDirectory = initialpath;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    return dialog.FileName;
                }
            }

            return null;
        }

        public static string[] OpenBettrerFoldersDialog(string title, string initialpath = null)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.Title = title;
                dialog.IsFolderPicker = true;
                dialog.RestoreDirectory = true;
                dialog.Multiselect = true;

                if (string.IsNullOrEmpty(initialpath))
                    dialog.InitialDirectory = initialpath;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    return dialog.FileNames.ToArray();
                }
            }

            return null;
        }


        public static string OpenNormalFolderDialog(string initialpath = null)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a directory";
                dialog.ShowNewFolderButton = true;
                if (string.IsNullOrEmpty(initialpath))
                    dialog.SelectedPath = initialpath;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }

            return null;
        }

        public static string OpenFolderDialog(string initialpath = null)
        {
            if (isAvailable)
                return OpenBetterFolderDialog(initialpath);
            else
                return OpenNormalFolderDialog();
        }
    }
}
