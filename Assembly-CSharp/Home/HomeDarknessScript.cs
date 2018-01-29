using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000F8 RID: 248
public class HomeDarknessScript : MonoBehaviour {

  // Token: 0x060004E7 RID: 1255 RVA: 0x0004132C File Offset: 0x0003F72C
  private void Start() {
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
  }

  // Token: 0x060004E8 RID: 1256 RVA: 0x00041388 File Offset: 0x0003F788
  private void Update() {
    if (this.FadeOut) {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a + Time.deltaTime * ((!this.FadeSlow) ? 1f : 0.2f));
      if (this.Sprite.color.a >= 1f) {
        if (this.HomeCamera.ID != 2) {
          if (this.HomeCamera.ID == 5) {
            SceneManager.LoadScene("YanvaniaTitleScene");
          } else if (this.HomeCamera.ID == 9) {
            SceneManager.LoadScene("CalendarScene");
          } else if (this.HomeCamera.ID == 10) {
            StudentGlobals.SetStudentKidnapped(SchoolGlobals.KidnapVictim, false);
            StudentGlobals.SetStudentSlave(SchoolGlobals.KidnapVictim, true);
            SceneManager.LoadScene("LoadingScene");
          } else if (this.HomeCamera.ID == 11) {
            EventGlobals.KidnapConversation = true;
            SceneManager.LoadScene("PhoneScene");
          } else if (this.HomeExit.ID == 1) {
            SceneManager.LoadScene("LoadingScene");
          } else if (this.HomeExit.ID != 2) {
            if (this.HomeExit.ID == 3) {
              if (this.HomeYandere.transform.position.y > -5f) {
                this.HomeYandere.transform.position = new Vector3(-2f, -10f, -2f);
                this.HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                this.HomeYandere.CanMove = true;
                this.FadeOut = false;
                this.HomeCamera.Destinations[0].position = new Vector3(2.425f, -8f, 0f);
                this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
                this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
                this.HomeCamera.Target = this.HomeCamera.Targets[0];
                this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
                this.BasementLabel.text = "Upstairs";
                this.HomeCamera.DayLight.SetActive(true);
              } else {
                this.HomeYandere.transform.position = new Vector3(-1.6f, 0f, -1.6f);
                this.HomeYandere.transform.eulerAngles = new Vector3(0f, 45f, 0f);
                this.HomeYandere.CanMove = true;
                this.FadeOut = false;
                this.HomeCamera.Destinations[0].position = new Vector3(-2.0615f, 2f, 2.418f);
                this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
                this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
                this.HomeCamera.Target = this.HomeCamera.Targets[0];
                this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
                this.BasementLabel.text = "Basement";
                if (HomeGlobals.Night) {
                  this.HomeCamera.DayLight.SetActive(false);
                }
              }
            }
          }
        } else {
          SceneManager.LoadScene("CalendarScene");
        }
      }
    } else {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a - Time.deltaTime);
      if (this.Sprite.color.a < 0f) {
        this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
      }
    }
  }

  // Token: 0x04000B27 RID: 2855
  public HomeYandereScript HomeYandere;

  // Token: 0x04000B28 RID: 2856
  public HomeCameraScript HomeCamera;

  // Token: 0x04000B29 RID: 2857
  public HomeExitScript HomeExit;

  // Token: 0x04000B2A RID: 2858
  public UILabel BasementLabel;

  // Token: 0x04000B2B RID: 2859
  public UISprite Sprite;

  // Token: 0x04000B2C RID: 2860
  public bool FadeSlow;

  // Token: 0x04000B2D RID: 2861
  public bool FadeOut;
}