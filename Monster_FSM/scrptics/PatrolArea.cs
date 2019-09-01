using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolArea:MonoBehaviour
{
    [HideInInspector]
    public bool inPatrolArea;

    // Start is called before the first frame update
    void Start()
    {
        inPatrolArea = false;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            inPatrolArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            inPatrolArea = false;
        }
    }
}
