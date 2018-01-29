using UnityEngine;

// Token: 0x0200010B RID: 267
public class InfoChanWindowScript : MonoBehaviour {

  // Token: 0x06000535 RID: 1333 RVA: 0x00048B28 File Offset: 0x00046F28
  private void Update() {
    if (this.Drop) {
      this.Rotation = Mathf.Lerp(this.Rotation, (!this.Drop) ? 0f : -90f, Time.deltaTime * 10f);
      base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, this.Rotation, base.transform.localEulerAngles.z);
      this.Timer += Time.deltaTime;
      if (this.Timer > 1f) {
        if ((float)this.Orders > 0f) {
          UnityEngine.Object.Instantiate<GameObject>(this.Drops[this.ItemsToDrop[this.Orders]], this.DropPoint.position, Quaternion.identity);
          this.Timer = 0f;
          this.Orders--;
        } else {
          this.Open = false;
          if (this.Timer > 3f) {
            base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, 0f, base.transform.localEulerAngles.z);
            this.Drop = false;
          }
        }
      }
    }
    if (this.Test) {
      this.DropObject();
    }
  }

  // Token: 0x06000536 RID: 1334 RVA: 0x00048C97 File Offset: 0x00047097
  public void DropObject() {
    this.Rotation = 0f;
    this.Timer = 0f;
    this.Dropped = false;
    this.Test = false;
    this.Drop = true;
    this.Open = true;
  }

  // Token: 0x04000C62 RID: 3170
  public Transform DropPoint;

  // Token: 0x04000C63 RID: 3171
  public GameObject[] Drops;

  // Token: 0x04000C64 RID: 3172
  public int[] ItemsToDrop;

  // Token: 0x04000C65 RID: 3173
  public int Orders;

  // Token: 0x04000C66 RID: 3174
  public int ID;

  // Token: 0x04000C67 RID: 3175
  public float Rotation;

  // Token: 0x04000C68 RID: 3176
  public float Timer;

  // Token: 0x04000C69 RID: 3177
  public bool Dropped;

  // Token: 0x04000C6A RID: 3178
  public bool Drop;

  // Token: 0x04000C6B RID: 3179
  public bool Open = true;

  // Token: 0x04000C6C RID: 3180
  public bool Test;
}