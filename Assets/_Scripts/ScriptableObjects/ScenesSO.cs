using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Scenes", menuName = "Custom/Scenes")]
public class ScenesSO : ScriptableObject
{
    [field: SerializeField]
    public string HUDScene;
    [field: SerializeField]
    public string PlayerScene;
    [field: SerializeField]
    public string MainMenuScene;
    [field: SerializeField]
    public string PauseScene;

    [field: SerializeField]
    public List<string> LevelScenes;

    [field: SerializeField]
    public List<string> CinematicScenes;



}

