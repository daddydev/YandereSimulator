using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000219 RID: 537
public class WelcomeScript : MonoBehaviour {

  // Token: 0x0600095C RID: 2396 RVA: 0x000A37B4 File Offset: 0x000A1BB4
  private void Start() {
    this.BeginLabel.color = new Color(this.BeginLabel.color.r, this.BeginLabel.color.g, this.BeginLabel.color.b, 0f);
    this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 2f);
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    if (ApplicationGlobals.VersionNumber != this.VersionNumber) {
      Globals.DeleteAll();
      ApplicationGlobals.VersionNumber = this.VersionNumber;
    }
    if (this.JSON.Students[33].Name != "Reserved") {
      if (Application.CanStreamedLevelBeLoaded("FunScene")) {
        SceneManager.LoadScene("FunScene");
      } else if (Application.CanStreamedLevelBeLoaded("MoreFunScene")) {
        SceneManager.LoadScene("MoreFunScene");
      } else {
        Application.Quit();
      }
    }
  }

  // Token: 0x0600095D RID: 2397 RVA: 0x000A38F0 File Offset: 0x000A1CF0
  private void Update() {
    if (Input.GetKeyDown(KeyCode.S)) {
      SceneManager.LoadScene("SchoolScene");
    }
    if (Input.GetKeyDown(KeyCode.Y)) {
      SceneManager.LoadScene("YanvaniaScene");
    }
    if (!this.Continue) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a - Time.deltaTime);
      if (this.Darkness.color.a <= 0f) {
        if (Input.GetKeyDown(KeyCode.W)) {
        }
        if (Input.anyKeyDown) {
          this.Timer = 5f;
        }
        this.Timer += Time.deltaTime;
        if (this.Timer > 5f) {
          this.BeginLabel.color = new Color(this.BeginLabel.color.r, this.BeginLabel.color.g, this.BeginLabel.color.b, this.BeginLabel.color.a + Time.deltaTime);
          if (this.BeginLabel.color.a >= 1f) {
            if (this.WelcomePanel.activeInHierarchy && Input.anyKeyDown) {
              this.Darkness.color = new Color(1f, 1f, 1f, 0f);
              this.Continue = true;
            }
            if (this.WarningPanel.activeInHierarchy && Input.anyKeyDown) {
              this.Darkness.color = new Color(1f, 1f, 1f, 0f);
              this.Continue = true;
            }
          }
        }
      }
    } else {
      this.Music.volume -= Time.deltaTime;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if (this.Darkness.color.a >= 1f) {
        SceneManager.LoadScene("SponsorScene");
      }
    }
    if (!this.FlashRed) {
      this.FlashingLabel.color = new Color(this.FlashingLabel.color.r + Time.deltaTime * 10f, this.FlashingLabel.color.g, this.FlashingLabel.color.b, this.FlashingLabel.color.a);
      if (this.FlashingLabel.color.r > 1f) {
        this.FlashRed = true;
      }
    } else {
      this.FlashingLabel.color = new Color(this.FlashingLabel.color.r - Time.deltaTime * 10f, this.FlashingLabel.color.g, this.FlashingLabel.color.b, this.FlashingLabel.color.a);
      if (this.FlashingLabel.color.r < 0f) {
        this.FlashRed = false;
      }
    }
  }

  // Token: 0x04001ACC RID: 6860
  [SerializeField]
  private JsonScript JSON;

  // Token: 0x04001ACD RID: 6861
  [SerializeField]
  private GameObject WelcomePanel;

  // Token: 0x04001ACE RID: 6862
  [SerializeField]
  private GameObject WarningPanel;

  // Token: 0x04001ACF RID: 6863
  [SerializeField]
  private UILabel FlashingLabel;

  // Token: 0x04001AD0 RID: 6864
  [SerializeField]
  private UILabel BeginLabel;

  // Token: 0x04001AD1 RID: 6865
  [SerializeField]
  private UISprite Darkness;

  // Token: 0x04001AD2 RID: 6866
  [SerializeField]
  private AudioSource Music;

  // Token: 0x04001AD3 RID: 6867
  [SerializeField]
  private bool Continue;

  // Token: 0x04001AD4 RID: 6868
  [SerializeField]
  private bool FlashRed;

  // Token: 0x04001AD5 RID: 6869
  [SerializeField]
  private float VersionNumber;

  // Token: 0x04001AD6 RID: 6870
  [SerializeField]
  private float Timer;
}