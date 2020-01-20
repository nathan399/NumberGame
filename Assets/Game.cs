using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GridButtons grid;
    [SerializeField] float WaitTime = 1;
    [SerializeField] Canvas EndCanvas;
    [SerializeField] Canvas StartCanvas;
    int nextNumber = 1;
    float time = 0;
    bool hard;
    enum GameState {Waiting,Playing,Won,Lost}
    GameState state = GameState.Waiting;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.Playing)
        {
            time += Time.deltaTime;
        }
    }

    public void StartNormal()
    {
        StartCanvas.gameObject.SetActive(false);
        grid.gameObject.SetActive(true);
        grid.setUpButtons();
        hard = false;
        StartCoroutine(WaitThenHide());
    }
    public void StartHard()
    {
        StartCanvas.gameObject.SetActive(false);
        grid.gameObject.SetActive(true);
        grid.setUpButtons();
        hard = true;
        StartCoroutine(WaitThenHide());
    }

    public void ResetToMainMenu()
    {
        EndCanvas.gameObject.SetActive(false);
        StartCanvas.gameObject.SetActive(true);
        nextNumber = 1;
        time = 0;
        state = GameState.Waiting;
    }

    IEnumerator WaitThenHide()
    {
        yield return new WaitForSeconds(WaitTime);
        grid.HideButtons(hard);
        state = GameState.Playing;
    }

    IEnumerator WaitThenEnd()
    {
        grid.ShowButtons();
        if(state == GameState.Lost)
        {
            yield return new WaitForSeconds(2);
            grid.gameObject.SetActive(false);
            EndCanvas.GetComponent<EndScreen>().EndScreenFail(nextNumber - 1, grid.getNumberOfButtons());
        }
        else if(state == GameState.Won)
        {
            yield return new WaitForSeconds(0.5f);
            grid.gameObject.SetActive(false);
            EndCanvas.GetComponent<EndScreen>().EndScreenVictory(nextNumber - 1, grid.getNumberOfButtons(), time);
        }
        grid.clear();
    }

    public bool btnNextNumberPressed(int number)
    {
        if(state == GameState.Playing)
        {
            if (number == nextNumber)
            {
                nextNumber++;
                if (nextNumber > grid.getNumberOfButtons())
                {
                    state = GameState.Won;
                    StartCoroutine(WaitThenEnd());
                }

                return true;
            }
            else if (number > nextNumber || (hard && number == -1))
            {
                state = GameState.Lost;
                StartCoroutine(WaitThenEnd());
            }
        }
        return false;
    }
}
