using UnityEngine;

namespace DefaultNamespace
{
    public class ThirdPersonMovement: MonoBehaviour
    {

        [SerializeField] private CharacterController controller;
        [SerializeField] private Transform cam;
        [SerializeField] private Animator animator;
        [SerializeField] private float speed = 6f;
        [SerializeField] private float runSpeed = 12f;
        [SerializeField] private float turnSmoothTime = 0.1f;
        [SerializeField] private int timeUntilIdle = 10;
        private float turnSmoothVelocity;
        private float idleTime = 0;
        private bool isIdle = true;
        
        public float gravity = -9.81f;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        Vector3 velocity;
        bool isGrounded;
        
        public AudioClip footStepSound;
        public float footStepDelay;
 
        private float nextFootstep = 0;

        private bool isRunning = false;

        private void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            
            if (isGrounded && velocity.y <0)
            {
                velocity.y = -2f;
            }
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            
            if (horizontal != 0 || vertical != 0)
            {
                animator.ResetTrigger("Pause");
                if (isRunning)
                {
                    animator.SetTrigger("Run");
                    animator.ResetTrigger("Go");
                }
                else
                {
                    animator.SetTrigger("Go");
                    animator.ResetTrigger("Run");
                }
                animator.ResetTrigger("Idle");
                isIdle = false;
            }

            if (idleTime < timeUntilIdle)
            {
                if (horizontal == 0 && vertical == 0)
                {
                    idleTime += Time.deltaTime;
                    if (!isIdle)
                    {
                        animator.SetTrigger("Pause");
                        animator.ResetTrigger("Go");
                        animator.ResetTrigger("Idle");
                        animator.ResetTrigger("Run");
                    }
                }
                else
                {
                    idleTime = 0;
                }
            }
            else
            {
                isIdle = true;
                animator.ResetTrigger("Pause");
                animator.ResetTrigger("Go");
                animator.SetTrigger("Idle");
                animator.ResetTrigger("Run");
                idleTime = 0;
            }

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                if (isRunning)
                {
                    controller.Move(moveDirection.normalized * runSpeed * Time.deltaTime);
                }
                else
                {
                    controller.Move(moveDirection.normalized * speed * Time.deltaTime);
                }
            }
            
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) && isGrounded)
            {
                nextFootstep -= Time.deltaTime;
                if (nextFootstep <= 0) 
                {
                    GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
                    if (!isRunning)
                    {
                        nextFootstep += footStepDelay;
                    }
                    else
                    {
                        nextFootstep += footStepDelay / 1.5f;
                    }
                }
            }
        }
    }
}