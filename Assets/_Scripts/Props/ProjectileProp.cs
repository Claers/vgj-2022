using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProjectileProp : MonoBehaviour
{
    public float speed;
    public float maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(transform.right * maxPosition, speed).SetEase(Ease.Linear).OnComplete(() => Object.Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
    }

}
