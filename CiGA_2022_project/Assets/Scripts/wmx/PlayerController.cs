using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerFSM stateMachine { private set; get; }
    public Animator animator { private set; get; }
    public Collider2D weaponHitbox { private set; get; }
    public Collider2D characterHitbox { private set; get; }
    public Rigidbody2D rigid2D { private set; get; }

    public float moveSpeed;
    public float jumpForce;

    GameObject spriteObj;
    Vector2 curSpeed = new Vector2();
    // Start is called before the first frame update
    private void Awake()
    {
        stateMachine = new PlayerFSM(this);
        rigid2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.HandleUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.HandleFixedUpdate();
    }

    public void HandleDirectionInput()
    {
        float dirX = Input.GetAxis("Horizontal");
        curSpeed = rigid2D.velocity;
        curSpeed.x = dirX * moveSpeed;
        rigid2D.velocity = curSpeed;
    }

    public void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("?");
            curSpeed = rigid2D.velocity;
            curSpeed.y = jumpForce;
            rigid2D.velocity = curSpeed;
        }
    }
}
