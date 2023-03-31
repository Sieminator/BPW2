using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float follow_x;
    float follow_y;
    public GameObject target;
    bool free_move = false;

    void Start()
    {
        follow_x = 0f;
        follow_y = 0f;
    }
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x+follow_x, target.transform.position.y+5+ follow_y, -10);

        if (Input.GetKeyDown(KeyCode.C)) free_move = !free_move;
        
        if (free_move)
        {
            if (Input.GetKey(KeyCode.UpArrow)) follow_y += 20*Time.deltaTime;
            if (Input.GetKey(KeyCode.DownArrow)) follow_y -= 20 * Time.deltaTime;
            if (Input.GetKey(KeyCode.RightArrow)) follow_x += 20 * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftArrow)) follow_x -= 20 * Time.deltaTime;

            target.GetComponent<PlayerMovement>().not_move= true;
        }

        else
        {
            target.GetComponent<PlayerMovement>().not_move = false;
            follow_y = 0;
            follow_x = 0;
        }
    }
}
