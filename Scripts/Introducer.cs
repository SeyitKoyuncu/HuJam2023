using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introducer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroTextController.isIntroEnd)
            Destroy(gameObject, 1);
    }
}
