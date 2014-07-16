using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jade : JadeAndRhododendronMechanics
{
    public Jade()
    {
        Type = TileTypes.Jade;
        Color = TileColor.White;
    }

    public override bool SendsHarmonyTo(TileTypes receiver)
    {
        if (receiver == TileTypes.Jasmine || receiver == TileTypes.Rhododendron || receiver == TileTypes.Chrysanthemum)
        {
            return true;
        }
        
        return false;
    }

    public override bool SendsDisharmonyTo(TileTypes receiver)
    {
        if (receiver == TileTypes.Jade || receiver == TileTypes.Lily || receiver == TileTypes.Rose)
        {
            return true;
        }
        
        return false;
    }

    public override TileTypes GetTileType()
    {
        return Type;
    }
}

