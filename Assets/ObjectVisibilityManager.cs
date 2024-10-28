using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] objects;

    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int i;
        for (i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }

        if (objects.Length > 0)
        {
            objects[0].SetActive(true);  // activate first object
        }
    }

    public void ShowNextObject()
    {
        objects[currentIndex].SetActive(false);

        currentIndex = (currentIndex + 1) % objects.Length;

        objects[currentIndex].SetActive(true);
    }

    public void ShowPreviousObject()
    {
        objects[currentIndex].SetActive(false);

        currentIndex = (currentIndex - 1 + objects.Length) % objects.Length;

        objects[currentIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
