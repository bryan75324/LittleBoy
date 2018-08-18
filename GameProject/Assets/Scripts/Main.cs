using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public Camera gameCamera;
    public float scrollSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }

        m_AssetManager = new AssetManager();
        m_AssetManager.Start();
        m_ResourceManager = new ResourceManager();
        m_ResourceManager.Start();
    }

    // Use this for initialization
    private void Start()
    {
        if (gameCamera == null) gameCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        gameCamera.transform.position += Vector3.down * scrollSpeed;
    }

    private AssetManager m_AssetManager;
    private ResourceManager m_ResourceManager;
}