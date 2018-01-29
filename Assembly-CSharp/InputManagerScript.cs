using UnityEngine;

// Token: 0x0200010E RID: 270
public class InputManagerScript : MonoBehaviour {

  // Token: 0x0600053A RID: 1338 RVA: 0x00048FC8 File Offset: 0x000473C8
  private void Update() {
    this.TappedUp = false;
    this.TappedDown = false;
    this.TappedRight = false;
    this.TappedLeft = false;
    if (Input.GetAxis("DpadY") > 0.5f) {
      this.TappedUp = !this.DPadUp;
      this.DPadUp = true;
    } else if (Input.GetAxis("DpadY") < -0.5f) {
      this.TappedDown = !this.DPadDown;
      this.DPadDown = true;
    } else {
      this.DPadUp = false;
      this.DPadDown = false;
    }
    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
      if (Input.GetAxis("Vertical") > 0.5f) {
        this.TappedUp = !this.StickUp;
        this.StickUp = !this.TappedDown;
      } else if (Input.GetAxis("Vertical") < -0.5f) {
        this.TappedDown = !this.StickDown;
        this.StickDown = !this.TappedUp;
      } else {
        this.StickUp = false;
        this.StickDown = false;
      }
    }
    if (Input.GetAxis("DpadX") > 0.5f) {
      this.TappedRight = !this.DPadRight;
      this.DPadRight = true;
    } else if (Input.GetAxis("DpadX") < -0.5f) {
      this.TappedLeft = !this.DPadLeft;
      this.DPadLeft = true;
    } else {
      this.DPadRight = false;
      this.DPadLeft = false;
    }
    if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
      if (Input.GetAxis("Horizontal") > 0.5f) {
        this.TappedRight = !this.StickRight;
        this.StickRight = true;
      } else if (Input.GetAxis("Horizontal") < -0.5f) {
        this.TappedLeft = !this.StickLeft;
        this.StickLeft = true;
      } else {
        this.StickRight = false;
        this.StickLeft = false;
      }
    }
    if (Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f && Input.GetAxis("DpadX") < 0.5f && Input.GetAxis("DpadX") > -0.5f) {
      this.TappedRight = false;
      this.TappedLeft = false;
    }
    if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("DpadY") < 0.5f && Input.GetAxis("DpadY") > -0.5f) {
      this.TappedUp = false;
      this.TappedDown = false;
    }
    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
      this.TappedUp = true;
      this.NoStick();
    }
    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
      this.TappedDown = true;
      this.NoStick();
    }
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
      this.TappedLeft = true;
      this.NoStick();
    }
    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
      this.TappedRight = true;
      this.NoStick();
    }
  }

  // Token: 0x0600053B RID: 1339 RVA: 0x0004933D File Offset: 0x0004773D
  private void NoStick() {
    this.StickUp = false;
    this.StickDown = false;
    this.StickLeft = false;
    this.StickRight = false;
  }

  // Token: 0x04000C75 RID: 3189
  public bool TappedUp;

  // Token: 0x04000C76 RID: 3190
  public bool TappedDown;

  // Token: 0x04000C77 RID: 3191
  public bool TappedRight;

  // Token: 0x04000C78 RID: 3192
  public bool TappedLeft;

  // Token: 0x04000C79 RID: 3193
  public bool DPadUp;

  // Token: 0x04000C7A RID: 3194
  public bool StickUp;

  // Token: 0x04000C7B RID: 3195
  public bool DPadDown;

  // Token: 0x04000C7C RID: 3196
  public bool StickDown;

  // Token: 0x04000C7D RID: 3197
  public bool DPadRight;

  // Token: 0x04000C7E RID: 3198
  public bool StickRight;

  // Token: 0x04000C7F RID: 3199
  public bool DPadLeft;

  // Token: 0x04000C80 RID: 3200
  public bool StickLeft;
}