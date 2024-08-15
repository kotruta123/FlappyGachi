using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BgMover : MonoBehaviour
{
    public float StartX;
    public float EndX;
    public GameObject bgPrefab;

    void Update()
    {
        if (transform.position.x < EndX)
        {
            transform.position = new Vector2(StartX, transform.position.y);
            
            Instantiate(bgPrefab, new Vector2(StartX, transform.position.y), Quaternion.identity);
        }
    }
}
