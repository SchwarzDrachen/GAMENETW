using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : SingletonPUN<NetworkManager>
{
    private const string PLAYER_PREFAB_NAME = "Player";

    private void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            return;
        }

        // Spawn the player
        PhotonNetwork.Instantiate(PLAYER_PREFAB_NAME, Vector3.zero, Quaternion.identity);
    }
}
