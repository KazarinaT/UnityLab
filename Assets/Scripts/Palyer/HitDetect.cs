using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetect : MonoBehaviour
{
    private DamageReact Enemy;
    private float EnemySizeDeltaHP;

    [SerializeField] private float DMG = 100f;
    [SerializeField] private GameObject EnemyInfo;

    private Text EnemyName;
    private RectTransform HPPanel;
    private Image EnemyImage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy = other.GetComponent<DamageReact>();
            EnemySizeDeltaHP = Enemy.GetSizeDeltaHP();

            EnemyInfo.GetComponent<Canvas>().enabled = true;

            HPPanel = GameObject.Find("EnemyHP").GetComponent<RectTransform>();
            EnemyName = GameObject.Find("EnemyName").GetComponent<Text>();
            EnemyImage = GameObject.Find("EnemyImage").GetComponent<Image>();

            EnemyName.text = other.name;
            EnemyImage.sprite = Resources.Load<Sprite>("EnemysPNG/" + other.name + ((Enemy.isDead == false) ? "/icon" : "/rip"));
            HPPanel.sizeDelta = new Vector2(EnemySizeDeltaHP, HPPanel.sizeDelta.y);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy = null;

            EnemyInfo.GetComponent<Canvas>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Enemy = null;
        EnemySizeDeltaHP = 0;

        EnemyInfo.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy != null) 
        {
            if (Input.GetMouseButtonDown(0) && !Enemy.isDead)
            {
                Enemy.HitReact((Enemy.isBlock) ? 50f : DMG);
            }

            EnemySizeDeltaHP = Enemy.GetSizeDeltaHP();
            SetHPPanel();
        }
    }

    void SetHPPanel()
    {
        HPPanel.sizeDelta = new Vector2(EnemySizeDeltaHP, HPPanel.sizeDelta.y);
        if (Enemy.isDead) { EnemyImage.sprite = Resources.Load<Sprite>("EnemysPNG/" + EnemyName.text + "/rip"); }
    }
}
