using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public class FSM_System_MonsterS 
{
    Dictionary<Monster_State, FSM_MonsterS> states = new Dictionary<Monster_State, FSM_MonsterS>();
    FSM_MonsterS currentstate;
    /// <summary>
    /// 更新当前状态行为
    /// </summary>
    public void UpdateFSM()
    {
        currentstate.Act();
        currentstate.Reason();
    }
    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="state">需要管理的状态</param>
    public void AddState(FSM_MonsterS state)
    {
        if(currentstate==null)
        {
            currentstate = state;
            states.Add(state.whichstate, state);
        }
        else
        {
            states.Add(state.whichstate,state);
        }
    }
    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="state">需要删除的状态</param>
    /// <returns></returns>
    public bool DeleteState(Monster_State state)
    {
        if (state == Monster_State.NullState)
        {
            return false;
        }
        else if (states.ContainsKey(state) == false)
        {
            return false;
        }
        else
        {
            states.Remove(state);
            return true;
        }
    }

    public void PerformTransition(Transition trans)
    {
        if(trans==Transition.NullTrans)
        {
            return ;
        }
        Monster_State targetstate = currentstate.GetMonster_State(trans);
        if(states.ContainsKey(targetstate)==false)
        {
            return;
        }
        FSM_MonsterS Targetstate = states[targetstate];
        /*currentstate.DowhileStart();
        currentstate.DowhileEnd();*/
        currentstate = Targetstate;
    }
}
