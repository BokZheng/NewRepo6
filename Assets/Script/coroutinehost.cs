using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutinehost : MonoBehaviour
{
    public static coroutinehost Instance
    {
        get 
        {
            if (m_Instance == null)
            {
                m_Instance = (coroutinehost)FindAnyObjectByType(typeof(coroutinehost));

                if (m_Instance == null)
                {
                    GameObject go = new GameObject();
                    m_Instance = go.AddComponent<coroutinehost>();
                }

                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }
    private static coroutinehost m_Instance = null;
}
