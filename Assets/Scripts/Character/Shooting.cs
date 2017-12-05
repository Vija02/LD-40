using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
  public GameObject laser;

  RectTransform playerTransform;
  RectTransform canvasTransform;
  GameObject adsHolderGameObject;
	Movement movement;
  GraphicRaycaster gr;

  public int combo = 0;

  
  void Start()
  {
		movement = GetComponent<Movement>();
    playerTransform = GameObject.Find("player").GetComponent<RectTransform>();
    canvasTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
    adsHolderGameObject = GameObject.Find("Ads Holder");

    gr = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
  }

  void shoot()
  {
    float currentPoint = playerTransform.position.x;
    while (currentPoint < canvasTransform.rect.width && currentPoint > 0)
    {
      PointerEventData ped = new PointerEventData(null);

      ped.position = new Vector2(currentPoint, playerTransform.position.y);

      List<RaycastResult> result = new List<RaycastResult>();

      gr.Raycast(ped, result);
      for (int i = 0; i < result.Count; i++)
      {
        if (result[i].gameObject.CompareTag("Embeded"))
        {
          combo++;
          GameManager.instance.addScore(200 + Mathf.RoundToInt((1.4f * Mathf.Pow(combo, 2))));
					Destroy (result [i].gameObject);
          playShootingAnimation(currentPoint);
          return;
        }
      }

      currentPoint += 5 * movement.facing;
    }
    playShootingAnimation(canvasTransform.position.x + (canvasTransform.rect.width/2 * movement.facing));
    combo = 0;
    adsHolderGameObject.GetComponent<Shake>().shakeFor(0.15f);
  }

  void playShootingAnimation(float hitGlobalLocationX){
    GameObject laserInstance = Instantiate(laser, transform.position, Quaternion.identity);
    laserInstance.transform.SetParent(canvasTransform, true);

    RectTransform laserTransform = laserInstance.GetComponent<RectTransform>();
    laserTransform.sizeDelta = new Vector2(Mathf.Abs(hitGlobalLocationX - transform.position.x), laserTransform.rect.height);
    laserTransform.position = new Vector3(transform.position.x + (laserTransform.rect.width/2 * movement.facing), laserTransform.position.y, 0);
    laserTransform.localScale = new Vector3(movement.facing, 1, 1);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GetComponent<AudioSource>().Play();
      shoot();
    }
  }
}
