using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogicOfEnemy : MonoBehaviour
{
    [HideInInspector]public Animator anim;
    [Header("基本属性")]
    public float blood = 10f;
    
    [Header("状态")]
    public bool isHurt = false;
    
    public bool isDead = false;
    
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("hurt",isHurt);
        anim.SetBool("dead",isDead);
        if (blood == 0)
        {
            // StartCoroutine(OnDead());
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if (other.name == "Player")
        {
            Time.timeScale = 0;
        }
        if (other.name == "BulletOfGun(Clone)") 
        {
            Debug.Log(2);
            blood -= GameObject.Find("BulletOfGun(Clone)").GetComponent<MoveOfBullet>().damage;
            StartCoroutine(OnHurt());
            GameObject.Find("BulletOfGun(Clone)").GetComponent<MoveOfBullet>().selfDestroy();
        }
    }
    
    private IEnumerator OnHurt()
    {
        isHurt = true;
        yield return new WaitForSeconds(1.0f);
        isHurt = false;
    }

    // private IEnumerator OnDead()
    // {
    //     isDead = true;
    //     yield return new WaitForSeconds(1.0f);
    // }
    
}
