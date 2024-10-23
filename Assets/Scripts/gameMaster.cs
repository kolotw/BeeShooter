using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public GameObject[] �ĤH; // �n�ͦ��� GameObject �w�s��
    public int rows = 3;
    public int columns = 5;
    public float spacing = 1.5f; // ���󤧶������Z
    public Vector3 origin = new Vector3(0, 0, 0);  // ��l���y�Э��I

    private GameObject[,] grid;

    public Text �C���T��;

    // Start is called before the first frame update
    void Start()
    {
        �C���T��.text = string.Empty;
        //���ͼĤH�}�C(2,4);
        ���͵٧�(5, 5);
    }
    void ���ͼĤH�}�C(int r, int c)
    {
        rows = r; columns = c;
        grid = new GameObject[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // �p��C�Ӫ��󪺦�m
                Vector3 position = origin + new Vector3(j * spacing, i * spacing, 0);

                // ��Ҥƪ���
                int rnd = Random.Range(0, �ĤH.Length);
                GameObject newObject = Instantiate(�ĤH[rnd], position, Quaternion.identity);

                // �N��Ҥƪ�����s�J�}�C
                grid[i, j] = newObject;
            }
        }
    }

    void ���͵٧�(int r, int c)
    {
        rows = r; columns = c;
        // �p��٧Ϊ����������
        int middleRow = rows / 2;

        for (int i = 0; i < rows; i++)
        {
            // �T�w�C�@�����Ӧ�������ƶq�A�ھڦ�ƪ����޶i�楪�k��ٱƦC
            int objectsInRow = rows - Mathf.Abs(middleRow - i);

            for (int j = 0; j < objectsInRow; j++)
            {
                // �p��C�Ӫ��󪺦�m
                float xOffset = (objectsInRow - 1) * 0.5f * spacing; // �T�O�~���ƦC
                Vector3 position = origin + new Vector3(j * spacing - xOffset, i * spacing, 0);

                // ��Ҥƪ���
                int rnd = Random.Range(0, �ĤH.Length);
                Instantiate(�ĤH[rnd], position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
         �ӱѱ���
         �ӡG�����L�ĤH
         �ѡG���a����
         */
        if(GameObject.FindGameObjectsWithTag("�ĤH").Length == 0)
        {
            �C���T��.text = "��";
        }
        if(GameObject.Find("/�ӪŲ�_Player") == null)
        {
            �C���T��.text = "��";
        }
    }
}
