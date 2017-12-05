using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class autowalk : MonoBehaviour
{

  float duration = 2.0f;

  float speed = 3F;

  RectTransform canvasTransform;

  bool shouldWalk = true;

  void Awake()
  {
    canvasTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
  }
  void Start()
  {
    float distance = canvasTransform.rect.width / 2 + GetComponent<RectTransform>().rect.width/2;
    speed = distance / duration;
    StartCoroutine(stopWalk(duration));
  }
  void Update()
  {
    if (shouldWalk)
    {
      transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed * Time.deltaTime, -Mathf.Infinity, canvasTransform.position.x), transform.position.y, 0);
    }
  }

	public void skip(){
		shouldWalk = false;
		transform.position = new Vector3(canvasTransform.position.x, transform.position.y, 0);
	}

  IEnumerator stopWalk(float duration)
  {
    yield return new WaitForSeconds(duration);
    shouldWalk = false;
		GetComponent<Animator>().SetBool("shouldWalk", false);

		OpeningManager.instance.StartSequence();
  }
}
