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
    private void Awake()
    {
    }

    void Start()
    {
        GridManager.Instance.ClearMap +=SelfDestruction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        GridController.Instance.OnClickedAnyGrid(rowIndex,columnIndex);
        gridMemberImage.sprite = clickedButtonSprite;
    }
    public void SelfDestruction()
    {
        GridManager.Instance.ClearMap -=SelfDestruction;
Debug.Log("asd");
        Destroy(buttonObj);
    }
}
