

using UnityEngine;



public class BarSpawner : MonoBehaviour
{
   public GameObject barPrefab;
   public float timeToSpawn;
   public float minYPossition, maxYPossition;
   private float timer;
  

   

   private void Update()
   {
      if (timer<=0)
      {
         timer = timeToSpawn;
         GameObject bar = Instantiate(barPrefab, transform.position, Quaternion.identity);
         var rand = Random.Range(minYPossition, maxYPossition);
         bar.transform.position = new Vector3(bar.transform.position.x, rand, 0);
      }
      else
      {
         timer -= Time.deltaTime;
      }
   }
}
