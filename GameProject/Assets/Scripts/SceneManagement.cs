using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private static SceneManagement m_Instance;
    public static SceneManagement Instance { get { return m_Instance; } }

    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else if (m_Instance != this)
            Destroy(this.gameObject);
    }

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadNextScene()
    {
    }
}