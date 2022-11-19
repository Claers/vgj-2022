using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.Object HUDScene;
    [SerializeField]
    public Scene PlayerScene;
    public Scene MainMenuScene;
    public Scene PauseScene;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }
}
