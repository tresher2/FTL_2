using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LORD
{
    public static int hp = 28, oxygen = 100, engine = 100, max_shield = 3, shield = 2, max_energy = 4, energy = 1;
    public static List<int> rooms = new List<int>{0, 1, 2, 3};
    //0-двигатель 1-щит 2-кислород 3-оружие
    public static List<int> rooms_enabled = new List<int> { 0, 1, 2 ,3};
}