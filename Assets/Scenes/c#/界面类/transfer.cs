using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transfer : MonoBehaviour
{
    public Transform map;
    public int num;
    public string direction;//跳进取的方向
    private Vector2 position;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
         scene = SceneManager.GetActiveScene();
        num = 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "play")
        {
            SceneManager.LoadScene(this.name);
            if (GameObject.Find("play").gameObject != this.gameObject)
            {
                Destroy(this.gameObject);
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
