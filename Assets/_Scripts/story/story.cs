using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class story : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Main.Instance.Input.MenuActions.Next.started += MoveCam;
    }

    void OnDisable()
    {
        Main.Instance.Input.MenuActions.Next.started -= MoveCam;
    }

    public void MoveCam(InputAction.CallbackContext context)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
