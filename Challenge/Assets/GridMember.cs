using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

public class GridMember : MonoBehaviour
{
    public int rowIndex;
    public int columnIndex;
    public GameObject buttonObj;
    public Sprite defaultButtonSprite, clickedButtonSprite;
    public Image gridMemberImage;
    public bool isClicked = false, isCombinated = false;
    
    void Start()
    {
        GridManager.Instance.ClearMap += SelfDestruction;
        GridController.Instance.ClearMarkedCombinatedGrids += ClearMarkedCombinatedGridMember;
    }
    public void Clicked()
    {
        isClicked = true;

        gridMemberImage.sprite = clickedButtonSprite;
        GridController.Instance.OnClickedAnyGrid();
    }

    public void SelfDestruction()
    {
        GridManager.Instance.ClearMap -= SelfDestruction;
        GridController.Instance.ClearMarkedCombinatedGrids -= ClearMarkedCombinatedGridMember;
        Destroy(buttonObj);
    }

    public void MarkedCombinated()
    {
        if (!isCombinated)
        {
            isCombinated = true;
            GridController.Instance.CombinedGridOperator(rowIndex, columnIndex);
        }
    }

    public void ClearMarkedCombinatedGridMember()
    {
        if (isCombinated)
        {
            gridMemberImage.sprite = defaultButtonSprite;
            isClicked = false;
            isCombinated = false;
        }
    }
}