using UnityEngine;

// Token: 0x02000216 RID: 534
public class WeaponScript : MonoBehaviour {

  // Token: 0x0600094B RID: 2379 RVA: 0x000A1CE0 File Offset: 0x000A00E0
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
    this.OriginalColor = this.Outline[0].color;
    if (this.StartLow) {
      this.OriginalOffset = this.Prompt.OffsetY[3];
      this.Prompt.OffsetY[3] = 0.2f;
    }
    if (this.DisableCollider) {
      this.MyCollider.enabled = false;
    }
    AudioSource component = base.GetComponent<AudioSource>();
    if (component != null) {
      this.OriginalClip = component.clip;
    }
    base.GetComponent<Rigidbody>().isKinematic = true;
  }

  // Token: 0x0600094C RID: 2380 RVA: 0x000A1DA0 File Offset: 0x000A01A0
  public string GetTypePrefix() {
    if (this.Type == WeaponType.Knife) {
      return "knife";
    }
    if (this.Type == WeaponType.Katana) {
      return "katana";
    }
    if (this.Type == WeaponType.Bat) {
      return "bat";
    }
    if (this.Type == WeaponType.Saw) {
      return "saw";
    }
    if (this.Type == WeaponType.Syringe) {
      return "syringe";
    }
    Debug.LogError("Weapon type \"" + this.Type.ToString() + "\" not implemented.");
    return string.Empty;
  }

  // Token: 0x0600094D RID: 2381 RVA: 0x000A1E34 File Offset: 0x000A0234
  public AudioClip GetClip(float sanity, bool stealth) {
    AudioClip[] array;
    if (this.Clips2.Length == 0) {
      array = this.Clips;
    } else {
      int num = UnityEngine.Random.Range(2, 4);
      array = ((num != 2) ? this.Clips3 : this.Clips2);
    }
    if (stealth) {
      return array[0];
    }
    if (sanity > 0.6666667f) {
      return array[1];
    }
    if (sanity > 0.333333343f) {
      return array[2];
    }
    return array[3];
  }

  // Token: 0x0600094E RID: 2382 RVA: 0x000A1EA8 File Offset: 0x000A02A8
  private void Update() {
    if (this.Dismembering) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.DismemberPhase < 4) {
        if (component.time > 0.75f) {
          if (this.Speed < 36f) {
            this.Speed += Time.deltaTime + 10f;
          }
          this.Rotation += this.Speed;
          this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
        }
        if (component.time > this.SoundTime[this.DismemberPhase]) {
          this.Yandere.Sanity -= 5f * this.Yandere.Numbness;
          this.Yandere.Bloodiness += 25f;
          this.ShortBloodSpray[0].Play();
          this.ShortBloodSpray[1].Play();
          this.Blood.enabled = true;
          this.DismemberPhase++;
        }
      } else {
        this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 2f);
        this.Blade.localEulerAngles = new Vector3(this.Rotation, this.Blade.localEulerAngles.y, this.Blade.localEulerAngles.z);
        if (!component.isPlaying) {
          component.clip = this.OriginalClip;
          this.Yandere.StainWeapon();
          this.Dismembering = false;
          this.DismemberPhase = 0;
          this.Rotation = 0f;
          this.Speed = 0f;
        }
      }
    } else if (this.Yandere.EquippedWeapon == this) {
      if (this.Yandere.AttackManager.IsAttacking()) {
        if (this.Type == WeaponType.Knife) {
          base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Mathf.Lerp(base.transform.localEulerAngles.y, (!this.Flip) ? 0f : 180f, Time.deltaTime * 10f), base.transform.localEulerAngles.z);
        } else if (this.Type == WeaponType.Saw && this.Spin) {
          this.Blade.transform.localEulerAngles = new Vector3(this.Blade.transform.localEulerAngles.x + Time.deltaTime * 360f, this.Blade.transform.localEulerAngles.y, this.Blade.transform.localEulerAngles.z);
        }
      }
    } else {
      Rigidbody component2 = base.GetComponent<Rigidbody>();
      if (!component2.isKinematic) {
        this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
        if (this.KinematicTimer == 5f) {
          component2.isKinematic = true;
          this.KinematicTimer = 0f;
        }
      }
      if (base.transform.position.x > -89f && base.transform.position.x < -79f && base.transform.position.z > -13.5f && base.transform.position.z < -3.5f) {
        base.transform.position = new Vector3(-80.75f, 1f, -2.75f);
      }
      if (base.transform.position.x > -21f && base.transform.position.x < 21f && base.transform.position.z > 79f && base.transform.position.z < 121f) {
        base.transform.position = new Vector3(0f, 1f, 79f);
      }
    }
  }

  // Token: 0x0600094F RID: 2383 RVA: 0x000A2348 File Offset: 0x000A0748
  private void LateUpdate() {
    if (this.Prompt.Circle[3].fillAmount == 0f) {
      this.Prompt.Circle[3].fillAmount = 1f;
      if (this.Prompt.Suspicious) {
        this.Yandere.TheftTimer = 1f;
      }
      if (!this.Yandere.Gloved) {
        this.FingerprintID = 100;
      }
      this.ID = 0;
      while (this.ID < this.Outline.Length) {
        this.Outline[this.ID].color = new Color(0f, 0f, 0f, 1f);
        this.ID++;
      }
      base.transform.parent = this.Yandere.ItemParent;
      base.transform.localPosition = Vector3.zero;
      base.transform.localEulerAngles = Vector3.zero;
      this.MyCollider.enabled = false;
      base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
      if (this.Yandere.Equipped == 3) {
        this.Yandere.Weapon[3].Drop();
      }
      if (this.Yandere.PickUp != null) {
        this.Yandere.PickUp.Drop();
      }
      if (this.Yandere.Dragging) {
        this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
      }
      if (this.Yandere.Carrying) {
        this.Yandere.StopCarrying();
      }
      if (this.Concealable) {
        if (this.Yandere.Weapon[1] == null) {
          if (this.Yandere.Weapon[2] != null) {
            this.Yandere.Weapon[2].gameObject.SetActive(false);
          }
          this.Yandere.Equipped = 1;
          this.Yandere.EquippedWeapon = this;
        } else if (this.Yandere.Weapon[2] == null) {
          if (this.Yandere.Weapon[1] != null) {
            this.Yandere.Weapon[1].gameObject.SetActive(false);
          }
          this.Yandere.Equipped = 2;
          this.Yandere.EquippedWeapon = this;
        } else if (this.Yandere.Weapon[2].gameObject.activeInHierarchy) {
          this.Yandere.Weapon[2].Drop();
          this.Yandere.Equipped = 2;
          this.Yandere.EquippedWeapon = this;
        } else {
          this.Yandere.Weapon[1].Drop();
          this.Yandere.Equipped = 1;
          this.Yandere.EquippedWeapon = this;
        }
      } else {
        if (this.Yandere.Weapon[1] != null) {
          this.Yandere.Weapon[1].gameObject.SetActive(false);
        }
        if (this.Yandere.Weapon[2] != null) {
          this.Yandere.Weapon[2].gameObject.SetActive(false);
        }
        this.Yandere.Equipped = 3;
        this.Yandere.EquippedWeapon = this;
      }
      this.Yandere.StudentManager.UpdateStudents();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Yandere.NearestPrompt = null;
      if (this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12) {
        this.SuspicionCheck();
      }
      if (this.Yandere.EquippedWeapon.Suspicious) {
        if (!this.Yandere.WeaponWarning) {
          this.Yandere.NotificationManager.DisplayNotification(NotificationType.Armed);
          this.Yandere.WeaponWarning = true;
        }
      } else {
        this.Yandere.WeaponWarning = false;
      }
      this.Yandere.WeaponMenu.UpdateSprites();
      this.Yandere.WeaponManager.UpdateLabels();
      if (this.Evidence) {
        this.Yandere.Police.BloodyWeapons--;
      }
      if (this.WeaponID == 11) {
        this.Yandere.IdleAnim = "CyborgNinja_Idle_Armed";
        this.Yandere.WalkAnim = "CyborgNinja_Walk_Armed";
        this.Yandere.RunAnim = "CyborgNinja_Run_Armed";
      }
      this.KinematicTimer = 0f;
      AudioSource.PlayClipAtPoint(this.EquipClip, Camera.main.transform.position);
    }
    if (this.Yandere.EquippedWeapon == this && this.Yandere.Armed) {
      base.transform.localScale = new Vector3(1f, 1f, 1f);
      if (!this.Yandere.Struggling) {
        if (this.Yandere.CanMove) {
          base.transform.localPosition = Vector3.zero;
          base.transform.localEulerAngles = Vector3.zero;
        }
      } else {
        base.transform.localPosition = new Vector3(-0.01f, 0.005f, -0.01f);
      }
    }
    if (this.Dumped) {
      this.DumpTimer += Time.deltaTime;
      if (this.DumpTimer > 1f) {
        this.Yandere.Incinerator.MurderWeapons++;
        UnityEngine.Object.Destroy(base.gameObject);
      }
    }
    if (base.transform.parent == this.Yandere.ItemParent && this.Concealable && this.Yandere.Weapon[1] != this && this.Yandere.Weapon[2] != this) {
      this.Drop();
    }
  }

  // Token: 0x06000950 RID: 2384 RVA: 0x000A296C File Offset: 0x000A0D6C
  public void Drop() {
    if (this.WeaponID == 11) {
      this.Yandere.IdleAnim = "CyborgNinja_Idle_Unarmed";
      this.Yandere.WalkAnim = this.Yandere.OriginalWalkAnim;
      this.Yandere.RunAnim = "CyborgNinja_Run_Unarmed";
    }
    if (this.StartLow) {
      this.Prompt.OffsetY[3] = this.OriginalOffset;
    }
    this.Yandere.EquippedWeapon = null;
    this.Yandere.Equipped = 0;
    this.Yandere.StudentManager.UpdateStudents();
    base.gameObject.SetActive(true);
    base.transform.parent = null;
    Rigidbody component = base.GetComponent<Rigidbody>();
    component.constraints = RigidbodyConstraints.None;
    component.isKinematic = false;
    component.useGravity = true;
    if (this.Dumped) {
      base.transform.position = this.Incinerator.DumpPoint.position;
    } else {
      this.Prompt.enabled = true;
      this.MyCollider.enabled = true;
      if (this.Yandere.GetComponent<Collider>().enabled) {
        Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), this.MyCollider);
      }
    }
    if (this.Evidence) {
      this.Yandere.Police.BloodyWeapons++;
    }
    this.ID = 0;
    while (this.ID < this.Outline.Length) {
      this.Outline[this.ID].color = ((!this.Evidence) ? this.OriginalColor : this.EvidenceColor);
      this.ID++;
    }
    if (base.transform.position.y > 1000f) {
      base.transform.position = new Vector3(12f, 0f, 28f);
    }
  }

  // Token: 0x06000951 RID: 2385 RVA: 0x000A2B60 File Offset: 0x000A0F60
  public void UpdateLabel() {
    if (this != null && base.gameObject.activeInHierarchy) {
      if (this.Yandere.Weapon[1] != null && this.Yandere.Weapon[2] != null && this.Concealable) {
        if (this.Prompt.Label[3] != null) {
          if (!this.Yandere.Armed || this.Yandere.Equipped == 3) {
            this.Prompt.Label[3].text = "     Swap " + this.Yandere.Weapon[1].Name + " for " + this.Name;
          } else {
            this.Prompt.Label[3].text = "     Swap " + this.Yandere.EquippedWeapon.Name + " for " + this.Name;
          }
        }
      } else if (this.Prompt.Label[3] != null) {
        this.Prompt.Label[3].text = "     " + this.Name;
      }
    }
  }

  // Token: 0x06000952 RID: 2386 RVA: 0x000A2CB4 File Offset: 0x000A10B4
  public void Effect() {
    if (this.WeaponID == 7) {
      this.BloodSpray[0].Play();
      this.BloodSpray[1].Play();
    } else if (this.WeaponID == 8) {
      base.gameObject.GetComponent<ParticleSystem>().Play();
      base.GetComponent<AudioSource>().clip = this.OriginalClip;
      base.GetComponent<AudioSource>().Play();
    } else if (this.WeaponID == 2 || this.WeaponID == 9 || this.WeaponID == 10 || this.WeaponID == 12 || this.WeaponID == 13) {
      base.GetComponent<AudioSource>().Play();
    } else if (this.WeaponID == 14) {
      UnityEngine.Object.Instantiate<GameObject>(this.HeartBurst, this.Yandere.TargetStudent.Head.position, Quaternion.identity);
      base.GetComponent<AudioSource>().Play();
    }
  }

  // Token: 0x06000953 RID: 2387 RVA: 0x000A2DB8 File Offset: 0x000A11B8
  public void Dismember() {
    AudioSource component = base.GetComponent<AudioSource>();
    component.clip = this.DismemberClip;
    component.Play();
    this.Dismembering = true;
  }

  // Token: 0x06000954 RID: 2388 RVA: 0x000A2DE8 File Offset: 0x000A11E8
  public void SuspicionCheck() {
    if ((this.WeaponID == 9 && ClubGlobals.Club == ClubType.Sports) || (this.WeaponID == 10 && ClubGlobals.Club == ClubType.Gardening) || (this.WeaponID == 12 && ClubGlobals.Club == ClubType.Sports)) {
      this.Suspicious = false;
    } else {
      this.Suspicious = true;
    }
  }

  // Token: 0x04001A83 RID: 6787
  public ParticleSystem[] ShortBloodSpray;

  // Token: 0x04001A84 RID: 6788
  public ParticleSystem[] BloodSpray;

  // Token: 0x04001A85 RID: 6789
  public OutlineScript[] Outline;

  // Token: 0x04001A86 RID: 6790
  public float[] SoundTime;

  // Token: 0x04001A87 RID: 6791
  public IncineratorScript Incinerator;

  // Token: 0x04001A88 RID: 6792
  public YandereScript Yandere;

  // Token: 0x04001A89 RID: 6793
  public PromptScript Prompt;

  // Token: 0x04001A8A RID: 6794
  public AudioClip[] Clips;

  // Token: 0x04001A8B RID: 6795
  public AudioClip[] Clips2;

  // Token: 0x04001A8C RID: 6796
  public AudioClip[] Clips3;

  // Token: 0x04001A8D RID: 6797
  public AudioClip DismemberClip;

  // Token: 0x04001A8E RID: 6798
  public AudioClip EquipClip;

  // Token: 0x04001A8F RID: 6799
  public ParticleSystem FireEffect;

  // Token: 0x04001A90 RID: 6800
  public AudioSource FireAudio;

  // Token: 0x04001A91 RID: 6801
  public Collider MyCollider;

  // Token: 0x04001A92 RID: 6802
  public Renderer MyRenderer;

  // Token: 0x04001A93 RID: 6803
  public Transform Blade;

  // Token: 0x04001A94 RID: 6804
  public Projector Blood;

  // Token: 0x04001A95 RID: 6805
  public bool DisableCollider;

  // Token: 0x04001A96 RID: 6806
  public bool Dismembering;

  // Token: 0x04001A97 RID: 6807
  public bool WeaponEffect;

  // Token: 0x04001A98 RID: 6808
  public bool Concealable;

  // Token: 0x04001A99 RID: 6809
  public bool Suspicious;

  // Token: 0x04001A9A RID: 6810
  public bool Evidence;

  // Token: 0x04001A9B RID: 6811
  public bool StartLow;

  // Token: 0x04001A9C RID: 6812
  public bool Flaming;

  // Token: 0x04001A9D RID: 6813
  public bool Bloody;

  // Token: 0x04001A9E RID: 6814
  public bool Dumped;

  // Token: 0x04001A9F RID: 6815
  public bool Heated;

  // Token: 0x04001AA0 RID: 6816
  public bool Metal;

  // Token: 0x04001AA1 RID: 6817
  public bool Flip;

  // Token: 0x04001AA2 RID: 6818
  public bool Spin;

  // Token: 0x04001AA3 RID: 6819
  public Color EvidenceColor;

  // Token: 0x04001AA4 RID: 6820
  public Color OriginalColor;

  // Token: 0x04001AA5 RID: 6821
  public float OriginalOffset;

  // Token: 0x04001AA6 RID: 6822
  public float KinematicTimer;

  // Token: 0x04001AA7 RID: 6823
  public float DumpTimer;

  // Token: 0x04001AA8 RID: 6824
  public float Rotation;

  // Token: 0x04001AA9 RID: 6825
  public float Speed;

  // Token: 0x04001AAA RID: 6826
  public string SpriteName;

  // Token: 0x04001AAB RID: 6827
  public string Name;

  // Token: 0x04001AAC RID: 6828
  public int DismemberPhase;

  // Token: 0x04001AAD RID: 6829
  public int FingerprintID;

  // Token: 0x04001AAE RID: 6830
  public int WeaponID;

  // Token: 0x04001AAF RID: 6831
  public int AnimID;

  // Token: 0x04001AB0 RID: 6832
  public WeaponType Type = WeaponType.Knife;

  // Token: 0x04001AB1 RID: 6833
  public bool[] Victims;

  // Token: 0x04001AB2 RID: 6834
  private AudioClip OriginalClip;

  // Token: 0x04001AB3 RID: 6835
  private int ID;

  // Token: 0x04001AB4 RID: 6836
  public GameObject HeartBurst;
}