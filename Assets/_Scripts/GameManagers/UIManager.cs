using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text playerHealtText;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Main.Instance.Input.MenuActions.Pause.started += TooglePauseMenu;

    }

    void OnDisable()
    {
        Main.Instance.Input.MenuActions.Pause.started -= TooglePauseMenu;

    }

    // Update is called once per frame
    void Update()
    {
        if (Main.Instance.GameManager.state == State.playing)
        {
            playerHealtText.text = Main.Instance.MainPlayer.Data.PlayerHealth.ToString();
        }
    }

    void TooglePauseMenu(InputAction.CallbackContext context)
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }


}
