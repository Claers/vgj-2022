using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[Serializable]
public enum State
{
    playing,
    paused,
    cinematic,
    mainMenu

}
public class GameManager : MonoBehaviour
{
    public State state;




    // Start is called before the first frame update
    void Start()
    {
        state = State.mainMenu;
        Main.Instance.Input.PlayerActions.Move.Disable();
        Main.Instance.Input.PlayerActions.Shoot.Disable();
        Main.Instance.Input.MenuActions.Pause.started += PauseGameInput;
        Main.Instance.Input.MenuActions.Next.started += PlayGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (Main.Instance.MainPlayer.Data.PlayerHealth <= 0)
        {
            GameOver();
        }
    }

    void PauseGameInput(InputAction.CallbackContext context)
    {
        PauseGame();
    }

    void PauseGame()
    {
        state = State.paused;
        Main.Instance.Input.PlayerActions.Move.Disable();
        Main.Instance.Input.PlayerActions.Shoot.Disable();
        Time.timeScale = 0;
    }

    void PlayGame(InputAction.CallbackContext context)
    {
        state = State.playing;
        Main.Instance.SceneManager.LoadScene(Main.Instance.PlayerScene);
        Main.Instance.Input.MenuActions.Next.started -= PlayGame;
        Main.Instance.Input.PlayerActions.Move.Enable();
        Main.Instance.Input.PlayerActions.Shoot.Enable();
        Time.timeScale = 1;
        Main.Instance.MainPlayer.Data.PlayerHealth = 3;
    }

    void GameOver()
    {
        PauseGame();
        Main.Instance.Input.MenuActions.Next.started += ReloadSceneInput;
    }

    void ReloadSceneInput(InputAction.CallbackContext context)
    {
        Main.Instance.SceneManager.ReloadScene();
        Main.Instance.Input.MenuActions.Next.started -= ReloadSceneInput;
        Main.Instance.Input.MenuActions.Next.started += PlayGame;
    }




}
