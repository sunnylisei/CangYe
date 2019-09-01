using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public abstract class FSM_MonsterS
{
    
    public Monster_State whichstate
    {
        get { return this.monster_state; }
    }
    public FSM_MonsterS(FSM_System_MonsterS fsm,int monstertype,GameObject monster)
    {
        this.fsm = fsm;
        this.MonsterType = monstertype;
        this.thismonster = monster;
    }
    protected Monster_State monster_state;
    protected GameObject thismonster;
    protected int MonsterType;
    protected AudioSource audiosource;
    Dictionary<Transition, Monster_State> transition = new Dictionary<Transition, Monster_State>();
    protected FSM_System_MonsterS fsm;

    /// <summary>
    /// 添加转换条件
    /// </summary>
    /// <param name="trans">转换条件</param>
    /// <param name="stateID">转换的目标状态</param>
    public void Addtransition(Transition trans,Monster_State monster_State)
    {
        if(trans==Transition.NullTrans)
        {
            return;
        }
        else if(monster_State==Monster_State.NullState)
        {
            return;
        }
        else if(transition.ContainsKey(trans))
        {
            return;
        }
        transition.Add(trans, monster_State);
    }
    /// <summary>
    /// 删除转换条件
    /// </summary>
    /// <param name="trans">转换条件(Key)</param>
    public void Deletetransition(Transition trans)
    {
        transition.Remove(trans);
    }
    /// <summary>
    /// 通过转换条件得到状态
    /// </summary>
    /// <param name="trans">转换条件</param>
    /// <returns></returns>
    public Monster_State GetMonster_State(Transition trans)
    {
        if(transition.ContainsKey(trans)==false)
        {

            return Monster_State.NullState;
        }
        else
        {
            return transition[trans];
        }
    }

    public abstract void Act();//执行动作
    public abstract void Reason();//转换动作
    
}
