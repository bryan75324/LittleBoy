using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElement : MonoBehaviour
{
    public GameObject m_display;
    public AudioClip m_audioClip;

    protected virtual void Awake()
    {
        this.gameObject.tag = "Terrain";
        m_display = Instantiate(m_display, this.transform);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_audioClip != null)
        {
            AudioSource.PlayClipAtPoint(m_audioClip, this.transform.position);
        }
    }
}