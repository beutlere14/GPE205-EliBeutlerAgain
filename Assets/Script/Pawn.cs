using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    /// <summary>
    /// Varible for Movement Speed.
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// Varible for Turn Speed
    /// </summary>
    public float turnSpeed;

    


    // Start is called before the first frame update
    public virtual void Start()
    {
     
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void RotateTowards(Vector3 targetPosition);
    public abstract void Shoot();

}
