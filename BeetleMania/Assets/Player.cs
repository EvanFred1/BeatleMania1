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
    public float rateOfFire = 0.5f;
    private float shootTimer = 0.0f;
    [HideInInspector] public int bulletCounter = 0;
    private int MaxBullets = 5;
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
        if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0 && bulletCounter < MaxBullets)
        {
            SpawnBullet();
            shootTimer = rateOfFire;
            bulletCounter++;
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
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
        newBullet.GetComponent<Bullet>().player = this;
    }
}
