using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //You may consider adding a rigid body to the zombie for accurate physics simulation
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 10.0f;
    [SerializeField] bool isFollowing;
    [SerializeField] GameObject player;
    Rigidbody followBody;

    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("wayPoint");
        player = GameObject.Find("Player");
        followBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isFollowing)
        {
            wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            //Here, the zombie's will follow the waypoint.
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(isFollowing == false)
            {
                Movement playerscript = (Movement)player.GetComponent("Movement");
                playerscript.AddBuddy();
                isFollowing = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(isFollowing == true)
        {
                followBody.velocity = Vector3.zero;
                followBody.angularVelocity = Vector3.zero;
        }
    }
}
