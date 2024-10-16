using UnityEngine;
using UnityEngine.UI;

public class RotateCube : MonoBehaviour
{
    [Header("Animators")]
    public Animator animCube;
    public Animator animTriangle;
    public Animator animPentagon;

    [Space]
    public Animator Instructions;

    [Header("Instructions")]
    public Color DarkColor;
    public Color LightColor;

    [Header("Audio")]
    public AudioSource audRotate;

    int actualState;
    bool firstClick;

    private static string level;

    private void Start()
    {
        actualState = 0;
        firstClick = true;
        level = LevelSelectionManager.SelectetedLevel; // Gets the level from the previous Scene
        //firstClick = true;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Get the touch position
            Vector2 touchPosition = Input.GetTouch(0).position;

            // Determine if the touch is on the left or right side of the screen
            bool isRightSide = touchPosition.x > Screen.width / 2;

            // Rotate based on the level and touch position
            switch (level)
            {
                case "TRIANGLE":
                    if (isRightSide)
                        Rotate_TriangleClockwise();
                    else
                        Rotate_TriangleAntiClockwise();
                    break;
                case "CUBE":
                    if (isRightSide)
                        Rotate_CubeClockwise();
                    else
                        Rotate_CubeAntiClockwise();
                    break;
                case "PENTAGON":
                    if (isRightSide)
                        Rotate_PentagonClockwise();
                    else
                        Rotate_PentagonAntiClockwise();
                    break;
            }

            if (firstClick)
            {
                if (PlayerPrefs.GetInt("SETTINGS_DARKMODE", 0) == 1)
                {
                    Instructions.SetTrigger("HideLight");
                }
                else
                {
                    Instructions.SetTrigger("HideDark");
                }

                firstClick = false;
            }

            audRotate.Play();
        }
    }


    /// <summary>
    /// Rotates the Cube (Rectangle)
    /// </summary>
    private void Rotate_CubeClockwise()
    {
        switch (actualState)
        {
            case 0:
                animCube.SetTrigger("GreenToBlue");
                actualState = 1;
                break;
            case 1:
                animCube.SetTrigger("BlueToYellow");
                actualState = 2;
                break;
            case 2:
                animCube.SetTrigger("YellowToRed");
                actualState = 3;
                break;
            case 3:
                animCube.SetTrigger("RedToGreen");
                actualState = 0;
                break;
        }
    }

    private void Rotate_CubeAntiClockwise()
    {
        switch (actualState)
        {
            case 0:
                animCube.SetTrigger("GreenToRed");
                actualState = 3;
                break;
            case 3:
                animCube.SetTrigger("RedToYellow");
                actualState = 2;
                break;
            case 2:
                animCube.SetTrigger("YellowToBlue");
                actualState = 1;
                break;
            case 1:
                animCube.SetTrigger("BlueToGreen");
                actualState = 0;
                break;
        }
    }


    /// <summary>
    /// Rotates the Triangle
    /// </summary>
    private void Rotate_TriangleClockwise()
    {
        switch (actualState)
        {
            case 0:
                animTriangle.SetTrigger("BlueToYellow");
                actualState = 1;
                break;
            case 1:
                animTriangle.SetTrigger("YellowToRed");
                actualState = 2;
                break;
            case 2:
                animTriangle.SetTrigger("RedToBlue");
                actualState = 0;
                break;
        }
    }

    private void Rotate_TriangleAntiClockwise()
    {
        switch (actualState)
        {
            case 0:
                animTriangle.SetTrigger("BlueToRed");
                actualState = 2;
                break;
            case 2:
                animTriangle.SetTrigger("RedToYellow");
                actualState = 1;
                break;
            case 1:
                animTriangle.SetTrigger("YellowToBlue");
                actualState = 0;
                break;
        }
    }


    /// <summary>
    /// Rotates the Pentagon
    /// </summary>
    private void Rotate_PentagonClockwise()
    {
        switch (actualState)
        {
            case 0:
                animPentagon.SetTrigger("PurpleToGreen");
                actualState = 1;
                break;
            case 1:
                animPentagon.SetTrigger("GreenToBlue");
                actualState = 2;
                break;
            case 2:
                animPentagon.SetTrigger("BlueToYellow");
                actualState = 3;
                break;
            case 3:
                animPentagon.SetTrigger("YellowToRed");
                actualState = 4;
                break;
            case 4:
                animPentagon.SetTrigger("RedToPurple");
                actualState = 0;
                break;
        }
    }

    private void Rotate_PentagonAntiClockwise()
    {
        switch (actualState)
        {
            case 0:
                animPentagon.SetTrigger("PurpleToRed");
                actualState = 4;
                break;
            case 4:
                animPentagon.SetTrigger("RedToYellow");
                actualState = 3;
                break;
            case 3:
                animPentagon.SetTrigger("YellowToBlue");
                actualState = 2;
                break;
            case 2:
                animPentagon.SetTrigger("BlueToGreen");
                actualState = 1;
                break;
            case 1:
                animPentagon.SetTrigger("GreenToPurple");
                actualState = 0;
                break;
        }
    }

}
