using UnityEngine;

// Token: 0x020000EB RID: 235
public class GrowShrinkScript : MonoBehaviour {

  // Token: 0x060004BA RID: 1210 RVA: 0x0003D543 File Offset: 0x0003B943
  private void Start() {
    this.OriginalPosition = base.transform.localPosition;
    base.transform.localScale = Vector3.zero;
  }

  // Token: 0x060004BB RID: 1211 RVA: 0x0003D568 File Offset: 0x0003B968
  private void Update() {
    this.Timer += Time.deltaTime;
    this.Scale += Time.deltaTime * (this.Strength * this.Speed);
    if (!this.Shrink) {
      this.Strength += Time.deltaTime * this.Speed;
      if (this.Strength > this.Threshold) {
        this.Strength = this.Threshold;
      }
      if (this.Scale > this.Target) {
        this.Threshold *= this.Slowdown;
        this.Shrink = true;
      }
    } else {
      this.Strength -= Time.deltaTime * this.Speed;
      float num = this.Threshold * -1f;
      if (this.Strength < num) {
        this.Strength = num;
      }
      if (this.Scale < this.Target) {
        this.Threshold *= this.Slowdown;
        this.Shrink = false;
      }
    }
    if (this.Timer > 3.33333f) {
      this.FallSpeed += Time.deltaTime * 10f;
      base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.FallSpeed * this.FallSpeed, base.transform.localPosition.z);
    }
    base.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
  }

  // Token: 0x060004BC RID: 1212 RVA: 0x0003D720 File Offset: 0x0003BB20
  public void Return() {
    base.transform.localPosition = this.OriginalPosition;
    base.transform.localScale = Vector3.zero;
    this.FallSpeed = 0f;
    this.Threshold = 1f;
    this.Slowdown = 0.5f;
    this.Strength = 1f;
    this.Target = 1f;
    this.Scale = 0f;
    this.Speed = 5f;
    this.Timer = 0f;
    base.gameObject.SetActive(false);
  }

  // Token: 0x04000A71 RID: 2673
  public float FallSpeed;

  // Token: 0x04000A72 RID: 2674
  public float Threshold = 1f;

  // Token: 0x04000A73 RID: 2675
  public float Slowdown = 0.5f;

  // Token: 0x04000A74 RID: 2676
  public float Strength = 1f;

  // Token: 0x04000A75 RID: 2677
  public float Target = 1f;

  // Token: 0x04000A76 RID: 2678
  public float Scale;

  // Token: 0x04000A77 RID: 2679
  public float Speed = 5f;

  // Token: 0x04000A78 RID: 2680
  public float Timer;

  // Token: 0x04000A79 RID: 2681
  public bool Shrink;

  // Token: 0x04000A7A RID: 2682
  public Vector3 OriginalPosition;
}