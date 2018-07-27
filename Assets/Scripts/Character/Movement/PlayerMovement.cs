using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseObjectScene
{

    public float speed = 6f;

    private Vector3 movement;

    protected override void Awake()
    {
        base.Awake();
        if (_rigidbody!=null)
        {
            _rigidbody.freezeRotation = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
    }
	
	void Move (float h, float v) {
        if (h != 0 || v != 0)
        {
            movement.Set(h, 0f, v);
            _myTransform.Translate(movement.normalized * speed * Time.fixedDeltaTime);
            //_rigidbody.AddForce(movement.normalized * speed * Time.fixedDeltaTime * 100);
            //movement = movement.normalized * speed * Time.fixedDeltaTime;
            //_rigidbody.MovePosition(_myTransform.position + movement);
        }
	}
}
