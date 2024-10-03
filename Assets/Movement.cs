using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace
{
    public class Movement : MonoBehaviour
    {
        private float xRotation = 0f;
        private float yRotation = 0f;

        private float rotationSpeed = 2f;
        public float mouseSensitivity = 2f;
        public float speed = 50f;
        private Camera first_person_camera;
        public float jumpForce = 10f;
        private Rigidbody rb;
        private bool isGrounded = true;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            first_person_camera = Camera.main;
        }
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");  
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);

            yRotation += mouseX;
            transform.Rotate(Vector3.up * yRotation * rotationSpeed);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            first_person_camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            
//            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//            {
//                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//                isGrounded = false;   
//            }
        }
    }
}
