using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{

    [SerializeField] float reqBuddyCount = 2;
    [SerializeField] GameObject player;
    GameObject scoreText;
    GameObject leftText;
    GameObject rightText;
    float buddies;
    Movement playerscript;

    void Start()
    {
        player = GameObject.Find("Player");
        playerscript = (Movement)player.GetComponent("Movement");
        buddies = playerscript.CountBuddies();
        scoreText = GameObject.FindGameObjectWithTag("BuddyCount");
        leftText = GameObject.FindGameObjectWithTag("LeftDisplay");
        rightText = GameObject.FindGameObjectWithTag("RightDisplay");
    }

    void Update()
    {
        ChangeCount();
        buddies = playerscript.CountBuddies();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(buddies == reqBuddyCount)
            {
                TextMeshPro left = leftText.gameObject.GetComponent<TextMeshPro>();
                TextMeshPro right = rightText.gameObject.GetComponent<TextMeshPro>();
                left.text = "YEET!";
                right.text = "YEET!";
                GameObject.Destroy(gameObject);
            }
        }
    }

    void ChangeCount()
    {
        TextMeshPro score = scoreText.gameObject.GetComponent<TextMeshPro>();
        score.text = buddies.ToString();
    }
}
