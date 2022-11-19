using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProjectileProp : MonoBehaviour
{
    public ProjectileSO projectileData;
    public DG.Tweening.Tween movementTween;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = projectileData.tag;
        Ray r = new Ray(transform.position, transform.right);
        movementTween = transform.DOMove(r.GetPoint(projectileData.maxDistance), projectileData.speed).SetEase(projectileData.easeType).OnComplete(() => Object.Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        movementTween.Kill();
        Destroy(this);
    }

}
