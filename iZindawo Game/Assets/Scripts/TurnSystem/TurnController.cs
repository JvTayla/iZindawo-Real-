using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public GameState state;
    public CameraController CamScript;
    public CountdownController TimeScript;
    public int hasRun = 30;
    private void Awake()
    {
        CamScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        TimeScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<CountdownController>();

        state = GameState.BlueState;
    }


    void Start()
    {
        StartCoroutine(BluesClues());
    }

    public IEnumerator BluesClues()
    {
        if (hasRun > 0)
        {
            CamScript.CameraPosJuan();
            TimeScript.countdownTimer();
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 30;
        state = GameState.YellowState;
        StartCoroutine(YellowMellow());
    }
    public IEnumerator YellowMellow()
    {
        if (hasRun > 0)
        {
            CamScript.CameraPosDos();
            TimeScript.countdownTimer();
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 30;
        state = GameState.YellowState;
        StartCoroutine(PinkStink());
    }
    public IEnumerator PinkStink()
    {
        if (hasRun > 0)
        {
            CamScript.CameraPosTres();
            TimeScript.countdownTimer();
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 5;
        state = GameState.PinkState;
        SceneManager.LoadScene("EndScene");
    }
}
public enum GameState
{
    BlueState, PinkState, YellowState
}
