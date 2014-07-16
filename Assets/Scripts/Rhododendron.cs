using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rhododendron : JadeAndRhododendronMechanics
{
    public Rhododendron()
    {
        Type = TileTypes.Rhododendron;
        Color = TileColor.Red;
    }
    
    public override bool SendsDisharmonyTo(TileTypes receiver)
    {
        if (receiver == TileTypes.Jasmine || receiver == TileTypes.Rhododendron || receiver == TileTypes.Chrysanthemum)
        {
            return true;
        }
        
        return false;
    }
    
    public override bool SendsHarmonyTo(TileTypes receiver)
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