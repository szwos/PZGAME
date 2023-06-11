using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using UnityEngine.UIElements;

namespace CharacterController
{
    [CreateAssetMenu(menuName = "States/Character/Slide")]

    public class SlideState : State<CharacterCtrl>
    {
        [SerializeField]
        private float speed = 6f;

        private float slideDirection;
        private bool leaveSlide;
        private bool leaveSlideJump;
        private int slideSpeedModifier;
        private CharacterAnimation animation;

        private Rigidbody2D rb;
        

        public override void Enter(CharacterCtrl parent)
        {
            


            base.Enter(parent);
            if (rb == null)
                rb = parent.GetComponent<Rigidbody2D>();

            if (animation == null) 
                animation = parent.CharacterAnimation;

            leaveSlide = false;
            leaveSlideJump = false;
            slideSpeedModifier = 4000;

            animation.animator.SetBool("IsSliding", true);
            slideDirection = rb.transform.localScale.x;



        }

        public override void CaptureInput()
        {

            if (Input.GetButtonUp("Slide"))
                leaveSlide = true;

            if (Input.GetButtonDown("Jump"))
                leaveSlideJump = true;

        }

        public override void ChangeState()
        {
            if(leaveSlide)
                stateRunner.SetState(typeof(WalkState));

            if(leaveSlideJump)
                stateRunner.SetState(typeof(JumpState));
        }

        public override void Exit()
        {
            //do nothing for now
            slideSpeedModifier = 4000;
            rb.gravityScale = 3f;
            animation.animator.SetBool("IsSliding", false);
        }

        public override void FixedUpdate()
        {
            //noting
        }

        public override void Update()
        {
            
            rb.gravityScale = 100f;
            rb.velocity = new Vector2(slideDirection * (slideSpeedModifier / 1000) * speed, rb.velocity.y);

            if(slideSpeedModifier < 1000)
            {
                slideSpeedModifier = 1000;
            } else
            {
                slideSpeedModifier -= 5;
            }

        }
    }
}
