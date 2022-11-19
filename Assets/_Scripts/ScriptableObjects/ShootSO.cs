using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ShootType", menuName = "Custom/Characters/ShootType")]
public class ShootSO : ScriptableObject
{
    [field: SerializeField] public ProjectileSO projectileType { get; set; }
    [field: SerializeField] public Vector3 shootOffset { get; set; }
    [field: SerializeField] public float shootZRotation { get; set; }
    [field: SerializeField] public int BPMDelay { get; set; }
    [field: SerializeField] public float inputDelay { get; set; }
    [field: SerializeField] public float mercyDelay { get; set; }


}

