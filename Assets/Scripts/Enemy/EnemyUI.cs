using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public CharacterController controller;

    public float seeDistance = 12f;
    public float attackDistance = 2f;

    public float speed = 5f;

    public float JumpHeight = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;

    public Animator animator;

    public Transform Player;
    public RectTransform PlayerHP;

    private Gravity gravity;
    private DamageReact damageReact;

    private int DMG = 5;
    private float PlayerHPMax;
    private object anonymous;
    private object anager;

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Gravity();
        animator = GetComponent<Animator>();

        damageReact = GetComponent<DamageReact>();

        PlayerHPMax = PlayerHP.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<DamageReact>().isDead)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) <= seeDistance && !damageReact.isBlock)
            {

                if (Vector3.Distance(transform.position, Player.transform.position) >= attackDistance)
                {
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isDead", false);
                    animator.SetBool("isBlock", false);

                    animator.SetBool("isDetection", true);

                    transform.LookAt(Player.transform);
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

                    PlayerHP.sizeDelta = (PlayerHP.sizeDelta.x < PlayerHPMax) ?
                        new Vector2(PlayerHP.sizeDelta.x + (1 * Time.deltaTime * 10), PlayerHP.sizeDelta.y) : PlayerHP.sizeDelta;
                }
                else
                {
                    animator.SetBool("isDetection", false);
                    animator.SetBool("isDead", false);
                    animator.SetBool("isBlock", false);

                    animator.SetBool("isAttack", true);

                    PlayerHP.sizeDelta = new Vector2(PlayerHP.sizeDelta.x - ((DMG / 2) * Time.deltaTime * 10), PlayerHP.sizeDelta.y);
                }
            }
            else
            {
                animator.SetBool("isDetection", false);
                animator.SetBool("isAttack", false);
                animator.SetBool("isDead", false);

                PlayerHP.sizeDelta = (PlayerHP.sizeDelta.x < PlayerHPMax) ?
                        new Vector2(PlayerHP.sizeDelta.x + (1 * Time.deltaTime * 10), PlayerHP.sizeDelta.y) : PlayerHP.sizeDelta;
            }
        }

        if(PlayerHP.sizeDelta.x <= 0) { Player.gameObject.GetComponent<Animator>().SetBool("isDie", true); }
        //controller.Move((transform.right * transform.position.x + transform.forward * transform.position.z) * speed * Time.deltaTime);
        gravity.Math(groundCheck, groundMask, controller, JumpHeight, false);
    }
}
