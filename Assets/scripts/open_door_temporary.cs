using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door_temporary : MonoBehaviour
{
    public GameObject door;
    public GameObject door1;

    void OnTriggerStay2D(Collider2D other)
    {
         if (other.gameObject.tag.Equals("Player") == true || other.gameObject.tag.Equals("drag") == true)
           {
            if (door.GetComponent<open>() == true)
            {
                door.SetActive(door.GetComponent<open>().default_open);
                if (door1 != null) door1.SetActive(door1.GetComponent<open>().default_open);
            }
            else
            {
                door.SetActive(!door.GetComponent<push_player>().default_on);
                if (door1 != null) door1.SetActive(!door1.GetComponent<push_player>().default_on);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") == true || other.gameObject.tag.Equals("drag") == true)
        {
            if (door.GetComponent<open>() == true)
            {
                door.SetActive(!door.GetComponent<open>().default_open);
                if (door1 != null) door1.SetActive(!door1.GetComponent<open>().default_open);
            }
            else
            {
                door.SetActive(door.GetComponent<push_player>().default_on);
                if (door1 != null) door1.SetActive(door1.GetComponent<push_player>().default_on);
            }
        }
    }
}
