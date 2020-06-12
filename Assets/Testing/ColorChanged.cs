using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanged : MonoBehaviour
{
    private MeshRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        Checkpoint.onCubeTouched += ChangeColor;
    }

    private void OnDisable()
    {
        Checkpoint.onCubeTouched -= ChangeColor;
    }

    private void ChangeColor()
    {
        
        Color color = new Color(Random.value, Random.value, Random.value);
        //this.GetComponent<MeshRenderer>().material.color = Color.white;
        _renderer.material.color = color;
        Debug.Log(color);
    }
}
