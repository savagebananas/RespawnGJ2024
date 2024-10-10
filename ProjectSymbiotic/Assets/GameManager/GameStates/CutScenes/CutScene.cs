using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class CutScene : State
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject platform;
    [SerializeField] SeesawHingeScript seesaw;
    [SerializeField] State nextState;
    private EnemySpawner[] spawners;
    private List<Collision2D> onPlatform;
    [SerializeField] float duration = 10f;

    /// <summary>
    /// If true will kill all obstacles on the platform before cutscene starts
    /// </summary>
    [SerializeField] bool killOnPlatform;
    private float timer;

    public void ShakeCamera()
    {

    }
    public void PauseActivity()
    {
        spawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);

        Difficulty.SetDifficultyLevel(DifficultyLevel.Peaceful);
        seesaw.FreezeAtAngle(0);

        player1.GetComponent<PlayerInput>().enabled = false;
        player2.GetComponent<PlayerInput>().enabled = false;
        player1.GetComponent<Rigidbody2D>().mass = 0;
        player2.GetComponent<Rigidbody2D>().mass = 0;

        foreach (Collision2D collision in onPlatform)
        {
            if (collision.gameObject.tag.StartsWith("Player")) continue;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = false;
        }

    }
    public void ResumeActivity()
    {
        player1.GetComponent<PlayerInput>().enabled = true;
        player2.GetComponent<PlayerInput>().enabled = true;
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.enabled = true;
        }
        player1.GetComponent<Rigidbody2D>().mass = GameConstants.PLAYER_MASS;
        player2.GetComponent<Rigidbody2D>().mass = GameConstants.PLAYER_MASS;
        seesaw.Unfreeze();
    }
    public override void OnExit()
    {
        ResumeActivity();
    }

    public override void OnStart()
    {
        timer = duration;
        ShakeCamera();
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
