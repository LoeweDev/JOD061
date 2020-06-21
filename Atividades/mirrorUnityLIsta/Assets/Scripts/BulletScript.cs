using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class BulletScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f,0f,Time.deltaTime * 25f);
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        NetworkServer.Destroy(gameObject);
        NetworkServer.Destroy(other.gameObject);
    }
}
