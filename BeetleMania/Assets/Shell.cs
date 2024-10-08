using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * Random.Range(-1f, 1f) * 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom Wall")
        {
            rb.velocity = new Vector2(rb.velocity.x, 27);
        }
        if (collision.gameObject.name == "Left Wall" || collision.gameObject.name == "Right Wall")
        {
            if(Mathf.Abs(rb.velocity.x) < 0.5f)
            {
                rb.velocity = new Vector2(-Mathf.Sign(rb.velocity.x) * 2, rb.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter " + collision.gameObject.tag);
    }
}
