using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Define_file
{
    public enum Monster_State
    {
        NullState,
        Idle,//暂不用
        Trace,
        Attack,
        Hurt,
        Die
    }
    
    public enum Transition
    {
        NullTrans,
        Losehero,//暂不用
        Searchhero,
        Inattackrange,
        Attacked,
        Outoflife
    }
}
