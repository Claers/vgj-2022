using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProjectileProp : MonoBehaviour
{
    public ProjectileSO projectileData;
    public DG.Tweening.Tween movementTween;

    public Vector3 direction;
    public Quaternion angle;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = projectileData.tag;
        Ray r = new Ray(transform.position, transform.right);
        if (direction != Vector3.zero)
        {
            r = new Ray(transform.position, direction);
        }
        movementTween = transform.DOMove(r.GetPoint(projectileData.maxDistance), projectileData.speed).SetEase(projectileData.easeType).OnComplete(() => Object.Destroy(gameObject));
        transform.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Destructible") || other.CompareTag("Obstacles"))
        {
            movementTween.Kill();
            Destroy(gameObject);
        }
    }

}
