using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum PieceType
{
    Circle,
    Cross,
    None
}

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Image image;
    public int PiecePower;
    public PieceType pieceType;
    public Cellcheck cellCheck;

    Vector3 Spawnposition;
    bool IsInteractable = true;
   // public GameObject self;

    private void Start()
    {
        Spawnposition = transform.position;
        //self = this.gameObject;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(IsInteractable && pieceType == cellCheck.turnPiece)
        image.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsInteractable && pieceType == cellCheck.turnPiece)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            image.transform.position = new Vector3(pos.x, pos.y + 0.2f, 0);
        }
    }

    public void Dropped()
    {
        IsInteractable = false;
    }

    public void SendBack()
    {
        IsInteractable = true;
        transform.position = Spawnposition;
    }

}