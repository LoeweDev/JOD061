using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody body;
    // Start is called before the first frame update
   
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveForward,moveSides;
        moveForward = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        moveSides = Input.GetAxis("Horizontal")*Time.deltaTime*speed;

        transform.Translate(moveSides,0f,moveForward);
    }
}