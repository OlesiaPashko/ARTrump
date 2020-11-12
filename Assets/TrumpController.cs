using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour
{
    private Animation animation;
    private Rigidbody rb;
    [SerializeField]private float speed = 4f;
    [SerializeField]private FixedJoystick fixedJoystick;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animation>();
    }

    void Update()
    {
        float x = fixedJoystick.Horizontal;
        float y = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(x, 0, y);
        rb.velocity = movement * speed;

        if (x != 0 && y != 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x,y)*Mathf.Rad2Deg, transform.eulerAngles.z);

        if (x != 0 && y != 0)
            animation.Play("Walk");
        else
            animation.Play("Idle");
    }
}
