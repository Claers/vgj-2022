using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class story : MonoBehaviour
{
    public List<Vector3> _positionCam;
    public int _step = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        Main.Instance.Input.MenuActions.Next.started += MoveCam;
    }

    void OnDisable()
    {
        Main.Instance.Input.MenuActions.Next.started -= MoveCam;
    }

    void Start()
    {
    }

    public void MoveCam(InputAction.CallbackContext context)
    {
        Main.Instance.CameraManager.mainCamera.transform.DOMove(_positionCam[_step], 2f);
        _step++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
