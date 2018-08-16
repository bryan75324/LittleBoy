using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{
    public class MEStandard : MapElement
    {
        [SerializeField] private int m_Width = 1;

        protected override void Awake()
        {
            base.Awake();

            m_MEScaler = m_Display.AddComponent<MEScaler>();
        }

        private void OnEnable()
        {
            m_MEScaler.Resize(m_Width);
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

        private MEScaler m_MEScaler;
    }
}