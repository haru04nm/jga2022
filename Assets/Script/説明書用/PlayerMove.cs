using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rbody;
    private Animator animator;
    private Vector2 _moveInoutValue;
    GameObject body;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = transform.Find("Mesh Object").gameObject.GetComponent<Animator>();
        body = GameObject.Find("Body").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector3(2,0,0);

        animator.SetFloat("Move", rbody.velocity.magnitude);
    }
}
