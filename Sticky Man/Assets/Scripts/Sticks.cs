using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticks : MonoBehaviour
{
    private bool active = false;

    public bool Active { get => active; set => active = value; }
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (active)
        {
            //rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tilemap"))
        {
            if (PlayerMovement.TempObj == null)
            {
                active = true;
            }

            else if (PlayerMovement.TempObj != this.gameObject)
            {
                active = true;
            }
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tilemap"))
        {
            active = false;
        }

    }

}
