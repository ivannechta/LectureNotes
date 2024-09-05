using System;
using System.Collections.Generic;

namespace OneNote
{
    public enum FSM_STATES
    {
        FSM_STATE_ELEMENT_READY_DRAW,   //Выбран пункт меню добавить линию
        FSM_STATE_ELEMENT_DRAW,         //Начато рисование
        FSM_STATE_ELEMENT_PUT,
        FSM_STATE_ELEMENT_MOVE,
        FSM_STATE_ELEMENT_SELECT,
        FSM_STATE_CANVAS_MOVE,
        FSM_STATE_IDLE
    };

    delegate void Callback();

    struct Instance
    {
        public String name;
        public List<FSM_STATES> NextPosibleStates;
        public Callback onEnter;
    };

    internal class FSM
    {
        public FSM_STATES State = FSM_STATES.FSM_STATE_IDLE;
        private Dictionary<FSM_STATES, Instance> AllStates = new Dictionary<FSM_STATES, Instance>()
        {
            [FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW] = new Instance()
            {
                name = "Рисуем элемент",
                onEnter = Stub,
                NextPosibleStates = new List<FSM_STATES> { FSM_STATES.FSM_STATE_IDLE, FSM_STATES.FSM_STATE_ELEMENT_DRAW }
            },
            [FSM_STATES.FSM_STATE_ELEMENT_DRAW] = new Instance()
            {
                name = "Рисуем элемент",
                onEnter = Stub,
                NextPosibleStates = new List<FSM_STATES> { FSM_STATES.FSM_STATE_IDLE }
            },
            [FSM_STATES.FSM_STATE_ELEMENT_PUT] = new Instance()
            {
                name = "Ставим элемент в позицию",
                onEnter = Stub,
                NextPosibleStates = new List<FSM_STATES> { FSM_STATES.FSM_STATE_IDLE }
            },
            [FSM_STATES.FSM_STATE_ELEMENT_MOVE] = new Instance()
            {
                name = "Перемещаем элемент",
                onEnter = Stub,
                NextPosibleStates = new List<FSM_STATES> { FSM_STATES.FSM_STATE_IDLE }
            },
            [FSM_STATES.FSM_STATE_ELEMENT_SELECT] = new Instance()
            {
                name = "Выбран элемент",
                onEnter = Stub,
                NextPosibleStates = new List<FSM_STATES> { FSM_STATES.FSM_STATE_IDLE }
            },
            [FSM_STATES.FSM_STATE_CANVAS_MOVE] = new Instance()
            {
                name = "Перемещается полотно",
                onEnter = Stub,
                NextPosibleStates = new List<FSM_STATES> {  FSM_STATES.FSM_STATE_IDLE }
            },
            [FSM_STATES.FSM_STATE_IDLE] = new Instance()
            {
                name = "Ожидание действия",
                onEnter = Stub,
                NextPosibleStates = new List<FSM_STATES> 
                {
                                                            FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW,
                                                            FSM_STATES.FSM_STATE_ELEMENT_DRAW,
                                                            FSM_STATES.FSM_STATE_ELEMENT_PUT,
                                                            FSM_STATES.FSM_STATE_ELEMENT_MOVE,
                                                            FSM_STATES.FSM_STATE_ELEMENT_SELECT,
                                                            FSM_STATES.FSM_STATE_CANVAS_MOVE,
                                                            FSM_STATES.FSM_STATE_IDLE 
                }
            }
        };
        public FSM_STATES GetState()
        {
            return State;
        }
        public String GetName()
        {
            return AllStates[State].name;
        }
        public void SetState(FSM_STATES _newState)
        {
            if (AllStates[State].NextPosibleStates.Contains(_newState))
            {
                State = _newState;
                AllStates[_newState].onEnter();
            }
            else
            {
                throw new Exception("New state is not allowed");
            }
        }
        public static void Stub() { }
    }
}
