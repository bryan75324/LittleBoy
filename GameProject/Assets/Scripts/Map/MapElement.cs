using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapSystem
{
    public class MapElement : MonoBehaviour
    {
        [SerializeField] private AudioClip m_Sound;

        protected virtual void Awake()
        {
            m_Display = ResourceManager.Instance.LoadObject(typeof(GameObject), "ME_001", "MapElement/Prefabs/MapElement") as GameObject;
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
            SoundEffect();
        }

        private void SoundEffect()
        {
        }

        protected GameObject m_Display;
    }
}