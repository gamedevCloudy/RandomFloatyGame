using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _pm;
    private float _move; 

    void Update()
    {
        _move = (Input.GetAxis("Horizontal"))%1; 
        _pm.Rotate(Mathf.RoundToInt(_move)); 
        
    }

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
