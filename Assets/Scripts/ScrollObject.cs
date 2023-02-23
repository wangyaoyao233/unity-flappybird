using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float Speed = 2.0f;

    // ÊµÏÖ¹ö¶¯
    void Update()
    {
        if (GameControl.instance.isGameOver) return;

        Vector3 pos = this.gameObject.transform.position;
        pos.x -= Speed * Time.deltaTime;
        this.gameObject.transform.position = pos;
    }
}
