using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class MyNetworkManager : NetworkManager
{
    //[SerializeField] private GameManagerGame gmg;
    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;

    private GameObject ball;
    //public GameObject outBall;
    //public GameObject player1;
    //public GameObject player2;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // mirror pong copy pasta
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        // spawn ball if two players
        if (numPlayers == 2)
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            GameObject addButton = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "AddPointButton"));
            NetworkServer.Spawn(addButton);
            NetworkServer.Spawn(ball);

            player.name = "Player2";
        }
        else if (numPlayers == 1)
        {
            player.name = "Player1";
        }
    }

    

    [System.Obsolete]
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
