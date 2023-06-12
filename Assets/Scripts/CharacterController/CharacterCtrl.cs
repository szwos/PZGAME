using System;
using UnityEngine;

namespace CharacterController
{
    public class CharacterCtrl : StateRunner<CharacterCtrl>
    {
        public CharacterAnimation CharacterAnimation;

        protected override void Awake()
        {
            Debug.Log("CharacterCtrl - awake");
            CharacterAnimation = new CharacterAnimation(GetComponent<Animator>(), transform);
            
            Debug.Log(CharacterAnimation.GetHashCode());
            base.Awake();
        }

          
    }
}
