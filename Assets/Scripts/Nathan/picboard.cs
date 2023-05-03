using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
namespace PartTimeExocist
{
    public class picboard : MonoBehaviour
    {
        [SerializeField] private Transform picGrid;
        [SerializeField] private Transform stringGrid;
        [SerializeField] private GameObject polaroidPrefab;
        [SerializeField] private GameObject stringPrefab;
        private void Start()
        {
            CreatePhotos();
        }

        public void CreatePhotos()
        {
            //Debug.Log(System.DateTime.Now.ToString());
            if (Directory.Exists(ScreenShotManager.FolderName))
            {
                if (Directory.GetFiles(ScreenShotManager.FolderName).Length > 0)
                {
                    int count = 0;

                    foreach (string file in Directory.GetFiles(ScreenShotManager.FolderName,"*.png"))
                    {
                        
                        Texture2D texture = new Texture2D(500, 500);
                        byte[] fileBye = File.ReadAllBytes(file);
                        texture.LoadImage(fileBye);
                        GameObject Polaroid = Instantiate(polaroidPrefab, picGrid);
                        Polaroid.GetComponentInChildren<UnityEngine.UI.RawImage>().texture = texture;
                        TextMeshProUGUI tmp = Polaroid.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
                        //string datetimeString = System.DateTime.Now.ToString();
                        //string dateString = oldString.Substring(0, 10);
                        string tempString = file.Substring(file.IndexOf("$�"), 21);//file.Length - 14); //file name to date
                        //tempString = tempString.Substring(0, tempString.Length - 4); //chop ".png"
                        tempString = tempString.Substring(11, 10);
                        tempString = tempString.Substring(0,2)+"/"+ tempString.Substring(3, 2) + "/" + tempString.Substring(6,4); //swap the "-"s
                        tmp.text = tempString;
                        if (count%2 == 0)
                        {
                            GameObject String = Instantiate(stringPrefab, stringGrid);
                            this.GetComponent<RectTransform>().sizeDelta = new Vector2(900, 760 + (680 * count/2));
                            String.transform.GetChild(Random.Range(1, 4)).gameObject.SetActive(true);
                            String.transform.GetChild(Random.Range(4, 7)).gameObject.SetActive(true);
                            String.transform.GetChild(Random.Range(7, 10)).gameObject.SetActive(true);
                        }
                        count++;
                    }
                }
            }
        }

    }
}
