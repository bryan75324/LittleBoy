using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{
    public class MapElement : MonoBehaviour
    {
        public GameObject m_Display;

        protected virtual void Awake()
        {
            this.gameObject.tag = "Terrain";
            m_Display = Instantiate(m_Display, this.transform);
        }

        private void OnEnable()
        {
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
        }
    }
}