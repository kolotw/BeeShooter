using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 背景移動 : MonoBehaviour
{
    public float speed = 0.5f; // 控制位移速度
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // 計算新的 Y 偏移
        float offsetY = (Time.time * speed) % 1;


        // 設置材質的偏移量
        material.mainTextureOffset = new Vector2(material.mainTextureOffset.x, offsetY);
    }
}
