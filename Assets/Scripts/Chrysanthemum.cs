using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chrysanthemum :LilyAndChrysanthemumMechanics
{
    public Chrysanthemum()
    {
        Color = TileColor.Red;
        Type = TileTypes.Chrysanthemum;
    }

    public override bool SendsHarmonyTo (TileTypes receiver)
    {
        if (receiver == TileTypes.Lily || receiver == TileTypes.Rhododendron || receiver == TileTypes.Rose)
        {
            return true;
        }
        
        return false;
    }
    
    public override bool SendsDisharmonyTo (TileTypes receiver)
    {
        if (receiver == TileTypes.Jasmine || receiver == TileTypes.Jade || receiver == TileTypes.Chrysanthemum)
        {
            return true;
        }

        return false;
    }
}

