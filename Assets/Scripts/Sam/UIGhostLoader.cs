using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace PartTimeExocist
{
    public class UIGhostLoader : MonoBehaviour
    {
        [System.Serializable]
        private class GhostBook
        {
            public int id;
            public string name = "???";
            public string description;
            public EnemyScriptableObject scriptableObject;
        }

        [SerializeField] private GameObject ghostBookPrefab;
        [SerializeField] private Transform ghostBookParent;
        [SerializeField] private List<GhostBook> ghostBooks = new List<GhostBook>();

        private List<GhostBook> m_SpawnedObjects = new List<GhostBook>();

        public void CreateBooks()
        {
            if (ghostBookPrefab != null)
            {
                foreach (GhostBook book in ghostBooks)
                {
                    if(m_SpawnedObjects.Contains(book)) return;

                    Debug.Log(book.scriptableObject.isUnlocked);

                    GameObject b = Instantiate(ghostBookPrefab, ghostBookParent);


                    if (book.scriptableObject.isUnlocked)
                    {
                        b.GetComponentInChildren<TMPro.TMP_Text>().text = book.name + "\n" + book.description;
                    }

                    m_SpawnedObjects.Add(book);
                }
            }
            else
            {
                Debug.LogError("ghostBookPrefab is null: please assign it in the inspector");
            }
        }
    }
}


