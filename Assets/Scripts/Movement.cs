using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody playerBody;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpspeed = 5f;
    [SerializeField] GameObject wayPoint;
    private float timer = 0.12f;
    [SerializeField] float buddycount = 0;

    void Awake()
    {

    }

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            //The position of the waypoint will update to the player's position
            UpdatePosition();
            timer = 0.5f;
        }

        Move();
        //Jump();
    }

    void Move()
    {
        playerBody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, playerBody.velocity.y, Input.GetAxis("Vertical") * speed);
    }

    void Jump()
    {
        playerBody.velocity = new Vector3(playerBody.velocity.x, Input.GetAxis("Jump") * jumpspeed, playerBody.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.transform.name);
    }

    void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
        wayPoint.transform.position = transform.position;
    }

    public void AddBuddy()
    {
        buddycount += 1;
    }

    public void DelBuddy()
    {
        buddycount -= 1;
    }

    public float CountBuddies()
    {
        return buddycount;
    }
}
