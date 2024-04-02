using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public int CurrentLevel = 0;
    public static gamemanager Instance
    { 
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (gamemanager)FindAnyObjectByType(typeof(gamemanager));

                if (m_Instance == null)
                {
                    GameObject go = new GameObject();
                    m_Instance = go.AddComponent<gamemanager>();
                }
                DontDestroyOnLoad(m_Instance.gameObject);
            }

            return m_Instance;
        }
    }
    private static gamemanager m_Instance = null;

    public void GoToNextLevel()
    {
        CurrentLevel++;
        SceneManager.LoadScene(CurrentLevel);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
