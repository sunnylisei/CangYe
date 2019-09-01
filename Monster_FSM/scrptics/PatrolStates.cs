using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public class PatrolStates : FSM_MonsterS
{
    Transform   thismonster_T;
    Transform   player_T;
    float       speed;

    public PatrolStates(FSM_System_MonsterS fsm,int monstertype,GameObject thismonster):base(fsm,monstertype,thismonster)
    {
        monster_state = Monster_State.Trace;
        player_T = GameObject.FindWithTag("player").transform;
        thismonster_T=thismonster.transform;
        audiosource = thismonster.AddComponent<AudioSource>();
        switch(monstertype)
        {
            case 1:
                {
                    speed = thismonster.GetComponent<FireMonStates>().movespeed;
                }
                break;
            case 2:
                {
                    speed = thismonster.GetComponent<FlyMonStates>().movespeed;
                }
                break;
        }
    }

    public override void Act()
    {
        bool frontA = thismonster.transform.Find("frontPArea").GetComponent<PatrolArea>().inPatrolArea;
        bool backA = thismonster.transform.Find("backPArea").GetComponent<PatrolArea>().inPatrolArea;
        switch(MonsterType)
        {
            case 1:
                {
                    if (frontA || backA)
                    {
                        FireMonAction();
                    }
                }
                break;
            case 2:
                {
                    if (frontA || backA)
                    {
                        FlyMonAction();
                    }
                }
                break;
        }           
    }
    public override void Reason()
    {
        bool inAttackAreas = thismonster.GetComponentInChildren<AttackArea>().inAttackArea;
        bool isHurt = thismonster.GetComponentInChildren<HurtArea>().isHurt;
        if(inAttackAreas)
        {
            fsm.PerformTransition(Transition.Inattackrange);
        }
        if(isHurt)
        {
            fsm.PerformTransition(Transition.Attacked);
            thismonster.GetComponentInChildren<HurtArea>().isHurt=false;
        }
    }
   
    void FireMonAction()
    {
        thismonster_T.localScale = new Vector3((thismonster_T.position.x - player_T.position.x) > 0 ? 1.0f : -1.0f, thismonster_T.localScale.y, thismonster_T.localScale.z);
        thismonster_T.Translate(Vector2.left * ((thismonster_T.position.x - player_T.position.x) > 0 ? 1.0f : -1.0f) * speed * Time.deltaTime);
    }

    void FlyMonAction()
    {
        thismonster_T.localScale = new Vector3((thismonster_T.position.x - player_T.position.x) > 0 ? 1.0f : -1.0f, thismonster_T.localScale.y, thismonster_T.localScale.z);
        thismonster_T.Translate(Vector2.left * ((thismonster_T.position.x - player_T.position.x) > 0 ? 1.0f : -1.0f) * speed * Time.deltaTime);
    }

}
