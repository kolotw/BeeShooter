using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    //Raycast
    public Camera mainCamera;
    Vector3 rayPos = Vector3.zero;
    public float 子彈間距 = 0.3f;

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
        mainCamera = Camera.main;
        //連續發射子彈
        InvokeRepeating("發射子彈", 0.5f, 子彈間距);
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast
        // 當滑鼠左鍵按下時
        if (Input.GetMouseButton(0))
        {
            // 創建一條從滑鼠位置射向場景的 Ray
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 檢查 Ray 是否碰撞到物件
            if (Physics.Raycast(ray, out hit))
            {
                // 將 GameObject 移動到碰撞點的位置
                rayPos = hit.point;
                rayPos.z = 0;
                transform.position = rayPos;
            }
        }
        



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
    void 發射子彈()
    {
        Instantiate(myBullet, firePosA.position, Quaternion.identity);
        Instantiate(myBullet, firePosB.position, Quaternion.identity);
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
