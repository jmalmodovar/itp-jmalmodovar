using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("The SpawnManager is NULL");
            }

            return _instance;              
        }
    }

    [SerializeField]
    private GameObject _enemiesContainer;
    [SerializeField]
    private int _initialPoolSize;
    [SerializeField]
    private List<GameObject> _enemiesPool;
    [SerializeField]
    private GameObject[] _enemyPrefab;
    public GameObject startPoint;
    public GameObject endPoint;
    

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _enemiesPool = GenerateEnemies(_initialPoolSize);
    }

    private List<GameObject> GenerateEnemies(int amountOfEnemies)
    {

        for(int i = 0; i < amountOfEnemies; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab[Random.Range(0,2)]); // lenght array
            enemy.transform.parent = _enemiesContainer.transform;
            enemy.SetActive(false);
            _enemiesPool.Add(enemy);
        }

        return _enemiesPool;
    }

    public GameObject RequestEnemy()
    {
        // Loop enemy pool checking for inactive enemy.
        foreach (var enemy in _enemiesPool)
        {
            if(enemy.activeInHierarchy==false)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        // if no enemy available generate a new one
        GameObject newEnemy = Instantiate(_enemyPrefab[Random.Range(0, 2)]);
        newEnemy.transform.parent = _enemiesContainer.transform;
        _enemiesPool.Add(newEnemy);
        return newEnemy;
    }
}
