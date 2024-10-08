using System;
using Unity.VisualScripting;
using UnityEngine;

public enum Level
{
    Easy,
    Medium,
    Hard
}
public class Difficulty : State
{
    [SerializeField] FallingObjectSpawner spawner;

    [Serializable]
    public struct DifficultyModifier
    {
        /// <summary>
        /// Sets timePerSpawn from FallingObjectSpawner
        /// </summary>
        public float objectSpawnTime;
        /// <summary>
        /// Sets minPerSpawn from FallingObjectSpawner
        /// </summary>
        public int minPerSpawn;
        /// <summary>
        /// Sets maxPerSpawn from FallingObjectSpawner
        /// </summary>
        public int maxPerSpawn;
        /// <summary>
        /// Sets force from FallingObjectSpawner
        /// </summary>
        public float fallingForce;
        /// <summary>
        /// Sets shootingCooldown from GoblinArcherCooldown
        /// </summary>
        public float shootingCooldown;
        /// <summary>
        /// Sets difficulty from Enemy
        /// </summary>
        public int arrowSpeed;
    }
    [SerializeField] DifficultyModifier easy;
    [SerializeField] DifficultyModifier medium;
    [SerializeField] DifficultyModifier hard;


    private DifficultyModifier difficulty;
    public void SetDifficulty(Level level)
    {
        switch (level)
        {
            case Level.Easy:
                difficulty = easy;
                break;
            case Level.Medium:
                difficulty = medium;
                break;
            case Level.Hard:
                difficulty = hard;
                break;
        }
        stateMachine.setNewState(this);
    }
    public override void OnStart()
    {
        spawner.timePerSpawn = difficulty.objectSpawnTime;
        spawner.minPerSpawn = difficulty.minPerSpawn;
        spawner.maxPerSpawn = difficulty.maxPerSpawn;
        spawner.force = difficulty.fallingForce;
        GoblinArcherCooldown.shootingCooldown = difficulty.shootingCooldown;
        Enemy.difficulty = difficulty.arrowSpeed;
    }

    public override void OnUpdate()
    {
    }

    public override void OnLateUpdate()
    {
    }

    public override void OnExit()
    {
    }
}
