using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TateScroll : MonoBehaviour
{
    private float speed = 1;//”wŒi‚ªˆÚ“®‚·‚é‘¬“x

    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        if (transform.position.y <= -11)
        {
            transform.position = new Vector3(0, 21.1f);
        }
    }
}
