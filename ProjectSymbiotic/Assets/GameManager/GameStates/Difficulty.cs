using System;
using Unity.VisualScripting;
using UnityEngine;

public enum DifficultyLevel
{
    Peaceful,
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
        //Normal Constructor
        public DifficultyModifier(float objSpwnTime, int minSpwn, int maxSpwn,
        float fallForce, float shootCooldown, int arrSpd)
        {
            objectSpawnTime = objSpwnTime; minPerSpawn = minSpwn;
            maxPerSpawn = maxSpwn; fallingForce = fallForce;
            shootingCooldown = shootCooldown; arrowSpeed = arrSpd;
        }
    }
    [SerializeField] DifficultyModifier easy;
    [SerializeField] DifficultyModifier medium;
    [SerializeField] DifficultyModifier hard;
    static DifficultyModifier peaceful = new DifficultyModifier(0, 0, 0, 0, 0, 0);
    private static DifficultyModifier difficulty;
    private static DifficultyLevel difficultyLevel;
    public void SetDifficulty(DifficultyLevel level)
    {
        switch (level)
        {
            case DifficultyLevel.Peaceful:
                difficulty = peaceful;
                break;
            case DifficultyLevel.Easy:
                difficulty = easy;
                break;
            case DifficultyLevel.Medium:
                difficulty = medium;
                break;
            case DifficultyLevel.Hard:
                difficulty = hard;
                break;
        }
        stateMachine.setNewState(this);
    }

    /// <summary>
    /// Use this to stop enemy attacks without changing the state. Intended ONLY for cutscenes.
    /// Save the old difficulty before calling this and then switch back to it.
    /// </summary>
    public void Peaceful()
    {
        difficulty = peaceful;
        SetModifiers();
    }
    public override void OnStart()
    {
        SetModifiers();
    }
    public void SetModifiers()
    {
        spawner.timePerSpawn = difficulty.objectSpawnTime;
        spawner.minPerSpawn = difficulty.minPerSpawn;
        spawner.maxPerSpawn = difficulty.maxPerSpawn;
        spawner.force = difficulty.fallingForce;
        GoblinArcherCooldown.shootingCooldown = difficulty.shootingCooldown;
        Enemy.difficulty = difficulty.arrowSpeed;
    }
    public static DifficultyLevel GetDifficulty()
    {
        return difficultyLevel;
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
