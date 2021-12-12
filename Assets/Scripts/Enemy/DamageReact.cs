using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DamageReact : MonoBehaviour
{
    private float SizeDeltaHP;
    private float SizeDeltaHPTemp;

    private Animator animator;
    private Timer BlockTime;

    public bool isDead;
    public bool isBlock;

    // Start is called before the first frame update
    void Start()
    {
        SizeDeltaHP = EnemyHPCollection.GetSizeDeltaHP(name);
        SizeDeltaHPTemp = SizeDeltaHP;

        animator = GetComponent<Animator>();

        isDead = false;
        isBlock = false;
    }

    public void HitReact(float damage)
    {
        SizeDeltaHP -= damage * Time.deltaTime * 10;

        isDead = (SizeDeltaHP <= 0) ? true : false;

        if (!isBlock)
        {
            SizeDeltaHPTemp = SizeDeltaHP;

            animator.SetBool("isAttack", false);
            animator.SetBool("isDetection", false);
            animator.SetBool("isDead", false);

            animator.SetBool("isBlock", true);

            BlockTime = new Timer();

            BlockTime.Interval = 3000;
            BlockTime.Elapsed += CheckForDamage;
            BlockTime.AutoReset = false;
            BlockTime.Enabled = true;
            BlockTime.Start();

            isBlock = true;
        }

        if (isDead)
        {
            BlockTime.Enabled = false;
            BlockTime.Stop();
            BlockTime = null;

            isBlock = false;

            animator.SetBool("isAttack", false);
            animator.SetBool("isDetection", false);
            animator.SetBool("isBlock", false);

            animator.SetBool("isDead", true);
        }
    }

    private void CheckForDamage(object sender, ElapsedEventArgs e)
    {
        Debug.Log(SizeDeltaHP + " " + SizeDeltaHPTemp + " " + (SizeDeltaHP == SizeDeltaHPTemp));
        if(SizeDeltaHP == SizeDeltaHPTemp)
        {
            isBlock = false;
            BlockTime.Enabled = false;
            BlockTime.Stop();
        }
        else if(SizeDeltaHP < SizeDeltaHPTemp)
        {
            SizeDeltaHPTemp = SizeDeltaHP;

            isBlock = true;
            BlockTime.Enabled = true;
        }
    }

    public float GetSizeDeltaHP() { return SizeDeltaHP; }
}
