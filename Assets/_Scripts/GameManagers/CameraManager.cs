using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera playerCamera;
    public Camera UICamera;
    public float scrollingSpeed;
    public Vector3 baseMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Scroll();

    }

    void Scroll()
    {
        if (Main.Instance.GameManager.state == State.playing)
        {
            baseMovement = new Vector3(scrollingSpeed, 0, 0);
            playerCamera.gameObject.transform.position += baseMovement;
        }
        else
        {
            baseMovement = new Vector3(0, 0, 0);

        }
    }
}
