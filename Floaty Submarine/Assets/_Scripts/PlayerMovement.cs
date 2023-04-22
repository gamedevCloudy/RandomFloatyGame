using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb; 
    [SerializeField] private float _forceToAdd;
    [SerializeField] private float _torque;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate =60; 
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        //Add Force to move it in forward direction, by a factor of ForceToAdd. Multiplied with Time.deltaTime to standardize speed across devices. 
        rb.AddRelativeForce(Vector3.forward * _forceToAdd * Time.deltaTime); 
    }

    public void Rotate(int direction)
    {
        rb.AddTorque(0, direction*_torque * Time.deltaTime, 0, ForceMode.Impulse); 
    }
}
