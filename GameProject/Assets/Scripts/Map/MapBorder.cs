using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorder : MonoBehaviour
{
    public Camera gameCamera;
    public BoxCollider2D topCollider;
    public BoxCollider2D bottomCollider;
    public BoxCollider2D leftCollider;
    public BoxCollider2D rightCollider;

    // Use this for initialization
    private void Start()
    {
        if (gameCamera == null) gameCamera = Camera.main;

        this.transform.position = CameraPosition;

        InitBorderPosSize();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameCamera != null)
            this.transform.position = CameraPosition;
    }

    private void InitBorderPosSize()
    {
        float CameraHeight = gameCamera.pixelHeight;
        float CameraWidth = gameCamera.pixelWidth;
        float CameraScale = gameCamera.orthographicSize / 6.4f;

        Vector3 topPos = gameCamera.ScreenToWorldPoint(new Vector2(CameraWidth * 0.5f, CameraHeight));
        topPos.z = 0.0f;
        topCollider.transform.position = topPos;

        Vector3 bottomPos = gameCamera.ScreenToWorldPoint(Vector2.right * (CameraWidth * 0.5f));
        bottomPos.z = 0.0f;
        bottomCollider.transform.position = bottomPos;

        Vector3 rightPos = gameCamera.ScreenToWorldPoint(new Vector2(CameraWidth, CameraHeight * 0.5f));
        rightPos.z = 0.0f;
        rightCollider.transform.position = rightPos;

        Vector3 leftPos = gameCamera.ScreenToWorldPoint(Vector2.up * (CameraHeight * 0.5f));
        leftPos.z = 0.0f;
        leftCollider.transform.position = leftPos;

        Vector2 TBBorderSize = new Vector2(CameraWidth * 0.01f * CameraScale, 1.0f);
        topCollider.size = TBBorderSize;
        bottomCollider.size = TBBorderSize;

        Vector2 LRBorderSize = new Vector2(1.0f, CameraHeight * 0.01f * CameraScale);
        rightCollider.size = LRBorderSize;
        leftCollider.size = LRBorderSize;
    }

    private Vector2 CameraPosition { get { return gameCamera.transform.position; } }
}