using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
