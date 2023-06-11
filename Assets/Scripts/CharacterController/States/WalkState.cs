using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;
using UnityEditor.UI;

namespace CharacterController
{
    [CreateAssetMenu(menuName = "States/Character/Walk")]
    public class WalkState : State<CharacterCtrl>
    {
        [SerializeField]
        private float speed = 5f;
        //private int slide_slowdown = 3000;
        private Rigidbody2D rb;
        private GroundCheck groundCheck;
        private CharacterAnimation animation;
        private float xInput;
        private bool jumpInput;
        private bool bhopPossible = false;
        private bool enterSlide = false;


        public override void Enter(CharacterCtrl parent)
        {
            base.Enter(parent);
            if (groundCheck == null)
                groundCheck = parent.GetComponentInChildren<GroundCheck>();
            if (rb == null)
                rb = parent.GetComponent<Rigidbody2D>();
            if (animation == null)
                animation = parent.CharacterAnimation;

            //every time player enters walking state, he has 0.1s time to enter BunnyHop state
            stateRunner.StartCoroutine(BhopWait());

            enterSlide = false;
        }

        public override void CaptureInput()
        {
            xInput = Input.GetAxis("Horizontal");
            jumpInput = Input.GetButtonDown("Jump");
            
            if (Input.GetButtonDown("Slide"))
            {
                enterSlide = true;
            }
            //TODO: other inputs
        }

        public override void ChangeState()
        {
            if (groundCheck.Check() && jumpInput)
            {
                //BHOP is a special state of jump state
                if (bhopPossible)
                    stateRunner.SetState(typeof(BunnyHopState));
                else
                    stateRunner.SetState(typeof(JumpState));
            }

            if(enterSlide)
            {
                stateRunner.SetState(typeof(SlideState));
            }
            
        }

        public override void Exit()
        {
            //do nothing
        }

        public override void FixedUpdate()
        {
            //do nothing
        }

        //TODO: handle slopes better (currently character breaks away from the ground after goin up slope, what is worse - this also happens when character changes direction going up slope)
        public override void Update()
        {
            rb.gravityScale = 3f;
            rb.velocity = new Vector2(speed * xInput, rb.velocity.y); 

            if (rb.velocity.x > 0.1 || rb.velocity.x < -0.1) //TODO: remove magic numbers, set as MonoBehaviour parameters or const
                animation.animator.SetBool("IsMoving", true);
            else
                animation.animator.SetBool("IsMoving", false);
        }

        private IEnumerator BhopWait()
        {
            bhopPossible = true;

            yield return new WaitForSeconds(0.1f);

            bhopPossible = false;

        }


    }
}
