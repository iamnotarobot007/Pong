using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropable : MonoBehaviour,IDropHandler
{
    public PieceType currentType;
    bool firstPlay = true;
    Dragable currentPiece;
    public Cellcheck Checkcells;

    private void Start()
    {
        currentType = PieceType.None;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.gameObject != null && eventData.pointerDrag.GetComponent<Dragable>().pieceType == Checkcells.turnPiece)
        {
            eventData.pointerDrag.gameObject.transform.position = this.transform.position;
            if (firstPlay)
            {
                currentPiece = eventData.pointerDrag.GetComponent<Dragable>();
                currentType = currentPiece.pieceType;
                firstPlay = false;
                CheckWin(currentType);
                Checkcells.GetPlayerTurn();
            }
            else
            { 
                CheckPiece(eventData.pointerDrag.GetComponent<Dragable>());
            }
        }
    }


    public void CheckPiece(Dragable currentDragable)
    {
        if(currentDragable.PiecePower <= currentPiece.PiecePower)
        {
            currentDragable.SendBack();
            CheckWin(currentType);
        }
        else
        {
            currentPiece.SendBack();
            currentPiece = currentDragable;
            currentType = currentPiece.pieceType;
            CheckWin(currentPiece.pieceType);
            Checkcells.GetPlayerTurn();
        }
    }

    public void CheckWin(PieceType pieceType)
    {
        Checkcells.CheckCells(pieceType);
    }

    public void ResetCell()
    {
        currentPiece = null;
        currentType = PieceType.None;
        firstPlay = true;
    }

}
