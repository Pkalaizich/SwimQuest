using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanels : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCreadores;

    public void ChangePanel()
    {
        if (panelMenu.gameObject.activeSelf ==true)
        {
            panelMenu.gameObject.SetActive(false);
            panelCreadores.gameObject.SetActive(true);
        }
        else
        {
            panelMenu.gameObject.SetActive(true);
            panelCreadores.gameObject.SetActive(false);
        }
    }

    public void PassingSound()
    {
        MenuSound.Instance.PassingSound();
    }
}
