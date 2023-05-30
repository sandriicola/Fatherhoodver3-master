using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;
    private Animator _animator;
    private PersonajeMovimiento _personajeMovimiento;

    private readonly int direccionX = Animator.StringToHash(name:"X");
    private readonly int direccionY = Animator.StringToHash(name:"Y");
    private void Awake (){
        _animator = GetComponent<Animator>();
        _personajeMovimiento =GetComponent<PersonajeMovimiento>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarLayer();
        if (_personajeMovimiento.EnMovimiento == false){
            return;
        }


        _animator.SetFloat(name:"X", _personajeMovimiento.DireccionMovimiento.x);
        _animator.SetFloat(name:"Y", _personajeMovimiento.DireccionMovimiento.y);
    }

    private void ActivarLayer(string nombreLayer){
        for (int i = 0; i < _animator.layerCount; i++){
            _animator.SetLayerWeight(i, weight:0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(nombreLayer), weight:1);
    }

    private void ActualizarLayer(){
        if (_personajeMovimiento.EnMovimiento){
            ActivarLayer(layerCaminar);
        }
        else
        {
            ActivarLayer(layerIdle);
        }
    }
}
