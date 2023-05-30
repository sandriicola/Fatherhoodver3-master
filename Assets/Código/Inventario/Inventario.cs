using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : Singleton<Inventario>
{
    [SerializeField] private int numeroDeSlots;
    public int NumeroDeSlots => numeroDeSlots;

    [Header("Items")] 
    [SerializeField] private InventarioItem[] itemsInventario;

     private void Start()
    {
        itemsInventario = new InventarioItem[numeroDeSlots];
    }
    public void AñadirItem(InventarioItem itemPorAñadir, int cantidad)
    {
        if (itemPorAñadir ==null){
            return;
        }
//Verificar en caso tener un item similar en inventario
        List<int> indexes = VerificarExistencias(itemPorAñadir.ID);
        if (itemPorAñadir.EsAcumulable)
        {
            if (indexes.Count > 0)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (itemsInventario[indexes[i]].Cantidad < itemPorAñadir.AcumulacionMax)
                    {
                        itemsInventario[indexes[i]].Cantidad += cantidad;
                        if (itemsInventario[indexes[i]].Cantidad > itemPorAñadir.AcumulacionMax)
                        {
                            int diferencia = itemsInventario[indexes[i]].Cantidad - itemPorAñadir.AcumulacionMax;
                            itemsInventario[indexes[i]].Cantidad = itemPorAñadir.AcumulacionMax;
                            AñadirItem(itemPorAñadir, diferencia);
                        }
                        
                        InventarioUI.Instance.DibujarItemEnInventario(itemPorAñadir, 
                            itemsInventario[indexes[i]].Cantidad, indexes[i]);
                        return;
                    }
                }
            }
        }

        if(cantidad <= 0)
        {
            return;
        }
        if (cantidad>itemPorAñadir.AcumulacionMax)
        {
            AñadirItemEnSlotDisponible(itemPorAñadir, itemPorAñadir.AcumulacionMax);
            cantidad -= itemPorAñadir.AcumulacionMax;
            AñadirItem(itemPorAñadir, cantidad);
        }
        else
        {
            AñadirItemEnSlotDisponible(itemPorAñadir,cantidad);
        }

    }
    public bool TieneItem(string itemID)
{
    for (int i = 0; i < itemsInventario.Length; i++)
    {
        if (itemsInventario[i] != null && itemsInventario[i].ID == itemID)
        {
            return true;
        }
    }
    return false;
}


    private List<int> VerificarExistencias(string itemID)
    {
         List<int> indexesDelItem = new List<int>();
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] != null){
               if (itemsInventario[i].ID ==itemID)
            {
                indexesDelItem.Add(i);
            }  
            }
           
        }
        return indexesDelItem;
    }

    private void AñadirItemEnSlotDisponible(InventarioItem item, int cantidad)
    {
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] == null)
            {
                itemsInventario[i] = item.CopiarItem();
                itemsInventario[i].Cantidad = cantidad;
                InventarioUI.Instance.DibujarItemEnInventario(item,cantidad,i);
                return;
            }
        }
    }
   
}
