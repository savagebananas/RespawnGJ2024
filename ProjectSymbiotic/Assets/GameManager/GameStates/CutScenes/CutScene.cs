using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class CutScene : State
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] SeesawHingeScript seesaw;
    [SerializeField] State nextState;
    private Enemy[] enemies;
    private EnemySpawner[] spawners;
    private GameObject[] rocks;
    private GameObject[] crates;
    const string rockTag = "Rock";
    const string crateTag = "CrateStick";
    [SerializeField] float duration = 10f;
    private float timer;

    public void PauseActivity()
    {
        enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        spawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        rocks = GameObject.FindGameObjectsWithTag(rockTag);
        crates = GameObject.FindGameObjectsWithTag(crateTag);
        Difficulty.SetDifficultyLevel(DifficultyLevel.Peaceful);

        seesaw.FreezeAtAngle(0);
        player1.GetComponent<PlayerInput>().enabled = false;
        player2.GetComponent<PlayerInput>().enabled = false;
        foreach (Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = false;
        }
        foreach (GameObject rock in rocks)
        {
            Destroy(rock);
        }
        foreach (GameObject crate in crates)
        {
            Destroy(crate);
        }
    }
    public void ResumeActivity()
    {
        seesaw.Unfreeze();
        player1.GetComponent<PlayerInput>().enabled = true;
        player2.GetComponent<PlayerInput>().enabled = true;
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = true;
        }
        foreach (Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
        }
    }
    public override void OnExit()
    {
        ResumeActivity();
    }

    public override void OnStart()
    {
        timer = duration;


        PauseActivity();
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachine.setNewState(nextState);
        }
    }

    public override void OnLateUpdate()
    {
    }
}
