using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(this.transform.parent.name);
        if (this.transform.parent.name != "play")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
