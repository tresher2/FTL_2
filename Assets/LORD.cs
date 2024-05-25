using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LORD
{
    public static int hp = 28, oxygen = 100, engine = 100, max_shield = 3, shield = 2, max_energy = 4, energy = 1;
    //hp (0-29) oxygen (0-100) engine (0-100) max shield (0-4) shield (0-max shield) max_energy (2-?) energy (0-max_energy)
    public static List<int> rooms = new List<int>{0, 1, 2, 3, 6, 5, 4};
    //0-двигатель 1-щит 2-кислород 3-оружие,4-капитанская рубка, 5-камера, 6-двери, минимально 1 комната (0-3)
    public static List<int> rooms_enabled = new List<int> { 0, 1, 2, 3, 1, 2, 3 };
    //0 - вкл/выкл 1-сломано 2-недоломано 3-вкл
}