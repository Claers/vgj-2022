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

    public List<GameObject> healthBees;
    public GameEventListener bmpEventListener;



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


        Data.healthBees = healthBees;
        AddInputActionsCallbacks();

        foreach (ShootSO shoot in Data.shootDatas)
        {
            Shoot shootComp = gameObject.AddComponent<Shoot>();
            shootComp.shootData = shoot;
            bmpEventListener.customEvents += shootComp.inBPMTriggerPlayer;
        }


    }

    private void OnDisable()
    {
        RemoveInputActionsCallbacks();
    }
    // Start is called before the first frame update
    void Start()
    {
        Main.Instance.Input.MenuActions.Pause.started += PauseOut;
    }

    void PauseOut(InputAction.CallbackContext context)
    {
        if (Main.Instance.GameManager.state == State.paused)
        {
            Debug.Log("Paused");
        }
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
        transform.position += new Vector3(playerMovement.x, playerMovement.y, 0);
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
        Data.healthBees[Data.PlayerHealth - 1].SetActive(false);
        if (Data.PlayerHealth <= Data.lowHealth)
        {
            foreach (GameObject healtBee in Data.healthBees)
            {
                healtBee.GetComponent<SpriteRenderer>().sprite = Data.lowHealthSprite;
            }
        }
        Data.canBeTouched = false;
    }

    IEnumerator invulnerabilityCooldown()
    {
        yield return new WaitForSeconds(Data.invenurabilityTime);
        Data.canBeTouched = true;
    }

    void PlayerHeal()
    {

        Data.PlayerHealth++;
        Data.healthBees[Data.PlayerHealth - 1].SetActive(true);
        if (Data.PlayerHealth > Data.lowHealth)
        {
            foreach (GameObject healtBee in Data.healthBees)
            {
                healtBee.GetComponent<SpriteRenderer>().sprite = Data.normalHealthSprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnnemyProjectile") || other.CompareTag("Obstacles"))
        {
            PlayerDamage();
        }
        if (other.tag.Contains("PlayerHeal"))
        {
            PlayerHeal();
        }
    }


}
