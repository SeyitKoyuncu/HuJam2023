using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This method for using, dont destroy the necesseray objects when we loading new scene
public class SaveMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
