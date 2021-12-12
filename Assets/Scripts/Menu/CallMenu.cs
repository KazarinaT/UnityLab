using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallMenu : MonoBehaviour
{
    public bool isMenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpen = !isMenuOpen;
        }

        if (isMenuOpen) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GetComponent<Canvas>().enabled = true;
        }else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            GetComponent<Canvas>().enabled = false;
        }
    }
}
