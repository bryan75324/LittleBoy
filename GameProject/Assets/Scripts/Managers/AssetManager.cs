using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager
{
    public static AssetManager Instance;

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        m_AssetMap = new Dictionary<System.Type, List<AssetData>>();
    }

    /// <summary>
    /// Add asset to the asset cache.
    /// If the asset is already exist, then return false.
    /// </summary>
    public bool AddAsset(System.Type type, string name, string path, Object o)
    {
        List<AssetData> pList;
        if (_FindAssetDataList(type, out pList) == false)
        {
            pList = new List<AssetData>();
            m_AssetMap.Add(type, pList);
        }
        else
        {
            if (_IsAssetDataExist(pList, name, path) == true) return false;
        }

        AssetData newData = new AssetData()
        {
            Asset = o,
            Name = name,
            Path = path
        };
        pList.Add(newData);
        return true;
    }

    /// <summary>
    /// Get asset for he asset cache.
    /// If the asset is not exist, then return null.
    /// </summary>
    public Object GetAsset(System.Type type, string name, string path)
    {
        List<AssetData> pList;
        if (_FindAssetDataList(type, out pList) == false) return null;

        for (int i = 0; i < pList.Count; i++)
        {
            if (pList[i].Name.Equals(name) && pList[i].Path.Equals(path))
            {
                return pList[i].Asset;
            }
        }
        return null;
    }

    /// <summary>
    /// Clear the asset cache.
    /// And unload unused assets.
    /// </summary>
    public void Clear()
    {
        foreach (var datas in m_AssetMap)
        {
            datas.Value.Clear();
        }

        m_AssetMap.Clear();
        Resources.UnloadUnusedAssets();
    }

    private bool _IsAssetDataExist(List<AssetData> pList, string name, string path)
    {
        foreach (AssetData data in pList)
        {
            if (data.Name.Equals(name) && data.Path.Equals(path))
                return true;
        }

        return false;
    }

    private bool _FindAssetDataList(System.Type type, out List<AssetData> datas)
    {
        if (m_AssetMap.ContainsKey(type) == false)
        {
            datas = null;
            return false;
        }
        else
        {
            datas = m_AssetMap[type];
            return true;
        }
    }

    private Dictionary<System.Type, List<AssetData>> m_AssetMap;

    public class AssetData
    {
        public Object Asset { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}