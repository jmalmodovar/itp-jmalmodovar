using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // communicate with the object pool system to request an enemy.
            GameObject enemy = SpawnManager.Instance.RequestEnemy();
            enemy.transform.position = SpawnManager.Instance.startPoint.transform.position;
        }

    }
}
