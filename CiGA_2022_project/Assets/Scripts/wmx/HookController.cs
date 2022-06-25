using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [HideInInspector] public bool isCatching = false;
    [HideInInspector] public GameObject caughtObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (caughtObj != null)
        {
            caughtObj.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("trigger");
        if (collider.CompareTag("Coin"))
        {
            isCatching = true;
            Debug.Log("catch");
            caughtObj = collider.gameObject;
        }
        if(collider.CompareTag("Enemy")&& collider.CompareTag("Barrier"))
        {
            if (caughtObj != null)
            {
                caughtObj = null;
            }
        }
    }

}
