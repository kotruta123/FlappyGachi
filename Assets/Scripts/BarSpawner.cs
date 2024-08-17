using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSpawner : MonoBehaviour
{
    public GameObject barPrefab;
    public GameObject burgerPrefab; // Add this line for the burger prefab
    public float timeToSpawn;
    public float minYPossition, maxYPossition;
    private float timer;

    [Range(0f, 1f)]
    public float burgerSpawnChance = 0.03f; // Very low chance to spawn a burger (1%)

    private void Update()
    {
        if (timer <= 0)
        {
            timer = timeToSpawn;

            // Instantiate the bar
            GameObject bar = Instantiate(barPrefab, transform.position, Quaternion.identity);
            var rand = Random.Range(minYPossition, maxYPossition);
            bar.transform.position = new Vector3(bar.transform.position.x, rand, 0);

            // Get the BarPart1 and BarPart2 positions
            Transform barPart1 = bar.transform.Find("BarPart1");
            Transform barPart2 = bar.transform.Find("BarPart2");

            // Calculate the midpoint between BarPart1 and BarPart2
            Vector3 burgerSpawnPosition = new Vector3(
                bar.transform.position.x, 
                (barPart1.position.y + barPart2.position.y) / 2, 
                0
            );

            // Randomly spawn the burger between the bars with a very low chance
            if (Random.value < burgerSpawnChance)
            {
                GameObject burger = Instantiate(burgerPrefab, burgerSpawnPosition, Quaternion.identity);
                Burger burgerScript = burger.GetComponent<Burger>();
                burgerScript.EnableCollision(); // Enable burger collision when it spawns
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}