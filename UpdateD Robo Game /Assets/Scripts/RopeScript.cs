using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RopeScript : MonoBehaviour
{

    public Vector2 destiny;
    public float speed = 1f;

    public float distance = 2f;

    public GameObject nodePrefab;

    public GameObject player;

    public GameObject lastnode;

    public List<GameObject> Nodes = new List<GameObject>();

    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        lastnode = transform.gameObject;

        Nodes.Add(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed);




        if((Vector2)transform.position != destiny)
        {
           if(Vector2.Distance(player.transform.position,lastnode.transform.position) > distance)
            {
                CreateNode();
            }
        }
        else if(done == false)
        {
            done = true;
            lastnode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }




    }// update

    private void CreateNode()
    {
        Vector2 pos2Create = player.transform.position - lastnode.transform.position;

        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastnode.transform.position;

        GameObject go = (GameObject) Instantiate(nodePrefab, pos2Create, Quaternion.identity);

        lastnode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();

        lastnode = go;

        Nodes.Add(lastnode);

      
    }
}



