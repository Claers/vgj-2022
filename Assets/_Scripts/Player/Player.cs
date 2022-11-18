using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
  public PlayerInput Input { get; private set; }

  public delegate void OnPlayerShoot();
  public static event OnPlayerShoot onPlayerShoot;



  private void Awake()
  {
    Input = GetComponent<PlayerInput>();
  }

  private void OnEnable()
  {
    AddInputActionsCallbacks();
  }
  private void OnDisable()
  {
    RemoveInputActionsCallbacks();
  }
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  void launchShoot(InputAction.CallbackContext context)
  {
    onPlayerShoot?.Invoke();
  }

  protected virtual void AddInputActionsCallbacks()
  {
    Input.PlayerActions.Shoot.started += launchShoot;
  }

  protected virtual void RemoveInputActionsCallbacks()
  {
    Input.PlayerActions.Shoot.started -= launchShoot;
  }
}
