using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform startPosn; 
    [SerializeField]private List<GameObject> _spawnPosn; 
    [SerializeField] private GameObject _empty; 

    void Start()
    {
        GenerateGrid(); 
    }
    void GenerateGrid()
    {
        for(int i=1;i<30;i*=5)
        {
            for(int j=1; j<30;j*=5)
            {
                // GameObject _g = Instantiate(_empty, Vector3.zero, Quaternion.identity); 
                // // Transform _t = new Transform();     
                // _g.transform.position = new Vector3(i,0,j); 
                // _g.transform.SetParent(gameObject.transform); 
                // _spawnPosn.Add(_g);  
                Debug.Log(i,j); 
            }

        }
    }
}
