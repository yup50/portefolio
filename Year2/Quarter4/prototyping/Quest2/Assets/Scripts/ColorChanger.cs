// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    public ColorPalette color;

    public enum ColorPalette
    {
        Red,
        White,
        Green,
        Blue
    }


    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor(color);
    }

    public void ChangeColor(ColorPalette color)
    {
        switch (color)
        {
            case ColorPalette.Red:
                mySpriteRenderer.color = Color.red;
                break;
            case ColorPalette.White:
                mySpriteRenderer.color = Color.white;
                break;
            case ColorPalette.Green:
                mySpriteRenderer.color = Color.green;
                break;
            case ColorPalette.Blue:
                mySpriteRenderer.color = Color.blue;
                break;
        }
        this.color = color;
    }

    public void RandomColor()
    {
        int x = Random.Range(0, 4);

        switch (x)
        {
            case 0:
                ChangeColor(ColorPalette.Red);
                break;
            case 1:
                ChangeColor(ColorPalette.White);
                break;
            case 2:
                ChangeColor(ColorPalette.Green);
                break;
            case 3:
                ChangeColor(ColorPalette.Blue);
                break;
        }
    }
}
