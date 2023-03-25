using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Vector2 Amount = new Vector2(0.25f, 0f);
    public float Duration = 1f;
    public float Speed = 7.5f;
    public AnimationCurve Curve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
    public bool DeltaMovement = true;

    private Camera _camera;
    private float time = 0f;
    private Vector2 lastPos;
    private Vector2 nextPos;
    private float lastOrthographicSize;
    private float nextOrthographicSize;
    
    public bool destroyAfterPlay = false;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }


    public void Shake()
    {
        ResetCamera();
        time = Duration;
    }

    private void ResetCamera()
    {
        GetComponent<Camera>().transform.Translate(DeltaMovement ? -lastPos : Vector3.zero);
        GetComponent<Camera>().orthographicSize -= lastOrthographicSize;
        lastPos = nextPos = Vector2.zero;
        lastOrthographicSize = nextOrthographicSize = 0f;
    }

    private void LateUpdate()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            if (time > 0f)
            {
                nextPos = (Mathf.PerlinNoise(time * Speed, time * Speed * 2) - 0.5f) * Amount.x * transform.right * Curve.Evaluate(1f - time / Duration) +
                           (Mathf.PerlinNoise(time * Speed * 2, time * Speed) - 0.5f) * Amount.y * transform.up * Curve.Evaluate(1f - time / Duration);
                nextOrthographicSize = (Mathf.PerlinNoise(time * Speed * 2, time * Speed * 2) - 0.5f) * Curve.Evaluate(1f - time / Duration) * Amount.y;

                GetComponent<Camera>().orthographicSize += (nextOrthographicSize - lastOrthographicSize);
                GetComponent<Camera>().transform.Translate(DeltaMovement ? (Vector3)(nextPos - lastPos) : (Vector3)nextPos);

                lastPos = nextPos;
                lastOrthographicSize = nextOrthographicSize;
            }
            else
            {
                ResetCamera();
                if (destroyAfterPlay)
                    Destroy(this);
            }
        }
    }

    public static void ShakeOnce(float duration = 1f, float speed = 10f, Vector2? amount = null, Camera camera = null, bool deltaMovement = true, AnimationCurve curve = null)
    {
        var instance = ((camera != null) ? camera : Camera.main).gameObject.AddComponent<CameraShake>();
        instance.Duration = duration;
        instance.Speed = speed;
        instance.Amount = new Vector3((amount != null) ? amount.Value.x : 1f, (amount != null) ? amount.Value.y : 1f, 0);
        if (curve != null)
            instance.Curve = curve;
        instance.DeltaMovement = deltaMovement;
        instance.destroyAfterPlay = true; // use destroyAfterPlay property
        instance.Shake();
    }
}