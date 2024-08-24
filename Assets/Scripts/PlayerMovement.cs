using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationForce;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _headTransform;

    private Vector3 _moveDirection;
    private float _rotationY;
    private Vector3 _targetRotation;

    private void Awake()
    {
        Time.fixedDeltaTime = (float)1 / (float)60;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput > 0)
        {
            _targetRotation = new Vector3(0f, 0f, -_rotationForce);
        }
        else if (horizontalInput < 0)
        {
            _targetRotation = new Vector3(0f, 0f, _rotationForce);
        }
        else
        {
            _targetRotation = Vector3.zero;
        }

        _headTransform.localRotation = Quaternion.Lerp(_headTransform.localRotation, Quaternion.Euler(_targetRotation), Time.deltaTime * _rotationSpeed);

        _moveDirection = ((transform.forward * verticalInput) + (transform.right * horizontalInput)).normalized;

        _rotationY += Input.GetAxisRaw("Mouse X");
        transform.rotation = Quaternion.Euler(0, _rotationY, 0);
    }

    private void FixedUpdate()
    {
        _characterController.SimpleMove(_moveDirection * _speed);
    }
}