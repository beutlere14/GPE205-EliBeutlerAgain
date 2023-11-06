using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public float invincibleTimer;

    public Renderer[] PlayerRenderers;
    public Material invinMat;
    public Material invinMatTwo;
    public Material invinMatThree;


    public Material tankFirst;
    public Material tankSecond;
    public Material tankThird;

    public Animator m_anim;

    Material[] newMat;
    Material[] oldMat;

    //float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        newMat = new Material[] { invinMat, invinMatTwo, invinMatThree };

        oldMat = new Material[] { tankFirst , tankSecond , tankThird  };
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("ColorChange"))
        {
            foreach (var renderer in PlayerRenderers)
            {

                renderer.materials = newMat;
            }

            Invoke("NormalColor", invincibleTimer);

          
           
       }
    }

    public void NormalColor()
    {

        foreach (var renderer in PlayerRenderers)
        {
            renderer.materials = oldMat;

        }
    }
        
}
