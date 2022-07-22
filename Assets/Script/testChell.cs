using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testChell : MonoBehaviour
{
    private Rigidbody2D rb;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FloorMap"))
        {
            //rb.MovePosition(collision.gameObject.transform.position);
            transform.parent = collision.gameObject.transform;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FloorMap"))
        {
            transform.parent = null;
        }
    }
}
