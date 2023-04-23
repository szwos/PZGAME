//TODO: move to States???
using UnityEngine;

namespace CharacterController
{
    [CreateAssetMenu(menuName = "States/Character/Walk")]
    public class WalkState : State<CharacterCtrl>
    {
        [SerializeField]
        private float speed = 5f;

        private Rigidbody2D rb;
        private GroundCheck groundCheck;
        //private CharacterAnimation animation;
        private float xInput;
        private bool jump;

        public override void Init(CharacterCtrl parent)
        {
            base.Init(parent);
            if (groundCheck == null)
                groundCheck = parent.GetComponentInChildren<GroundCheck>();
            if (rb == null)
                rb = parent.GetComponent<Rigidbody2D>();
            /*if (animation == null)
                animation = parent.CharacterAnimation;*/
        }

        public override void CaptureInput()
        {
            xInput = Input.GetAxis("Horizontal");
            jump = Input.GetButtonDown("Jump");
            //TODO: other inputs
        }

        public override void ChangeState()
        {
            if(groundCheck.Check() && jump)
            {
                stateRunner.SetState(typeof(JumpState));
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
            rb.velocity = new Vector2(speed * xInput, rb.velocity.y);
            //TODO: animation flip character
            //TODO: play walking animation
        }
    }
}
