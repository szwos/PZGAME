//TODO: move to States???
using UnityEngine;
using System.Collections;

namespace CharacterController
{
    [CreateAssetMenu(menuName = "States/Character/BunnyHop")]
    public class BunnyHopState : State<CharacterCtrl>
    {
        [SerializeField]
        private float speed = 5f;

        [SerializeField]
        private float jumpVelocity = 10f;

        private Rigidbody2D rb;
        private GroundCheck groundCheck;
        //private CharacterAnimation animation;
        private float xInput;
        private bool jumpInput;
        private int bhopCount;
        private bool inAir;
        private bool bhopPossible;

        public override void Enter(CharacterCtrl parent)
        {
            base.Enter(parent);
            if (groundCheck == null)
                groundCheck = parent.GetComponentInChildren<GroundCheck>();
            if (rb == null)
                rb = parent.GetComponent<Rigidbody2D>();
            /*if (animation == null)
                animation = parent.CharacterAnimation;*/

            //reset bhopCount when player enters Bhop state
            bhopCount = 1;

        }

        public override void CaptureInput()
        {
            xInput = Input.GetAxis("Horizontal");
            jumpInput = Input.GetButtonDown("Jump");
            //TODO: other inputs
        }

        public override void ChangeState()
        {
            //if player is still on the ground when timeframe for Bhop has passed
            if (groundCheck.Check() && !bhopPossible)
            {
                stateRunner.SetState(typeof(WalkState));
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

        //TODO: consider moving to FixedUpdate
        //TODO: handle slopes better (currently character breaks away from the ground after goin up slope, what is worse - this also happens when character changes direction going up slope)
        public override void Update()
        {
            rb.velocity = new Vector2(speed * xInput * bhopCount, rb.velocity.y);

            Debug.Log(groundCheck.Check().ToString() + ", " + jumpInput.ToString());
            if (groundCheck.Check() && jumpInput)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }

            //TODO: animation flip character
            //TODO: play walking animation

            //that means, that in the previous frame player was inAir and now is grounded
            if (groundCheck.Check() && inAir)
            {
                stateRunner.StartCoroutine(BhopWait());
                bhopCount++;
            }

            

            inAir = !groundCheck.Check();
        }

        private IEnumerator BhopWait()
        {
            bhopPossible = true;

            yield return new WaitForSeconds(1f);

            bhopPossible = false;

        }
    }
}
