using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmbededAds : MonoBehaviour
{
  public Sprite[] spriteList;

  float movespeed = 100.0f;
  int adsCount = 0;

  RectTransform rectTransform;
  RectTransform playerTransform;

  void Awake()
  {
    rectTransform = GetComponent<RectTransform>();
    playerTransform = GameObject.Find("player").GetComponent<RectTransform>();
  }
  void Start()
  {
    if (spriteList.Length > 0)
    {
      GetComponent<Image>().sprite = spriteList[Random.Range(0, spriteList.Length)];
    }
    adsCount = GameManager.instance.adsCount;
    //speed = number of ads* ratio
    movespeed = Mathf.Max(movespeed, movespeed * (adsCount / 8));
  }

  // Update is called once per frame
  void Update()
  {
    checkUser();
    checkOutOfScreen();
    //Different speed properties for ads
    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - (Time.deltaTime * movespeed * GameManager.instance.timeSpeed), 0);
  }

  public void removeEmbededAd()
  {
    Destroy(gameObject);
  }

  void checkUser()
  {
    if (transform.position.y + rectTransform.rect.height / 2 > playerTransform.position.y - playerTransform.rect.height / 2 &&
                transform.position.y - rectTransform.rect.height / 2 < playerTransform.position.y + playerTransform.rect.height / 2)
    {
      if (playerTransform.position.x + playerTransform.rect.width / 2 > rectTransform.position.x - rectTransform.rect.width / 2 &&
              playerTransform.position.x - playerTransform.rect.width / 2 < rectTransform.position.x + rectTransform.rect.width / 2)
      {
        GameManager.loadLose();
      }
    }
  }
  void checkOutOfScreen()
  {
    if (transform.position.y + rectTransform.rect.height / 2 < 0)
    {
      removeEmbededAd();
    }
  }
}
