using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerSelet : MonoBehaviour
{
    [Header("ê¬Win")]
    public GameObject BlueWin;
    [Header("ê‘Win")]
    public GameObject RedWin;

    // Start is called before the first frame update
    void Start()
    {
        BlueWin.SetActive(false);
        RedWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HammerCollision.WinPlayer == 1)
        {
            BlueWin.SetActive(true);
        }
        else if (HammerCollision.WinPlayer == 2)
        {
            RedWin.SetActive(true);
        }
    }
}
