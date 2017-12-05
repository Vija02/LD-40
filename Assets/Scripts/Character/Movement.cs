using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  //Movement elements
  public float speed = 1.5F;
  RectTransform canvasTransform;
  RectTransform playerTransform;
  public int facing = 1;
  Animator animator;

  void Awake()
  {
    canvasTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
    playerTransform = GameObject.Find("player").GetComponent<RectTransform>();
        animator = GetComponent<Animator> ();
  }

  void Update()
  {
    float x = transform.localPosition.x;

    if (Input.GetKey(KeyCode.A))
    {
      x -= speed;
      facing = -1;
      animator.SetBool("moving",true);
    }else if (Input.GetKey(KeyCode.D))
    {
      x += speed;
      facing = 1;
      animator.SetBool("moving",true);
    }else{
      animator.SetBool("moving",false);
    }

    x = Mathf.Clamp(x, -canvasTransform.rect.width / 2 + (playerTransform.rect.width / 2), canvasTransform.rect.width / 2 - (playerTransform.rect.width / 2));
    transform.localPosition = new Vector3(x, transform.localPosition.y, 0);
    transform.localScale = new Vector3(facing, 1, 1);
  }
}
