using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    const int size = 4;

    Game game;

    public Text MovesText;

    // Start is called before the first frame update
    void Start()
    {
        game = new Game(size);
        HideButtons();
    }

    public void OnStart()
    {
        game.Start(1000 + DateTime.Now.DayOfYear);
        ShowButtons();
    }



    public void OnClick()
    {
        if (game.Solved())
            return;
        string name1 = EventSystem.current.currentSelectedGameObject.name;
        var x = int.Parse(name1.Substring(0, 1));
        var y = int.Parse(name1.Substring(1, 1));
        game.PressAt(x, y);
        ShowButtons();

        if (game.Solved())
            MovesText.text = "You are KPACABA!";
    }

    void ShowDigitAt(int digit, int x, int y)
    {
        var button = GameObject.Find($"{x}{y}");
        var text = button.GetComponentInChildren<Text>();
        text.text = GetNumber(digit);
        button.GetComponentInChildren<Image>().color =
            (digit > 0) ? Color.white : Color.clear;
    }

    void  HideButtons()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                ShowDigitAt(0, x, y);
            }
        }

        MovesText.text = "Welcome to game!";
    }

    void ShowButtons()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                ShowDigitAt(game.GetDigitAt(x, y), x, y);
            }
        }

        MovesText.text = $"";
    }

    string GetNumber(int digit)
    {
        if (digit == 0)
        {
            return "";
        }
        return digit.ToString();
    }
}

