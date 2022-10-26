using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class GameController : MonoBehaviour
{
    [Tooltip("小球预制件")]
    public SmallCircleController smallCircleController;

    [Tooltip("参演的小球颜色")]
    public Color[] colors;

    [Tooltip("每个小球最高多少个")]
    public int maxColors;

    [Tooltip("出生点")]
    public Transform birthPoint;

    [Tooltip("用来存所有小球引用的东西")]
    public SmallCircleController[][] smallCircleControllers;
    [Tooltip("用来统计每个颜色的小球的数量")]
    public int currSmlCleCount = 1;
    private void Start()
    {
        smallCircleControllers = new SmallCircleController[colors.Length][];
        for (int i = 0; i < smallCircleControllers.Length; i++)
        {
            smallCircleControllers[i] = new SmallCircleController[maxColors];
        }
        for (int i = 0; i < colors.Length; i++)
        {
            var instNewSmallCircle = Instantiate(smallCircleController, birthPoint.position, birthPoint.rotation);
            instNewSmallCircle.spriteRenderer.color = colors[i];
            smallCircleControllers[i][0] = instNewSmallCircle;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < smallCircleControllers.Length; i++)
            {
                for (int j = 0; j < currSmlCleCount; j++)
                {
                    var instNewSmallCircle = Instantiate(smallCircleController, birthPoint.position, birthPoint.rotation);
                    instNewSmallCircle.spriteRenderer.color = colors[i];
                    smallCircleControllers[i][j + currSmlCleCount] = instNewSmallCircle;
                }
            }
            currSmlCleCount *= 2;
        }
    }
}
