using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace PartTimeExocist
{
    public static class ScreenShotManager
    {

        public static string FolderName { get { return m_folderName; } }

        private static string m_folderName = Application.persistentDataPath;
        private static int m_index = 1;

        public static void TakeScreenShot(string name)
        {
            
            ScreenCapture.CaptureScreenshot(name + m_index + ".png");
            m_index++;            

            // if (!Directory.Exists(m_folderName))
            // {
            //     Directory.CreateDirectory(m_folderName);
            //     
            // }
            // else
            // {
            //     if (File.Exists(m_folderName + name + ".png"))
            //     {
            //         ScreenCapture.CaptureScreenshot(m_folderName + name + m_index + ".png");
            //         m_index++;
            //     }
            //     else
            //     {
            //         ScreenCapture.CaptureScreenshot(m_folderName + name + ".png");
            //     }
            // }
        }
    }
}


