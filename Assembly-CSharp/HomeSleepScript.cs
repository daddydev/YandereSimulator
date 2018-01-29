using UnityEngine;

// Token: 0x02000102 RID: 258
public class HomeSleepScript : MonoBehaviour {

  // Token: 0x06000512 RID: 1298 RVA: 0x00046388 File Offset: 0x00044788
  private void Update() {
    if (!this.HomeYandere.CanMove && !this.HomeDarkness.FadeOut) {
      if (Input.GetButtonDown("A")) {
        this.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
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

  // Token: 0x04000C02 RID: 3074
  public HomeDarknessScript HomeDarkness;

  // Token: 0x04000C03 RID: 3075
  public HomeYandereScript HomeYandere;

  // Token: 0x04000C04 RID: 3076
  public HomeCameraScript HomeCamera;

  // Token: 0x04000C05 RID: 3077
  public HomeWindowScript HomeWindow;
}