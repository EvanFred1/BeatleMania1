using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector3.up * 500* Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
