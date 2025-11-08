using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Rigidbody rb;
    public float jumpPower = 3f;
    public bool isGrounded;
    public float mouseSensitivity;
    public float upDownRange;
    public Camera mainCam;
    private float mouseYRotation;
    public float clippingDis;


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        mouseYRotation = mainCam.transform.rotation.y;
        Cursor.lockState = CursorLockMode.Locked;
        mainCam.nearClipPlane = clippingDis;
    }

    private void Update()
    {
        CheckGround();
        MoveUpdate();
        RotationUpdate();
    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = transform.localScale.y;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void MoveUpdate()
    {
        if (_playerMovement.jumpPressed == true && isGrounded == true)
        {
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            Debug.Log("jumped");
            _playerMovement.jumpPressed = false;
        }

        Vector3 positionChange = transform.forward * _playerMovement.MovementInputVector.y + transform.right * _playerMovement.MovementInputVector.x;
        positionChange = positionChange * Time.deltaTime;

        transform.position += positionChange;
    }

    private void RotationUpdate()
    {
        float mouseXRotation = _playerMovement.LookInputVector.x * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);


        mouseYRotation -= _playerMovement.LookInputVector.y * mouseSensitivity;
        mouseYRotation = Mathf.Clamp(mouseYRotation, -upDownRange, upDownRange);
        mainCam.transform.localRotation = Quaternion.Euler(mouseYRotation, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            //Debug.Log("Collecting water");
            Destroy(other.gameObject);

            Vector3 currentPos = transform.position;

            
            GetComponentInParent<SwapPlayerSizes>().SwapNextSize(currentPos);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && GetComponentInParent<SwapPlayerSizes>().sizeIndex == 0)
        {
            GetComponentInParent<SwapPlayerSizes>().ResetPlayer();
            StartCoroutine(Respawn());
        }
    }
    
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        transform.position = GetComponentInParent<SwapPlayerSizes>().spawnPoint;
    }

}
