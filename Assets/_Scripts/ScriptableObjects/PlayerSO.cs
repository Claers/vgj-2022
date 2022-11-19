using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Player", menuName = "Custom/Characters/Players")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public int PlayerHealth { get; set; } = 3;
    [field: SerializeField] public int lowHealth { get; set; } = 1;

    [field: SerializeField] public float invenurabilityTime { get; set; } = 1;
    [field: SerializeField] public bool canBeTouched { get; set; } = true;



    [field: SerializeField] public Vector2 MovementInput { get; set; }
    [field: SerializeField] public float PlayerSpeed { get; set; }
    [field: SerializeField] public float maxDirectionHeight { get; set; }
    [field: SerializeField] public float maxDirectionWidth { get; set; }
    [field: SerializeField] public List<GameObject> healthBees { get; set; }

    [field: SerializeField] public Sprite lowHealthSprite { get; set; }
    [field: SerializeField] public Sprite normalHealthSprite { get; set; }


    [field: SerializeField] public List<ShootSO> shootDatas { get; set; }




}

