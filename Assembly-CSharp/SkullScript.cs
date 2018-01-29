using UnityEngine;

// Token: 0x020001B8 RID: 440
public class SkullScript : MonoBehaviour {

  // Token: 0x060007B0 RID: 1968 RVA: 0x00076193 File Offset: 0x00074593
  private void Start() {
    this.OriginalPosition = this.RitualKnife.transform.position;
    this.OriginalRotation = this.RitualKnife.transform.eulerAngles;
  }

  // Token: 0x060007B1 RID: 1969 RVA: 0x000761C4 File Offset: 0x000745C4
  private void Update() {
    if (this.Yandere.Armed) {
      if (this.Yandere.EquippedWeapon.WeaponID == 8) {
        this.Prompt.enabled = true;
      } else if (this.Prompt.enabled) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.EquippedWeapon.Drop();
      this.Yandere.EquippedWeapon = null;
      this.Yandere.Unequip();
      this.Yandere.DropTimer[this.Yandere.Equipped] = 0f;
      this.RitualKnife.transform.position = this.OriginalPosition;
      this.RitualKnife.transform.eulerAngles = this.OriginalRotation;
      this.RitualKnife.GetComponent<Rigidbody>().useGravity = false;
      if (this.RitualKnife.GetComponent<WeaponScript>().Heated && !this.RitualKnife.GetComponent<WeaponScript>().Flaming) {
        component.clip = this.FlameDemonVoice;
        component.Play();
        this.FlameTimer = 10f;
        this.RitualKnife.GetComponent<WeaponScript>().Prompt.Hide();
        this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = false;
      } else if (this.RitualKnife.GetComponent<WeaponScript>().Blood.enabled) {
        this.DebugMenu.SetActive(false);
        this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
        this.Yandere.CanMove = false;
        UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
        this.Timer += Time.deltaTime;
        this.Clock.StopTime = true;
      }
    }
    if (this.FlameTimer > 0f) {
      this.FlameTimer = Mathf.MoveTowards(this.FlameTimer, 0f, Time.deltaTime);
      if (this.FlameTimer == 0f) {
        this.RitualKnife.GetComponent<WeaponScript>().FireEffect.gameObject.SetActive(true);
        this.RitualKnife.GetComponent<WeaponScript>().Prompt.enabled = true;
        this.RitualKnife.GetComponent<WeaponScript>().FireEffect.Play();
        this.RitualKnife.GetComponent<WeaponScript>().FireAudio.Play();
        this.RitualKnife.GetComponent<WeaponScript>().Flaming = true;
        this.Prompt.enabled = true;
        component.clip = this.FlameActivation;
        component.Play();
      }
    }
    if (this.Timer > 0f) {
      if (this.Yandere.transform.position.y < 1000f) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 4f) {
          this.Darkness.enabled = true;
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
          if (this.Darkness.color.a == 1f) {
            this.Yandere.transform.position = new Vector3(0f, 2000f, 0f);
            this.Yandere.Character.SetActive(true);
            this.Yandere.SetAnimationLayers();
            this.HeartbeatCamera.SetActive(false);
            this.FPS.SetActive(false);
            this.HUD.SetActive(false);
          }
        } else if (this.Timer > 1f) {
          this.Yandere.Character.SetActive(false);
        }
      } else {
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime * 0.5f);
        if (this.Jukebox.Volume == 0f) {
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
          if (this.Darkness.color.a == 0f) {
            this.Yandere.CanMove = true;
            this.Timer = 0f;
          }
        }
      }
    }
    if (this.Yandere.Egg) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      base.enabled = false;
    }
  }

  // Token: 0x040013BE RID: 5054
  public JukeboxScript Jukebox;

  // Token: 0x040013BF RID: 5055
  public YandereScript Yandere;

  // Token: 0x040013C0 RID: 5056
  public PromptScript Prompt;

  // Token: 0x040013C1 RID: 5057
  public ClockScript Clock;

  // Token: 0x040013C2 RID: 5058
  public AudioClip FlameDemonVoice;

  // Token: 0x040013C3 RID: 5059
  public AudioClip FlameActivation;

  // Token: 0x040013C4 RID: 5060
  public GameObject HeartbeatCamera;

  // Token: 0x040013C5 RID: 5061
  public GameObject RitualKnife;

  // Token: 0x040013C6 RID: 5062
  public GameObject DebugMenu;

  // Token: 0x040013C7 RID: 5063
  public GameObject DarkAura;

  // Token: 0x040013C8 RID: 5064
  public GameObject FPS;

  // Token: 0x040013C9 RID: 5065
  public GameObject HUD;

  // Token: 0x040013CA RID: 5066
  public Vector3 OriginalPosition;

  // Token: 0x040013CB RID: 5067
  public Vector3 OriginalRotation;

  // Token: 0x040013CC RID: 5068
  public UISprite Darkness;

  // Token: 0x040013CD RID: 5069
  public float FlameTimer;

  // Token: 0x040013CE RID: 5070
  public float Timer;
}