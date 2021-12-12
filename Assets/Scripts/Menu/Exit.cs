using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    private Button button;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnExit);
    }
    void OnExit() { Debug.Log("Exit"); Application.Quit(); }
}
