using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    Animator spaceShipAni;

    void Awake () {
        spaceShipAni = gameObject.GetComponent<Animator>();
        //spaceShipAni.enabled = false;
        var lvlPas = PlayerPrefs.GetInt("LevelPassed");
        spaceShipAni.SetInteger("levelComplete", lvlPas);
        //spaceShipAni.SetInteger("ShipSet", shipSet);
        //Debug.Log("spaceshipSet" + shipSet + " lvlPas " + lvlPas);
        // if (shipSet == lvlPas) {
        //     if (PlayerPrefs.HasKey("shipRotation")) {
        //         var x = PlayerPrefs.GetFloat("shipPosX");
        //         var y = PlayerPrefs.GetFloat("shipPosY");
        //         gameObject.transform.position = new Vector3(x,y,0);
        //         //Debug.Log("x " + x + " y " + y);
        //         var rot = PlayerPrefs.GetFloat("shipRotation");
        //         gameObject.transform.rotation = new Quaternion(0,0,rot, gameObject.transform.rotation.w);
        //     }
        // } else {
        //     spaceShipAni.enabled = true;
        // }
        
    }
    public void ShipAnimEnd(int lvl)
    {
        // Transform transform = gameObject.GetComponent<Transform>();
        // PlayerPrefs.SetFloat("shipRotation", transform.rotation.z);
        // PlayerPrefs.SetFloat("shipPosX", transform.position.x);
        // PlayerPrefs.SetFloat("shipPosY", transform.position.y);
        spaceShipAni.SetInteger("ShipSet", lvl);
        
        //PlayerPrefs.SetInt("shipSet", lvl);
        //spaceShipAni.enabled = false;
        //Awake();
    }
}
