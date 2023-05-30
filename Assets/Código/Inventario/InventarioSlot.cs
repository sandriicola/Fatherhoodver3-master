using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventarioSlot : MonoBehaviour
{
    [SerializeField] private Image itemIcono;
    
    

    public int Index { get; set; }
    
    public void ActualizarSlot(InventarioItem item, int cantidad)
    {
      itemIcono.sprite = item.Icono;
    
     
    }

    public void ActivarSlotUI(bool estado)
    {
        itemIcono.gameObject.SetActive(estado);
       
        
    }


}
