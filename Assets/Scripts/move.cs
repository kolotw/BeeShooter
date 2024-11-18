using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    //Raycast
    public Camera mainCamera;
    Vector3 rayPos = Vector3.zero;
    public float �l�u���Z = 0.3f;

    public float �t�� = 2f;
    Vector3 pos;
    public GameObject myBullet;
    public Transform firePosA;
    public Transform firePosB;
    public int ��q = 30;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        mainCamera = Camera.main;
        //�s��o�g�l�u
        InvokeRepeating("�o�g�l�u", 0.5f, �l�u���Z);
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast
        // ��ƹ�������U��
        if (Input.GetMouseButton(0))
        {
            // �Ыؤ@���q�ƹ���m�g�V������ Ray
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // �ˬd Ray �O�_�I���쪫��
            if (Physics.Raycast(ray, out hit))
            {
                // �N GameObject ���ʨ�I���I����m
                rayPos = hit.point;
                rayPos.z = 0;
                transform.position = rayPos;
            }
        }
        



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
            Instantiate(myBullet, firePosA.position, Quaternion.identity);
            Instantiate(myBullet, firePosB.position, Quaternion.identity);
        }


    }
    void �o�g�l�u()
    {
        Instantiate(myBullet, firePosA.position, Quaternion.identity);
        Instantiate(myBullet, firePosB.position, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("�Ĥ�l�u"))
        {
            Destroy(other.gameObject);
            ��q--;
            if(��q <= 0)
            {
                Destroy(this.gameObject);
                print("��F");
            }
        }
    }
}
