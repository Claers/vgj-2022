using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyData;

    [Header("Enemy stats")]
    public int enemyHealth;
    public Transform weapon;

    public bool isPlayerInRange;

    private void Awake()
    {
        enemyHealth = enemyData.enemyHealth;
        foreach (ShootSO shoot in enemyData.shootDatas)
        {
            Shoot shootComp = gameObject.AddComponent<Shoot>();
            shootComp.shootData = shoot;
            GetComponent<GameEventListener>().customEvents += shootComp.inBPMTriggerEnemy;
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

    void OnTriggerEnter()
    {


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        AnglesRotation(other.gameObject);
        isPlayerInRange = true;
    }

    public void AnglesRotation(GameObject player)
    {
        float angle = Mathf.Atan2(player.transform.position.y - weapon.position.y, player.transform.position.x - weapon.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));
        weapon.rotation = Quaternion.RotateTowards(weapon.rotation, targetRotation, enemyData.aimSpeed * Time.deltaTime);

    }

}


