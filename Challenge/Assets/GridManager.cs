using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public int gridSize;
    public GameObject gridPrefab, gridParentObj;
    private List<GameObject> _spawnedObjects = new List<GameObject>();

    public event Action ClearMap;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreateGridMap();
        FixGridScales();
    }


    private void CreateGridMap()
    {
        GridController.Instance.DefineMatrix(gridSize);
        //ClearGridMap();

     /*   for (int i = 0; i < gridSize * gridSize; i++)
        {
            GameObject newGridObject = Instantiate(gridPrefab, gridParentObj.transform);
            _spawnedObjects.Add(newGridObject);
        }
        */
        for (int rows = 0; rows < gridSize; rows++)
        {
            for (int column = 0; column < gridSize; column++)
            {
                var newGridMember = Instantiate(gridPrefab, gridParentObj.transform).GetComponent<GridMember>();
                newGridMember.columnIndex = column;
                newGridMember.rowIndex = rows;
               GridController.Instance.matrixGrid[rows, column] = newGridMember;
                //_spawnedObjects.Add(newGridObject);
            }
        }
    }

    private void FixGridScales()
    {
        var gridLayoutComponent = gridParentObj.transform.GetComponent<GridLayoutGroup>();
        var maxCellSize = 400 / (float)gridSize;

        gridLayoutComponent.cellSize = new Vector2(maxCellSize, maxCellSize);
        gridLayoutComponent.constraintCount = gridSize;
    }

    [NaughtyAttributes.Button()]
    public void ReloadGridMap()
    {
        ClearGridMap();
     //Invoke(nameof(CreateGridMap),1f);   
    // Invoke(nameof(FixGridScales),1f);
    CreateGridMap();
    FixGridScales();
    }

    private void ClearGridMap()
    {
        ClearMap?.Invoke();
     /*   foreach (GameObject obj in _spawnedObjects)
        {
            Destroy(obj);
        }

        _spawnedObjects.Clear();*/
    }
}