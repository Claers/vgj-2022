using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum State
{
  playing,
  paused,

}
public class GameManager : MonoBehaviour
{
  public State state;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
