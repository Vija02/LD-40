using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
  static bool AudioBegin = false;

  static float originalVolume = 0;
  static float targetVolume = 1;
  static float interpolator = 0;

  static float originalPitch = 0;
  static float targetPitch = 0;
  static float pitchInterpolator = 0;
  static bool pitching = false;

  static AudioSource audio;

  void Awake()
  {
    if (!AudioBegin)
    {
      audio = GetComponent<AudioSource>();
      audio.Play();
      DontDestroyOnLoad(gameObject);
      AudioBegin = true;
    }
  }

  void Update()
  {
    targetPitch = GameManager.instance ? Mathf.Clamp(GameManager.instance.timeSpeed, 0.9f, 1) : 1;
    if (audio.pitch != targetPitch)
    {
      if (audio.pitch != targetPitch)
      {
        if (!pitching)
        {
          originalPitch = audio.pitch;
        }
        pitching = true;

        pitchInterpolator += 0.1f;
        audio.pitch = Mathf.Lerp(originalPitch, targetPitch, pitchInterpolator);
      }
      else
      {
        pitching = false;
      }
    }

    if (audio.volume != targetVolume)
    {
      interpolator += 0.1f;
      audio.volume = Mathf.Lerp(originalVolume, targetVolume, interpolator);
    }
    if (SceneManager.GetActiveScene().buildIndex == 2)
    {
      originalVolume = audio.volume;
      targetVolume = 0.3f;
      interpolator = 0;
    }
    else
    {
      originalVolume = audio.volume;
      targetVolume = 1f;
      interpolator = 0;
    }
  }
}
