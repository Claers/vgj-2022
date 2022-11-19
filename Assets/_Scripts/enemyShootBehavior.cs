using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShootBehavior : MonoBehaviour
{





    [Header("Enemy stats")]
    public int _lifePoint;
    public float _speed;

    public Transform _target;

    public Transform _weapon;




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
        if (!CompareTag("Player")) return;
        AnglesRotation();


    }

    public void AnglesRotation()
    {
        float angle = Mathf.Atan2(_target.position.y - _weapon.position.y, _target.position.x - _weapon.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));
        _weapon.rotation = Quaternion.RotateTowards(_weapon.rotation, targetRotation, _speed * Time.deltaTime);

    }

}


