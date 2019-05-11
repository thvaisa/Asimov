using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum STATUS
{
    SUCCEED, WAITING, ACTIVE, FAIL
}

public class Panel{
    public STATUS status = STATUS.WAITING;


    public STATUS Check_status(){
        return status;
    }

    public void Fail(){
        status = STATUS.FAIL;
    }

    public void SUCCEED()
    {
        status = STATUS.SUCCEED;
    }

}
