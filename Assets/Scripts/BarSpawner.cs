using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSpawner : MonoBehaviour
{
    public GameObject barPrefab;
    public GameObject burgerPrefab; 
    public float timeToSpawn;
    public float minYPossition, maxYPossition;
    private float timer;

    [Range(0f, 1f)]
    public float burgerSpawnChance = 0.03f; 

    private void Update()
    {
        if (timer <= 0)
        {
            timer = timeToSpawn;
            
            GameObject bar = Instantiate(barPrefab, transform.position, Quaternion.identity);
            var rand = Random.Range(minYPossition, maxYPossition);
            bar.transform.position = new Vector3(bar.transform.position.x, rand, 0);

            Transform barPart1 = bar.transform.Find("BarPart1");
            Transform barPart2 = bar.transform.Find("BarPart2");

            Vector3 burgerSpawnPosition = new Vector3(
                bar.transform.position.x, 
                (barPart1.position.y + barPart2.position.y) / 2, 
                0
            );

            if (Random.value < burgerSpawnChance)
            {
                GameObject burger = Instantiate(burgerPrefab, burgerSpawnPosition, Quaternion.identity);
                Burger burgerScript = burger.GetComponent<Burger>();
                burgerScript.EnableCollision();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}