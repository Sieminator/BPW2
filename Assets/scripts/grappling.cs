using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class grappling : MonoBehaviour
{
    //control values
    public float grapple_speed;

    //calculation variables
    Vector2 shoot_direction;
    Vector2 mouseWorldPos;
    Vector2 player_position;

    bool inWall = false;
    int comeBack = 1;

    //references
    Transform player;
    
    void Start()
    {
        //get mouse and player position for calculating direction
        player = FindObjectOfType<PlayerMovement>().transform;
        player_position = player.position;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //begin at the player
        transform.position = player.position;

        //rotate the hook
        //FIGURE OUT

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(player_position, transform.position) > 25) GameObject.Destroy(gameObject);

        shoot_direction = new Vector2(mouseWorldPos.x-player_position.x, mouseWorldPos.y - player_position.y); //calculate direction
        if (inWall == false) transform.Translate(shoot_direction.normalized*Time.deltaTime*grapple_speed*comeBack); //move hook
        else //grapple the player
        {
            if (Vector2.Distance(player.position, transform.position) > 0.35f) FindObjectOfType<PlayerMovement>().rb.MovePosition(player.position +(transform.position - player.position).normalized*grapple_speed/50); //moves the player
            FindObjectOfType<PlayerMovement>().is_grappling = true; //disables player movement
            FindObjectOfType<PlayerMovement>().rb.velocity = Vector2.zero; //disables player physics
            FindObjectOfType<PlayerMovement>().rb.gravityScale = 0; //disable gravity
        }
    }

    void OnTriggerEnter2D(Collider2D other) //check collision
    {
        if (other.gameObject.tag.Equals("grapple")) inWall = true;
        else if (other.gameObject.tag != "Player" && other.gameObject.tag != "grappleTrough")
        {
            Destroy(this);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        //{
        //    if (other.gameObject.tag == ("Player") && comeBack == -1) Destroy(this);
        //    else if (other.gameObject.tag != ("Player")) comeBack = -1;
        //}
    }
}
