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
    
    enum States
    {
        Move,
        Downed
    }
    States state = States.Move;
    private int pressesNeeded = 5;
    private int presses = 0;

    private bool isInvincible = false;
    private float invincibleTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Get components
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.Move:
                StateMove();
                break;
            case States.Downed:
                StateDowned();
                break;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = inputVec * speed * Time.fixedDeltaTime;
    }
    void SpawnBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<Bullet>().SetUp(Vector3.up);
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Bullet>().player = this;
    }
    private void StateMove()
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
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    private void StateDowned()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            presses++;
            }
        if(presses>= pressesNeeded)
        {
            state = States.Move;
            presses = 0;
            pressesNeeded += 2;
            pressesNeeded = Mathf.Min(pressesNeeded, 25);

            GetComponent<SpriteRenderer>().color = Color.yellow;
            isInvincible = true;
            invincibleTimer = 1.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shell" && !isInvincible)
        {
            state = States.Downed;

            rb.velocity = Vector3.zero;
            inputVec = Vector3.zero;

            GetComponent<SpriteRenderer>().color = Color.gray;

            shootTimer = 0;
        }
    }
}
