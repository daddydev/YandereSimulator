using UnityEngine;

// Token: 0x02000025 RID: 37
public class Tutorial5 : MonoBehaviour {

  // Token: 0x06000091 RID: 145 RVA: 0x0000B144 File Offset: 0x00009544
  public void SetDurationToCurrentProgress() {
    UITweener[] componentsInChildren = base.GetComponentsInChildren<UITweener>();
    foreach (UITweener uitweener in componentsInChildren) {
      uitweener.duration = Mathf.Lerp(2f, 0.5f, UIProgressBar.current.value);
    }
  }
}