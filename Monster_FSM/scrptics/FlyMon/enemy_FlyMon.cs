using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define_file;

public class enemy_FlyMon : MonoBehaviour
{
    FSM_System_MonsterS fsm;
    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM_System_MonsterS();

        FSM_MonsterS patrol = new PatrolStates(fsm, 2, this.gameObject);
        fsm.AddState(patrol);
        patrol.Addtransition(Transition.Inattackrange, Monster_State.Attack);
        patrol.Addtransition(Transition.Attacked,Monster_State.Hurt);

        FSM_MonsterS attack = new AttackStates(fsm, 2, this.gameObject);
        fsm.AddState(attack);
        attack.Addtransition(Transition.Searchhero, Monster_State.Trace);
        attack.Addtransition(Transition.Attacked, Monster_State.Hurt);

        FSM_MonsterS hurt = new HurtStates(fsm, 2, this.gameObject);
        fsm.AddState(hurt);
        hurt.Addtransition(Transition.Searchhero, Monster_State.Trace);
        hurt.Addtransition(Transition.Outoflife,Monster_State.Die);

        FSM_MonsterS die = new DieStates(fsm, 2, this.gameObject);
        fsm.AddState(die);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.UpdateFSM();
    }
}
