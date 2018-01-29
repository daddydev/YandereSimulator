using UnityEngine;

// Token: 0x0200010A RID: 266
public class IncineratorScript : MonoBehaviour {

  // Token: 0x06000531 RID: 1329 RVA: 0x0004808E File Offset: 0x0004648E
  private void Start() {
    this.Panel.SetActive(false);
  }

  // Token: 0x06000532 RID: 1330 RVA: 0x0004809C File Offset: 0x0004649C
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.Open) {
      this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.RightDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), this.RightDoor.transform.localEulerAngles.z);
      this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.LeftDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), this.LeftDoor.transform.localEulerAngles.z);
      if (this.RightDoor.transform.localEulerAngles.y < 36f) {
        if (this.RightDoor.transform.localEulerAngles.y > 0f) {
          component.clip = this.IncineratorClose;
          component.Play();
        }
        this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 0f, this.RightDoor.transform.localEulerAngles.z);
      }
    } else {
      if (this.RightDoor.transform.localEulerAngles.y == 0f) {
        component.clip = this.IncineratorOpen;
        component.Play();
      }
      this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 10f), this.RightDoor.transform.localEulerAngles.z);
      this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 10f), this.LeftDoor.transform.localEulerAngles.z);
      if (this.RightDoor.transform.localEulerAngles.y > 134f) {
        this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 135f, this.RightDoor.transform.localEulerAngles.z);
      }
    }
    if (this.OpenTimer > 0f) {
      this.OpenTimer -= Time.deltaTime;
      if (this.OpenTimer <= 1f) {
        this.Open = false;
      }
      if (this.OpenTimer <= 0f) {
        this.Prompt.enabled = true;
      }
    } else if (!this.Smoke.isPlaying) {
      this.YandereHoldingEvidence = (this.Yandere.Ragdoll != null);
      if (!this.YandereHoldingEvidence) {
        if (this.Yandere.PickUp != null) {
          this.YandereHoldingEvidence = (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Garbage);
        } else {
          this.YandereHoldingEvidence = false;
        }
      }
      if (!this.YandereHoldingEvidence) {
        if (this.Yandere.EquippedWeapon != null) {
          this.YandereHoldingEvidence = this.Yandere.EquippedWeapon.Evidence;
        } else {
          this.YandereHoldingEvidence = false;
        }
      }
      if (!this.YandereHoldingEvidence) {
        if (!this.Prompt.HideButton[3]) {
          this.Prompt.HideButton[3] = true;
        }
      } else if (this.Prompt.HideButton[3]) {
        this.Prompt.HideButton[3] = false;
      }
      if (this.Ready) {
        if (!this.Smoke.isPlaying) {
          if (this.Prompt.HideButton[0]) {
            this.Prompt.HideButton[0] = false;
          }
        } else if (!this.Prompt.HideButton[0]) {
          this.Prompt.HideButton[0] = true;
        }
      }
      if (!this.YandereHoldingEvidence && !this.Ready) {
        if (this.Prompt.enabled) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      } else if (!this.Prompt.enabled) {
        this.Prompt.enabled = true;
      }
    }
    if (this.Prompt.Circle[3].fillAmount == 0f) {
      Time.timeScale = 1f;
      if (this.Yandere.Ragdoll != null) {
        this.Yandere.Character.GetComponent<Animation>().CrossFade((!this.Yandere.Carrying) ? "f02_dragIdle_00" : "f02_carryIdleA_00");
        this.Yandere.YandereVision = false;
        this.Yandere.CanMove = false;
        this.Yandere.Dumping = true;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.Victims++;
        this.VictimList[this.Victims] = this.Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
        this.Open = true;
      }
      if (this.Yandere.PickUp != null) {
        if (this.Yandere.PickUp.BodyPart != null) {
          this.Limbs++;
          this.LimbList[this.Limbs] = this.Yandere.PickUp.GetComponent<BodyPartScript>().StudentID;
        }
        this.Yandere.PickUp.Incinerator = this;
        this.Yandere.PickUp.Dumped = true;
        this.Yandere.PickUp.Drop();
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.OpenTimer = 2f;
        this.Ready = true;
        this.Open = true;
      }
      WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
      if (equippedWeapon != null) {
        this.DestroyedEvidence++;
        this.EvidenceList[this.DestroyedEvidence] = equippedWeapon.WeaponID;
        equippedWeapon.Incinerator = this;
        equippedWeapon.Dumped = true;
        equippedWeapon.Drop();
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.OpenTimer = 2f;
        this.Ready = true;
        this.Open = true;
      }
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Panel.SetActive(true);
      this.Timer = 60f;
      component.clip = this.IncineratorActivate;
      component.Play();
      this.Flames.Play();
      this.Smoke.Play();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Yandere.Police.IncineratedWeapons += this.MurderWeapons;
      this.Yandere.Police.BloodyClothing -= this.BloodyClothing;
      this.Yandere.Police.BloodyWeapons -= this.MurderWeapons;
      this.Yandere.Police.BodyParts -= this.BodyParts;
      this.Yandere.Police.Corpses -= this.Corpses;
      if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1) {
        this.Yandere.Police.MurderScene = false;
      }
      if (this.Yandere.Police.Corpses == 0) {
        this.Yandere.Police.MurderScene = false;
      }
      this.BloodyClothing = 0;
      this.MurderWeapons = 0;
      this.BodyParts = 0;
      this.Corpses = 0;
    }
    if (this.Smoke.isPlaying) {
      this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
      this.FlameSound.volume += Time.deltaTime;
      this.Circle.fillAmount = 1f - this.Timer / 60f;
      if (this.Timer <= 0f) {
        this.Prompt.HideButton[0] = true;
        this.Prompt.enabled = true;
        this.Panel.SetActive(false);
        this.Ready = false;
        this.Flames.Stop();
        this.Smoke.Stop();
      }
    } else {
      this.FlameSound.volume -= Time.deltaTime;
    }
    if (this.Panel.activeInHierarchy) {
      float num = (float)Mathf.CeilToInt(this.Timer * 60f);
      float num2 = num / 60f;
      float num3 = num % 60f;
      this.TimeLabel.text = string.Format("{0:00}:{1:00}", num2, num3);
    }
  }

  // Token: 0x06000533 RID: 1331 RVA: 0x00048AE4 File Offset: 0x00046EE4
  public void SetVictimsMissing() {
    foreach (int studentID in this.CorpseList) {
      StudentGlobals.SetStudentMissing(studentID, true);
    }
  }

  // Token: 0x04000C43 RID: 3139
  public YandereScript Yandere;

  // Token: 0x04000C44 RID: 3140
  public PromptScript Prompt;

  // Token: 0x04000C45 RID: 3141
  public ClockScript Clock;

  // Token: 0x04000C46 RID: 3142
  public AudioClip IncineratorActivate;

  // Token: 0x04000C47 RID: 3143
  public AudioClip IncineratorClose;

  // Token: 0x04000C48 RID: 3144
  public AudioClip IncineratorOpen;

  // Token: 0x04000C49 RID: 3145
  public AudioSource FlameSound;

  // Token: 0x04000C4A RID: 3146
  public ParticleSystem Flames;

  // Token: 0x04000C4B RID: 3147
  public ParticleSystem Smoke;

  // Token: 0x04000C4C RID: 3148
  public Transform DumpPoint;

  // Token: 0x04000C4D RID: 3149
  public Transform RightDoor;

  // Token: 0x04000C4E RID: 3150
  public Transform LeftDoor;

  // Token: 0x04000C4F RID: 3151
  public GameObject Panel;

  // Token: 0x04000C50 RID: 3152
  public UILabel TimeLabel;

  // Token: 0x04000C51 RID: 3153
  public UISprite Circle;

  // Token: 0x04000C52 RID: 3154
  public bool YandereHoldingEvidence;

  // Token: 0x04000C53 RID: 3155
  public bool Ready;

  // Token: 0x04000C54 RID: 3156
  public bool Open;

  // Token: 0x04000C55 RID: 3157
  public int DestroyedEvidence;

  // Token: 0x04000C56 RID: 3158
  public int BloodyClothing;

  // Token: 0x04000C57 RID: 3159
  public int MurderWeapons;

  // Token: 0x04000C58 RID: 3160
  public int BodyParts;

  // Token: 0x04000C59 RID: 3161
  public int Corpses;

  // Token: 0x04000C5A RID: 3162
  public int Victims;

  // Token: 0x04000C5B RID: 3163
  public int Limbs;

  // Token: 0x04000C5C RID: 3164
  public float OpenTimer;

  // Token: 0x04000C5D RID: 3165
  public float Timer;

  // Token: 0x04000C5E RID: 3166
  public int[] EvidenceList;

  // Token: 0x04000C5F RID: 3167
  public int[] CorpseList;

  // Token: 0x04000C60 RID: 3168
  public int[] VictimList;

  // Token: 0x04000C61 RID: 3169
  public int[] LimbList;
}