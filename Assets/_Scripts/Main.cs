using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public UIManager UIManager { get; private set; }
    public GameManager GameManager { get; private set; }
    public SceneManager SceneManager { get; private set; }
    public CameraManager CameraManager { get; private set; }
    public PlayerInput Input { get; private set; }

    [field: SerializeField] public Player MainPlayer { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        AudioManager = GetComponentInChildren<AudioManager>();
        UIManager = GetComponentInChildren<UIManager>();
        GameManager = GetComponentInChildren<GameManager>();
        SceneManager = GetComponentInChildren<SceneManager>();
        CameraManager = GetComponentInChildren<CameraManager>();
        Input = GetComponent<PlayerInput>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // if (!SceneManager.loadedScenes.Contains(SceneManager.GetSceneByName(SceneManager.scenes.MainMenuScene)))
        // {
        //     SceneManager.LoadScene(SceneManager.scenes.MainMenuScene);
        // }
        LaunchGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaunchGame()
    {
        SceneManager.UnloadScene(SceneManager.scenes.MainMenuScene);
        GameManager.LoadGame();
        GameManager.PlayGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
