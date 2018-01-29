using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000105 RID: 261
public class HomeVideoGamesScript : MonoBehaviour {

  // Token: 0x0600051C RID: 1308 RVA: 0x000467EC File Offset: 0x00044BEC
  private void Start() {
    if (TaskGlobals.GetTaskStatus(14) == 0) {
      this.TitleScreens[1] = this.TitleScreens[2];
      UILabel uilabel = this.GameTitles[1];
      uilabel.text = this.GameTitles[2].text;
      uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
    }
    this.TitleScreen.mainTexture = this.TitleScreens[1];
  }

  // Token: 0x0600051D RID: 1309 RVA: 0x00046880 File Offset: 0x00044C80
  private void Update() {
    if (this.HomeCamera.Destination == this.HomeCamera.Destinations[5]) {
      if (Input.GetKeyDown("y")) {
        TaskGlobals.SetTaskStatus(14, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
      this.TV.localScale = Vector3.Lerp(this.TV.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (!this.HomeYandere.CanMove) {
        if (!this.HomeDarkness.FadeOut) {
          if (this.InputManager.TappedDown) {
            this.ID++;
            if (this.ID > 5) {
              this.ID = 1;
            }
            this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
            this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 150f - (float)this.ID * 50f, this.Highlight.localPosition.z);
          }
          if (this.InputManager.TappedUp) {
            this.ID--;
            if (this.ID < 1) {
              this.ID = 5;
            }
            this.TitleScreen.mainTexture = this.TitleScreens[this.ID];
            this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 150f - (float)this.ID * 50f, this.Highlight.localPosition.z);
          }
          if (Input.GetButtonDown("A") && this.GameTitles[this.ID].color.a == 1f) {
            Transform transform = this.HomeCamera.Targets[5];
            transform.localPosition = new Vector3(transform.localPosition.x, 1.153333f, transform.localPosition.z);
            this.HomeDarkness.Sprite.color = new Color(this.HomeDarkness.Sprite.color.r, this.HomeDarkness.Sprite.color.g, this.HomeDarkness.Sprite.color.b, -1f);
            this.HomeDarkness.FadeOut = true;
            this.HomeWindow.Show = false;
            this.PromptBar.Show = false;
            this.HomeCamera.ID = 5;
          }
          if (Input.GetButtonDown("B")) {
            this.Quit();
          }
        } else {
          Transform transform2 = this.HomeCamera.Destinations[5];
          Transform transform3 = this.HomeCamera.Targets[5];
          transform2.position = new Vector3(Mathf.Lerp(transform2.position.x, transform3.position.x, Time.deltaTime * 0.75f), Mathf.Lerp(transform2.position.y, transform3.position.y, Time.deltaTime * 10f), Mathf.Lerp(transform2.position.z, transform3.position.z, Time.deltaTime * 10f));
        }
      }
    } else {
      this.TV.localScale = Vector3.Lerp(this.TV.localScale, Vector3.zero, Time.deltaTime * 10f);
    }
  }

  // Token: 0x0600051E RID: 1310 RVA: 0x00046C64 File Offset: 0x00045064
  public void Quit() {
    this.Controller.transform.localPosition = new Vector3(0.20385f, 0.0595f, 0.0215f);
    this.Controller.transform.localEulerAngles = new Vector3(-90f, -90f, 0f);
    this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
    this.HomeCamera.Target = this.HomeCamera.Targets[0];
    this.HomeYandere.CanMove = true;
    this.HomeYandere.enabled = true;
    this.HomeWindow.Show = false;
    this.HomeCamera.PlayMusic();
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
  }

  // Token: 0x04000C14 RID: 3092
  public InputManagerScript InputManager;

  // Token: 0x04000C15 RID: 3093
  public HomeDarknessScript HomeDarkness;

  // Token: 0x04000C16 RID: 3094
  public HomeYandereScript HomeYandere;

  // Token: 0x04000C17 RID: 3095
  public HomeCameraScript HomeCamera;

  // Token: 0x04000C18 RID: 3096
  public HomeWindowScript HomeWindow;

  // Token: 0x04000C19 RID: 3097
  public PromptBarScript PromptBar;

  // Token: 0x04000C1A RID: 3098
  public Texture[] TitleScreens;

  // Token: 0x04000C1B RID: 3099
  public UITexture TitleScreen;

  // Token: 0x04000C1C RID: 3100
  public GameObject Controller;

  // Token: 0x04000C1D RID: 3101
  public Transform Highlight;

  // Token: 0x04000C1E RID: 3102
  public UILabel[] GameTitles;

  // Token: 0x04000C1F RID: 3103
  public Transform TV;

  // Token: 0x04000C20 RID: 3104
  public int ID = 1;
}