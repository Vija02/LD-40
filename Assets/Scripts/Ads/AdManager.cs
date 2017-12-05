using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour {

	bool shouldClose = false;

	//Actions when close-ad button is clicked
	public void onXClicked(){
		shouldClose = true;
		GameManager.instance.addScore(100);
	}
	//Actions when the Ad is clicked, instead of the close-ad button
	public void onYClicked(){
		GameManager.instance.createAd ();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(shouldClose && !GetComponent<AudioSource>().isPlaying){
			GameManager.instance.removeAd (gameObject);
		}
	}
}
