using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Movement : NetworkBehaviour
{
    public float speed,rotSpeed;
    float moveForward,moveSides;
    public Transform arma;
    private Rigidbody body;
    public GameObject projectile;
    private Material materialRef;
    
    // Start is called before the first frame update   
    void Start()
    {
        arma = GetComponentInChildren<Transform>();
        body = GetComponent<Rigidbody>();
        materialRef = GetComponent<Material>();
        materialRef.color = new Color (Random.Range(0f,1f), Random.Range(0f,1f),Random.Range(0f,1f));
    }

    // Update is called once per frame
    void Update()
    {
        float moveForward,moveSides;
        moveForward = Input.GetAxis("Vertical")*Time.deltaTime;
        moveSides = Input.GetAxis("Horizontal")*Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            CmdAtirar();
        }

        if (isLocalPlayer)
        {
            body.velocity = new Vector3 (0f,0f,moveForward)*speed;
            transform.Rotate(0f,moveSides*rotSpeed,0f);
        }
        if (!isLocalPlayer)
        return;
    }

    void CmdAtirar()
    {
        GameObject projetil = Instantiate(projectile, arma.position, transform.rotation);
        NetworkServer.Spawn(projetil);
    }
}