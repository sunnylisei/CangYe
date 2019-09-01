using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public class HurtStates : FSM_MonsterS
{
    float  hurtTime_over;
    float  hurtTime_standard;
    AudioClip hurt_sound;

    public HurtStates(FSM_System_MonsterS fsm,int monstertype,GameObject thismonster) : base(fsm,monstertype,thismonster)
    {       
        monster_state = Monster_State.Hurt;
        audiosource = thismonster.GetComponent<AudioSource>();
        switch(monstertype)
        {
            case 1:
                {
                    hurtTime_standard = thismonster.GetComponent<FireMonStates>().hurtTime;
                    hurtTime_over = 0;
                    hurt_sound = thismonster.GetComponent<FireMonStates>().Hurt;
                }
                break;
            case 2:
                {
                    hurtTime_standard = thismonster.GetComponent<FlyMonStates>().hurtTime;
                    hurtTime_over = 0;
                    hurt_sound = thismonster.GetComponent<FlyMonStates>().Hurt;
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
                    if (thismonster.GetComponent<FireMonStates>().hurting == false)
                    {
                        audiosource.PlayOneShot(hurt_sound);
                        thismonster.GetComponent<FireMonStates>().hurting = true;
                        thismonster.GetComponent<Animator>().SetTrigger("Hurt");
                        thismonster.GetComponent<FireMonStates>().hp--;
                        thismonster.GetComponent<Animator>().SetTrigger("Trace");
                    }
                    hurtTime_over += Time.deltaTime;
                }
                break;
            case 2:
                {
                    if (thismonster.GetComponent<FlyMonStates>().hurting == false)
                    {
                        audiosource.PlayOneShot(hurt_sound);
                        thismonster.GetComponent<FlyMonStates>().hurting = true;
                        thismonster.GetComponent<Animator>().SetTrigger("Hurt");
                        thismonster.GetComponent<FlyMonStates>().hp--;
                        thismonster.GetComponent<Animator>().SetTrigger("Trace");
                    }
                    hurtTime_over += Time.deltaTime;
                }
                break;
        }   
    }

    public override void Reason()
    {
        switch(MonsterType)
        {
            case 1:
                {
                    float hp = thismonster.GetComponent<FireMonStates>().hp;
                    if (hurtTime_over >= hurtTime_standard)
                    {
                        thismonster.GetComponent<FireMonStates>().hurting = false;
                        fsm.PerformTransition(Transition.Searchhero);
                        hurtTime_over = 0;
                    }
                    if(hp==0)
                    {
                        fsm.PerformTransition(Transition.Outoflife);
                    }
                }
                break;
            case 2:
                {
                    float hp = thismonster.GetComponent<FlyMonStates>().hp;
                    if (hurtTime_over >= hurtTime_standard)
                    {
                        thismonster.GetComponent<FlyMonStates>().hurting = false;
                        fsm.PerformTransition(Transition.Searchhero);
                        hurtTime_over = 0;
                    }
                    if (hp == 0)
                    {
                        fsm.PerformTransition(Transition.Outoflife);
                    }
                }
                break;
        }        
    }
}
