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
    Vector2[] rooms_logo_size;
    [SerializeField]
    GameObject prefab_shield, prefab_energy, prefab_room, prefab_room_mini;
    [SerializeField]
    Transform shield_pos, reactor_pos, room_mini_pos;
    [SerializeField]
    Transform[] rooms_in_ship;
    [SerializeField]
    Color[] colors_rooms;
    [SerializeField]
    TMP_Text oxygen, engine;
    [SerializeField]
    List<GameObject> list_shields, list_energy,list_rooms;
    int d = 0;
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
        LORD.rooms.Sort();
        for (int i = 1; i < LORD.rooms.Count; i++)
        {
            if (LORD.rooms[i] >= 4)
            {
                GameObject c = Instantiate(prefab_room_mini, Vector3.zero, Quaternion.identity, room_mini_pos);
                c.GetComponent<RectTransform>().localPosition = new Vector2(-100.5f + 67 * (i-d), 38.5f);
                list_rooms.Add(c);
                c.GetComponent<RawImage>().texture = rooms[LORD.rooms_enabled[i]];
                c.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = rooms_logo[LORD.rooms[i]];
                c.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = rooms_logo_size[LORD.rooms[i]];
            }
            else
            {
                d = i+1;
                GameObject c = Instantiate(prefab_room, Vector3.zero, Quaternion.identity, reactor_pos);
                c.GetComponent<RectTransform>().localPosition = new Vector2(28 + 68 * i, -19);
                list_rooms.Add(c.transform.GetChild(0).gameObject);
                c.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = rooms[LORD.rooms_enabled[i]];
                c.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RawImage>().texture = rooms_logo[LORD.rooms[i]];
                c.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = rooms_logo_size[LORD.rooms[i]];
            }
            rooms_in_ship[LORD.rooms[i]].gameObject.SetActive(true);
            rooms_in_ship[LORD.rooms[i]].GetChild(0).GetComponent<RawImage>().color = colors_rooms[LORD.rooms_enabled[i]];
        }
        list_rooms[0].GetComponent<RawImage>().texture = rooms[LORD.rooms_enabled[0]];
        list_rooms[0].transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = rooms_logo[LORD.rooms[0]];
        list_rooms[0].transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = rooms_logo_size[LORD.rooms[0]];
        rooms_in_ship[LORD.rooms[0]].gameObject.SetActive(true);
        rooms_in_ship[LORD.rooms[0]].GetChild(0).GetComponent<RawImage>().color = colors_rooms[LORD.rooms_enabled[0]];


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
