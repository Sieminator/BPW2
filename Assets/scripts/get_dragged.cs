using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_dragged : MonoBehaviour
{
    public bool is_dragged = false;

    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (is_dragged) gameObject.layer = LayerMask.NameToLayer("Default");
       else gameObject.layer = LayerMask.NameToLayer("Ground");
    }
}
