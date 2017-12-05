using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{

  public static OpeningManager instance;

  public GameObject[] textToShow;

  void Awake()
  {
		for(int i=0; i<textToShow.Length; i++){
			textToShow[i].SetActive(false);
		}
    instance = GetComponent<OpeningManager>();
  }

  public void StartSequence()
  {
    StartCoroutine(showText());
  }
  IEnumerator showText()
  {
    textToShow[0].SetActive(true);
    yield return new WaitForSeconds(1f);
    textToShow[1].SetActive(true);
    yield return new WaitForSeconds(1);
    textToShow[2].SetActive(true);
  }
	
	public void skipSequence(){
		GameObject.Find("autoplayer").GetComponent<autowalk>().skip();
		for(int i=0; i<textToShow.Length; i++){
			textToShow[i].SetActive(true);
		}
	}

	public void StartGame(){
		SceneManager.LoadScene(1);
	}
}
