using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void Active(Vector3 pos)
    {
        transform.position = pos;

//        transform.position = pos + new Vector3(-0.21,0.1,0); << 이렇게하면 좀 더 위로 위치시킬 수 잇음
    }

    public void CallAni()
    {
        Destroy(gameObject);
    }
}
