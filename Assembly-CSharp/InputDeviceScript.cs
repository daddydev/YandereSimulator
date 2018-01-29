using UnityEngine;

// Token: 0x0200010D RID: 269
public class InputDeviceScript : MonoBehaviour {

  // Token: 0x06000538 RID: 1336 RVA: 0x00048CDC File Offset: 0x000470DC
  private void Update() {
    this.MouseDelta = Input.mousePosition - this.MousePrevious;
    this.MousePrevious = Input.mousePosition;
    InputDeviceType type = this.Type;
    if (Input.anyKey || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || this.MouseDelta != Vector3.zero) {
      this.Type = InputDeviceType.MouseAndKeyboard;
    }
    if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Joystick1Button5) || Input.GetKey(KeyCode.Joystick1Button6) || Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.Joystick1Button8) || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button10) || Input.GetKey(KeyCode.Joystick1Button11) || Input.GetKey(KeyCode.Joystick1Button12) || Input.GetKey(KeyCode.Joystick1Button13) || Input.GetKey(KeyCode.Joystick1Button14) || Input.GetKey(KeyCode.Joystick1Button15) || Input.GetKey(KeyCode.Joystick1Button16) || Input.GetKey(KeyCode.Joystick1Button17) || Input.GetKey(KeyCode.Joystick1Button18) || Input.GetKey(KeyCode.Joystick1Button19) || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetAxis("DpadY") > 0.5f || Input.GetAxis("DpadY") < -0.5f) {
      this.Type = InputDeviceType.Gamepad;
    }
    if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && (Input.GetAxis("Vertical") == 1f || Input.GetAxis("Vertical") == -1f || Input.GetAxis("Horizontal") == 1f || Input.GetAxis("Horizontal") == -1f)) {
      this.Type = InputDeviceType.Gamepad;
    }
    if (this.Type != type) {
      PromptSwapScript[] array = Resources.FindObjectsOfTypeAll<PromptSwapScript>();
      foreach (PromptSwapScript promptSwapScript in array) {
        promptSwapScript.UpdateSpriteType(this.Type);
      }
    }
    this.Horizontal = Input.GetAxis("Horizontal");
    this.Vertical = Input.GetAxis("Vertical");
  }

  // Token: 0x04000C70 RID: 3184
  public InputDeviceType Type = InputDeviceType.Gamepad;

  // Token: 0x04000C71 RID: 3185
  public Vector3 MousePrevious;

  // Token: 0x04000C72 RID: 3186
  public Vector3 MouseDelta;

  // Token: 0x04000C73 RID: 3187
  public float Horizontal;

  // Token: 0x04000C74 RID: 3188
  public float Vertical;
}