using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cellcheck : MonoBehaviour
{
    public PieceType turnPiece;
    public Text Wintext;
    public Text TurnText;
    public Canvas Wincanvas;
    public Dropable[] Celllist;
    public Dragable[] Piecelist;


    private void Start()
    {
        TurnText.text = "Turn: " + turnPiece;
    }


    public void CheckCells(PieceType cellType)
    {
        if (Celllist[0].currentType == cellType && Celllist[1].currentType == cellType && Celllist[2].currentType == cellType)
        {
            ShowWinner(cellType);
        }
        else if (Celllist[3].currentType == cellType && Celllist[4].currentType == cellType && Celllist[5].currentType == cellType)
        {
            ShowWinner(cellType);
        }
        else if (Celllist[6].currentType == cellType && Celllist[7].currentType == cellType && Celllist[8].currentType == cellType)
        {
            ShowWinner(cellType);
        }
        else if (Celllist[0].currentType == cellType && Celllist[3].currentType == cellType && Celllist[6].currentType == cellType)
        {
            ShowWinner(cellType);
        }
        else if (Celllist[1].currentType == cellType && Celllist[4].currentType == cellType && Celllist[7].currentType == cellType)
        {
            ShowWinner(cellType);
        }
        else if (Celllist[2].currentType == cellType && Celllist[5].currentType == cellType && Celllist[8].currentType == cellType)
        {
            ShowWinner(cellType);
        }
        else if (Celllist[0].currentType == cellType && Celllist[4].currentType == cellType && Celllist[8].currentType == cellType)
        {
            ShowWinner(cellType);
        }
        else if (Celllist[2].currentType == cellType && Celllist[4].currentType == cellType && Celllist[6].currentType == cellType)
        {
            ShowWinner(cellType);
        }
    }

    public void GetPlayerTurn()
    {
        turnPiece = (turnPiece == PieceType.Cross) ? PieceType.Circle : PieceType.Cross;
        TurnText.text = "Turn: "+turnPiece;
    }

    void ShowWinner(PieceType cellType)
    {
        Wintext.text = cellType + " Won";
        Wincanvas.enabled = true;
        TurnText.enabled = false;
    }

    public void Restart()
    {
        Wincanvas.enabled = false;
        turnPiece = (turnPiece == PieceType.Cross) ? PieceType.Circle : PieceType.Cross;
        TurnText.text = "Turn: " + turnPiece;
        TurnText.enabled = true;
        foreach(Dragable drag in Piecelist)
        {
            drag.SendBack();
        }
        foreach(Dropable drop in Celllist)
        {
            drop.ResetCell();
        }
    }


}
