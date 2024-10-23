using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 敵人的行為 : MonoBehaviour
{
    
    
    // 移動速度
    public float 移動速度 = 2.0f;
    // 左右移動範圍
    public float 移動範圍 = 5.0f;
    // 初始位置
    private Vector3 初始位置;
    public int 血量 = 10;

    public GameObject 敵人的子彈;
    public Transform 發射點A; public Transform 發射點B;
    public float 發射頻率 = 1f;
    // Start is called before the first frame update
    void Start()
    {
        初始位置 = transform.position;
        血量 = Random.Range(1, 10);
        發射頻率 = Random.Range(1, 5);
        InvokeRepeating("發射子彈", 3f, 發射頻率);
    }
    void 發射子彈()
    {
        if (發射點B == null)
        {
            Instantiate(敵人的子彈, 發射點A.position, Quaternion.identity);
        }
        else
        {
            Instantiate(敵人的子彈, 發射點A.position, Quaternion.identity);
            Instantiate(敵人的子彈, 發射點B.position, Quaternion.identity);
        }
        
    }

// Update is called once per frame
void Update()
    {
        // 使用 Mathf.PingPong 來改變 x 軸的位置
        float x軸 = Mathf.PingPong(Time.time * 移動速度, 移動範圍) - 移動範圍 / 2;
        transform.position = new Vector3(初始位置.x + x軸, 初始位置.y, 初始位置.z);
    }

    //onTriggerEnter 另外一種寫法
    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.transform.tag == "我方子彈")
        {            
            血量--;
            if(血量<=0)
            {
                Destroy(gameObject); 
            }
            Destroy(collision.gameObject);
        }
    }


}
