using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{

    private float timeBtwnSpawns;
    public float startTimeBtwnSpwns;

    private PlayerController player;

    public GameObject echo;


    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {

        if (player.isMoving = true)
        {
            if (timeBtwnSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);

                Destroy(instance, 4f);
                timeBtwnSpawns = startTimeBtwnSpwns;
            }

            else
            {
                timeBtwnSpawns -= Time.deltaTime;
            }
        }
    }
}
