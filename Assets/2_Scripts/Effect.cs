using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public void Active(Vector3 pos)
    {
        transform.position = pos;

//        transform.position = pos + new Vector3(-0.21,0.1,0); << �̷����ϸ� �� �� ���� ��ġ��ų �� ����
    }

    public void CallAni()
    {
        Destroy(gameObject);
    }
}
