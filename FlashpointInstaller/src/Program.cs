﻿using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

using FlashpointInstaller.Common;

namespace FlashpointInstaller
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var listStream = new MemoryStream(new WebClient().DownloadData(FPM.ListURL)) { Position = 0 };

                FPM.XmlTree = new XmlDocument();
                FPM.XmlTree.Load(listStream);
            }
            catch
            {
                MessageBox.Show(
                    "The component list could not be downloaded! Do you have an internet connection?",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );

                Environment.Exit(1);
            }
            
            Application.Run(new Main());
        }
    }
}
