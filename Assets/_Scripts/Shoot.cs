using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public ShootSO shootData;

    public bool inBPM;
    public int BPMShoot;

    [Header("For Player")]
    public float lastInputTime;
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

        GameObject projectile = Instantiate<Object>(shootData.projectileType.prefab, transform.position + shootData.shootOffset, Quaternion.Euler(0, 0, shootData.shootZRotation)) as GameObject;
        projectile.GetComponent<ProjectileProp>().projectileData = shootData.projectileType;
        projectile.transform.SetParent(transform.parent, true);
        if (GetComponent<Enemy>())
        {
            projectile.GetComponent<ProjectileProp>().direction = -GetComponent<Enemy>().weapon.right;
            projectile.GetComponent<ProjectileProp>().angle = GetComponent<Enemy>().weapon.rotation;
        }
    }

    public void inBPMTriggerEnemy()
    {
        if (!GetComponent<Enemy>().isPlayerInRange) return;
        if (BPMShoot < shootData.BPMDelay)
        { BPMShoot++; return; };
        InvokeProjectile();
        BPMShoot = 0;
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


    public void inBPMTriggerPlayer()
    {
        inBPM = true;
        StartCoroutine(resetInBPMTrigger());
        if (lastInputTime != 0 && Time.time - lastInputTime < shootData.mercyDelay)
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
        yield return new WaitForSeconds(shootData.inputDelay);
        inBPM = false;
    }


    #endregion


}
