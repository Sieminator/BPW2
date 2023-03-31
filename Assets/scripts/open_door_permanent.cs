using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door_permanent : MonoBehaviour
{
    public GameObject door;
    public GameObject door1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") == true || other.gameObject.tag.Equals("drag") == true)
        {
            door.SetActive(false);
            door1.SetActive(false);
        }
    }
}
