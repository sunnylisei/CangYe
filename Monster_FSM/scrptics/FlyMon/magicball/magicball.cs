using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicball : MonoBehaviour
{
    bool startattack;
    bool canmove;
    [HideInInspector]
    public Transform FlyMon_T;
    Vector3 Player_P;
    Animator ani;
    float dir;
    [HideInInspector]
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        canmove = true;
        ani = GetComponent<Animator>();
        startattack = false;
        Player_P = GameObject.FindGameObjectWithTag("player").GetComponent<BoxCollider2D>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyMon_T)
        {
            dir = FlyMon_T.localScale.x;
        }
        else
        {
            Destroy(this.gameObject);
        }
        if(startattack&&canmove)
        {
            transform.Translate(Vector2.left * dir * speed * Time.deltaTime);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        startattack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            ani.SetBool("End",true);
            canmove = false;
        }
        if (collision.tag == "tilemap")
        {
            ani.SetBool("End", true);
            canmove = false;
        }

    }

    void DeleteMagicball()
    {
        Destroy(gameObject);
    }
}
