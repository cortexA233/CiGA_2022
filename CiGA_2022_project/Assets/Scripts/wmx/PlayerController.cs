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
    public float moveSpeed;
    public GameObject baitObj;

    //GameObject spriteObj;
    //Vector2 curSpeed = new Vector2();
    // Start is called before the first frame update
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        hookObj = transform.Find("hook").gameObject;
        hookController = hookObj.GetComponent<HookController>();
        stateMachine = new PlayerFSM(this);
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

    public void HandleHorizantalInput()
    {
        float dirX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //Debug.Log("dirx"+dirX.ToString());
        transform.Translate(new Vector3(dirX, 0), Space.World);
    }

    public void HandleThrowBaitInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var baitItem = Instantiate(baitObj, transform);
            baitItem.transform.parent = null;
        }
    }

    public bool CheckHookHasCaught() 
    {
        return hookController.isCatching;
    }

    public void FollowMousePosition()
    {
        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction.y = Mathf.Max(Mathf.Abs(direction.x) * 0.2f, direction.y);
        transform.up = direction;
    }

    public void ClearHook()
    {
        hookController.isCatching = false;
        if (hookController.caughtObj != null)
        {
            Destroy(hookController.caughtObj);
            ++GlobalUtils.instance.score;
        }
    }
}
