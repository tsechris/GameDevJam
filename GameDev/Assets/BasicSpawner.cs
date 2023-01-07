using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.SceneManagement;

public class BasicSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
  [SerializeField] private NetworkPrefabRef _playerPrefab;
  private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();



  public void OnPlayerJoined(NetworkRunner runner, PlayerRef player) { 
    if (runner.IsServer) {
      // Returns true if the object is on a active server I think
      Vector3 spawnPosition = new Vector3((player.RawEncoded%runner.Config.Simulation.DefaultPlayers)*3,1,0);
      NetworkObject networkPlayerObject = runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);
      _spawnedCharacters.Add(player, networkPlayerObject);
    }
  }



  public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { 
    if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
    {
      runner.Despawn(networkObject);
      _spawnedCharacters.Remove(player);
    }

  }


  public void OnInput(NetworkRunner runner, NetworkInput input) { 
    var data = new NetworkInputData();

    if (Input.GetKey(KeyCode.W))
    {
      data.direction += Vector3.forward;
    }
    if (Input.GetKey(KeyCode.S))
    {
      data.direction += Vector3.back;
    }
    if (Input.GetKey(KeyCode.A))
    {
      data.direction += Vector3.left;
    }
    if (Input.GetKey(KeyCode.D))
    {
      data.direction += Vector3.right;
    }
    if (Input.GetKey(KeyCode.Space))
    {
      data.direction += Vector3.up;
    }

    input.Set(data);


  }
  public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
  public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
  public void OnConnectedToServer(NetworkRunner runner) { }
  public void OnDisconnectedFromServer(NetworkRunner runner) { }
  public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
  public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
  public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
  public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
  public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
  public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
  public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
  public void OnSceneLoadDone(NetworkRunner runner) { }
  public void OnSceneLoadStart(NetworkRunner runner) { }

  async void StartGame(GameMode mode)
  {
    // Create the Fusion runner and let it know that we will be providing user input
    _runner = gameObject.AddComponent<NetworkRunner>();
    _runner.ProvideInput = true;

    // Start or join (depends on gamemode) a session with a specific name
    await _runner.StartGame(new StartGameArgs()
    {
      GameMode = mode,
      SessionName = "TestRoom",
      Scene = SceneManager.GetActiveScene().buildIndex,
      SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
    });}

  private NetworkRunner _runner;

  private void OnGUI()
  {
    if (_runner == null)
    {
      if (GUI.Button(new Rect(0,0,200,40), "Host"))
      {
          StartGame(GameMode.Host);
      }
      if (GUI.Button(new Rect(0,40,200,40), "Join"))
      {
          StartGame(GameMode.Client);
      }
    }
  }
}

