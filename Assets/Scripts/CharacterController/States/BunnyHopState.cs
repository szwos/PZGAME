//TODO: move to States???
using UnityEngine;
using System.Collections;

//TODO: coyote time for bunny hop cooldown (accept input, that was pressed fraction of second before colliding with ground)

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
        //private int bhopCount;
        private float bhopVelocityScaler;
        private bool inAir;
        private bool bhopPossible;

        public override void Enter(CharacterCtrl parent)
        {
            Debug.Log("Entering Bhop State");
            base.Enter(parent);
            if (groundCheck == null)
                groundCheck = parent.GetComponentInChildren<GroundCheck>();
            if (rb == null)
                rb = parent.GetComponent<Rigidbody2D>();
            /*if (animation == null)
                animation = parent.CharacterAnimation;*/

            //reset bhopCount when player enters Bhop state
            //bhopCount = 1;
            bhopVelocityScaler = 1.1f;
            bhopPossible = true;

            //jump when entering state
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);

        }

        public override void CaptureInput()
        {
            xInput = Input.GetAxis("Horizontal");
            jumpInput = Input.GetButtonDown("Jump");

            //Debug.Log(jumpInput);
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
            //Debug.Log("Leaving BHOP state");
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
            //Debug.Log("BHOPSTATE");
            //rb.velocity = new Vector2(speed * xInput * bhopCount, rb.velocity.y);
            rb.velocity = new Vector2(speed * xInput * bhopVelocityScaler, rb.velocity.y);

            //Debug.Log(groundCheck.Check().ToString() + ", " + jumpInput.ToString());
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
                //bhopCount++;
                if(bhopVelocityScaler <= 3f)//limit to 3x original speed
                    bhopVelocityScaler += 0.2f;
            }

            

            inAir = !groundCheck.Check();
        }

        private IEnumerator BhopWait()
        {
            bhopPossible = true;

            yield return new WaitForSeconds(0.2f);

            bhopPossible = false;

        }
    }
}
