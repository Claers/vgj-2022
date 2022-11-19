using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public enum State
{
    playing,
    paused,

}
public class GameManager : MonoBehaviour
{
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        Main.Instance.Input.MenuActions.Pause.started += PauseGame;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PauseGame(InputAction.CallbackContext context)
    {
        state = State.paused;
        Main.Instance.Input.PlayerActions.Move.Disable();
        Main.Instance.Input.PlayerActions.Shoot.Disable();
    }
}
