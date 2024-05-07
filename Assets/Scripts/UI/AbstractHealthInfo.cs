using UnityEngine;

public abstract class AbstractHealthInfo : MonoBehaviour
{
    protected Health Health;

    protected abstract void InfoUpdate();

    protected void OnEnable()
    {
        Health.Changed += InfoUpdate;
    }

    protected void OnDisable()
    {
        Health.Changed -= InfoUpdate;
    }
}


