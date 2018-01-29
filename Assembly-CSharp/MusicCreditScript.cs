using UnityEngine;

// Token: 0x02000138 RID: 312
public class MusicCreditScript : MonoBehaviour {

  // Token: 0x060005DB RID: 1499 RVA: 0x00051A3C File Offset: 0x0004FE3C
  private void Start() {
    base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
    this.Panel.enabled = false;
  }

  // Token: 0x060005DC RID: 1500 RVA: 0x00051A90 File Offset: 0x0004FE90
  private void Update() {
    if (this.Slide) {
      this.Timer += Time.deltaTime;
      if (this.Timer < 5f) {
        base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
      } else {
        base.transform.localPosition = new Vector3(base.transform.localPosition.x + Time.deltaTime, base.transform.localPosition.y, base.transform.localPosition.z);
        base.transform.localPosition = new Vector3(base.transform.localPosition.x + Mathf.Abs(base.transform.localPosition.x * 0.01f) * (Time.deltaTime * 1000f), base.transform.localPosition.y, base.transform.localPosition.z);
        if (base.transform.localPosition.x > 400f) {
          base.transform.localPosition = new Vector3(400f, base.transform.localPosition.y, base.transform.localPosition.z);
          this.Panel.enabled = false;
          this.Slide = false;
          this.Timer = 0f;
        }
      }
    }
  }

  // Token: 0x04000DF7 RID: 3575
  public UILabel SongLabel;

  // Token: 0x04000DF8 RID: 3576
  public UILabel BandLabel;

  // Token: 0x04000DF9 RID: 3577
  public UIPanel Panel;

  // Token: 0x04000DFA RID: 3578
  public bool Slide;

  // Token: 0x04000DFB RID: 3579
  public float Timer;
}