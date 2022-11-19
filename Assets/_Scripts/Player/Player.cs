using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data { get; set; }

    public delegate void OnPlayerShoot();
    public static event OnPlayerShoot onPlayerShoot;

    public static GameEvent onProjectileTouch;

    public GameObject upLimit;
    public GameObject downLimit;
    public GameObject rightLimit;
    public GameObject leftLimit;



    private void Awake()
    {
        float vertExtent = Main.Instance.CameraManager.mainCamera.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        Data.maxDirectionHeight = vertExtent;
        Data.maxDirectionWidth = horzExtent;

        upLimit.transform.position = new Vector3(0, Data.maxDirectionHeight + 0.5f, 0);
        upLimit.transform.localScale = new Vector3(Data.maxDirectionWidth * 2, 1, 1);

        downLimit.transform.position = new Vector3(0, -Data.maxDirectionHeight - 0.5f, 0);
        downLimit.transform.localScale = new Vector3(Data.maxDirectionWidth * 2, 1, 1);

        rightLimit.transform.position = new Vector3(Data.maxDirectionWidth + 0.5f, 0, 0);
        rightLimit.transform.localScale = new Vector3(1, Data.maxDirectionHeight * 2, 1);

        leftLimit.transform.position = new Vector3(-Data.maxDirectionWidth - 0.5f, 0, 0);
        leftLimit.transform.localScale = new Vector3(1, Data.maxDirectionHeight * 2, 1);


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
        Data.MovementInput = Main.Instance.Input.PlayerActions.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        if (Data.MovementInput == Vector2.zero)
        {
            return;
        }

        Vector2 playerMovement = Data.MovementInput * Data.PlayerSpeed;
        transform.position += new Vector3(playerMovement.x, playerMovement.y, 0) + Main.Instance.CameraManager.baseMovement;
    }

    public void launchShoot(InputAction.CallbackContext context)
    {
        onPlayerShoot?.Invoke();
    }

    protected virtual void AddInputActionsCallbacks()
    {
        Main.Instance.Input.PlayerActions.Shoot.started += launchShoot;
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        Main.Instance.Input.PlayerActions.Shoot.started -= launchShoot;
    }

    void PlayerDamage()
    {
        Data.PlayerHealth--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("EnnemyProjectile"))
        {
            PlayerDamage();
        }
    }


}
