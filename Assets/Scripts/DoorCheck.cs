using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{

    [SerializeField] float reqBuddyCount = 2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] follow;
    GameObject scoreText;
    GameObject leftText;
    GameObject rightText;
    float buddies;
    Movement playerscript;
    Follow followscript;

    void Start()
    {
        player = GameObject.Find("Player");
        playerscript = (Movement)player.GetComponent("Movement");
        buddies = playerscript.CountBuddies();
        scoreText = GameObject.FindGameObjectWithTag("BuddyCount");
        leftText = GameObject.FindGameObjectWithTag("LeftDisplay");
        rightText = GameObject.FindGameObjectWithTag("RightDisplay");
        follow = GameObject.FindGameObjectsWithTag("Buddy");
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
                KillAllFollowers();
                GameObject.Destroy(gameObject);
            }
        }
    }

    void ChangeCount()
    {
        TextMeshPro score = scoreText.gameObject.GetComponent<TextMeshPro>();
        score.text = buddies.ToString();
    }

    void KillAllFollowers()
    {
        foreach (GameObject f in follow)
        {
            followscript = (Follow)f.GetComponent("Follow");
            followscript.KillFollow();
        }
    }
}
