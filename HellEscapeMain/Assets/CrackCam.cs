using Cinemachine;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CrackCam : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    private CancellationTokenSource cancellationTokenSource;
    private CinemachineBasicMultiChannelPerlin noise;
    private void Awake()
    {
        _camera = SharedVariables.Instance.cam2;
        noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void OnEnable()
    {
        cancellationTokenSource = new CancellationTokenSource();
        
        noise.m_FrequencyGain = 50;
        DelayDeactivate(cancellationTokenSource.Token).Forget();
    }
    private async UniTask DelayDeactivate(CancellationToken token)
    {
        await UniTask.Delay(300, cancellationToken: token);
        this.gameObject.SetActive(false);

    }
    private void OnDisable()
    {
        cancellationTokenSource.Cancel();
        cancellationTokenSource.Dispose();
        noise.m_FrequencyGain = 1;
    }
}
