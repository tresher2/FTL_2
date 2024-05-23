using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class game : MonoBehaviour
{
    [SerializeField]
    RawImage healch;
    [SerializeField]
    Texture[] healches, rooms, rooms_logo;
    [SerializeField]
    Vector2[] rooms_logo_size= { new Vector2(43,29), new Vector2(37,43),new Vector2(41,31),new Vector2(43,35) };
    [SerializeField]
    GameObject prefab_shield, prefab_energy, prefab_room;
    [SerializeField]
    Transform shield_pos, reactor_pos;
    [SerializeField]
    TMP_Text oxygen, engine;
    [SerializeField]
    List<GameObject> list_shields, list_energy,list_rooms;
    // 
    void Start()
    {
        healch.texture = healches[LORD.hp];
        oxygen.text = LORD.oxygen.ToString() + "%";
        engine.text = LORD.engine.ToString() + "%";
        /*spawn_bars(shield_pos, LORD.max_shield, 0, prefab_shield, new Vector2(-45.5f, 10.5f), new Vector2(45, 0));
        spawn_bars(reactor_pos, LORD.max_energy, 2, prefab_energy, new Vector2(-34, -5.5f), new Vector2(0, 17));
        spawn_bars(reactor_pos, LORD.rooms.Length, 1, prefab_room, new Vector2(96, -19), new Vector2(68, 0));*/
        for (int i = 0; i < LORD.max_shield; i++)
        {
            GameObject c = Instantiate(prefab_shield, Vector3.zero, Quaternion.identity, shield_pos);
            c.GetComponent<RectTransform>().localPosition = new Vector2(-45.5f + 45 * i, 10.5f);
            list_shields.Add(c.transform.GetChild(0).gameObject);
            if (LORD.shield <= i)
            {
                c.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 2; i < LORD.max_energy; i++)
        {
            GameObject c = Instantiate(prefab_energy, Vector3.zero, Quaternion.identity, reactor_pos);
            c.GetComponent<RectTransform>().localPosition = new Vector2(-34,-5.5f+17*i);
            list_energy.Add(c.transform.GetChild(0).gameObject);
            if (LORD.energy <= i)
            {
                c.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if (LORD.energy <= 0)
        {
            list_energy[0].SetActive(false);
        }
        if (LORD.energy <= 1)
        {
            list_energy[1].SetActive(false);
        }
        for (int i = 1; i < LORD.rooms.Count; i++)
        {
            GameObject c = Instantiate(prefab_room, Vector3.zero, Quaternion.identity, reactor_pos);
            c.GetComponent<RectTransform>().localPosition = new Vector2(28+ 68*i, -19);
            list_rooms.Add(c.transform.GetChild(0).gameObject);
            c.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = rooms[LORD.rooms_enabled[i]];
            c.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RawImage>().texture = rooms_logo[LORD.rooms[i]];
            c.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta= rooms_logo_size[LORD.rooms[i]];
        }
        list_rooms[0].GetComponent<RawImage>().texture = rooms[LORD.rooms_enabled[0]];
        list_rooms[0].transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = rooms_logo[LORD.rooms[0]];
        list_rooms[0].transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = rooms_logo_size[LORD.rooms[0]];

    }
    /*void spawn_bars(Transform pos, int max, int ot, GameObject prefab, Vector2 coord, Vector2 smeh)
    {
        for (int i = ot; i < max; i++)
        {
            GameObject c = Instantiate(prefab, Vector3.zero, Quaternion.identity, pos);
            c.GetComponent<RectTransform>().anchoredPosition = coord + smeh * i;
            c.GetComponent<bar>().num = i;
            c.GetComponentInChildren<GameObject>();
            
        }
    }*/
}
