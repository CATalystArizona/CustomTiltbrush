using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DrawLineManager : MonoBehaviour
{

    public Material material;
    private SteamVR_Action_Boolean start = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    private SteamVR_Action_Boolean keepAddingPoints = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("TriggerHold");
    private MeshLineRenderer currLine; 
    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Input_Sources source = SteamVR_Input_Sources.RightHand;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("trigger just clicked: "+start.GetStateDown(source));
        Debug.Log("trigger being held: "+keepAddingPoints.GetState(source));
        if(start.GetStateDown(source)){
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();

            currLine = go.AddComponent<MeshLineRenderer>();
            currLine.setWidth (0.1f);
            currLine.lmat = material;
           
           
        }
        if(keepAddingPoints.GetState(source)){
           
            Debug.Log("still here");
            
            currLine.AddPoint(trackedObj.transform.position);
            
        }
    }
}
