using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _numOfWaves;
    [SerializeField]
    private int _enemiesWaveMultiplier = 10;
    [SerializeField]
    private int _actualWave = 1;
    [SerializeField]
    private int _numOfEnemies;

    private float _timer;

    private void Start()
    {
        _timer = Time.time;
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {/*
        // int totalEnemies
        if(_numOfEnemies > _actualWave*_enemiesWaveMultiplier)
        {
            _numOfEnemies = 0;
            _actualWave++;
            _timer = Time.time + 10f;
        }

        if (Time.time > _timer)
        {
            SpawnEnemy();
            _timer = Time.time + Random.Range(1f, 3f);
            _numOfEnemies++;
        }
*/
    }

    void SpawnEnemy()
    {
        GameObject enemy = SpawnManager.Instance.RequestEnemy();
        enemy.transform.position = SpawnManager.Instance.startPoint.transform.position;

    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            // int
            if (_numOfEnemies < _actualWave * _enemiesWaveMultiplier)
            {
                SpawnEnemy();
                _numOfEnemies++;
                yield return new WaitForSeconds(Random.Range(0f, 1.5f));
            }
            else
            {
                _actualWave++;
                _numOfEnemies = 0;
                yield return new WaitForSeconds(3f);
            }
        }
    }


   


}
