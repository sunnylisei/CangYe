using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonStates : MonoBehaviour
{
    [HideInInspector]
    public bool canattack;
    [HideInInspector]
    public bool hurting;
    [HideInInspector]
    public bool attackover;

    public float attacktime=2.0f;//攻击间隔
    public float movespeed=1.0f;//移动速度
    public float fireballspeed=0.5f;//火球飞行速度
    public float damage=1.0f;//攻击伤害量
    public float hp = 5.0f;//生命值
    public float hurtTime = 1.0f;//受伤间隔

    public AudioClip Hurt;

    float times;
    GameObject diamond;
    GameObject firepos;
    GameObject fireball;
    Transform player_T;

    void Start()
    {
        hurting = false;
        times = attacktime;
        canattack = false;
        player_T = GameObject.FindWithTag("player").transform;
        firepos = transform.Find("firePos").gameObject;
        attackover = false;
    }
    void Update()
    {
        times += Time.deltaTime;
        if (times >= attacktime)
        {
            times = 0;
            canattack = true;
        }
    }

    void Fire()
    {
        Vector3 pos = firepos.transform.position;
        Quaternion rotate = firepos.transform.rotation;
        Vector3 sca =transform.localScale;
        fireball=GameObject.Instantiate(firepos.GetComponent<OnFire>().fireball, pos, rotate) as GameObject;
        fireball.transform.localScale = sca;
        fireball.GetComponent<FireBall>().speed = fireballspeed;
        fireball.GetComponent<FireBall>().FireMon_T = this.transform;
    }

    void skill_diamond()
    {
        diamond=GameObject.Instantiate(GetComponent<Diamonds>().FireMon_Diaminod,transform.position, Quaternion.identity);
        int dir = transform.position.x < player_T.position.x ? 1 : -1;
        diamond.GetComponent<Rigidbody2D>().AddForce(new Vector3((dir * 20), 120, 0));
    }

    void AttackOver()
    {
        attackover = true;
    }

    void die()
    {
        Destroy(gameObject);
    }
}
