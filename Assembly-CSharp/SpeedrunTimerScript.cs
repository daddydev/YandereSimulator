using UnityEngine;

// Token: 0x020001B9 RID: 441
public class SpeedrunTimerScript : MonoBehaviour {

  // Token: 0x060007B3 RID: 1971 RVA: 0x00076773 File Offset: 0x00074B73
  private void Start() {
    this.Label.enabled = false;
  }

  // Token: 0x060007B4 RID: 1972 RVA: 0x00076784 File Offset: 0x00074B84
  private void Update() {
    if (!this.Police.FadeOut) {
      this.Timer += Time.deltaTime;
      this.Label.text = string.Empty + this.FormatTime(this.Timer);
      if (Input.GetKeyDown(KeyCode.Delete)) {
        this.Label.enabled = !this.Label.enabled;
      }
    }
  }

  // Token: 0x060007B5 RID: 1973 RVA: 0x000767FC File Offset: 0x00074BFC
  private string FormatTime(float time) {
    int num = (int)time;
    int num2 = num / 60;
    int num3 = num % 60;
    float num4 = time * 1000f;
    num4 %= 1000f;
    return string.Format("{0:00}:{1:00}:{2:000}", num2, num3, num4);
  }

  // Token: 0x040013CF RID: 5071
  public PoliceScript Police;

  // Token: 0x040013D0 RID: 5072
  public UILabel Label;

  // Token: 0x040013D1 RID: 5073
  public float Timer;
}