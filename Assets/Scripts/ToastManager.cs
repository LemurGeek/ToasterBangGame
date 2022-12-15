using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastManager : Singleton<ToastManager>
{

    [SerializeField]
    ToastTypes toast_type;

    public void SetToastType(ToastTypes value)

    {
        toast_type = value;
    }

    public ToastTypes GetToastType()
    {
       
       return toast_type;
    }

    public void ResetToastType()
    {
        toast_type = ToastTypes.NORMAL;
    }

}
