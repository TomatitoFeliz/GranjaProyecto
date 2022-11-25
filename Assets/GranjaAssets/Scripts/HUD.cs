using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    GameObject fondo, fondoC�mara, recuadroCreaci�n, c�mara;

    public enum Estados
    {
        EnEspera,
        Crear,
    }
    public Estados estadoActual;

    private void Start()
    {
        fondo.SetActive(true);
        fondoC�mara.SetActive(false);
        recuadroCreaci�n.SetActive(false);
        LeanTween.moveLocal(fondo, new Vector3(3f, -721f, 0f), 0f);
        LeanTween.moveLocal(fondo, new Vector3(3f, -476f, 0f), 1.5f).setEaseInOutBounce();
    }

    public void C�mara()
    {
        LeanTween.moveLocal(fondo, new Vector3(3f, -721f, 0f), 0.5f).setOnComplete(OnComplete);
        void OnComplete()
        {       
            fondo.SetActive(false);
            fondoC�mara.SetActive(true);
            LeanTween.scale(fondoC�mara, new Vector3(17f, 1f, 1f), 1.5f).setEaseInOutCubic().setOnComplete(OnComplete);
            void OnComplete()
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");
                Debug.Log(mouseX);
                Debug.Log(mouseY);
                if (Input.GetMouseButtonDown(0))
                {
                    c�mara.transform.Translate(new Vector3(mouseX, mouseY, 0f));
                }
            }
        }

    }

    public void Crear()
    {
        LeanTween.moveLocal(fondo, new Vector3(3f, -721f, 0f), 0.5f).setOnComplete(OnComplete);
        void OnComplete()
        {
            fondo.SetActive(false);
            recuadroCreaci�n.SetActive(true);
            LeanTween.moveLocal(recuadroCreaci�n, new Vector3(698f, 0f, 0f), 1.5f).setEaseInOutElastic();
        }
    }

    public void CrearObjeto(GameObject objetoseleccionado)
    {
        LeanTween.moveLocal(recuadroCreaci�n, new Vector3(1309f, 0f, 0f), 1.5f).setEaseInOutElastic();
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Input.mousePosition;
            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitinfo;
            if (Physics.Raycast(rayo, out hitinfo) == true)
            {
                Instantiate(objetoseleccionado, pos, Quaternion.identity);
                LeanTween.moveLocal(recuadroCreaci�n, new Vector3(698f, 0f, 0f), 1.5f).setEaseInOutElastic();
            }
        }
    }

    //-----------------------------------------------------Acciones---------------------------------------------

























    //--------------------------------------------------------HUD-----------------------------------------------

    public void CancelarC�mara()
    {
        LeanTween.scale(fondoC�mara, new Vector3(0f, 0f, 0f), 1f).setEaseInOutCubic().setOnComplete(Oncomplete);   
        void Oncomplete()
        {
            fondoC�mara.SetActive(false);
            fondo.SetActive(true);
            LeanTween.moveLocal(fondo, new Vector3(3f, -476f, 0f), 1.5f).setEaseInOutBounce();
        }


    }
    public void CancelarCrear()
    {
        LeanTween.moveLocal(recuadroCreaci�n, new Vector3(1309f, 0f, 0f), 1.5f).setEaseInOutCubic().setOnComplete(Oncomplete);
        void Oncomplete()
        {
            fondo.SetActive(true);
            recuadroCreaci�n.SetActive(false);
            LeanTween.moveLocal(fondo, new Vector3(3f, -476f, 0f), 1.5f).setEaseInOutBounce();
        }
    }
}
