using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

namespace CharacterController
{
    public abstract class StateRunner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        private List<State<T>> states;
        private State<T> activeState;

        protected virtual void Awake()
        {
            SetState(states[0].GetType());
        }

        public void SetState(Type newStateType)
        {
            if(activeState != null)
            {
                activeState.Exit();
            }

            activeState = states.First(s => s.GetType() == newStateType);
            activeState.Init(GetComponent<T>());
        }

        private void Update()
        {
            activeState.CaptureInput();
            activeState.Update();
            activeState.ChangeState();
        }

        private void FixedUpdate()
        {
            activeState.FixedUpdate();
        }
    }
}