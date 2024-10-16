using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [HideInInspector] public ShellSpawner spawner;
    private Rigidbody2D rb;
    private bool wasHit = false;
    public GameObject bullet;
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
        if (collision.gameObject.tag == "Bullet" && !wasHit)
        {
            wasHit = true;
            Destroy(collision.gameObject);
           
           
            for(var i = 0; i < 5; i++)
            {
                //
                GameObject newBullet = Instantiate(bullet);

                Vector3 bulletDir = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f),0).normalized;

                newBullet.GetComponent<Bullet>().SetUp(bulletDir);
                
                newBullet.transform.position = transform.position;

                Destroy(newBullet.gameObject, 0.25f);
            }
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        spawner.numberOfShells--;
    }
}
