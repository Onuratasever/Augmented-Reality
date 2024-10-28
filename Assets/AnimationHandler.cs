using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private float lastTapTime;
    public float doubleTapThreshold = 0.3f; // time between two tap

    void Start()
    {
        animator = GetComponent<Animator>(); // get animator
    }

    void Update()
    {
        // one tap
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            // detect object with ray
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // Eğer dokunulan obje bu script'e sahip obje ise
                {
                    float currentTime = Time.time;
                    if (currentTime - lastTapTime < doubleTapThreshold)
                    {
                        // double tap is detected use this trigger
                        animator.SetTrigger("PlayAnimation2");
                    }
                    else
                    {
                        // one tap is detected use this trigger
                        animator.SetTrigger("PlayAnimation");
                    }

                    lastTapTime = currentTime;
                }
            }
        }
    }
}
