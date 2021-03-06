﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _decoyTower;

    [SerializeField]
    private GameObject[] _realTower;

    private bool _isPlacingTower;

    // Event signaling that I'm placing a tower
    public delegate void PlacingTower();
    public static event PlacingTower OnPlacingTower;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _decoyTower[0].gameObject.SetActive(true);

            // event
            if(OnPlacingTower!=null)
            {
                OnPlacingTower();
            }

            _isPlacingTower = true;
        }

        if(Input.GetMouseButtonDown(1))
        {
            _isPlacingTower = false;
            _decoyTower[0].gameObject.SetActive(false);
            //_decoyTower[0].transform.GetChild(0).gameObject.SetActive(false);
            //_decoyTower[0].transform.GetChild(1).gameObject.SetActive(true);
        }

        if(_isPlacingTower) PlaceTurret();

    }

    private void PlaceTurret()
    {
        // Cast a ray to the game world & update position of our decoy tower
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            if (hitInfo.collider.tag == "Base")
            {
                _decoyTower[0].transform.position = hitInfo.collider.transform.position + new Vector3(0f, 1f, 0f);
                _decoyTower[0].transform.GetChild(0).gameObject.SetActive(true);
                _decoyTower[0].transform.GetChild(1).gameObject.SetActive(false);

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(_realTower[0], _decoyTower[0].transform.position, Quaternion.identity);
                }
            }
            else
            {
                _decoyTower[0].transform.position = hitInfo.point;
                _decoyTower[0].transform.GetChild(0).gameObject.SetActive(false);
                _decoyTower[0].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
