using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int num = 0;
    private bool i = false;
    void Update()
    {
        if (i)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if(PlayerControl.instance.pState == PlayerState.IDLE)
                {
                    i = false;
                    Destroy(this.transform.parent.gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            i = true;
            PlayerControl.instance.Diamond = num;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            i = false;
        }
    }
}
