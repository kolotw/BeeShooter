using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 移動背景 : MonoBehaviour
{
    // 調整移動速度
    public float scrollSpeed = 0.5f;

    // 用來儲存材質的 Material
    private Material backgroundMaterial;

    // 用來儲存材質的 Offset
    private Vector2 textureOffset;
    // Start is called before the first frame update
    void Start()
    {
        // 獲取物件上的材質
        backgroundMaterial = GetComponent<Renderer>().material;
        textureOffset = backgroundMaterial.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // 持續在 Y 軸上移動材質的 Offset
        textureOffset.y += scrollSpeed * Time.deltaTime;

        // 更新材質的 Offset
        backgroundMaterial.mainTextureOffset = textureOffset;
    }
}
