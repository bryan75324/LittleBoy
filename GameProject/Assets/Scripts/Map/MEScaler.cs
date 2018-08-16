using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEScaler : MonoBehaviour
{
    [SerializeField] private int m_Width;

    public int Width
    {
        get { return m_Width; }
        set
        {
            m_Width = (value < 1) ? 1 : value;
        }
    }

    private void Awake()
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            RendererData rendererData = new RendererData()
            {
                Renderer = sr,
                Size = sr.size
            };
            m_RendererDatas.Add(rendererData);
        }

        BoxCollider2D[] boxCollider2Ds = GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D bc in boxCollider2Ds)
        {
            ColliderData colliderData = new ColliderData()
            {
                Collider = bc,
                size = bc.size
            };
            m_ColliderDatas.Add(colliderData);
        }
    }

    public void Resize(int width)
    {
        Width = width;

        foreach (RendererData rd in m_RendererDatas)
        {
            rd.Renderer.size = Vector2.Scale(rd.Size, m_Size);
        }

        foreach (ColliderData cd in m_ColliderDatas)
        {
            cd.Collider.size = Vector2.Scale(cd.size, m_Size);
        }
    }

    private Vector2 m_Size { get { return new Vector2(m_Width, 1.0f); } }
    private List<RendererData> m_RendererDatas = new List<RendererData>();
    private List<ColliderData> m_ColliderDatas = new List<ColliderData>();

    private class RendererData
    {
        public SpriteRenderer Renderer { get; set; }
        public Vector2 Size { get; set; }
    }

    private class ColliderData
    {
        public BoxCollider2D Collider { get; set; }
        public Vector2 size { get; set; }
    }
}