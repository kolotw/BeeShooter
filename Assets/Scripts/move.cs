using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float 速度 = 2f;
    Vector3 pos;
    public GameObject myBullet;
    public Transform firePosA;
    public Transform firePosB;
    public int 血量 = 30;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // movement method
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(Vector3.up * 速度 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(Vector3.down * 速度 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(Vector3.right * 速度 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(Vector3.left * 速度 * Time.deltaTime);
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
            Instantiate(myBullet, firePosA.position, Quaternion.identity);
            Instantiate(myBullet, firePosB.position, Quaternion.identity);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("敵方子彈"))
        {
            Destroy(other.gameObject);
            血量--;
            if(血量 <= 0)
            {
                Destroy(this.gameObject);
                print("輸了");
            }
        }
    }
}
