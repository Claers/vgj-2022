using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBoxes : MonoBehaviour
{
    public GameObject _visible;

    // Start is called before the first frame update
    void Start()
    {
        //_visible = GetComponent<SpriteRenderer>();
        _visible.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit()
    {
        if (CompareTag("Boss"))
        {
            _visible.gameObject.SetActive(true);
        }
    }
}
