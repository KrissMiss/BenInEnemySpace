using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{
    // Start is called before the first frame update
    private void Start()
    {
        auto = true;
        cooldown = 0.2f;
        ammoCurrent = 40;
        ammoMax = 40;
        ammoAll = 400;
    }
}
