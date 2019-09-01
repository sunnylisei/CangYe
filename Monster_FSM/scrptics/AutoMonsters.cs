using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMonsters : MonoBehaviour
{
    public GameObject MonsterType;
    public GameObject maincamera;

    
    GameObject monster;
    bool born;

    void Start()
    {
        born = true;
    }

    void Update()
    {
        if(born)
        {
            monster= GameObject.Instantiate(MonsterType, this.transform.position,Quaternion.identity) as GameObject;
            born = false;
        }
        if (!monster)
        {
            if(outofscreen(maincamera.transform))
            {
                born = true;
            }
        }
    }

    bool outofscreen(Transform atransform)
    {
        float disX = Vector3.Distance(atransform.position, this.transform.position);
        if (disX>=45.45)
        {
            return true;
        }
        return false;
    }
}
