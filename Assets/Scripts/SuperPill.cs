﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPill : Collectable {

    protected override void collected(Collider2D coll)
    {
        GameManager.makeGhostsVulnerable();
        base.collected(coll);
    }
}
