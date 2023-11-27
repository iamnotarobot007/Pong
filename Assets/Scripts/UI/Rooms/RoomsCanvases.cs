using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateAndJoinRoomsCanvas _createAndJoinRoomsCanvas;

    public CreateAndJoinRoomsCanvas CreateAndJoinRoomsCanvas { get { return _createAndJoinRoomsCanvas; } }

    [SerializeField]
    private CurrentRoomsCanvas _currentRoomsCanvas;

    public CurrentRoomsCanvas CurrentRoomsCanvas { get { return _currentRoomsCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }
    private void FirstInitialize()
    {
        CreateAndJoinRoomsCanvas.FirstInitialize(this);
        CurrentRoomsCanvas.FirstInitialize(this);

    }
}
