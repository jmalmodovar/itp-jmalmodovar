using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The PoolManager is NULL.");

            return _instance;
        }
    }
    [SerializeField]
    private GameObject _bulletContainer;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private List<GameObject> _bulletPool;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _bulletPool = GenerateBullets(3);
    }

    List<GameObject> GenerateBullets(int ammountOfBullets)
    {
        for (int i = 0; i < ammountOfBullets; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.parent = _bulletContainer.transform;
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }

        return _bulletPool;
    }

    public GameObject RequestBullet()
    {
        // Loop through the bullet list checking for in-active bullet
        // found one? set it active and return it to the player
        foreach (var bullet in _bulletPool)
        {
            if(bullet.activeInHierarchy == false)
            {
                // bullet is available
                bullet.SetActive(true);
                return bullet;
            }
        }

        // if we made to this point... we need to generate more bullets.
        // if no bullets available (all are turned on)
        // generate x amount of bullets and run the request bullet method.
        GameObject newBullet = Instantiate(_bulletPrefab);
        newBullet.transform.parent = _bulletContainer.transform;
        _bulletPool.Add(newBullet);

        return newBullet;
    }

}
