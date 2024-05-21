using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController Instance;
    public GridMember[,] MatrixGrid { get; private set; }
    public event Action ClearMarkedCombinatedGrids;

    private void Awake()
    {
        Instance = this;
    }

    public void OnClickedAnyGrid()
    {
        CalculateGrids();
    }

    private void CalculateGrids()
    {
        var gridSize = GridManager.Instance.gridSize;
        for (int rows = 0; rows < gridSize; rows++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                if (MatrixGrid[rows, column].isClicked)
                {
                    if (CheckNeighbors(rows, column))
                    {
                        MatrixGrid[rows, column].MarkedCombinated();
                    }
                }
            }
        }

        ClearMarkedCombinatedGrids?.Invoke();
    }

    private bool CheckNeighbors(int rows, int column)
    {
        var gridSize = GridManager.Instance.gridSize;
        int clickedNeighborsCounter = 0;

        if ((column + 1 < gridSize) && MatrixGrid[rows, column + 1].isClicked)
        {
            clickedNeighborsCounter++;
        }

        if ((column - 1 >= 0) && MatrixGrid[rows, column - 1].isClicked)
        {
            clickedNeighborsCounter++;
        }

        if ((rows + 1 < gridSize) && MatrixGrid[rows + 1, column].isClicked)
        {
            clickedNeighborsCounter++;
        }

        if ((rows - 1 >= 0) && MatrixGrid[rows - 1, column].isClicked)
        {
            clickedNeighborsCounter++;
        }

        return clickedNeighborsCounter > 1;
    }

    public void CombinedGridOperator(int rows, int column)
    {
        var gridSize = GridManager.Instance.gridSize;

        if ((column + 1 < gridSize) && MatrixGrid[rows, column + 1].isClicked)
        {
            MatrixGrid[rows, column + 1].MarkedCombinated();
        }

        if ((column - 1 >= 0) && MatrixGrid[rows, column - 1].isClicked)
        {
            MatrixGrid[rows, column - 1].MarkedCombinated();
        }

        if ((rows + 1 < gridSize) && MatrixGrid[rows + 1, column].isClicked)
        {
            MatrixGrid[rows + 1, column].MarkedCombinated();
        }

        if ((rows - 1 >= 0) && MatrixGrid[rows - 1, column].isClicked)
        {
            MatrixGrid[rows - 1, column].MarkedCombinated();
        }
    }

    public void DefineMatrix(int size)
    {
        MatrixGrid = new GridMember[size, size];
    }
}