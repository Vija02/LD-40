using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
  public GameObject score;
  public GameObject combo;

  Shooting shootingScript;

  TextMeshProUGUI scoreText;
  TextMeshProUGUI comboText;

  void Awake()
  {
    shootingScript = GameObject.Find("player").GetComponent<Shooting>();
    scoreText = score.GetComponent<TextMeshProUGUI>();
    comboText = combo.GetComponent<TextMeshProUGUI>();
  }

  void Update()
  {
    scoreText.text = GameManager.instance.score.ToString();
    comboText.text = shootingScript.combo == 0 ? "" : shootingScript.combo.ToString() + "X";
  }
}
