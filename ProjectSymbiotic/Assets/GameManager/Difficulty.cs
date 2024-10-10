using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum DifficultyLevel
{
    Peaceful,
    Easy,
    Medium,
    Hard,
    Custom
}
public class Difficulty : MonoBehaviour
{
    [SerializeField] FallingObjectSpawner Spawner;

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
        public List<float> objectWeights;
        public float shootingCooldown;
        /// <summary>
        /// Sets difficulty from Enemy
        /// </summary>
        public int arrowSpeed;
        //Normal Constructor
        public DifficultyModifier(float objSpwnTime, int minSpwn, int maxSpwn,
        float fallForce, List<float> weights, float shootCooldown, int arrSpd)
        {
            objectSpawnTime = objSpwnTime; minPerSpawn = minSpwn;
            maxPerSpawn = maxSpwn; fallingForce = fallForce;
            shootingCooldown = shootCooldown; arrowSpeed = arrSpd;
            objectWeights = weights;
        }
    }
    [SerializeField] DifficultyModifier Easy;
    [SerializeField] DifficultyModifier Medium;
    [SerializeField] DifficultyModifier Hard;
    private static DifficultyModifier easy, medium, hard;
    private static DifficultyModifier peaceful = new DifficultyModifier(10000, 0, 0, 0, new List<float> { 1f, 1f }, 10000, 0);
    private static DifficultyModifier difficulty;
    private static DifficultyLevel difficultyLevel;
    private static FallingObjectSpawner spawner;
    private static bool initialized = false;

    public static void SetCustomDifficulty(DifficultyModifier modifier)
    {
        difficultyLevel = DifficultyLevel.Custom;
        difficulty = modifier;
        SetModifiers();
    }
    void Awake()
    {
        if (!initialized)
        {
            easy = Easy;
            medium = Medium;
            hard = Hard;
            spawner = Spawner;
            initialized = true;
        }
    }

    /// <summary>
    /// Sets the Difficulty Modifier according to level
    /// </summary>
    public static void SetDifficultyLevel(DifficultyLevel difficultyLevel)
    {
        switch (difficultyLevel)
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
        SetModifiers();
    }
    public static void SetModifiers()
    {
        spawner.timePerSpawn = difficulty.objectSpawnTime;
        spawner.minPerSpawn = difficulty.minPerSpawn;
        spawner.maxPerSpawn = difficulty.maxPerSpawn;
        spawner.force = difficulty.fallingForce;
        spawner.initialWeights = difficulty.objectWeights;
        spawner.NormalizeWeights();
        GoblinArcherCooldown.shootingCooldown = difficulty.shootingCooldown;
        Enemy.difficulty = difficulty.arrowSpeed;
    }
    public static DifficultyLevel GetDifficulty()
    {
        return difficultyLevel;
    }

}
