using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    //score
    public int currentScore = 0;
    private int pointValue = 1;
    private float chainTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chainTimer > 0)
        {
            chainTimer -= Time.deltaTime;
        }
    }
    public void AddPoints()
    {
        currentScore += pointValue;
        pointValue *= 2;
        pointValue = Mathf.Min(pointValue, 9999);

        if (chainTimer <= 0)
        {
            pointValue = 1;
            chainTimer = 0.5f;
        } 
        Debug.Log(currentScore);

    }
}
