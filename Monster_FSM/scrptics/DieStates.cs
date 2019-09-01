using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public class DieStates :FSM_MonsterS
{
    public DieStates(FSM_System_MonsterS fsm, int monstertype, GameObject thismonster) : base(fsm, monstertype, thismonster)
    {
        monster_state = Monster_State.Die;  
    }

    public override void Act()
    {
        thismonster.GetComponent<Animator>().SetTrigger("Die");                               
    }

    public override void Reason()
    {
        monster_state = Monster_State.NullState;
    }
}
