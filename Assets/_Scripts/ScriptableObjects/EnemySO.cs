using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "Custom/Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public int enemyHealth { get; set; } = 3;

    [field: SerializeField] public float aimSpeed { get; set; }

    [field: SerializeField] public List<GameObject> shootPoints { get; set; }
    [field: SerializeField] public List<ProjectileSO> projectileTypes { get; set; }




}

