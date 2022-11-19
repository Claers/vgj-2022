using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProjectileProp : MonoBehaviour
{
    public ProjectileSO projectileData;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = projectileData.tag;
        Ray r = new Ray(transform.position, transform.right);
        Debug.Log(r.GetPoint(projectileData.maxDistance));
        transform.DOMove(r.GetPoint(projectileData.maxDistance), projectileData.speed).SetEase(projectileData.easeType).OnComplete(() => Object.Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this);
    }

}
