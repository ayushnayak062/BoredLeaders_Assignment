using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
   
    public float[] _cageposition;
    public float[] _mineposition;
    public GameData (Tile tile)
    {
        _cageposition = new float[Tile._cagepos.Count * 3];
        for (int i = 0; i < Tile._cagepos.Count; i++)
        {
            int startIndex = i * 3;
            _cageposition[startIndex] = Tile._cagepos[i].x;
            _cageposition[startIndex + 1] = Tile._cagepos[i].y;
            _cageposition[startIndex + 2] = Tile._cagepos[i].z;
        }

        _mineposition = new float[Tile._minepos.Count * 3];
        for (int i = 0; i < Tile._minepos.Count; i++)
        {
            int startIndex = i * 3;
            _mineposition[startIndex] = Tile._minepos[i].x;
            _mineposition[startIndex + 1] = Tile._minepos[i].y;
            _mineposition[startIndex + 2] = Tile._minepos[i].z;
        }
    }
}
