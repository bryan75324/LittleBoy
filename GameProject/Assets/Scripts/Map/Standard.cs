using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{
    public class Standard : MapElement
    {
        [SerializeField] private uint m_Width = 1;

        protected override void Awake()
        {
            base.Awake();

            m_SpriteRenderers = m_Display.GetComponentInChildren<SpriteRenderer>();
            m_BoxCollider2Ds = m_Display.GetComponentInChildren<BoxCollider2D>();
            m_OriginSize = m_SpriteRenderers.size;
        }

        private void OnEnable()
        {
            m_SpriteRenderers.size = Vector3.Scale(m_OriginSize, new Vector3(m_Width, 1.0f, 1.0f));
            m_BoxCollider2Ds.size = m_SpriteRenderers.size;
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(this.transform.position, Vector3.Scale(new Vector3(0.64f, 0.64f, 0.0f), new Vector3(m_Width, 1.0f, 1.0f)));
        }

        private Vector3 m_OriginSize;
        private SpriteRenderer m_SpriteRenderers;
        private BoxCollider2D m_BoxCollider2Ds;
    }
}