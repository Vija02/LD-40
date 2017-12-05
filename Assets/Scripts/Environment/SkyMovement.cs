using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
{
    RectTransform canvasTransform;
    RectTransform playerTransform;

    void Awake()
    {
        canvasTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        playerTransform = GameObject.Find("player").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = playerTransform.localPosition.x;
        float x = (-playerX) * (playerTransform.rect.width/canvasTransform.rect.width);
        transform.localPosition = new Vector3(x, transform.localPosition.y, 0);
    }
}
