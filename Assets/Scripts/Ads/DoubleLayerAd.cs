using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLayerAd : MonoBehaviour {

  public GameObject areYouSurePanel;

  public void XClicked(){
    areYouSurePanel.GetComponent<CanvasGroup>().alpha = 1;
    areYouSurePanel.GetComponent<CanvasGroup>().interactable = true;
    areYouSurePanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
  }
  public void yesClicked(){
    GetComponent<AudioSource>().Play();
    GetComponent<AdManager>().onXClicked();
  }
  public void noClicked(){
    areYouSurePanel.GetComponent<CanvasGroup>().alpha = 0;
    areYouSurePanel.GetComponent<CanvasGroup>().interactable = false;
    areYouSurePanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
  }

}
