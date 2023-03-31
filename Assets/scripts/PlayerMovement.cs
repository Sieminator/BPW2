using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    public bool not_move = false;

    //control values
    public float speed;
    public float Jump;

    //calculation variables
    private float Move;
    public LayerMask groundLayer;
    [SerializeField] private float raycastLength;
    private RaycastHit2D groundCheck;

    //grappling
    public bool is_grappling = false;

    //references
    public Rigidbody2D rb;
    public GameObject grappling_hook;
    public GameObject drag_hook;
    GameObject hook_destroy;
    GameObject drag_destroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 300;
    }


    void Update()
    {
        if (!not_move)
        {
            //input
            Move = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && groundCheck.collider != null)
            {
                if (!is_grappling) rb.AddForce(new Vector2(rb.velocity.x, Jump));
            }


            //grappling
            if (Input.GetMouseButtonDown(0)) hook_destroy = Instantiate(grappling_hook, transform.position, transform.rotation, null);//begin grapple

            if (!Input.GetMouseButton(0))//end grapple
            {
                rb.gravityScale = 1;//enable gravity
                Destroy(hook_destroy);
                is_grappling = false; //get control over player
            }

            //pulling
            if (Input.GetMouseButtonDown(1)) drag_destroy = Instantiate(drag_hook, transform.position, transform.rotation, null);//begin pull

            if (!Input.GetMouseButton(1)) Destroy(drag_destroy);//end pull
        }
        else
        {
            Destroy(drag_destroy);

            rb.gravityScale = 1;//enable gravity
            Destroy(hook_destroy);
            is_grappling = false; //get control over player
        }
    }

    void FixedUpdate()
    {
        if (is_grappling == false)//output
        {
            groundCheck = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, groundLayer); //check whether the player can jump
            rb.velocity = new Vector2(speed * Move, rb.velocity.y); //output movement
        }
    }

    void OnCollisionEnter2D(Collision2D other) //end the grapple when a movable object is hit
    {
        if (other.gameObject.tag == "drag" && is_grappling == true)
        {
            if (other.gameObject.GetComponent<get_dragged>().is_dragged == false)
            {
                //if (other.gameObject.GetComponent<get>)
                rb.gravityScale = 1;//enable gravity
                Destroy(hook_destroy);
                is_grappling = false; //get control over player
            }
        }
    }
}
