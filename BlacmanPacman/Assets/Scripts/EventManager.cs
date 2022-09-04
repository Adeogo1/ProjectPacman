using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction<int,int> TileSelected;
    public static void OnTileSelected(int x, int y) => TileSelected?.Invoke(x,y);
    
    public static event UnityAction<TileSprite> ChangeActiveTile;
    public static void OnChangedActiveTile(TileSprite _tileSprite) => ChangeActiveTile?.Invoke(_tileSprite);
    
    
}
