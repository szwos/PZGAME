using UnityEngine;

namespace CharacterController
{
    public abstract class State<T> : ScriptableObject where T : MonoBehaviour
    {
        protected T stateRunner;

        public virtual void Init(T parent)
        {
            stateRunner = parent;
        }

        public abstract void CaptureInput();

        public abstract void Update();

        public abstract void FixedUpdate();

        public abstract void ChangeState();

        public abstract void Exit();
    }
}