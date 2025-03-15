using CodeBase.Services;
using UnityEngine;
using Zenject;
public class DropInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var hud = Container.InstantiatePrefabResource(ResourcesPaths.HUD_PATH);
        DropButtonLogic _buttonLogic = hud.GetComponentInChildren<DropButtonLogic>();

        if (_buttonLogic == null)
        {
            Debug.LogError("DropButtonLogic не найден на объекте HUD!");
        }
        if (_buttonLogic != null)
        {
            Debug.LogError("All пиздато!");
            Container.Bind<DropButtonLogic>().FromInstance(_buttonLogic).AsTransient();
            Container.InstantiatePrefabResource(ResourcesPaths.PLAYER_PATH);
        }
    }
}
