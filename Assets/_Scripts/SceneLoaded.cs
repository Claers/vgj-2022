using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaded : MonoBehaviour
{
    public GameEvent OnSceneLoaded;
    // Start is called before the first frame update
    void Start()
    {
        OnSceneLoaded.Raise();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
