using UnityEngine;

// Token: 0x020000E8 RID: 232
public class GrandfatherScript : MonoBehaviour {

  // Token: 0x060004B4 RID: 1204 RVA: 0x0003D21C File Offset: 0x0003B61C
  private void Update() {
    if (!this.Flip) {
      if ((double)this.Force < 0.1) {
        this.Force += Time.deltaTime * 0.1f * this.Speed;
      }
    } else if ((double)this.Force > -0.1) {
      this.Force -= Time.deltaTime * 0.1f * this.Speed;
    }
    this.Rotation += this.Force;
    if (this.Rotation > 1f) {
      this.Flip = true;
    } else if (this.Rotation < -1f) {
      this.Flip = false;
    }
    if (this.Rotation > 5f) {
      this.Rotation = 5f;
    } else if (this.Rotation < -5f) {
      this.Rotation = -5f;
    }
    this.Pendulum.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
    this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Clock.Minute * 6f);
    this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Clock.Hour * 30f);
  }

  // Token: 0x04000A61 RID: 2657
  public ClockScript Clock;

  // Token: 0x04000A62 RID: 2658
  public Transform MinuteHand;

  // Token: 0x04000A63 RID: 2659
  public Transform HourHand;

  // Token: 0x04000A64 RID: 2660
  public Transform Pendulum;

  // Token: 0x04000A65 RID: 2661
  public float Rotation;

  // Token: 0x04000A66 RID: 2662
  public float Force;

  // Token: 0x04000A67 RID: 2663
  public float Speed;

  // Token: 0x04000A68 RID: 2664
  public bool Flip;
}