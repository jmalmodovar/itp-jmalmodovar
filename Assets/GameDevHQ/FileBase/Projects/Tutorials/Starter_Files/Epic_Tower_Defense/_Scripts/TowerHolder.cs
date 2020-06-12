using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    private bool _isEmpty = true;

    void OnEnable()
    {
        TowerPlacement.OnPlacingTower += AvailableSpot;
    }

    void OnDisable()
    {
        TowerPlacement.OnPlacingTower -= AvailableSpot;
    }

    public void AvailableSpot()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isEmpty)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }


}
