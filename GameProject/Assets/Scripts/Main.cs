using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public Transform mapRoot;
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
        if (mapRoot == null)
        {
            mapRoot = GameObject.Find("MapRoot").transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (mapRoot != null)
        {
            mapRoot.position += Vector3.up * scrollSpeed;
        }
    }

    private AssetManager m_AssetManager;
    private ResourceManager m_ResourceManager;
}