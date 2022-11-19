using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text playerHealtText;

    public GameObject pauseMenu;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Main.Instance.MainPlayer;
        Main.Instance.Input.MenuActions.Pause.started += TooglePauseMenu;

    }

    void OnDisable()
    {
        Main.Instance.Input.MenuActions.Pause.started -= TooglePauseMenu;

    }

    // Update is called once per frame
    void Update()
    {
        playerHealtText.text = player.Data.PlayerHealth.ToString();
    }

    void TooglePauseMenu(InputAction.CallbackContext context)
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }


}
