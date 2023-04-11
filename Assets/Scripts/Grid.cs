using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    int _width;
    int _height;
    int[,] _grid;
    public Grid(int width, int height)
    {
        _width = width;
        _height = height;
        _grid = new int[width, height];
    }
}
