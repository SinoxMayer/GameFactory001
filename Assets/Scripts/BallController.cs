using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BallController : MonoBehaviour
{
    [SerializeField]private float _moveSpeed = 1f;
    [SerializeField]private float _jumpSpeed = 2f;
    
    private Rigidbody _rigidbody;

    private bool _isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();    
    }



    private void CheckInput()
    {

        if (Input.GetKey(KeyCode.D))
        {
           Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
 
        
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _moveSpeed,ForceMode.Acceleration);
    }

    private void Jump()
    {

        if (!_isGrounded)
        {
            return;
        }
        _rigidbody.AddForce(Vector3.up * (_jumpSpeed ),ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        bool isCollectible = collectible != null;
        if (isCollectible)
        {
            collectible.Collect();
        }
    }
}
