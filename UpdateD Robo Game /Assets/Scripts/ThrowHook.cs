using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{

    public GameObject hook;
    private GameObject currentHook;

    private Rigidbody2D hookRB;
    // Start is called before the first frame update
    void Start()
    {
        hookRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

          currentHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

            currentHook.GetComponent<RopeScript>().destiny = destiny;
        }
    }
}
