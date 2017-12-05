using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmotion : MonoBehaviour
{

  public void onUse()
  {
    StartCoroutine(use());
		CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
  }

  IEnumerator use()
  {
    GameManager.instance.timeSpeed = 0.3f;
    yield return new WaitForSeconds(5);
    GameManager.instance.timeSpeed = 1f;
		Destroy(gameObject);
  }
}
