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
    public GameObject hookObj { private set; get; }
    public HookController hookController { private set; get; }

    public float hookSpeed;
    //public float jumpForce;

    //GameObject spriteObj;
    //Vector2 curSpeed = new Vector2();
    // Start is called before the first frame update
    private void Awake()
    {
        stateMachine = new PlayerFSM(this);
        rigid2D = GetComponent<Rigidbody2D>();
        hookObj = transform.Find("hook").gameObject;
        hookController = hookObj.GetComponent<HookController>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stateMachine.currentState.HandleTrigger(collision);
    }

    public bool CheckHookHasCaught() 
    {
        return hookController.isCatching;
    }
}
