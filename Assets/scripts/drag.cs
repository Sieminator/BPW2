using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class drag : MonoBehaviour
{
    //control values
    public float grapple_speed;

    //calculation variables
    Vector2 shoot_direction;
    Vector2 mouseWorldPos;
    Vector2 player_position;

    bool inWall = false;

    //references
    Transform player;
    Transform block;

    GameObject drag_object;
    
    void Start()
    {
        //get block and player position for calculating direction
        player = FindObjectOfType<PlayerMovement>().transform;
        player_position = player.position;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        block = FindObjectOfType<get_dragged>().transform;

        drag_object = GameObject.Find("drag_block");

        //begin at the player
        transform.position = player.position;

        //rotate the hook
        //FIGURE OUT

    }

    void Update()
    {
        shoot_direction = new Vector2(mouseWorldPos.x-player_position.x, mouseWorldPos.y - player_position.y); //calculate direction
        if (inWall == false) transform.Translate(shoot_direction.normalized*Time.deltaTime*grapple_speed); //move hook
        else //grapple the object
        {
            //MovePosition(block.position + (player.position - block.position).normalized * grapple_speed/2 * Time.deltaTime); //moves the object
        }

        if (Vector2.Distance(player_position, transform.position) > 18) GameObject.Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other) //check collision
    {
        if (other.gameObject.tag.Equals("drag"))
        {
            transform.position = new Vector3 (other.transform.position.x,other.transform.position.y,-2);
            inWall = true;
            var direction = new Vector2(player.position.x - other.transform.position.x, player.position.y - other.transform.position.y);
            if (Vector2.Distance(player.position, other.transform.position) > 1.5f) other.GetComponent<get_dragged>().rb.velocity = direction.normalized * Time.deltaTime * grapple_speed * 15 * Mathf.Sqrt(Vector2.Distance(player.position, other.transform.position)-3);
            other.gameObject.GetComponent<get_dragged>().is_dragged = true;
        }
        else if (other.gameObject.tag != "Player" && other.gameObject.tag != "grappleTrough" && inWall == false) GameObject.Destroy(gameObject);  
    }

    void OnTriggerExit2D(Collider2D other) //check collision
    {
        if (other.gameObject.tag.Equals("drag"))
        {
            other.gameObject.GetComponent<get_dragged>().is_dragged = false;
        }



    }
}
