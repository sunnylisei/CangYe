using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackArea : MonoBehaviour
{
    [HideInInspector]
    public bool inAttackArea;

    // Start is called before the first frame update
    void Start()
    {
        inAttackArea = false;      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            inAttackArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            inAttackArea = false;
        }
    }
}
