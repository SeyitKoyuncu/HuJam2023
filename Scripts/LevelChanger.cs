using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isInFirstLevel = true;
    private bool keyWasPressed;
    [SerializeField] GameObject[] firstLevelObjects;
    [SerializeField] GameObject[] secondLevelObjects;

    void Start()
    {
        if(secondLevelObjects != null)
        {
            foreach (GameObject platform2 in secondLevelObjects)
            {
                platform2.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K) && !keyWasPressed)
        {
            // Toggle the flag
            keyWasPressed = true;

            // Deactivate or activate objects based on the current level
            DeactivateOtherLevelObejcts();
        }
        else if (!Input.GetKey(KeyCode.K))
        {
            // Reset the flag when the key is released
            keyWasPressed = false;
        }
    }

    private void DeactivateOtherLevelObejcts()
    {
        isInFirstLevel = !isInFirstLevel;
        if (firstLevelObjects != null && secondLevelObjects != null)
        {
            if (isInFirstLevel == true)
            {
                foreach (GameObject platform1 in firstLevelObjects)
                {
                    platform1.SetActive(true);
                }
                foreach (GameObject platform2 in secondLevelObjects)
                {
                    platform2.SetActive(false);
                }
            }
            else if (isInFirstLevel == false)
            {
                foreach (GameObject platform1 in firstLevelObjects)
                {
                    platform1.SetActive(false);
                }
                foreach (GameObject platform2 in secondLevelObjects)
                {
                    platform2.SetActive(true);
                }
            }
        }
    }
}
