using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float JumpForce;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelosity = 0;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
        
        //Fall and Jump
       _fallVelosity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelosity * Time.fixedDeltaTime);

        //Stop fall if on the ground
        if (_characterController.isGrounded)
        {
            _fallVelosity = 0;
        }

    }
    void Update()
    {
        //Movement
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelosity = -JumpForce;
        }
    }


}
