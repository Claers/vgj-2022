using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.Object HUDScene;
    [SerializeField]
    public UnityEngine.Object PlayerScene;
    [SerializeField]
    public UnityEngine.Object MainMenuScene;
    [SerializeField]
    public UnityEngine.Object PauseScene;

    [SerializeField]
    public List<UnityEngine.Object> LevelScenes;
    [SerializeField]
    public Scene actualLevel;


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
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.name);
    }

    public void LoadScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);
    }

    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(actualLevel);
        LoadScene(actualLevel);
    }

    public void SetActiveScene(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(scene);
    }
}
