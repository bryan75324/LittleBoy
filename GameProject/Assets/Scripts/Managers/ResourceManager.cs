using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public static ResourceManager Instance;

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Object LoadObject(System.Type type, string name, string path)
    {
        Object o = AssetManager.Instance.GetAsset(type, name, path);
        if (o == null)
        {
            string fullPath = string.Format("{0}/{1}", path, name);
            o = Resources.Load(fullPath);
            AssetManager.Instance.AddAsset(type, name, path, o);
        }

        return o;
    }
}