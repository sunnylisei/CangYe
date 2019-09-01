using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMonStates : MonoBehaviour
{
    [HideInInspector]
    public bool canattack;
    [HideInInspector]
    public bool attackover;
    [HideInInspector]
    public bool hurting;


    public float attacktime = 2.0f;//攻击间隔
    public float movespeed = 1.0f;//移动速度
    public float magicballspeed = 0.5f;//魔法球飞行速度
    public float damage = 1.0f;//攻击伤害量
    public float hp = 5.0f;//生命值
    public float hurtTime = 1.0f;//受伤间隔

    public AudioClip Hurt;

    float times;
    GameObject magicballpos;
    GameObject magicball;
    GameObject diamond;
    Transform player_T;

    // Start is called before the first frame update
    void Start()
    {
        hurting = false;
        canattack = false;
        times = attacktime;
        attackover = false;
        magicballpos = transform.Find("magicballPos").gameObject;
        player_T = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        times += Time.deltaTime;
        if (times >= attacktime)
        {
            times = 0;
            canattack = true;
        }
    }

    void AttackOver()
    {
        attackover = true;
    }

    void MagicBall()
    {
        Vector3 pos = magicballpos.transform.position;
        Quaternion rotate = magicballpos.transform.rotation;
        Vector3 sca = transform.localScale;
        magicball = GameObject.Instantiate(magicballpos.GetComponent<onMagicball>().MagicBall, pos, rotate) as GameObject;
        magicball.transform.localScale = sca;
        magicball.GetComponent<magicball>().speed = magicballspeed;
        magicball.GetComponent<magicball>().FlyMon_T = this.transform;
    }

    void die()
    {
        Destroy(gameObject);
    }

    void skill_diamond()
    {
        diamond = GameObject.Instantiate(GetComponent<Diamonds>().FlyMon_Diaminod, transform.position, Quaternion.identity);
        int dir = transform.position.x < player_T.position.x ? 1 : -1;
        diamond.GetComponent<Rigidbody2D>().AddForce(new Vector3((dir * 20), 120, 0));
    }
}
