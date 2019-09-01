using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public class AttackStates : FSM_MonsterS
{
    Transform player_T;


    public AttackStates(FSM_System_MonsterS fsm, int monstertype, GameObject thismonster) : base(fsm, monstertype, thismonster)
    {
        monster_state = Monster_State.Attack;
        player_T = GameObject.FindWithTag("player").transform;
        switch (monstertype)
        {
            case 1:
                {
                    
                }
                break;
        }   
    }

    public override void Act()
    {
        switch(MonsterType)
        {
            case 1:
                {
                    bool attack = thismonster.GetComponent<FireMonStates>().canattack;
                    if (attack)
                    {
                        thismonster.transform.localScale = new Vector3(((thismonster.transform.position.x - player_T.position.x) > 0 ? 1.0f : -1.0f), thismonster.transform.localScale.y, thismonster.transform.localScale.z);
                        thismonster.GetComponent<Animator>().SetTrigger("Attack");           
                        thismonster.GetComponent<FireMonStates>().canattack = false;
                    }
                }
                break;
            case 2:
                {
                    bool attack = thismonster.GetComponent<FlyMonStates>().canattack;
                    if(attack)
                    {
                        thismonster.transform.localScale = new Vector3(((thismonster.transform.position.x - player_T.position.x) > 0 ? 1.0f : -1.0f), thismonster.transform.localScale.y, thismonster.transform.localScale.z);
                        thismonster.GetComponent<Animator>().SetTrigger("Attack");
                        thismonster.GetComponent<FlyMonStates>().canattack = false;
                    }
                }
                break;
        }
    }

    public override void Reason()
    {
        bool attackover = false ;
        bool inAttackAreas = thismonster.GetComponentInChildren<AttackArea>().inAttackArea;
        switch (MonsterType)
        {
            case 1:
                {
                    attackover = thismonster.GetComponent<FireMonStates>().attackover;
                    if (!inAttackAreas && attackover)
                    {
                        fsm.PerformTransition(Transition.Searchhero);
                        thismonster.GetComponent<FireMonStates>().attackover = false;
                    }
                }
                break;
            case 2:
                {
                    attackover = thismonster.GetComponent<FlyMonStates>().attackover;
                    if (!inAttackAreas && attackover)
                    {
                        fsm.PerformTransition(Transition.Searchhero);
                        thismonster.GetComponent<FlyMonStates>().attackover = false;
                    }
                }
                break;
        }
        bool isHurt = thismonster.transform.GetComponentInChildren<HurtArea>().isHurt;
        
        if(isHurt)
        {
            fsm.PerformTransition(Transition.Attacked);
            thismonster.GetComponentInChildren<HurtArea>().isHurt = false;
        }
    }
}
