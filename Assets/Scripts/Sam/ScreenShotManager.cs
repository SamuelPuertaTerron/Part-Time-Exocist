using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace PartTimeExocist {
    public static class ScreenShotManager {
        public static string FolderName { get { return m_folderName; } }

        private static string m_folderName = Application.persistentDataPath + @"/Screenshots/";
        private static int m_index = 1;

        public static void TakeScreenShot(string name) {
            #if UNITY_STANDALONE	
            if (!Directory.Exists(m_folderName)) {
                Directory.CreateDirectory(m_folderName);

                if (File.Exists(m_folderName + name + ".png")) {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + m_index + ".png");
                    m_index++;
                } else {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + ".png");
                }
            } else {
                if (File.Exists(m_folderName + name + ".png")) {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + m_index + ".png");
                    m_index++;
                } else {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + ".png");
                }
            }
            #endif
            #if UNITY_ANDROID	
            if (!Directory.Exists(m_folderName)) {
                Directory.CreateDirectory(m_folderName);

                if (File.Exists(m_folderName + name + ".png")) {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + m_index + ".png");
                    m_index++;
                } else {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + ".png");
                }
            } else {
                if (File.Exists(m_folderName + name + ".png")) {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + m_index + ".png");
                    m_index++;
                } else {
                    ScreenCapture.CaptureScreenshot(@"\Screenshots\" + name + ".png");
                }
            }
            #endif
        }
    }
}