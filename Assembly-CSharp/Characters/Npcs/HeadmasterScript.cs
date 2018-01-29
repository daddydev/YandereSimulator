using UnityEngine;

// Token: 0x020000EE RID: 238
public class HeadmasterScript : MonoBehaviour {

  // Token: 0x060004C5 RID: 1221 RVA: 0x0003DBCD File Offset: 0x0003BFCD
  private void Start() {
    this.MyAnimation["HeadmasterRaiseTazer"].speed = 2f;
    this.Tazer.SetActive(false);
  }

  // Token: 0x060004C6 RID: 1222 RVA: 0x0003DBF8 File Offset: 0x0003BFF8
  private void Update() {
    if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f && this.Yandere.transform.position.x < 6f && this.Yandere.transform.position.x > -6f) {
      this.Distance = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
      if (this.Shooting) {
        this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.AimWeaponAtYandere();
        this.AimBodyAtYandere();
      } else if ((double)this.Distance < 1.2) {
        this.AimBodyAtYandere();
        if (this.Yandere.CanMove && !this.Shooting) {
          this.Shoot();
        }
      } else if ((double)this.Distance < 2.8) {
        this.PlayedSitSound = false;
        this.PatienceTimer -= Time.deltaTime;
        if (this.PatienceTimer < 0f) {
          this.LostPatience = true;
          this.PatienceTimer = 60f;
          this.Patience = 0;
          this.Shoot();
        }
        if (!this.LostPatience) {
          this.LostPatience = true;
          this.Patience--;
          if (this.Patience < 1 && !this.Shooting) {
            this.Shoot();
          }
        }
        this.AimBodyAtYandere();
        this.Threatened = true;
        this.AimWeaponAtYandere();
        this.ThreatTimer = Mathf.MoveTowards(this.ThreatTimer, 0f, Time.deltaTime);
        if (this.ThreatTimer == 0f) {
          this.ThreatID++;
          if (this.ThreatID < 5) {
            this.HeadmasterSubtitle.text = this.HeadmasterThreatText[this.ThreatID];
            this.MyAudio.clip = this.HeadmasterThreatClips[this.ThreatID];
            this.MyAudio.Play();
            this.ThreatTimer = this.HeadmasterThreatClips[this.ThreatID].length + 1f;
          }
        }
        this.CheckBehavior();
      } else if (this.Distance < 10f) {
        this.PlayedStandSound = false;
        this.LostPatience = false;
        this.targetRotation = Quaternion.LookRotation(new Vector3(0f, 8f, 0f) - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -4.66666f), Time.deltaTime * 1f);
        this.LookAtPlayer = true;
        if (!this.Threatened) {
          this.MyAnimation.CrossFade("HeadmasterAttention", 1f);
          this.ScratchTimer = 0f;
          this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
          if (this.SpeechTimer == 0f) {
            if (this.CardboardBox.parent == null && this.Yandere.Mask == null) {
              this.VoiceID++;
              if (this.VoiceID < 6) {
                this.HeadmasterSubtitle.text = this.HeadmasterSpeechText[this.VoiceID];
                this.MyAudio.clip = this.HeadmasterSpeechClips[this.VoiceID];
                this.MyAudio.Play();
                this.SpeechTimer = this.HeadmasterSpeechClips[this.VoiceID].length + 1f;
              }
            } else {
              this.BoxID++;
              if (this.BoxID < 6) {
                this.HeadmasterSubtitle.text = this.HeadmasterBoxText[this.BoxID];
                this.MyAudio.clip = this.HeadmasterBoxClips[this.BoxID];
                this.MyAudio.Play();
                this.SpeechTimer = this.HeadmasterBoxClips[this.BoxID].length + 1f;
              }
            }
          }
        } else if (!this.Relaxing) {
          this.HeadmasterSubtitle.text = this.HeadmasterRelaxText;
          this.MyAudio.clip = this.HeadmasterRelaxClip;
          this.MyAudio.Play();
          this.Relaxing = true;
        } else {
          if (!this.PlayedSitSound) {
            AudioSource.PlayClipAtPoint(this.SitDown, base.transform.position);
            this.PlayedSitSound = true;
          }
          this.MyAnimation.CrossFade("HeadmasterLowerTazer");
          this.Aiming = false;
          if ((double)this.MyAnimation["HeadmasterLowerTazer"].time > 1.33333) {
            this.Tazer.SetActive(false);
          }
          if (this.MyAnimation["HeadmasterLowerTazer"].time > this.MyAnimation["HeadmasterLowerTazer"].length) {
            this.Threatened = false;
            this.Relaxing = false;
          }
        }
        this.CheckBehavior();
      } else {
        if (this.LookAtPlayer) {
          this.MyAnimation.CrossFade("HeadmasterType");
          this.LookAtPlayer = false;
          this.Threatened = false;
          this.Relaxing = false;
          this.Aiming = false;
        }
        this.ScratchTimer += Time.deltaTime;
        if (this.ScratchTimer > 10f) {
          this.MyAnimation.CrossFade("HeadmasterScratch");
          if (this.MyAnimation["HeadmasterScratch"].time > this.MyAnimation["HeadmasterScratch"].length) {
            this.MyAnimation.CrossFade("HeadmasterType");
            this.ScratchTimer = 0f;
          }
        }
      }
      if (!this.MyAudio.isPlaying) {
        this.HeadmasterSubtitle.text = string.Empty;
        if (this.Shooting) {
          UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.TazerEffectTarget.position, Quaternion.identity);
          UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.Yandere.Spine[3].position, Quaternion.identity);
          this.MyAudio.clip = this.HeadmasterShockClip;
          this.MyAudio.Play();
          this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_swingB_00");
          this.Yandere.Character.GetComponent<Animation>()["f02_swingB_00"].time = 0.5f;
          this.Yandere.RPGCamera.enabled = false;
          this.Yandere.Attacked = true;
          this.Heartbroken.Headmaster = true;
          this.Jukebox.Volume = 0f;
          this.Shooting = false;
        }
      }
      if (this.Yandere.Attacked && this.Yandere.Character.GetComponent<Animation>()["f02_swingB_00"].time >= this.Yandere.Character.GetComponent<Animation>()["f02_swingB_00"].length * 0.85f) {
        this.MyAudio.clip = this.Crumple;
        this.MyAudio.Play();
        base.enabled = false;
      }
    } else {
      this.HeadmasterSubtitle.text = string.Empty;
    }
  }

  // Token: 0x060004C7 RID: 1223 RVA: 0x0003E480 File Offset: 0x0003C880
  private void LateUpdate() {
    this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, (!this.LookAtPlayer) ? this.Default.position : this.Yandere.Head.position, Time.deltaTime * 1f);
    this.Head.LookAt(this.LookAtTarget);
  }

  // Token: 0x060004C8 RID: 1224 RVA: 0x0003E4E8 File Offset: 0x0003C8E8
  private void AimBodyAtYandere() {
    this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
    base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
    this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -5.2f), Time.deltaTime * 1f);
  }

  // Token: 0x060004C9 RID: 1225 RVA: 0x0003E5A4 File Offset: 0x0003C9A4
  private void AimWeaponAtYandere() {
    if (!this.Aiming) {
      this.MyAnimation.CrossFade("HeadmasterRaiseTazer");
      if (!this.PlayedStandSound) {
        AudioSource.PlayClipAtPoint(this.StandUp, base.transform.position);
        this.PlayedStandSound = true;
      }
      if ((double)this.MyAnimation["HeadmasterRaiseTazer"].time > 1.166666) {
        this.Tazer.SetActive(true);
        this.Aiming = true;
      }
    } else if (this.MyAnimation["HeadmasterRaiseTazer"].time > this.MyAnimation["HeadmasterRaiseTazer"].length) {
      this.MyAnimation.CrossFade("HeadmasterAimTazer");
    }
  }

  // Token: 0x060004CA RID: 1226 RVA: 0x0003E670 File Offset: 0x0003CA70
  private void Shoot() {
    this.StudentManager.YandereDying = true;
    this.Yandere.StopAiming();
    this.Yandere.StopLaughing();
    this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
    if (this.Patience < 1) {
      this.HeadmasterSubtitle.text = this.HeadmasterPatienceText;
      this.MyAudio.clip = this.HeadmasterPatienceClip;
    } else if (this.Yandere.Armed) {
      this.HeadmasterSubtitle.text = this.HeadmasterWeaponText;
      this.MyAudio.clip = this.HeadmasterWeaponClip;
    } else if (this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart)) {
      this.HeadmasterSubtitle.text = this.HeadmasterCorpseText;
      this.MyAudio.clip = this.HeadmasterCorpseClip;
    } else {
      this.HeadmasterSubtitle.text = this.HeadmasterAttackText;
      this.MyAudio.clip = this.HeadmasterAttackClip;
    }
    this.StudentManager.StopMoving();
    this.Yandere.EmptyHands();
    this.Yandere.CanMove = false;
    this.MyAudio.Play();
    this.Shooting = true;
  }

  // Token: 0x060004CB RID: 1227 RVA: 0x0003E7EC File Offset: 0x0003CBEC
  private void CheckBehavior() {
    if (this.Yandere.CanMove) {
      if (this.Yandere.Chased) {
        if (!this.Shooting) {
          this.Shoot();
        }
      } else if (this.Yandere.Armed) {
        if (!this.Shooting) {
          this.Shoot();
        }
      } else if ((this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart)) && !this.Shooting) {
        this.Shoot();
      }
    }
  }

  // Token: 0x04000A88 RID: 2696
  public StudentManagerScript StudentManager;

  // Token: 0x04000A89 RID: 2697
  public HeartbrokenScript Heartbroken;

  // Token: 0x04000A8A RID: 2698
  public YandereScript Yandere;

  // Token: 0x04000A8B RID: 2699
  public JukeboxScript Jukebox;

  // Token: 0x04000A8C RID: 2700
  public AudioClip[] HeadmasterSpeechClips;

  // Token: 0x04000A8D RID: 2701
  public AudioClip[] HeadmasterThreatClips;

  // Token: 0x04000A8E RID: 2702
  public AudioClip[] HeadmasterBoxClips;

  // Token: 0x04000A8F RID: 2703
  public AudioClip HeadmasterRelaxClip;

  // Token: 0x04000A90 RID: 2704
  public AudioClip HeadmasterAttackClip;

  // Token: 0x04000A91 RID: 2705
  public AudioClip HeadmasterCrypticClip;

  // Token: 0x04000A92 RID: 2706
  public AudioClip HeadmasterShockClip;

  // Token: 0x04000A93 RID: 2707
  public AudioClip HeadmasterPatienceClip;

  // Token: 0x04000A94 RID: 2708
  public AudioClip HeadmasterCorpseClip;

  // Token: 0x04000A95 RID: 2709
  public AudioClip HeadmasterWeaponClip;

  // Token: 0x04000A96 RID: 2710
  public AudioClip Crumple;

  // Token: 0x04000A97 RID: 2711
  public AudioClip StandUp;

  // Token: 0x04000A98 RID: 2712
  public AudioClip SitDown;

  // Token: 0x04000A99 RID: 2713
  public readonly string[] HeadmasterSpeechText = new string[]
  {
    string.Empty,
    "Ahh...! It's...it's you!",
    "No, that would be impossible...you must be...her daughter...",
    "I'll tolerate you in my school, but not in my office.",
    "Leave at once.",
    "There is nothing for you to achieve here. Just. Get. Out."
  };

  // Token: 0x04000A9A RID: 2714
  public readonly string[] HeadmasterThreatText = new string[]
  {
    string.Empty,
    "Not another step!",
    "You're up to no good! I know it!",
    "I'm not going to let you harm me!",
    "I'll use self-defense if I deem it necessary!",
    "This is your final warning. Get out of here...or else."
  };

  // Token: 0x04000A9B RID: 2715
  public readonly string[] HeadmasterBoxText = new string[]
  {
    string.Empty,
    "What...in...blazes are you doing?",
    "Are you trying to re-enact something you saw in a video game?",
    "Ugh, do you really think such a stupid ploy is going to work?",
    "I know who you are. It's obvious. You're not fooling anyone.",
    "I don't have time for this tomfoolery. Leave at once!"
  };

  // Token: 0x04000A9C RID: 2716
  public readonly string HeadmasterRelaxText = "Hmm...a wise decision.";

  // Token: 0x04000A9D RID: 2717
  public readonly string HeadmasterAttackText = "You asked for it!";

  // Token: 0x04000A9E RID: 2718
  public readonly string HeadmasterCrypticText = "Mr. Saikou...the deal is off.";

  // Token: 0x04000A9F RID: 2719
  public readonly string HeadmasterWeaponText = "How dare you raise a weapon in my office!";

  // Token: 0x04000AA0 RID: 2720
  public readonly string HeadmasterPatienceText = "Enough of this nonsense!";

  // Token: 0x04000AA1 RID: 2721
  public readonly string HeadmasterCorpseText = "You...you murderer!";

  // Token: 0x04000AA2 RID: 2722
  public UILabel HeadmasterSubtitle;

  // Token: 0x04000AA3 RID: 2723
  public Animation MyAnimation;

  // Token: 0x04000AA4 RID: 2724
  public AudioSource MyAudio;

  // Token: 0x04000AA5 RID: 2725
  public GameObject LightningEffect;

  // Token: 0x04000AA6 RID: 2726
  public GameObject Tazer;

  // Token: 0x04000AA7 RID: 2727
  public Transform TazerEffectTarget;

  // Token: 0x04000AA8 RID: 2728
  public Transform CardboardBox;

  // Token: 0x04000AA9 RID: 2729
  public Transform Chair;

  // Token: 0x04000AAA RID: 2730
  public Quaternion targetRotation;

  // Token: 0x04000AAB RID: 2731
  public float PatienceTimer;

  // Token: 0x04000AAC RID: 2732
  public float ScratchTimer;

  // Token: 0x04000AAD RID: 2733
  public float SpeechTimer;

  // Token: 0x04000AAE RID: 2734
  public float ThreatTimer;

  // Token: 0x04000AAF RID: 2735
  public float Distance;

  // Token: 0x04000AB0 RID: 2736
  public int Patience = 10;

  // Token: 0x04000AB1 RID: 2737
  public int ThreatID;

  // Token: 0x04000AB2 RID: 2738
  public int VoiceID;

  // Token: 0x04000AB3 RID: 2739
  public int BoxID;

  // Token: 0x04000AB4 RID: 2740
  public bool PlayedStandSound;

  // Token: 0x04000AB5 RID: 2741
  public bool PlayedSitSound;

  // Token: 0x04000AB6 RID: 2742
  public bool LostPatience;

  // Token: 0x04000AB7 RID: 2743
  public bool Threatened;

  // Token: 0x04000AB8 RID: 2744
  public bool Relaxing;

  // Token: 0x04000AB9 RID: 2745
  public bool Shooting;

  // Token: 0x04000ABA RID: 2746
  public bool Aiming;

  // Token: 0x04000ABB RID: 2747
  public Vector3 LookAtTarget;

  // Token: 0x04000ABC RID: 2748
  public bool LookAtPlayer;

  // Token: 0x04000ABD RID: 2749
  public Transform Default;

  // Token: 0x04000ABE RID: 2750
  public Transform Head;
}