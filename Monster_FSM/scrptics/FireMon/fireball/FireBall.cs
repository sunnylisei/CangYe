using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Animator ani;
    [HideInInspector]
    public Transform FireMon_T;

    [HideInInspector]
    public float speed;
    public AudioClip firemove;
    public AudioClip fire_exp;
    AudioSource audiosource;

    float dir=0;//火焰喷射方向

    void Awake()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
        audiosource.playOnAwake = false;
        audiosource.volume = 0.5f;
    }

    void Start()
    {
        ani = GetComponent<Animator>();
        audiosource.PlayOneShot(firemove);
    }

    void OverFire()
    {
        ani.SetBool("End", true);

        /*火焰爆炸音效*/
        /*audiosource.Stop();
        audiosource.PlayOneShot(fire_exp);*/
    }
    void DeleteFire()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            OverFire();
        }
        if (collision.tag == "tilemap")
        {
            OverFire();
        }
        if (collision.tag == "wall")
        {
            OverFire();
        }
    }
    void Update()
    {
        if (FireMon_T)
        {
            dir = FireMon_T.localScale.x;
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (!ani.GetBool("End"))
        {
            transform.Translate(Vector2.left* dir*speed * Time.deltaTime);
        }
    }

}
