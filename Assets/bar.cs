using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    public int num;
    [SerializeField]
    int type;
    int c;
    [SerializeField]
    GameObject test;
    private void FixedUpdate()
    {
        switch (type)
        {
            case 0:
                c = LORD.shield;
            break;
            case 1:
                c = LORD.energy;
            break;
        }
        if (c > num)
        {
            test.SetActive(true);
        }
        else
        {
            test.SetActive(false);
        }
    }
}
