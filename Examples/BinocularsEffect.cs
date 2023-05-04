using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BinocularsEffect : PostProcessEffectRenderer<Binoculars> 
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/Binoculars"));

        sheet.properties.SetFloat("_Zoom", settings.zoom);
        sheet.properties.SetFloat("_Distortion", settings.distortion);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
    
        private void Update()
        {
            float y = Input.mouseScrollDelta.y;

            currentFOV -= y;
            currentFOV = Mathf.Clamp(currentFOV, -54, baseFOV);

            Game.instance.playerScript.PlayerWeaponsComponent.IronsightsComponent.fovMod = currentFOV;

            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(Game.instance.settings.controls.inventory))
            {
                Destroy(this);
            }
        }
}

[System.Serializable]
[PostProcess(typeof(BinocularsEffect), PostProcessEvent.AfterStack, "Custom/Binoculars")]
public class Binoculars : PostProcessEffectSettings 
{
    [Range(0f, 1f), Tooltip("Zoom amount.")]
    public FloatParameter zoom = new FloatParameter { value = 0.5f };

    [Range(-1f, 1f), Tooltip("Distortion amount.")]
    public FloatParameter distortion = new FloatParameter { value = 0.1f };
}
