using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harmText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.position.x,transform.position.y + Time.deltaTime * 0.3f, transform.position.z);
    }
}
