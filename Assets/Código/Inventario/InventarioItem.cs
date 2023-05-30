using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TiposDeItems
{
Carta,
Botella,
Funda,
Mechero,
Uniforme,
Yoyo,
Fotos,
Gancho,
Palo,
PaloGancho,
Llave,
Espejo,
Linterna
}
public class InventarioItem : ScriptableObject
{
    [Header("Parametros")]
    public string ID;
    public string Nombre;
    public Sprite Icono;


    [Header("Parametros")]
    public TiposDeItems Tipo;
    public bool EsConsumible;
    public bool EsAcumulable;
    public int AcumulacionMax;

    [HideInInspector] public int Cantidad;

    public InventarioItem CopiarItem(){
        InventarioItem nuevaInstancia = Instantiate(original:this);
        return nuevaInstancia;
    }

}
