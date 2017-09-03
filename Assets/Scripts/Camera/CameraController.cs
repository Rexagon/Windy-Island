using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float movementSpeed = 25.0f;
    public float rotationSpeed = 100.0f;
    public float zoomSpeed = 250.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Handle movement
        float horizontalTranslation = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float forwardTranslation = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float verticalTranslation = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;

        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();

        transform.Translate(horizontalTranslation, 0, verticalTranslation);
        transform.Translate(forward * forwardTranslation, Space.World);

        float rotation = Input.GetAxis("Rotation") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation, Space.World);
    }
}
