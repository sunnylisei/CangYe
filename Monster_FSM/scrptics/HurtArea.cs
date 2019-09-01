using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtArea : MonoBehaviour
{
    [HideInInspector]
    public bool isHurt;
    GameObject PlayerHit;

    // Start is called before the first frame update
    void Start()
    {
        isHurt = false;
        //PlayerHit = GameObject.FindGameObjectWithTag("player").transform.Find("Sword").gameObject;
    }

    private void Update()
    {
        /*if(PlayerHit.activeInHierarchy==false)
        {
            isHurt = false;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerhit" || collision.tag == "playerfire" || collision.tag == "playerlaser")
        {
            isHurt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "playerhit" || collision.tag == "playerfire" || collision.tag == "playerlaser")
        {
            isHurt = false;
        }
    }



}
