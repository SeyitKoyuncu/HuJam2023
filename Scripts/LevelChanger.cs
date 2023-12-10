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

    [SerializeField] GameObject charachter;
    SpriteRenderer charachterSprite;
    [SerializeField] private Sprite firstLevelSprite;
    [SerializeField] private Sprite secondLevelSprite;

    void Start()
    {
        charachterSprite = charachter.GetComponent<SpriteRenderer>();
        if (firstLevelSprite != null)
            charachterSprite.sprite = firstLevelSprite;

        if (secondLevelObjects != null)
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
            ChangeChrachter();
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
    private void ChangeChrachter()
    {
        if (charachterSprite.sprite == firstLevelSprite)
        {
            charachterSprite.sprite = secondLevelSprite;
        }

        else
        {
            charachterSprite.sprite = firstLevelSprite;
        }
    }
}
