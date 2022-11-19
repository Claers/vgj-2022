using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputs InputActions { get; private set; }
    public PlayerInputs.GameActions PlayerActions { get; private set; }
    public PlayerInputs.MenuActions MenuActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerInputs();

        PlayerActions = InputActions.Game;

        MenuActions = InputActions.Menu;
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

    public void DisableActionFor(InputAction action, float seconds)
    {
        StartCoroutine(DisableAction(action, seconds));
    }

    private IEnumerator DisableAction(InputAction action, float seconds)
    {
        action.Disable();
        yield return new WaitForSeconds(seconds);
        action.Enable();
    }

}