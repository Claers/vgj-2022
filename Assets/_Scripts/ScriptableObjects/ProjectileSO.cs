using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[Serializable]
[CreateAssetMenu(fileName = "Projectile", menuName = "Custom/Props/Projectile")]
public class ProjectileSO : ScriptableObject
{
    [field: SerializeField] public int speed { get; set; } = 3;
    [field: SerializeField] public int scale { get; set; } = 1;
    [field: SerializeField] public int maxDistance { get; set; } = 20;
    [field: SerializeField] public Ease easeType { get; set; } = Ease.Linear;

    [field: SerializeField] public string tag;
    [field: SerializeField] public UnityEngine.Object prefab;



}

