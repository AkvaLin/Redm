using UnityEngine;

namespace DefaultNamespace
{
    public class ThirdPersonMovement: MonoBehaviour
    {

        [SerializeField] private CharacterController controller;
        [SerializeField] private Transform cam;
        [SerializeField] private float speed = 6f;
        [SerializeField] private float turnSmoothTime = 0.1f;
        private float turnSmoothVelocity;

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            }
        }
    }
}