using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000112 RID: 274
public class IntroScript : MonoBehaviour {

  // Token: 0x06000541 RID: 1345 RVA: 0x000497AC File Offset: 0x00047BAC
  private void Start() {
    this.LoveSickCheck();
    this.Circle.fillAmount = 0f;
    this.Darkness.color = new Color(0f, 0f, 0f, 1f);
    this.Label.text = string.Empty;
    this.SkipTimer = 15f;
  }

  // Token: 0x06000542 RID: 1346 RVA: 0x00049810 File Offset: 0x00047C10
  private void Update() {
    if (Input.GetButton("X")) {
      this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 1f, Time.deltaTime);
      this.SkipTimer = 15f;
      if (this.Circle.fillAmount == 1f) {
        this.FadeOut = true;
      }
      this.SkipPanel.alpha = 1f;
    } else {
      this.Circle.fillAmount = Mathf.MoveTowards(this.Circle.fillAmount, 0f, Time.deltaTime);
      this.SkipTimer -= Time.deltaTime;
      this.SkipPanel.alpha = this.SkipTimer / 10f;
    }
    this.Timer += Time.deltaTime;
    if (this.Timer > 1f && !this.Narrating) {
      this.Narration.Play();
      this.Narrating = true;
    }
    if (this.ID < this.Cue.Length && this.Narration.time > this.Cue[this.ID]) {
      this.Label.text = this.Lines[this.ID];
      this.ID++;
    }
    if (this.FadeOut) {
      this.FadeOutDarkness.color = new Color(this.FadeOutDarkness.color.r, this.FadeOutDarkness.color.g, this.FadeOutDarkness.color.b, Mathf.MoveTowards(this.FadeOutDarkness.color.a, 1f, Time.deltaTime));
      this.Circle.fillAmount = 1f;
      this.Narration.volume = this.FadeOutDarkness.color.a;
      if (this.FadeOutDarkness.color.a == 1f) {
        SceneManager.LoadScene("PhoneScene");
      }
    }
    if (this.Narration.time > 39.75f && this.Narration.time < 73f) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 0.5f));
    }
    if (this.Narration.time > 73f && this.Narration.time < 105.5f) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
    }
    if (this.Narration.time > 105.5f && this.Narration.time < 134f) {
      this.Darkness.color = new Color(1f, 0f, 0f, 1f);
    }
    if (this.Narration.time > 134f && this.Narration.time < 147f) {
      this.Darkness.color = new Color(0f, 0f, 0f, 1f);
    }
    if (this.Narration.time > 147f && this.Narration.time < 152f) {
      this.Logo.transform.localScale = new Vector3(this.Logo.transform.localScale.x + Time.deltaTime * 0.1f, this.Logo.transform.localScale.y + Time.deltaTime * 0.1f, this.Logo.transform.localScale.z + Time.deltaTime * 0.1f);
      this.LoveSickLogo.transform.localScale = new Vector3(this.LoveSickLogo.transform.localScale.x + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.y + Time.deltaTime * 0.05f, this.LoveSickLogo.transform.localScale.z + Time.deltaTime * 0.05f);
      this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 1f);
      this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 1f);
    }
    if (this.Narration.time > 152f) {
      this.Logo.color = new Color(this.Logo.color.r, this.Logo.color.g, this.Logo.color.b, 0f);
      this.LoveSickLogo.color = new Color(this.LoveSickLogo.color.r, this.LoveSickLogo.color.g, this.LoveSickLogo.color.b, 0f);
    }
    if (this.Narration.time > 156f) {
      SceneManager.LoadScene("PhoneScene");
    }
  }

  // Token: 0x06000543 RID: 1347 RVA: 0x00049EBC File Offset: 0x000482BC
  private void LoveSickCheck() {
    if (GameGlobals.LoveSick) {
      Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
      GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
      foreach (GameObject gameObject in array) {
        UISprite component = gameObject.GetComponent<UISprite>();
        if (component != null) {
          component.color = new Color(1f, 0f, 0f, component.color.a);
        }
        UITexture component2 = gameObject.GetComponent<UITexture>();
        if (component2 != null) {
          component2.color = new Color(1f, 0f, 0f, component2.color.a);
        }
        UILabel component3 = gameObject.GetComponent<UILabel>();
        if (component3 != null && component3.color != Color.black) {
          component3.color = new Color(1f, 0f, 0f, component3.color.a);
        }
      }
      this.FadeOutDarkness.color = new Color(0f, 0f, 0f, 0f);
      this.LoveSickLogo.enabled = true;
      this.Logo.enabled = false;
    } else {
      this.LoveSickLogo.enabled = false;
    }
  }

  // Token: 0x04000CA3 RID: 3235
  public UISprite FadeOutDarkness;

  // Token: 0x04000CA4 RID: 3236
  public UITexture LoveSickLogo;

  // Token: 0x04000CA5 RID: 3237
  public UIPanel SkipPanel;

  // Token: 0x04000CA6 RID: 3238
  public UISprite Darkness;

  // Token: 0x04000CA7 RID: 3239
  public UISprite Circle;

  // Token: 0x04000CA8 RID: 3240
  public UITexture Logo;

  // Token: 0x04000CA9 RID: 3241
  public UILabel Label;

  // Token: 0x04000CAA RID: 3242
  public AudioSource Narration;

  // Token: 0x04000CAB RID: 3243
  public string[] Lines;

  // Token: 0x04000CAC RID: 3244
  public float[] Cue;

  // Token: 0x04000CAD RID: 3245
  public bool Narrating;

  // Token: 0x04000CAE RID: 3246
  public bool Musicing;

  // Token: 0x04000CAF RID: 3247
  public bool FadeOut;

  // Token: 0x04000CB0 RID: 3248
  public float SkipTimer;

  // Token: 0x04000CB1 RID: 3249
  public float Timer;

  // Token: 0x04000CB2 RID: 3250
  public int ID;
}