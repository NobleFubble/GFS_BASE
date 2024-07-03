using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HideControllerOnGrab : MonoBehaviour
{
    public XRBaseInteractor interactor; // Interactor bileşenini atayın
    public GameObject controllerVisual; // Controller visual'ı atayın

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(OnGrab);
        interactor.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        interactor.selectEntered.RemoveListener(OnGrab);
        interactor.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (controllerVisual != null)
        {
            controllerVisual.SetActive(false);
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (controllerVisual != null)
        {
            controllerVisual.SetActive(true);
        }
    }
}
