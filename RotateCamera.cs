using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Remember horizontalInput gives value between -1 and 1 so we stored it here and later we will amplify it.
        float horizontalInput = Input.GetAxis("Horizontal");
        //rotate along Y axis and increase or decrease speed accordingly
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
