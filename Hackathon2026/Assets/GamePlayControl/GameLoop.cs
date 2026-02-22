using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Modifiers;

public enum GameState {
    Selection,
    RoomGeneration,
    Combat,
    Reward,
    Transition
}

public class GameLoopManager : MonoBehaviour {
    private GameState currentState;

        
    public GameObject spawnerPrefab;
    public GameObject[] enemyPrefabs;
    public GameObject[] propPrefabs;
    public GameObject chestPrefab; // need to pass these into room manager each cycle

    private List<ModifierBase> playerInventor = new List<ModifierBase>();

    private int playerLevel = 1;

    void Start() {
        ChangeState(GameState.Selection);
    }

    public void ChangeState(GameState newState) {
        currentState = newState;

        switch (newState) {
            case GameState.Selection:
                StartSelection();
                break;
            case GameState.RoomGeneration:
                GenerateRoom();
                break;
            case GameState.Combat:
                StartCombat();
                break;
            case GameState.Reward:
                GiveReward();
                break;
        }
    }


    void StartSelection() {
        // Acticate the modifier selection UI and allow the player to choose modifiers.
        // Once all are selected and submitted, move to room generation

        currentState = GameState.RoomGeneration;
        ChangeState(currentState);
    }

    void GenerateRoom() {
        
        // get enemy count based on xp level
        int offset = 0;
        int enemyCount = 0;
        if (playerLevel < 3)
        {
            enemyCount = 1 + playerLevel;
            offset = 1;
        }
        else if (playerLevel < 6)
        {
            enemyCount = 3 + (playerLevel - 3) * 2;
            offset = 2;
        }
        else
        {
            enemyCount = 7 + (playerLevel - 5) * 3;
            offset = 3;
        }

        RoomManager roomManager = GetComponent<RoomManager>();
        
        roomManager.spawnerPrefab = spawnerPrefab;

        // change this to only select some prefabs
        roomManager.enemyPrefabs = enemyPrefabs;

        roomManager.propPrefabs = propPrefabs;
        roomManager.chestPrefab = chestPrefab;
        roomManager.minEnemyCount = enemyCount;
        roomManager.maxEnemyCount = enemyCount + offset;

        //Apply modifiers to the room manager here, if they affect room generation.
        Debug.Log(roomManager.enemyPrefabs.Length);
        roomManager.startRoom();

        currentState = GameState.Combat;

        ChangeState(currentState);

         // example scaling, can be adjusted
        // initialize a room manager with the correct prefabs.
        // check when enemies are defeated, then move to reward.
    }

    void StartCombat() {
        //clear the player inventory of modifiers, as they should only apply for one combat.
        // Start the combat, end when all enemies are defeated (requires room and enemy management).

        //just init state

        // have to stay in this state until the room manager detects all enemies are defeated, then move to reward.
    }

    void GiveReward() {
        // Show the chest and allo the player to break it and receive modifiers for the next level.
        // Go back to selection
        // scale up the xp. 


        // TODO: increment player level and xp, then return to selection.
        currentState = GameState.Selection;
    }

    void Update() {
        if (currentState == GameState.Combat) {
            // check if all enemies are defeated, if so, move to reward state.
        }
    }
}

