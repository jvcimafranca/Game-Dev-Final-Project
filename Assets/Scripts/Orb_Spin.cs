using UnityEngine;

public class Orb_Spin : MonoBehaviour
{
    public float rotationSpeed = 20f; 
    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
