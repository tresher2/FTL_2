using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class door : MonoBehaviour
{
    [SerializeField]
    Sprite[] doors;
    bool i = true;
    public void open_door()
    {
        if (i)
        {
            gameObject.GetComponent<Image>().sprite = doors[1];
            i = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = doors[0];
            i = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        i = true;
        open_door();
        Debug.Log("open_door");
    }
}
