using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody = null;
    [SerializeField] private Vector3 _direction = Vector3.up;
    [SerializeField] private float _charge = 0f;
    [SerializeField] private float _jumpFore = 100f;
    private bool _isGround = false;
    private bool _isHold = false;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && !_isHold && _isGround) {
            _charge += 0.1f;
        }

        if(Input.GetMouseButtonUp(0)) {
            _isHold = true;
        }

        if(!_isGround) {
            _charge = 0f;
        }
    }

    private void FixedUpdate() {
        if(_isHold) {
            _rigidBody.AddForce(_direction * _jumpFore  * _charge);
            _isHold = false;
            _isGround = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")) {
            _isGround = true;
        }
    }
}
