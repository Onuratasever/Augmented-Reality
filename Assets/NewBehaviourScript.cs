using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this object supposed to be rotated according to camera rotation

        // get the camera rotation
        Quaternion cameraRotation = Camera.main.transform.rotation;

        // set the rotation of this object to the camera rotation by using Euler
        transform.rotation = Quaternion.Euler(cameraRotation.eulerAngles.x, cameraRotation.eulerAngles.y, cameraRotation.eulerAngles.z);
    }
}
