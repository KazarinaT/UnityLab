using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSensetive : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    void OnValueChanged()
    {
        Debug.Log("!!");
        Debug.Log(slider.value);
        Camera.GetComponent<CameraMove>().mouseSensetive = slider.value;
    }
}
