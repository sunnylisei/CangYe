using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public class Idlestates : FSM_MonsterS
{
    public Idlestates(FSM_System_MonsterS fsm,int monstertype,GameObject thismonseter) : base(fsm,monstertype,thismonseter)
    {
        monster_state = Monster_State.Idle;
    }
    public override void Act()
    {
        throw new System.NotImplementedException();
    }
    public override void Reason()
    {
        throw new System.NotImplementedException();
    }
}
