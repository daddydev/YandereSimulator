using UnityEngine;

// Token: 0x0200016B RID: 363
public class PromptSwapScript : MonoBehaviour {

  // Token: 0x060006B8 RID: 1720 RVA: 0x000666D0 File Offset: 0x00064AD0
  private void Awake() {
    if (this.InputDevice == null) {
      this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
    }
  }

  // Token: 0x060006B9 RID: 1721 RVA: 0x000666F0 File Offset: 0x00064AF0
  public void UpdateSpriteType(InputDeviceType deviceType) {
    if (this.InputDevice == null) {
      this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
    }
    if (deviceType == InputDeviceType.Gamepad) {
      this.MySprite.spriteName = this.GamepadName;
      if (this.MyLetter != null) {
        this.MyLetter.text = string.Empty;
      }
    } else {
      this.MySprite.spriteName = this.KeyboardName;
      if (this.MyLetter != null) {
        this.MyLetter.text = this.KeyboardLetter;
      }
    }
  }

  // Token: 0x040010C6 RID: 4294
  public InputDeviceScript InputDevice;

  // Token: 0x040010C7 RID: 4295
  public UISprite MySprite;

  // Token: 0x040010C8 RID: 4296
  public UILabel MyLetter;

  // Token: 0x040010C9 RID: 4297
  public string KeyboardLetter = string.Empty;

  // Token: 0x040010CA RID: 4298
  public string KeyboardName = string.Empty;

  // Token: 0x040010CB RID: 4299
  public string GamepadName = string.Empty;
}