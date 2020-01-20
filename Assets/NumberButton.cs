using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int number = -1;
    
    public void onClicked()
    {
        Game game = GameObject.Find("Game").GetComponent<Game>();
        if(game.btnNextNumberPressed(number))
        {
            ShowBtn();
        }
    }

    public void ShowBtn()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = number.ToString();
        GetComponent<Button>().image.color = new Color(0, 0, 0, 0);
    }
}
