using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
  public int BPMShootDelay;
  public float inputDelay;

  public bool inBPM;
  private void OnEnable()
  {
    if (GetComponent<Player>())
    {
      Player.onPlayerShoot += MakePlayerShoot;
    }
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  void MakePlayerShoot()
  {
    if (inBPM)
    {
      Debug.Log("Shoot");
      inBPM = false;
      StopCoroutine(resetInBPMTrigger());
    }
  }

  public void inBPMTrigger()
  {
    inBPM = true;
    StartCoroutine(resetInBPMTrigger());
  }

  public IEnumerator resetInBPMTrigger()
  {
    yield return new WaitForSeconds(inputDelay);
    inBPM = false;
  }


}
