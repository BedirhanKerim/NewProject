using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController Instance;
    public GridMember[,] matrixGrid { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void OnClickedAnyGrid(int row,int column)
    {
        Debug.Log(row);
        Debug.Log(column);

    }

    public void DefineMatrix(int size)
    {
        matrixGrid = new GridMember[size, size];

    }
}
