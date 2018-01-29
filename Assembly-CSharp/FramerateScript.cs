using UnityEngine;

// Token: 0x020000C3 RID: 195
public class FramerateScript : MonoBehaviour {

  // Token: 0x060002E9 RID: 745 RVA: 0x00037769 File Offset: 0x00035B69
  private void Start() {
    this.fpsText = base.GetComponent<GUIText>();
    this.timeleft = this.updateInterval;
  }

  // Token: 0x060002EA RID: 746 RVA: 0x00037784 File Offset: 0x00035B84
  private void Update() {
    this.timeleft -= Time.deltaTime;
    this.accum += Time.timeScale / Time.deltaTime;
    this.frames++;
    if (this.timeleft <= 0f) {
      this.FPS = this.accum / (float)this.frames;
      int num = Mathf.Clamp((int)this.FPS, 0, Application.targetFrameRate);
      if (num > 0) {
        this.fpsText.text = "FPS: " + num.ToString();
      }
      this.timeleft = this.updateInterval;
      this.accum = 0f;
      this.frames = 0;
    }
  }

  // Token: 0x04000947 RID: 2375
  public float updateInterval = 0.5f;

  // Token: 0x04000948 RID: 2376
  private GUIText fpsText;

  // Token: 0x04000949 RID: 2377
  private float accum;

  // Token: 0x0400094A RID: 2378
  private int frames;

  // Token: 0x0400094B RID: 2379
  private float timeleft;

  // Token: 0x0400094C RID: 2380
  public float FPS;
}