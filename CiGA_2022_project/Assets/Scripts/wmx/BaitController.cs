using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Water"))
        {
            Debug.Log("��ˮ");
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
