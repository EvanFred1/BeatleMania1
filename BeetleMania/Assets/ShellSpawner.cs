using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public GameObject shell;
    private float shellSpawnTime = 0.35f;
    private float spawnTimer = 0;
    private int maxShellSpawns = 30;
    [HideInInspector] public int numberOfShells = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Delat initail spawn
        spawnTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfShells < maxShellSpawns)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                SpawnShell();
            }

        }
    }
    private void SpawnShell()
    {
        GameObject newShell = Instantiate(shell);
        newShell.transform.position = new Vector2(Random.Range(-7f, 7f), 6.5f);
        numberOfShells++;
        spawnTimer = shellSpawnTime;

        newShell.GetComponent<Shell>().spawner = this;
    }
}
