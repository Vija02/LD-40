using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
public GameObject ScoreHolder;
	public static int score = 0;

	void Start () {
		ScoreHolder.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
	}
	
	void Update () {
		
	}
}
