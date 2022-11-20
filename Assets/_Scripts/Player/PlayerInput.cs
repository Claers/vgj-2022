using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputs InputActions { get; private set; }
    public PlayerInputs.PlayerActions PlayerActions { get; private set; }
    public PlayerInputs.UIActions MenuActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerInputs();

        PlayerActions = InputActions.Player;

        MenuActions = InputActions.UI;
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