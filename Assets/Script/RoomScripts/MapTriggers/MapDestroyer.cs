using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider[] intersecting = Physics.OverlapBox(transform.position, transform.forward);
        if (intersecting.Length == 0)
        {
            Destroy(gameObject);
            Debug.LogWarning("Map Destroyed to avoid Overlap.");
        }
    }

}
