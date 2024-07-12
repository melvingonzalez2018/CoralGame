using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class FogEffect : MonoBehaviour {
    public Material _mat;


    private void Start() {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        
    }
}
