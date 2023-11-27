using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndJoinRoomsCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomsMenu _createRoomsMenu;

    [SerializeField]
    private RoomsListingsMenu _roomsListingsMenu;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoomsMenu.FirstInitialize(canvases);
        _roomsListingsMenu.FirstInitialize(canvases);
    }

}
