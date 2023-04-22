using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _pm;
    public void MoveLeft()
    {
        _pm.Rotate(-1); 
        Debug.Log("Left"); 
    }

    public void MoveRight()
    {
        _pm.Rotate(1); 
        Debug.Log("Right"); 
    }
}
