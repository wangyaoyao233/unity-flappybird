using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    float width = 0f;
    Vector3 startPos;

    void Start()
    {
        width = GetComponent<BoxCollider2D>().size.x;
        startPos = this.gameObject.transform.position;
    }

    void Update()
    {
        // ���ƶ���һ����ȵľ���ʱ, ����Ϊ��ʼλ��
        if (startPos.x - this.gameObject.transform.position.x >= width)
        {
            this.gameObject.transform.position = startPos;
            return;
        }
    }
}
