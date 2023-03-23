using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

namespace PartTimeExocist {
    public class UIPaloriodCreator : MonoBehaviour {
        [SerializeField] private Transform parent;
        [SerializeField] private GameObject Image;

        private void Start() {
            CreatePhotos();
        }

        public void CreatePhotos() {

            if (Directory.Exists(ScreenShotManager.FolderName)) {
                if (Directory.GetFiles(ScreenShotManager.FolderName).Length > 0) {
                    
                    foreach(string file in Directory.GetFiles(ScreenShotManager.FolderName)) {
                        Texture2D texture = new Texture2D(500, 500);
                        byte[] fileBye = File.ReadAllBytes(file);

                        texture.LoadImage(fileBye);
                        GameObject obj = Instantiate(Image, parent);
                        obj.GetComponent<UnityEngine.UI.RawImage>().texture = texture;
                    }
                }
            }
        }
    }
}


