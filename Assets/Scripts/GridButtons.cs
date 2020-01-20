using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButtons: MonoBehaviour
{
    [SerializeField] int ButtonAmount;
    [SerializeField] int HighestNumber;
    [SerializeField] Button btn;
    [SerializeField] GameObject Grid;


    List<Button> buttons;
    List<int> numberPositions;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getNumberOfButtons()
    {
        return numberPositions.Count;
    }

    public void setUpButtons()
    {
        numberPositions = new List<int>();
        for (int counter = 0; counter < HighestNumber; counter++)
        {
            int numberToAdd;
            bool isInList;
            do
            {
                isInList = false;
                numberToAdd = Random.Range(0, ButtonAmount);

                foreach (int number in numberPositions)
                {
                    if (number == numberToAdd)
                        isInList = true;
                }
            } while (isInList);
            numberPositions.Add(numberToAdd);
        }



        buttons = new List<Button>();
        for (int counter = 0; counter < ButtonAmount; counter++)
        {
            bool isInList = false;
            int ButtonNumber = 0;
            int i = 0;
            foreach (int number in numberPositions)
            {
                i++;
                if (number == counter)
                {
                    isInList = true;
                    ButtonNumber = i;
                }
            }

            Button newBtn = Instantiate(btn, Grid.transform);
            if (isInList)
            {
                newBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = ButtonNumber.ToString();
                newBtn.GetComponent<NumberButton>().number = ButtonNumber;

            }
            //newBtn.image.color = Color.white;
            buttons.Add(newBtn);
        }
    }

    public void HideButtons(bool hideAll)
    {
        if(hideAll)
        {
            foreach (Button btn in buttons)
            {
                btn.image.color = Color.white;
                btn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
            }
        }
        else
        {
            foreach (int number in numberPositions)
            {
                buttons[number].image.color = Color.white;
                buttons[number].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
            }
        }
    }
    public void ShowButtons()
    {
        foreach (int number in numberPositions)
        {
            buttons[number].GetComponent<NumberButton>().ShowBtn();
        }
    }

    public void clear()
    {
        numberPositions.Clear();
        for(int counter = 0; counter < buttons.Count; counter++)
            Destroy(buttons[counter].gameObject);
        buttons.Clear();
    }
}
