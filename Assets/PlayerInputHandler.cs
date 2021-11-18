using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{


    private PlayerInput playerInput;
    private Player player;
    [SerializeField]
    private int playerIngame = 0;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var players = FindObjectsOfType<Player>();
        var index = playerInput.playerIndex;
        player = players.FirstOrDefault(m => m.GetIndex() == index);
    }

    public int AddMe()
    {
        playerIngame++;
        return playerIngame;
    }
}
