using UnityEngine;

// Token: 0x020000F9 RID: 249
public class HomeExitScript : MonoBehaviour {

  // Token: 0x060004EA RID: 1258 RVA: 0x00041880 File Offset: 0x0003FC80
  private void Start() {
    UILabel uilabel = this.Labels[2];
    uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
    if (HomeGlobals.Night) {
      UILabel uilabel2 = this.Labels[1];
      uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
    }
  }

  // Token: 0x060004EB RID: 1259 RVA: 0x00041964 File Offset: 0x0003FD64
  private void Update() {
    if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut) {
      if (this.InputManager.TappedDown) {
        this.ID++;
        if (this.ID > 3) {
          this.ID = 1;
        }
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
      }
      if (this.InputManager.TappedUp) {
        this.ID--;
        if (this.ID < 1) {
          this.ID = 3;
        }
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
      }
      if (Input.GetButtonDown("A") && this.ID != 2 && (!HomeGlobals.Night || (HomeGlobals.Night && this.ID == 3))) {
        if (this.ID < 3 && SchoolGlobals.SchoolAtmosphere >= 0.5f) {
          this.HomeDarkness.Sprite.color = new Color(1f, 1f, 1f, 0f);
        }
        this.HomeDarkness.FadeOut = true;
        this.HomeWindow.Show = false;
        base.enabled = false;
      }
      if (Input.GetButtonDown("B")) {
        this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
        this.HomeCamera.Target = this.HomeCamera.Targets[0];
        this.HomeYandere.CanMove = true;
        this.HomeWindow.Show = false;
        base.enabled = false;
      }
    }
  }

  // Token: 0x04000B2E RID: 2862
  public InputManagerScript InputManager;

  // Token: 0x04000B2F RID: 2863
  public HomeDarknessScript HomeDarkness;

  // Token: 0x04000B30 RID: 2864
  public HomeYandereScript HomeYandere;

  // Token: 0x04000B31 RID: 2865
  public HomeCameraScript HomeCamera;

  // Token: 0x04000B32 RID: 2866
  public HomeWindowScript HomeWindow;

  // Token: 0x04000B33 RID: 2867
  public Transform Highlight;

  // Token: 0x04000B34 RID: 2868
  public UILabel[] Labels;

  // Token: 0x04000B35 RID: 2869
  public int ID = 1;
}