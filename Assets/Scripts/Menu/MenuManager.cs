using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void StartGame(){
		SceneManager.LoadScene(3);
	}

	public void LoadScene(int index){
		SceneManager.LoadScene(index);
	}

	public void MainMenu(){
		SceneManager.LoadScene(0);
	}

	public void Restart(){
		SceneManager.LoadScene(1);
	}

	public void CloseGame(){
		Application.Quit();
	}

	public void TogglePanelVisibility(GameObject panel){
		CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
		if(!canvasGroup){ // If not there
			canvasGroup = panel.AddComponent<CanvasGroup>();
		}

		if(canvasGroup.alpha == 1){
			canvasGroup.alpha = 0;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}else{
			canvasGroup.alpha = 1;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
	}

}
