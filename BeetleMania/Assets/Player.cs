using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    private Rigidbody2D rb;
    private Vector2 inputVec = Vector2.zero;
    public float speed = 50.0f;

    public GameObject bullet;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = inputVec * speed * Time.fixedDeltaTime;
    }
    void SpawnBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
    }
}
