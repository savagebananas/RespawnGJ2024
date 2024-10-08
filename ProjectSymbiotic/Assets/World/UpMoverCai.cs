using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UpMoverCai : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text skipper;
    public float velocity;
    public float TimeContinue;
    public string TargetScene;
    public float timer;
    void Start()
    {
        timer = 0;
    }

    void CheckKeyCode()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //Debug.Log("Yes");
            SceneManager.LoadScene(TargetScene);
        }
    }
    // Update is called once per frame
    void Update()
    {
        TargetScene = "Main Menu";
        float latest = timer;
        timer += Time.deltaTime;
        Vector2 position = transform.position;
        position.y += velocity * Time.deltaTime;
        transform.position = position;
        TimeContinue -= Time.deltaTime;
        if (TimeContinue <= 0)
            SceneManager.LoadScene(TargetScene);
        if (timer >= 1 && latest < 1)
        {
            skipper.gameObject.SetActive(true);
        }
        if (timer >= 1)
        {
            CheckKeyCode();
        }
    }
}
