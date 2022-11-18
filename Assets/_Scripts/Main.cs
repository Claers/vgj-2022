using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
  public static Main Instance { get; private set; }
  public AudioManager AudioManager { get; private set; }
  public UIManager UIManager { get; private set; }
  public GameManager GameManager { get; private set; }
  public SceneManager SceneManager { get; private set; }
  private void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(this);
      return;
    }
    Instance = this;
    AudioManager = GetComponentInChildren<AudioManager>();
    UIManager = GetComponentInChildren<UIManager>();
    GameManager = GetComponentInChildren<GameManager>();
    SceneManager = GetComponentInChildren<SceneManager>();
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
