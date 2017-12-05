using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

  float shake = 0;
  float shakeAmount = 4f;
  float decreaseFactor = 1.0f;

  void Update()
  {
    if (shake > 0)
    {
      transform.localPosition = Random.insideUnitSphere * shakeAmount;
      shake -= Time.deltaTime * decreaseFactor;
    }
    else
    {
      shake = 0.0f;
    }
  }

	public void shakeFor(float second){
		shake = second;
		GetComponent<AudioSource>().Play();
	}
}
