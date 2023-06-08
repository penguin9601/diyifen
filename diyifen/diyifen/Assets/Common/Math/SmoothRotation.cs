using UnityEngine;

/// A helper for assistance with smoothing the camera rotation.
/// 帮助平滑相机旋转的助手。
public class SmoothRotation
{
    private float _current;
    private float _currentVelocity;

    public SmoothRotation(float startAngle)
    {
        _current = startAngle;
    }

    /// Returns the smoothed rotation.
    public float Update(float target, float smoothTime)
    {
        return _current = Mathf.SmoothDampAngle(_current, target, ref _currentVelocity, smoothTime);
    }

    public float Current
    {
        set { _current = value; }
    }
}
