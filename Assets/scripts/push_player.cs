using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push_player : MonoBehaviour
{
    public bool default_on;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.GetComponent<PlayerMovement>().rb.AddForce(Vector2.up * Time.deltaTime * 2000);
        }
        if (other.gameObject.tag.Equals("drag"))
        {
            other.GetComponent<get_dragged>().rb.AddForce(Vector2.up * Time.deltaTime * 2000);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.GetComponent<PlayerMovement>().rb.AddForce(Vector2.up * Time.deltaTime * 2000);
        }
        if (other.gameObject.tag.Equals("drag"))
        {
            other.GetComponent<get_dragged>().rb.AddForce(Vector2.up * Time.deltaTime * 2000);
        }
    }
}
