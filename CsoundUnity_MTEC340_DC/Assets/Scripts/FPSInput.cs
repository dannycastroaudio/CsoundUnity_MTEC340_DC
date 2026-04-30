using Unity.VisualScripting;
using UnityEngine;

// Require a CharacterController component on the object.
// If no CharacterController component has been attached, it will
// be automatically added.
[RequireComponent(typeof(CharacterController))]

// Place object in a given component bin.
[AddComponentMenu("Control Script/FPS Input")]


public class FPSInput : MonoBehaviour
{
    [Header("Movement Attributes")]
    
    [SerializeField, Range(1.0f, 10.0f)] float _speed = 6.0f;
    [SerializeField] float _gravity = -9.8f;
    
    [SerializeField, Range(0.0f, 5.0f)] private float _runBoost = 3.0f;
    private float _verticalVelocity;
    [SerializeField, Range(5.0f, 10.0f)] private float _jumpVelocity = 10.0f;

    private CharacterController _controller;
    
    //CsoundUnity
    public CsoundUnity CsoundSource;
    

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        
        //CsoundUnity
        CsoundSource = GetComponent<CsoundUnity>();
        CsoundSource.SendScoreEvent("i 1 0");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed += _runBoost;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed -= _runBoost;
        }
        // Moving the transform via the Translate method won't engage
        // collision detection.

        // transform.Translate(
        //    Input.GetAxis("Horizontal") * _speed * Time.deltaTime,
        //    0,
        //    Input.GetAxis("Vertical") * _speed * Time.deltaTime);

        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        
        Vector3 movement = new(deltaX, 0.0f, deltaZ);
        
        // Clamp diagonal movement
        movement = Vector3.ClampMagnitude(movement, _speed);
        
        //jumping behaviour
        if (_controller.isGrounded)
        {
            _verticalVelocity = _gravity;
            if (Input.GetButtonDown("Jump"))
            {
                _verticalVelocity = _jumpVelocity;
            }
        }
        else
        {
            _verticalVelocity += _gravity * 3.0f * Time.deltaTime;
        }
        
        // Apply gravity after X and Z have been clamped
        movement.y = _verticalVelocity;
        
        movement *= Time.deltaTime;
        
        // Convert movement vector to rotation settings of player
        //convert world vector to local space
        movement = transform.TransformDirection(movement);
        // CharacterController expects coordinates in world space
        _controller.Move(movement);
    }
}
