using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomsListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomsListing _roomListing;

    [SerializeField]
    private Transform _content;

    private List<RoomsListing> _listings = new List<RoomsListing>();

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        _roomsCanvases.CurrentRoomsCanvas.Show();
        _content.DestroyChildren();
        _listings.Clear();
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else
            {
                int index = _listings.FindIndex(X => X.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomsListing listing = Instantiate(_roomListing, _content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }
                else
                {
                    //Modif index here.
                    //listings[index].dowhatever.
                }

            }
        }
    }
}
