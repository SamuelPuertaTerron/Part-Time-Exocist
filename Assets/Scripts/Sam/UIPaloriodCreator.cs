using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace PartTimeExocist
{
    public class UIPaloriodCreator : MonoBehaviour
    {
        [SerializeField] private Transform pictureParent;
        [SerializeField] private Transform ropeParent;
        [SerializeField] private GameObject image;
        [SerializeField] private GameObject rope;

        private List<string> m_CurrentPictureNames = new List<string>();

        public void CreatePhotos()
        {
            if (Directory.Exists(ScreenShotManager.FolderName))
            {
                if (Directory.GetFiles(ScreenShotManager.FolderName).Length > 0)
                {
                    foreach (string file in Directory.GetFiles(ScreenShotManager.FolderName))
                    {
                        if (!m_CurrentPictureNames.Contains(file)) //Cannot duplicate pictures that are already on the gallery
                        {
                            Texture2D texture = new Texture2D(500, 500); 
                            byte[] fileBye = File.ReadAllBytes(file); 

                            texture.LoadImage(fileBye);
                            GameObject pictureObj = Instantiate(image, pictureParent);
                            pictureObj.GetComponentInChildren<UnityEngine.UI.RawImage>().texture = texture;

                            //Sort out text here
                            string time = System.DateTime.Now.ToLocalTime().ToString();
                            string monsterName = file.Trim(ScreenShotManager.FolderName.ToCharArray());
                            pictureObj.GetComponentInChildren<TMPro.TMP_Text>().text = time + "\n" + monsterName;

                            m_CurrentPictureNames.Add(file);
                        }
                    }
                }
            }
        }
    }
}