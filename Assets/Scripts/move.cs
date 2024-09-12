using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float �t�� = 3f;
    Vector3 pos;
    public GameObject myBullet;
    public Transform firePos;

    // Start is called before the first frame update
    void Start()
    {
        //print("Hello world");
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // movement method
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(Vector3.up * �t�� * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(Vector3.down * �t�� * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(Vector3.right * �t�� * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(Vector3.left * �t�� * Time.deltaTime);
            }
        }
        // set position
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            pos.y = -3f;
            this.transform.position = pos;
        }
        // fire bullet
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            Instantiate(myBullet, firePos.position, Quaternion.identity);

        }
    }
}
