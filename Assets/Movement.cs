using UnityEngine;

namespace Gamespace
{
    public class Movement : MonoBehaviour
    {
        private float xRotation = 0f;
        private float yRotation = 0f;

        private float rotationSpeed = 2f;
        private float speed = 50f;
        public float mouseSensitivity = 100f;
        private Camera first_person_camera;
        public float jumpForce = 10f;
        private Rigidbody rb;
        private bool isGrounded = true;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            first_person_camera = Camera.main;
            Cursor.lockState = CursorLockMode.Locked;
        }
        void Update()
        {
            float verticalInput = Input.GetAxis("Vertical");  
            xRotation = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            yRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation = Mathf.Clamp(yRotation, -90f, 90f);
            transform.Rotate(Vector3.up, xRotation);


            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
//            rb.transform.Rotate(xRotation, 0f, 0f);
            first_person_camera.transform.localEulerAngles = new Vector3(yRotation, transform.localEulerAngles.y, 0f);

            
//            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//            {
//                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//                isGrounded = false;   
//            }
        }
    }
}
