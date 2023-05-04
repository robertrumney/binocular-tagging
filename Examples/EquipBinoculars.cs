using UnityEngine;

public class EquipBinoculars : MonoBehaviour
{
    public void Equip()
    {
        Game.instance.BeepGood();

        Game.instance.playerScript.weaponCameraObj.AddComponent<CameraFilterPack_Oculus_Binoculars>();
        Game.instance.playerScript.mainCamTransform.gameObject.AddComponent<Binoculars>();
        Game.instance.playerScript.weaponCameraObj.GetComponent<CameraFilterPack_TV_ARCADE_2>().enabled = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameControl.inventory = false;

        GetComponent<EnableInventory>().SendMessage("SetObjects", false, SendMessageOptions.DontRequireReceiver);
    }

    public void UnEquip()
    {
        Game.instance.BeepGood();

        Destroy(Game.instance.playerScript.weaponCameraObj.GetComponent<CameraFilterPack_Oculus_Binoculars>());
        Destroy(Game.instance.playerScript.mainCamTransform.gameObject.GetComponent<Binoculars>());
    }
}
