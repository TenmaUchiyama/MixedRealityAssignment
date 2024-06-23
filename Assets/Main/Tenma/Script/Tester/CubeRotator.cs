using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{

    [SerializeField] GameObject referenceObject;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    
    public bool reverse;
    public float zoomSpeed = 1;

    private Camera mainCamera;
    private Vector2 lastMousePosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                var x = (Input.mousePosition.y - lastMousePosition.y);
                var y = (lastMousePosition.x - Input.mousePosition.x);

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                transform.Rotate(newAngle, Space.World);
                referenceObject.transform.Rotate(newAngle, Space.World);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var x = (lastMousePosition.y - Input.mousePosition.y);
                var y = (Input.mousePosition.x - lastMousePosition.x);

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                transform.Rotate(newAngle, Space.World);
                referenceObject.transform.Rotate(newAngle, Space.World);
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}
