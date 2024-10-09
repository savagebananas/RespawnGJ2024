using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Normal : State
{
    DifficultyLevel difficultyLevel = DifficultyLevel.Easy;
    [SerializeField] int mediumThreshold = 50;
    [SerializeField] int hardThreshold = 100;
    public override void OnExit()
    {
        return;
    }

    public override void OnLateUpdate()
    {
        return;
    }

    public override void OnStart()
    {
        Difficulty.SetDifficultyLevel(difficultyLevel);
    }

    public override void OnUpdate()
    {
        float score = GameManager.GetHeight();
        if (score > hardThreshold)
        {
            if (difficultyLevel != DifficultyLevel.Hard)
            {
                Debug.Log("AHHH");
                difficultyLevel = DifficultyLevel.Hard;
                Difficulty.SetDifficultyLevel(difficultyLevel);
            }
        }
        else if (score > mediumThreshold)
        {
            if (difficultyLevel != DifficultyLevel.Medium)
            {
                Debug.Log(difficultyLevel);
                difficultyLevel = DifficultyLevel.Medium;
                Difficulty.SetDifficultyLevel(difficultyLevel);
            }

        }
        else if (difficultyLevel != DifficultyLevel.Easy)
        {
            difficultyLevel = DifficultyLevel.Easy;
            Difficulty.SetDifficultyLevel(difficultyLevel);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
