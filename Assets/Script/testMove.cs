using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;
    public float step;
    private float progress;
    public Vector2 cur;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = start;
        cur = end;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (transform.position.x == cur.x && transform.position.y == cur.y)
        {
            if (cur == start)
                cur = end;
            else
                cur = start;
            progress = 0f;
        }
        else
        {
            if (cur == end)
            {
                transform.position = Vector2.Lerp(start, cur, progress);
               
            }
            else
            {
                transform.position = Vector2.Lerp(end, cur, progress);
                
            }
            progress += step;

        }
    }
}
