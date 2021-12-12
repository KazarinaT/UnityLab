using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] private GameObject GameLose;

    void isDie()
    {
        GameLose.GetComponent<Canvas>().enabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
