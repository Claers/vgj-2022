using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    public ScenesSO scenes;

    [SerializeField]
    public Scene actualLevel;

    public List<Scene> loadedScenes;



    private void Awake()
    {
        loadedScenes = UnityEngine.SceneManagement.SceneManager.GetAllScenes().ToList<Scene>();
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
        loadedScenes.Add(scene);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);
    }

    public void LoadScene(string scene)
    {
        loadedScenes.Add(GetSceneByName(scene));
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }

    public Scene GetSceneByName(string scene)
    {
        return UnityEngine.SceneManagement.SceneManager.GetSceneByName(scene);
    }

    public void ReloadScene()
    {
        UnloadScene(actualLevel);
        LoadScene(actualLevel);
    }

    public void SetActiveScene(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(scene);
    }

    public void UnloadScene(string scene)
    {
        loadedScenes.Remove(loadedScenes.Find((sc) => sc.name == scene));
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
    }

    public void UnloadScene(Scene scene)
    {
        loadedScenes.Remove(scene);
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
    }
}
