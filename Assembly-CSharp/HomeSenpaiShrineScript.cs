using UnityEngine;

// Token: 0x02000101 RID: 257
public class HomeSenpaiShrineScript : MonoBehaviour {

  // Token: 0x0600050C RID: 1292 RVA: 0x00045FAB File Offset: 0x000443AB
  private void Start() {
    this.UpdateText(this.GetCurrentIndex());
  }

  // Token: 0x0600050D RID: 1293 RVA: 0x00045FB9 File Offset: 0x000443B9
  private bool InUpperHalf() {
    return this.Y < 2;
  }

  // Token: 0x0600050E RID: 1294 RVA: 0x00045FC4 File Offset: 0x000443C4
  private int GetCurrentIndex() {
    if (this.InUpperHalf()) {
      return this.Y;
    }
    return 2 + (this.X + (this.Y - 2) * this.Columns);
  }

  // Token: 0x0600050F RID: 1295 RVA: 0x00045FF0 File Offset: 0x000443F0
  private void Update() {
    if (!this.HomeYandere.CanMove && !this.PauseScreen.Show) {
      if (this.HomeCamera.ID == 6) {
        this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
        this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
        this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
        if (this.InputManager.TappedUp) {
          this.Y = ((this.Y <= 0) ? (this.Rows - 1) : (this.Y - 1));
        }
        if (this.InputManager.TappedDown) {
          this.Y = ((this.Y >= this.Rows - 1) ? 0 : (this.Y + 1));
        }
        if (this.InputManager.TappedRight && !this.InUpperHalf()) {
          this.X = ((this.X >= this.Columns - 1) ? 0 : (this.X + 1));
        }
        if (this.InputManager.TappedLeft && !this.InUpperHalf()) {
          this.X = ((this.X <= 0) ? (this.Columns - 1) : (this.X - 1));
        }
        if (this.InUpperHalf()) {
          this.X = 1;
        }
        int currentIndex = this.GetCurrentIndex();
        this.HomeCamera.Destination = this.Destinations[currentIndex];
        this.HomeCamera.Target = this.Targets[currentIndex];
        bool flag = this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft;
        if (flag) {
          this.UpdateText(currentIndex);
        }
        if (Input.GetButtonDown("B")) {
          this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
          this.HomeCamera.Target = this.HomeCamera.Targets[0];
          this.HomeYandere.CanMove = true;
          this.HomeYandere.gameObject.SetActive(true);
          this.HomeWindow.Show = false;
        }
      }
    } else {
      this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
      this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
      this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, this.Rotation, this.LeftDoor.localEulerAngles.z);
    }
  }

  // Token: 0x06000510 RID: 1296 RVA: 0x00046355 File Offset: 0x00044755
  private void UpdateText(int newIndex) {
    this.NameLabel.text = this.Names[newIndex];
    this.DescLabel.text = this.Descs[newIndex];
  }

  // Token: 0x04000BF0 RID: 3056
  public InputManagerScript InputManager;

  // Token: 0x04000BF1 RID: 3057
  public PauseScreenScript PauseScreen;

  // Token: 0x04000BF2 RID: 3058
  public HomeYandereScript HomeYandere;

  // Token: 0x04000BF3 RID: 3059
  public HomeCameraScript HomeCamera;

  // Token: 0x04000BF4 RID: 3060
  public HomeWindowScript HomeWindow;

  // Token: 0x04000BF5 RID: 3061
  public Transform[] Destinations;

  // Token: 0x04000BF6 RID: 3062
  public Transform[] Targets;

  // Token: 0x04000BF7 RID: 3063
  public Transform RightDoor;

  // Token: 0x04000BF8 RID: 3064
  public Transform LeftDoor;

  // Token: 0x04000BF9 RID: 3065
  public UILabel NameLabel;

  // Token: 0x04000BFA RID: 3066
  public UILabel DescLabel;

  // Token: 0x04000BFB RID: 3067
  public string[] Names;

  // Token: 0x04000BFC RID: 3068
  public string[] Descs;

  // Token: 0x04000BFD RID: 3069
  public float Rotation;

  // Token: 0x04000BFE RID: 3070
  private int Rows = 5;

  // Token: 0x04000BFF RID: 3071
  private int Columns = 3;

  // Token: 0x04000C00 RID: 3072
  private int X = 1;

  // Token: 0x04000C01 RID: 3073
  private int Y = 3;
}