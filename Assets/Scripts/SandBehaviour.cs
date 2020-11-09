using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class SandBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("volley-ball"))
        {
            //col.collider.sharedMaterial = bouncelessBall;
            var horizontalSpeed = col.rigidbody.velocity.x;
            col.rigidbody.velocity = new Vector2(horizontalSpeed, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("volley-ball"))
        {
            var horizontalSpeed = col.rigidbody.velocity.x;
            col.rigidbody.velocity = new Vector2(horizontalSpeed / 1.2f, 0);
        }
    }
}
