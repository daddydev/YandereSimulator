using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000F4 RID: 244
public class HomeCameraScript : MonoBehaviour {

  // Token: 0x060004DA RID: 1242 RVA: 0x00040498 File Offset: 0x0003E898
  private void Start() {
    this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, 0f);
    this.Focus.position = this.Target.position;
    base.transform.position = this.Destination.position;
    if (HomeGlobals.Night) {
      this.CeilingLight.SetActive(true);
      this.SenpaiLight.SetActive(true);
      this.NightLight.SetActive(true);
      this.DayLight.SetActive(false);
      this.Triggers[7].Disable();
      this.BasementJukebox.clip = this.NightBasement;
      this.RoomJukebox.clip = this.NightRoom;
      this.PlayMusic();
      this.PantiesMangaLabel.text = "Read Manga";
    } else {
      this.BasementJukebox.Play();
      this.RoomJukebox.Play();
      this.ComputerScreen.SetActive(false);
      this.Triggers[2].Disable();
      this.Triggers[3].Disable();
      this.Triggers[5].Disable();
      this.Triggers[9].Disable();
    }
    if (SchoolGlobals.KidnapVictim == 0) {
      this.RopeGroup.SetActive(false);
      this.Tripod.SetActive(false);
      this.Victim.SetActive(false);
      this.Triggers[10].Disable();
    } else {
      int kidnapVictim = SchoolGlobals.KidnapVictim;
      if (StudentGlobals.GetStudentArrested(kidnapVictim) || StudentGlobals.GetStudentDead(kidnapVictim)) {
        this.RopeGroup.SetActive(false);
        this.Victim.SetActive(false);
        this.Triggers[10].Disable();
      }
    }
    if (GameGlobals.LoveSick) {
      this.LoveSickColorSwap();
    }
    Time.timeScale = 1f;
  }

  // Token: 0x060004DB RID: 1243 RVA: 0x00040698 File Offset: 0x0003EA98
  private void LateUpdate() {
    if (this.HomeYandere.transform.position.y > -5f) {
      Transform transform = this.Destinations[0];
      transform.position = new Vector3(-this.HomeYandere.transform.position.x, transform.position.y, transform.position.z);
    }
    this.Focus.position = Vector3.Lerp(this.Focus.position, this.Target.position, Time.deltaTime * 10f);
    base.transform.position = Vector3.Lerp(base.transform.position, this.Destination.position, Time.deltaTime * 10f);
    base.transform.LookAt(this.Focus.position);
    if (this.ID < 11 && Input.GetButtonDown("A") && this.HomeYandere.CanMove && this.ID != 0) {
      this.Destination = this.Destinations[this.ID];
      this.Target = this.Targets[this.ID];
      this.HomeWindows[this.ID].Show = true;
      this.HomeYandere.CanMove = false;
      if (this.ID == 1 || this.ID == 8) {
        this.HomeExit.enabled = true;
      } else if (this.ID == 2) {
        this.HomeSleep.enabled = true;
      } else if (this.ID == 3) {
        this.HomeInternet.enabled = true;
      } else if (this.ID == 4) {
        this.CorkboardLabel.SetActive(false);
        this.HomeCorkboard.enabled = true;
        this.LoadingScreen.SetActive(true);
        this.HomeYandere.gameObject.SetActive(false);
      } else if (this.ID == 5) {
        this.HomeYandere.enabled = false;
        this.Controller.transform.localPosition = new Vector3(0.1245f, 0.032f, 0f);
        this.HomeYandere.transform.position = new Vector3(1f, 0f, 0f);
        this.HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        this.HomeYandere.Character.GetComponent<Animation>().Play("f02_gaming_00");
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Play";
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.Label[4].text = "Select";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
      } else if (this.ID == 6) {
        this.HomeSenpaiShrine.enabled = true;
        this.HomeYandere.gameObject.SetActive(false);
      } else if (this.ID == 7) {
        this.HomePantyChanger.enabled = true;
      } else if (this.ID == 9) {
        this.HomeManga.enabled = true;
      } else if (this.ID == 10) {
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[1].text = "Back";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.HomePrisoner.UpdateDesc();
        this.HomeYandere.gameObject.SetActive(false);
      }
    }
    if (this.Destination == this.Destinations[0]) {
      this.Vignette.intensity = ((this.HomeYandere.transform.position.y <= -1f) ? Mathf.MoveTowards(this.Vignette.intensity, 5f, Time.deltaTime * 5f) : Mathf.MoveTowards(this.Vignette.intensity, 1f, Time.deltaTime));
      this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 1f, Time.deltaTime);
      this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 1f, Time.deltaTime);
    } else {
      this.Vignette.intensity = ((this.HomeYandere.transform.position.y <= -1f) ? Mathf.MoveTowards(this.Vignette.intensity, 0f, Time.deltaTime * 5f) : Mathf.MoveTowards(this.Vignette.intensity, 0f, Time.deltaTime));
      this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, 0f, Time.deltaTime);
      this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, 0f, Time.deltaTime);
    }
    this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, (this.ID <= 0 || !this.HomeYandere.CanMove) ? 0f : 1f, Time.deltaTime * 10f));
    if (this.HomeDarkness.FadeOut) {
      this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0f, Time.deltaTime);
      this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0f, Time.deltaTime);
    } else if (this.HomeYandere.transform.position.y > -1f) {
      this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0f, Time.deltaTime);
      this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0.5f, Time.deltaTime);
    } else if (!this.Torturing) {
      this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, 0.5f, Time.deltaTime);
      this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, 0f, Time.deltaTime);
    }
    if (Input.GetKeyDown(KeyCode.Y)) {
      TaskGlobals.SetTaskStatus(14, 1);
    }
    if (Input.GetKeyDown(KeyCode.BackQuote)) {
      HomeGlobals.Night = !HomeGlobals.Night;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    if (Input.GetKeyDown(KeyCode.Equals)) {
      Time.timeScale += 1f;
    }
    if (Input.GetKeyDown(KeyCode.Minus) && Time.timeScale > 1f) {
      Time.timeScale -= 1f;
    }
  }

  // Token: 0x060004DC RID: 1244 RVA: 0x00040E70 File Offset: 0x0003F270
  public void PlayMusic() {
    if (!YanvaniaGlobals.DraculaDefeated) {
      if (!this.BasementJukebox.isPlaying) {
        this.BasementJukebox.Play();
      }
      if (!this.RoomJukebox.isPlaying) {
        this.RoomJukebox.Play();
      }
    }
  }

  // Token: 0x060004DD RID: 1245 RVA: 0x00040EC0 File Offset: 0x0003F2C0
  private void LoveSickColorSwap() {
    GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gameObject in array) {
      if (gameObject.transform.parent != this.PauseScreen && gameObject.transform.parent != this.PromptBarPanel) {
        UISprite component = gameObject.GetComponent<UISprite>();
        if (component != null && component.color != Color.black) {
          component.color = new Color(1f, 0f, 0f, component.color.a);
        }
        UILabel component2 = gameObject.GetComponent<UILabel>();
        if (component2 != null && component2.color != Color.black) {
          component2.color = new Color(1f, 0f, 0f, component2.color.a);
        }
      }
    }
    this.DayLight.GetComponent<Light>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
    this.HomeDarkness.Sprite.color = Color.black;
    this.BasementJukebox.clip = this.HomeLoveSick;
    this.RoomJukebox.clip = this.HomeLoveSick;
    this.LoveSickCamera.SetActive(true);
    this.PlayMusic();
  }

  // Token: 0x04000AF1 RID: 2801
  public HomeWindowScript[] HomeWindows;

  // Token: 0x04000AF2 RID: 2802
  public HomeTriggerScript[] Triggers;

  // Token: 0x04000AF3 RID: 2803
  public HomePantyChangerScript HomePantyChanger;

  // Token: 0x04000AF4 RID: 2804
  public HomeSenpaiShrineScript HomeSenpaiShrine;

  // Token: 0x04000AF5 RID: 2805
  public HomeVideoGamesScript HomeVideoGames;

  // Token: 0x04000AF6 RID: 2806
  public HomeCorkboardScript HomeCorkboard;

  // Token: 0x04000AF7 RID: 2807
  public HomeDarknessScript HomeDarkness;

  // Token: 0x04000AF8 RID: 2808
  public HomeInternetScript HomeInternet;

  // Token: 0x04000AF9 RID: 2809
  public HomePrisonerScript HomePrisoner;

  // Token: 0x04000AFA RID: 2810
  public HomeYandereScript HomeYandere;

  // Token: 0x04000AFB RID: 2811
  public HomeMangaScript HomeManga;

  // Token: 0x04000AFC RID: 2812
  public HomeSleepScript HomeSleep;

  // Token: 0x04000AFD RID: 2813
  public HomeExitScript HomeExit;

  // Token: 0x04000AFE RID: 2814
  public PromptBarScript PromptBar;

  // Token: 0x04000AFF RID: 2815
  public Vignetting Vignette;

  // Token: 0x04000B00 RID: 2816
  public UILabel PantiesMangaLabel;

  // Token: 0x04000B01 RID: 2817
  public UISprite Button;

  // Token: 0x04000B02 RID: 2818
  public GameObject ComputerScreen;

  // Token: 0x04000B03 RID: 2819
  public GameObject CorkboardLabel;

  // Token: 0x04000B04 RID: 2820
  public GameObject LoveSickCamera;

  // Token: 0x04000B05 RID: 2821
  public GameObject LoadingScreen;

  // Token: 0x04000B06 RID: 2822
  public GameObject CeilingLight;

  // Token: 0x04000B07 RID: 2823
  public GameObject SenpaiLight;

  // Token: 0x04000B08 RID: 2824
  public GameObject Controller;

  // Token: 0x04000B09 RID: 2825
  public GameObject NightLight;

  // Token: 0x04000B0A RID: 2826
  public GameObject RopeGroup;

  // Token: 0x04000B0B RID: 2827
  public GameObject DayLight;

  // Token: 0x04000B0C RID: 2828
  public GameObject Tripod;

  // Token: 0x04000B0D RID: 2829
  public GameObject Victim;

  // Token: 0x04000B0E RID: 2830
  public Transform Destination;

  // Token: 0x04000B0F RID: 2831
  public Transform Target;

  // Token: 0x04000B10 RID: 2832
  public Transform Focus;

  // Token: 0x04000B11 RID: 2833
  public Transform[] Destinations;

  // Token: 0x04000B12 RID: 2834
  public Transform[] Targets;

  // Token: 0x04000B13 RID: 2835
  public int ID;

  // Token: 0x04000B14 RID: 2836
  public AudioSource BasementJukebox;

  // Token: 0x04000B15 RID: 2837
  public AudioSource RoomJukebox;

  // Token: 0x04000B16 RID: 2838
  public AudioClip NightBasement;

  // Token: 0x04000B17 RID: 2839
  public AudioClip NightRoom;

  // Token: 0x04000B18 RID: 2840
  public AudioClip HomeLoveSick;

  // Token: 0x04000B19 RID: 2841
  public bool Torturing;

  // Token: 0x04000B1A RID: 2842
  public Transform PromptBarPanel;

  // Token: 0x04000B1B RID: 2843
  public Transform PauseScreen;
}