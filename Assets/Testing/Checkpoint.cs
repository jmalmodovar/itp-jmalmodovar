using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public delegate void OnCubeTouched();
    public static event OnCubeTouched onCubeTouched;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(onCubeTouched != null)
            {
                onCubeTouched();
            }
        }
    }
}
