using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartTimeExocist.Extensions
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T m_Instance;
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    m_Instance = obj.AddComponent<T>();
                }


                return m_Instance;
            }
        }

        private void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}


