using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    private GameObject selectedObject;
    private float initialDistance;
    private Vector3 initialScale;
    private float lastTapTime;
    private int tapCount;
    public float doubleTapThreshold = 0.3f;
    private bool isRotating = false;
    private bool isMoving = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // object selection and checking number of clicking on screeen
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (selectedObject != null)
                    {
                        ResetObjectColor(selectedObject);
                    }

                    selectedObject = hit.transform.gameObject;
                    ChangeObjectColor(selectedObject, Color.red);

                    // check number of selection
                    float currentTime = Time.time;
                    if (currentTime - lastTapTime < doubleTapThreshold)
                    {
                        tapCount++;
                        if (tapCount == 2)
                        {
                            isRotating = true;
                            isMoving = false;
                        }
                        else if (tapCount == 3)
                        {
                            isRotating = false;
                            isMoving = true;
                            tapCount = 0; // 3 tap change mode
                        }
                    }
                    else
                    {
                        tapCount = 1; // new one tap
                    }
                    lastTapTime = currentTime;
                }
            }

            // rotating selected object
            if (selectedObject != null && isRotating && touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * 0.1f;
                float rotationY = touch.deltaPosition.y * 0.1f;

                selectedObject.transform.Rotate(Vector3.up, -rotationX, Space.World);
                selectedObject.transform.Rotate(Vector3.right, rotationY, Space.World);
            }

            // moving selected object
            if (selectedObject != null && isMoving && touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                selectedObject.transform.position = worldPosition;
            }

            // scaling with two fingers
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                // Calculate the distance between two fingers
                if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
                {
                    initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    initialScale = selectedObject.transform.localScale;
                }

                if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
                {
                    float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    if (Mathf.Approximately(initialDistance, 0))
                        return;

                    float scaleFactor = currentDistance / initialDistance;
                    selectedObject.transform.localScale = initialScale * scaleFactor;
                }
            }
        }
    }

    void ChangeObjectColor(GameObject obj, Color color)
    {
        var renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    void ResetObjectColor(GameObject obj)
    {
        var renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.white;
        }
    }
}
