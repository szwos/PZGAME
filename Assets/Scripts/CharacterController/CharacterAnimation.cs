using JetBrains.Annotations;
using UnityEngine;

namespace CharacterController
{
    public class CharacterAnimation
    {
        public Animator animator { get; }
        Transform parentTransform;

        public CharacterAnimation(Animator animator, Transform parent)
        {
            this.animator = animator;
            this.parentTransform = parent;
        }
    }
}