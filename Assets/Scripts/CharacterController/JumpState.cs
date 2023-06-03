using UnityEngine;

namespace CharacterController
{
    [CreateAssetMenu(menuName = "States/Character/Jump")]
    public class JumpState : State<CharacterCtrl>
    {
        [SerializeField]
        private float jumpVelocity;

        [SerializeField]
        private bool airControl = true;

        [SerializeField]
        private float speed = 5f;


        private GroundCheck groundCheck;
        private Rigidbody2D rb;
        private bool leftTheGround;
        private float xInput;

        public override void Enter(CharacterCtrl parent)
        {
            base.Enter(parent);
            if (groundCheck == null)
                groundCheck = parent.GetComponentInChildren<GroundCheck>();
            if (rb == null)
                rb = parent.GetComponent<Rigidbody2D>();
            leftTheGround = false;

            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity); //this line does actual jump
        }

        public override void CaptureInput()
        {
            xInput = Input.GetAxis("Horizontal");
        }

        public override void ChangeState()
        {
            if (leftTheGround && groundCheck.Check())
            {
                stateRunner.SetState(typeof(WalkState));
            }
        }

        public override void Exit()
        {
            //TODO: could implement hitting ground animation here (or instantiate some particles that indicate that character hit the ground after falling)
        }

        public override void FixedUpdate()
        {
            //do nothing
        }


        public override void Update()
        {
            if(airControl)
                rb.velocity = new Vector2(speed * xInput, rb.velocity.y);

            if (!groundCheck.Check())
                leftTheGround = true;
        }
    }
}