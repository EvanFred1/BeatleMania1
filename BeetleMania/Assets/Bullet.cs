using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector]public Player player;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void SetUp(Vector2 dir)
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector3.up * 500 * Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        if(player != null)
        {
            player.bulletCounter--;
        }
        
    }
}
