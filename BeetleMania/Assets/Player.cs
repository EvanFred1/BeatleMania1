using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    private Rigidbody2D rb;
    private Vector2 inputVec = Vector2.zero;
    public float speed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Get components
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }
    private void FixedUpdate()
    {
        rb.velocity = inputVec *speed *Time.fixedDeltaTime;
    }
}
