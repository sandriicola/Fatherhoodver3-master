using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
     [Header("Paneles")] 
     [SerializeField] private GameObject panelInventario;
    
   
    #region Paneles
    public void AbrirCerrarPanelInventario()
    {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }

    #endregion
}
