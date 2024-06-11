using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeAppearDisappear : MonoBehaviour
{
    public GameObject axe;

    public void appear()
    {
        axe.SetActive(true);
    }

    public void disappear()
    {
        axe.SetActive(false);
    }
}
