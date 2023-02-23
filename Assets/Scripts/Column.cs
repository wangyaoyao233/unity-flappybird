using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public float width = 40f;
    float startPosX;
    void Start()
    {
        startPosX = transform.position.x;
    }

    void Update()
    {
        // ����һ��λ��֮��, ���մ˶���
        if (startPosX - transform.position.x >= width)
        {
            ColumnSpawn.instance.DestoryColumn(gameObject);
        }
    }
}
