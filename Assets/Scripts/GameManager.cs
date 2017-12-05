using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  public GameObject[] PowerUpGameObject;

  public GameObject[] SpecialPopupAdGameObject;
  public GameObject AdsGameObject;
  public GameObject PopupAdHolder;

  public GameObject[] SpecialEmbededAdGameObject;
  public GameObject EmbededAdsGameObject;
  public GameObject EmbededAdHolder;

  GameObject canvas;
  RectTransform canvasTransform;

  public int adsCount = 0;
  float timeSinceLastSpawnPopup = 0;
  float timeSinceLastSpawnEmbeded = 0;

  public float timeSurvived = 0;

  public int score = 0;

  public float timeSpeed = 1;

  void Awake()
  {
    instance = gameObject.GetComponent<GameManager>();
    canvas = GameObject.Find("Canvas");
    canvasTransform = canvas.GetComponent<RectTransform>();
  }

  void Start()
  {
    createAd();
  }

  void Update()
  {
    timeSurvived += Time.deltaTime * timeSpeed;
    handlePopup();
    handleEmbeded();
  }

  void handlePopup()
  {
    timeSinceLastSpawnPopup += Time.deltaTime * timeSpeed;
    // float adsPerSecond = (float)0.1f * adsCount + 1;
    float adsPerSecond = Mathf.Pow(1.035f, adsCount);

    if (timeSinceLastSpawnPopup >= 1 / adsPerSecond)
    {
      createAd();
      timeSinceLastSpawnPopup = 0;
    }
  }

  void handleEmbeded()
  {
    timeSinceLastSpawnEmbeded += Time.deltaTime * timeSpeed;
    // float adsPerSecond = (float)0.1f * adsCount + 1;
    //float adsPerSecond = Mathf.Pow(1.035f, adsCount);
    // float adsPerSecond = 0.5f + (adsCount / 10);
    float adsPerSecond = 0.25f + (adsCount / 20f) + Mathf.Clamp((0.035f * timeSurvived) - 1.05f, 0, Mathf.Infinity);

    if (timeSinceLastSpawnEmbeded >= 1 / adsPerSecond)
    {
      createEmbededAd();
      timeSinceLastSpawnEmbeded = 0;
    }
  }

  public void addScore(int s)
  {
    score += s;
  }

  public static void loadLose()
  {
    ScoreManager.score = GameManager.instance.score;
    SceneManager.LoadScene(2);
  }

  public GameObject createEmbededAd()
  {
    GameObject ads = GameObject.Instantiate(EmbededAdsGameObject);
    ads.transform.SetParent(EmbededAdHolder.transform, true);
    positionAdsRandomly(ads, canvasTransform.rect.height + ads.transform.localPosition.y);

    return ads;
  }

  public GameObject createAd()
  {
    handlePowerUp();

    GameObject adsToSpawn = AdsGameObject;
    if (Random.Range(0, 100) < 20 + (timeSurvived * 0.3f - 10) && SpecialPopupAdGameObject.Length > 0)
    {
      adsToSpawn = SpecialPopupAdGameObject[Random.Range(0, SpecialPopupAdGameObject.Length)];
    }
    GameObject ads = GameObject.Instantiate(adsToSpawn);
    ads.transform.SetParent(PopupAdHolder.transform, true);
    if (adsToSpawn == AdsGameObject)
    {
      ads.GetComponent<RandomAdManager>().randomizeSize();
    }
    positionAdsRandomly(ads);

    adsCount++;
    return ads;
  }

  public void removeAd(GameObject ad)
  {
    Destroy(ad);
    adsCount--;
  }

  void positionAdsRandomly(GameObject ads)
  {
    float width = canvasTransform.rect.width;
    float height = canvasTransform.rect.height;

    RectTransform adsTransform = ads.transform.GetChild(0).transform.GetComponent<RectTransform>();
    float locationX = Random.Range(-width / 2 + adsTransform.rect.width / 2, width / 2 - adsTransform.rect.width / 2);
    float locationY = Random.Range(-height / 2 + adsTransform.rect.height / 2, height / 2 - adsTransform.rect.height / 2);
    ads.GetComponent<RectTransform>().localPosition = new Vector3(locationX, locationY);
  }
  void positionAdsRandomly(GameObject ads, float y)
  {
    float width = canvasTransform.rect.width;

    // RectTransform adsTransform = ads.transform.GetComponent<RectTransform>();
    float locationX = Random.Range(-width / 2, width / 2);
    ads.GetComponent<RectTransform>().localPosition = new Vector3(locationX, y);
  }

  void handlePowerUp()
  {
    if (PowerUpGameObject.Length > 0 && Random.Range(0, 100) < 5)
    {
      GameObject powerUp = GameObject.Instantiate(PowerUpGameObject[Random.Range(0, PowerUpGameObject.Length)]);
      powerUp.transform.SetParent(PopupAdHolder.transform, true);
      positionAdsRandomly(powerUp);
    }
  }
}
