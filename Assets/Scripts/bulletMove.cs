using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    float 速度 = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * 速度 * Time.deltaTime);
    }
}
