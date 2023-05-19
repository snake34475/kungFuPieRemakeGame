using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pugongMusic : MonoBehaviour
{
    public AudioClip cli1;
    public AudioClip cli2;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rd = new System.Random();
        int num=rd.Next(1,3);
        transform.GetComponent<AudioSource>().clip=num==1? cli1:cli2;
        transform.GetComponent<AudioSource>().Play();
        Debug.Log("num:" + num);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
