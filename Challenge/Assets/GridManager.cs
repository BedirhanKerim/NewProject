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
        ClearGridMap();

        for (int i = 0; i < gridSize * gridSize; i++)
        {
            GameObject newGridObject = Instantiate(gridPrefab, gridParentObj.transform);
            _spawnedObjects.Add(newGridObject);
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
        CreateGridMap();
        FixGridScales();
    }

    private void ClearGridMap()
    {
        foreach (GameObject obj in _spawnedObjects)
        {
            Destroy(obj);
        }

        _spawnedObjects.Clear();
    }
}