using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerController : MonoBehaviour
{
    private List<UnityEngine.InputSystem.PlayerInput> players = new List<UnityEngine.InputSystem.PlayerInput>();


    public void OnPlayerJoined(UnityEngine.InputSystem.PlayerInput playerInput) {
        int layer = 28 + players.Count;
        
        foreach (Transform child in playerInput.transform) {
            child.gameObject.layer = layer;
        }

        Camera camera = playerInput.transform.GetComponentInChildren<Camera>();
        camera.cullingMask |= (1 << layer);
        
        players.Add(playerInput);
    }
}
