using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomAdManager : MonoBehaviour
{
  void Start()
  {
    Transform backgroundTransform = transform.GetChild(0).GetChild(0);
    TextMeshProUGUI textMesh = backgroundTransform.GetChild(0).GetComponent<TextMeshProUGUI>();
    textMesh.text = AdGenerator.generateAd();

    float r = Random.Range(0, 200) / 255f;
    float g = Random.Range(0, 200) / 255f;
    float b = Random.Range(0, 200) / 255f;
    textMesh.color = new Color(
      r > 0.5 ? 0 : 1,
      g > 0.5 ? 0 : 1,
      b > 0.5 ? 0 : 1
    );

    backgroundTransform.GetComponent<RawImage>().color = new Color(r, g, b);
  }
  public void randomizeSize()
  {
    float width = Random.Range(150, 350);
    float height = Random.Range(100, 300);
    GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
  }
}
