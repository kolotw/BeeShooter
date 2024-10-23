using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public GameObject[] 敵人; // 要生成的 GameObject 預製體
    public int rows = 3;
    public int columns = 5;
    public float spacing = 1.5f; // 物件之間的間距
    public Vector3 origin = new Vector3(0, 0, 0);  // 初始的座標原點

    private GameObject[,] grid;

    public Text 遊戲訊息;

    // Start is called before the first frame update
    void Start()
    {
        遊戲訊息.text = string.Empty;
        //產生敵人陣列(2,4);
        產生菱形(5, 5);
    }
    void 產生敵人陣列(int r, int c)
    {
        rows = r; columns = c;
        grid = new GameObject[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // 計算每個物件的位置
                Vector3 position = origin + new Vector3(j * spacing, i * spacing, 0);

                // 實例化物件
                int rnd = Random.Range(0, 敵人.Length);
                GameObject newObject = Instantiate(敵人[rnd], position, Quaternion.identity);

                // 將實例化的物件存入陣列
                grid[i, j] = newObject;
            }
        }
    }

    void 產生菱形(int r, int c)
    {
        rows = r; columns = c;
        // 計算菱形的中間行索引
        int middleRow = rows / 2;

        for (int i = 0; i < rows; i++)
        {
            // 確定每一行應該有的物件數量，根據行數的索引進行左右對稱排列
            int objectsInRow = rows - Mathf.Abs(middleRow - i);

            for (int j = 0; j < objectsInRow; j++)
            {
                // 計算每個物件的位置
                float xOffset = (objectsInRow - 1) * 0.5f * spacing; // 確保居中排列
                Vector3 position = origin + new Vector3(j * spacing - xOffset, i * spacing, 0);

                // 實例化物件
                int rnd = Random.Range(0, 敵人.Length);
                Instantiate(敵人[rnd], position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
         勝敗條件
         勝：場內無敵人
         敗：玩家消失
         */
        if(GameObject.FindGameObjectsWithTag("敵人").Length == 0)
        {
            遊戲訊息.text = "勝";
        }
        if(GameObject.Find("/太空船_Player") == null)
        {
            遊戲訊息.text = "輸";
        }
    }
}
