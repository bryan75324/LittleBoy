using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElement : MonoBehaviour
{
    [SerializeField] private uint m_width;

    private void Awake()
    {
        m_Display = Resources.Load("MapElement/Prefabs/MapElement/ME_001") as GameObject;
        Instantiate(m_Display, this.transform);
    }

    // Use this for initialization
    private void Start()
    {
        m_SpriteRenderers = m_Display.GetComponentInChildren<SpriteRenderer>();
        m_BoxCollider2Ds = m_Display.GetComponentInChildren<BoxCollider2D>();
        m_SpriteRenderers.size = Vector3.Scale(m_SpriteRenderers.size, new Vector3(m_width, 1.0f, 1.0f));
        m_BoxCollider2Ds.size = m_SpriteRenderers.size;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, Vector3.Scale(unit, new Vector3(m_width, 1.0f, 1.0f)));
    }

    private Vector3 unit = new Vector3(0.64f, 0.64f, 0.0f);
    private GameObject m_Display;
    private SpriteRenderer m_SpriteRenderers;
    private BoxCollider2D m_BoxCollider2Ds;
}