using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMapOnExit : MonoBehaviour
{
    private float triggerLimit = 0;

    private void OnTriggerExit(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            if (triggerLimit == 0)
            {



                triggerLimit = 1;
                SelfDestruct();
            }
        }
    }




    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
