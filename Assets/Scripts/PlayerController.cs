using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody2D sandFloor;
    [SerializeField] private Rigidbody2D pole;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float dashCooldownOrigin;
    [SerializeField] private float dashMultiplier;
    [SerializeField] private float baseSpeed;
    private float dashCooldown;
    private Rigidbody2D player;
    private bool leftCollide = false;
    private bool rightCollide = false;
    private string[] keyNames;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        if (playerNumber == 1)
        {
            keyNames = new string[] { "w", "a", "d", "c" };  
        } else if (playerNumber == 2)
        {
            keyNames = new string[] { "i", "j", "l", "n" };
        }
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetAnimation();
        dashCooldown -= Time.fixedDeltaTime;
        float horizontalSpeed = Mathf.Abs(player.velocity.x) < baseSpeed + 1 ? baseSpeed : Mathf.Abs(player.velocity.x);

        if (Input.GetKey(keyNames[1]) && leftCollide == false)
        {
            player.velocity = new Vector2(-1 * horizontalSpeed, player.velocity.y);
            animator.transform.eulerAngles = new Vector3(0,180,0);
            
        } else if (Input.GetKey(keyNames[2]) && rightCollide == false)
        {
            player.velocity = new Vector2(1 * horizontalSpeed, player.velocity.y);
            animator.transform.eulerAngles = new Vector3(0,0,0);
        }

        if (Input.GetKey(keyNames[0]) && player.transform.position.y < sandFloor.transform.position.y + 2)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if (Input.GetKey(keyNames[3]) && dashCooldown <= 0)
        {
            var rotation = player.gameObject.transform.eulerAngles;
            player.velocity = new Vector2(Mathf.Sign(90 - rotation.y) * baseSpeed * dashMultiplier, player.velocity.y);
            dashCooldown = dashCooldownOrigin;
        }
    }

    private void SetAnimation()
    {
        if (player.transform.position.y > sandFloor.transform.position.y + 2 && Mathf.Abs(player.velocity.x) <= baseSpeed)
        {
            animator.Play("jumping");
        }
        else if (Mathf.Abs(player.velocity.x) > 0)
        {
            if (Mathf.Abs(player.velocity.x) > baseSpeed*1.2f)
            {
                animator.Play("dash");
            }
            else if (Mathf.Abs(player.velocity.x) > 0)
            {
                animator.Play("running");
            }
        }
        else
        {
            animator.Play("Idle");
        }
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "sand-floor" && collision.gameObject.name != "volley-ball")
        {
            float collisionDirection = player.transform.position.x - collision.transform.position.x;
            if (collisionDirection < 0 )
            {
                rightCollide = true;
            } else if (collisionDirection > 0)
            {
                leftCollide = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name != "sand-floor" && collision.gameObject.name != "volley-ball")
        {
            leftCollide = false;
            rightCollide = false;
        }
    }

}
