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

    public int lvlNb = 0;




    // Start is called before the first frame update
    void Start()
    {
        state = State.mainMenu;
        Main.Instance.Input.PlayerActions.Move.Disable();
        Main.Instance.Input.PlayerActions.Shoot.Disable();
        Main.Instance.Input.MenuActions.Pause.started += PauseGameInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.playing)
        {
            if (Main.Instance.MainPlayer.Data.PlayerHealth <= 0)
            {
                GameOver();
            }
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

    void PlayGameInput(InputAction.CallbackContext context)
    {
        PlayGame();
    }

    public void LoadGame()
    {
        Main.Instance.SceneManager.LoadScene(Main.Instance.SceneManager.scenes.PlayerScene);
        Main.Instance.SceneManager.LoadScene(Main.Instance.SceneManager.scenes.LevelScenes[lvlNb]);
    }

    public void PlayGame()
    {
        state = State.playing;
        Main.Instance.Input.PlayerActions.Move.Enable();
        Main.Instance.Input.PlayerActions.Shoot.Enable();
        Time.timeScale = 1;
        Main.Instance.MainPlayer.Data.PlayerHealth = 3;
    }

    public void LoadCinematic()
    {
        Main.Instance.SceneManager.LoadScene(Main.Instance.SceneManager.scenes.CinematicScenes[lvlNb]);
    }

    public IEnumerator PlayCinematic()
    {
        state = State.cinematic;
        Time.timeScale = 1;
        yield return new WaitForSeconds(2);
        Story story = GameObject.FindObjectOfType<Story>();
        story.NextStep();
    }

    public void CinematicDone()
    {
        Main.Instance.SceneManager.UnloadScene(Main.Instance.SceneManager.scenes.CinematicScenes[lvlNb]);

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
        Main.Instance.Input.MenuActions.Next.started += PlayGameInput;
    }




}
