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

    public static GameEvent onProjectileTouch;



    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
    }


    private void OnDisable()
    {
        RemoveInputActionsCallbacks();
    }
    // Start is called before the first frame update
    void Start()
    {
        AddInputActionsCallbacks();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void launchShoot(InputAction.CallbackContext context)
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

    void PlayerDamage()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("EnnemyProjectile"))
        {

        }
    }


}
