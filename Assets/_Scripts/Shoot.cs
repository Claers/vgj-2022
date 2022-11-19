using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public int BPMShootDelay;
    public float inputDelay;

    public bool inBPM;

    public Object projectile;

    public GameObject shootPoint;

    public float zRotation;

    [Header("For Player")]
    public float lastInputTime;
    public float mercyDelay;
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


    void InvokeProjectile()
    {
        Instantiate<Object>(projectile, shootPoint.transform.position, Quaternion.Euler(0, 0, zRotation));
    }

    #region Player


    void MakePlayerShoot()
    {
        if (inBPM)
        {
            InvokeProjectile();
            inBPM = false;
            StopCoroutine(resetInBPMTrigger());
            lastInputTime = 0;
            return;
        }
        lastInputTime = Time.time;

    }


    public void inBPMTrigger()
    {
        inBPM = true;
        StartCoroutine(resetInBPMTrigger());
        if (lastInputTime != 0 && Time.time - lastInputTime < mercyDelay)
        {
            MakePlayerShoot();
        }
        else
        {
            lastInputTime = 0;
        }
    }

    public IEnumerator resetInBPMTrigger()
    {
        yield return new WaitForSeconds(inputDelay);
        inBPM = false;
    }


    #endregion


}
