using UnityEngine;

// Token: 0x02000038 RID: 56
public class AttackManagerScript : MonoBehaviour {

  // Token: 0x060000CC RID: 204 RVA: 0x0000E318 File Offset: 0x0000C718
  private void Awake() {
    this.Yandere = base.GetComponent<YandereScript>();
  }

  // Token: 0x060000CD RID: 205 RVA: 0x0000E326 File Offset: 0x0000C726
  private void Start() {
    this.OriginalBloodEffect = this.BloodEffect;
  }

  // Token: 0x060000CE RID: 206 RVA: 0x0000E334 File Offset: 0x0000C734
  public bool IsAttacking() {
    return this.Victim != null;
  }

  // Token: 0x060000CF RID: 207 RVA: 0x0000E344 File Offset: 0x0000C744
  private float GetReachDistance(WeaponType weaponType, SanityType sanityType) {
    if (weaponType == WeaponType.Knife) {
      if (this.Stealth) {
        return 0.75f;
      }
      if (sanityType == SanityType.High) {
        return 1f;
      }
      if (sanityType == SanityType.Medium) {
        return 0.75f;
      }
      return 0.5f;
    } else {
      if (weaponType == WeaponType.Katana) {
        return (!this.Stealth) ? 1f : 0.5f;
      }
      if (weaponType == WeaponType.Bat) {
        if (this.Stealth) {
          return 0.5f;
        }
        if (sanityType == SanityType.High) {
          return 0.75f;
        }
        if (sanityType == SanityType.Medium) {
          return 1f;
        }
        return 1f;
      } else {
        if (weaponType == WeaponType.Saw) {
          return (!this.Stealth) ? 1f : 0.7f;
        }
        if (weaponType == WeaponType.Syringe) {
          return 0.5f;
        }
        Debug.LogError("Weapon type \"" + weaponType.ToString() + "\" not implemented.");
        return 0f;
      }
    }
  }

  // Token: 0x060000D0 RID: 208 RVA: 0x0000E438 File Offset: 0x0000C838
  public void Attack(GameObject victim, WeaponScript weapon) {
    this.Victim = victim;
    this.Yandere.FollowHips = true;
    this.AttackTimer = 0f;
    this.EffectPhase = 0;
    this.Yandere.Sanity = Mathf.Clamp(this.Yandere.Sanity, 0f, 100f);
    SanityType sanityType = this.Yandere.SanityType;
    string sanityString = this.Yandere.GetSanityString(sanityType);
    string typePrefix = weapon.GetTypePrefix();
    string str = (!this.Yandere.TargetStudent.Male) ? "f02_" : string.Empty;
    if (!this.Stealth) {
      this.AnimName = "f02_" + typePrefix + sanityString + "SanityA_00";
      this.VictimAnimName = str + typePrefix + sanityString + "SanityB_00";
    } else {
      this.AnimName = "f02_" + typePrefix + "StealthA_00";
      this.VictimAnimName = str + typePrefix + "StealthB_00";
    }
    Animation component = this.Yandere.Character.GetComponent<Animation>();
    component[this.AnimName].time = 0f;
    component.CrossFade(this.AnimName);
    Animation component2 = this.Victim.GetComponent<Animation>();
    component2[this.VictimAnimName].time = 0f;
    component2.CrossFade(this.VictimAnimName);
    AudioSource component3 = weapon.gameObject.GetComponent<AudioSource>();
    component3.clip = weapon.GetClip(this.Yandere.Sanity / 100f, this.Stealth);
    component3.time = 0f;
    component3.Play();
    if (weapon.Type == WeaponType.Knife) {
      weapon.Flip = true;
    }
    this.Distance = this.GetReachDistance(weapon.Type, sanityType);
  }

  // Token: 0x060000D1 RID: 209 RVA: 0x0000E608 File Offset: 0x0000CA08
  private void Update() {
    if (this.IsAttacking()) {
      this.AttackTimer += Time.deltaTime;
      WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
      SanityType sanityType = this.Yandere.SanityType;
      this.SpecialEffect(equippedWeapon, sanityType);
      if (sanityType == SanityType.Low && !this.Yandere.Chased) {
        this.LoopCheck(equippedWeapon);
      }
      this.SpecialEffect(equippedWeapon, sanityType);
      Animation component = this.Yandere.Character.GetComponent<Animation>();
      if (component[this.AnimName].time > component[this.AnimName].length - 0.333333343f) {
        component.CrossFade("f02_idle_00");
        equippedWeapon.Flip = false;
      }
      if (this.AttackTimer > component[this.AnimName].length) {
        if (this.Yandere.TargetStudent == this.Yandere.StudentManager.Reporter) {
          this.Yandere.StudentManager.Reporter = null;
        }
        if (!this.Yandere.CanTranq) {
          this.Yandere.TargetStudent.DeathType = DeathType.Weapon;
        } else {
          this.Yandere.TargetStudent.Tranquil = true;
          this.Yandere.CanTranq = false;
          this.Yandere.Followers--;
          equippedWeapon.Type = WeaponType.Knife;
        }
        this.Yandere.TargetStudent.DeathCause = equippedWeapon.WeaponID;
        this.Yandere.TargetStudent.BecomeRagdoll();
        this.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped != 10) ? 20f : 10f) * this.Yandere.Numbness;
        this.Yandere.Attacking = false;
        this.Yandere.FollowHips = false;
        this.Yandere.MyController.radius = 0.2f;
        this.Yandere.EquippedWeapon.Evidence = true;
        this.Victim = null;
        this.VictimAnimName = null;
        this.AnimName = null;
        this.Stealth = false;
        this.EffectPhase = 0;
        this.AttackTimer = 0f;
        this.Timer = 0f;
        this.CheckForSpecialCase(equippedWeapon);
        if (!this.Yandere.Noticed) {
          this.Yandere.CanMove = true;
        } else {
          equippedWeapon.Drop();
        }
      }
    }
  }

  // Token: 0x060000D2 RID: 210 RVA: 0x0000E87C File Offset: 0x0000CC7C
  private void SpecialEffect(WeaponScript weapon, SanityType sanityType) {
    this.BloodEffect = this.OriginalBloodEffect;
    if (weapon.WeaponID == 14) {
      this.BloodEffect = weapon.HeartBurst;
    }
    Animation component = this.Yandere.Character.GetComponent<Animation>();
    if (weapon.Type == WeaponType.Knife) {
      if (!this.Stealth) {
        if (sanityType == SanityType.High) {
          if (this.EffectPhase == 0 && component[this.AnimName].time > 1.06666672f) {
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (sanityType == SanityType.Medium) {
          if (this.EffectPhase == 0) {
            if (component[this.AnimName].time > 2.16666675f) {
              UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 1 && component[this.AnimName].time > 3.0333333f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 0) {
          if (component[this.AnimName].time > 2.76666665f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 1) {
          if (component[this.AnimName].time > 3.5333333f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 2 && component[this.AnimName].time > 4.16666651f) {
          UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
          this.EffectPhase++;
        }
      } else if (this.EffectPhase == 0 && component[this.AnimName].time > 0.966666639f) {
        this.Yandere.Bloodiness += 20f;
        this.Yandere.StainWeapon();
        UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.1f, Quaternion.identity);
        this.EffectPhase++;
      }
    } else if (weapon.Type == WeaponType.Katana) {
      if (!this.Stealth) {
        if (sanityType == SanityType.High) {
          if (this.EffectPhase == 0 && component[this.AnimName].time > 0.483333319f) {
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (sanityType == SanityType.Medium) {
          if (this.EffectPhase == 0) {
            if (component[this.AnimName].time > 0.55f) {
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 1 && component[this.AnimName].time > 1.51666665f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 0) {
          if (component[this.AnimName].time > 0.5f) {
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 1) {
          if (component[this.AnimName].time > 1f) {
            weapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 2) {
          if (component[this.AnimName].time > 2.33333325f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 3) {
          if (component[this.AnimName].time > 2.73333335f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 4) {
          if (component[this.AnimName].time > 3.13333344f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 5) {
          if (component[this.AnimName].time > 3.5333333f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 6) {
          if (component[this.AnimName].time > 4.133333f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 8 && component[this.AnimName].time > 5f) {
          weapon.transform.localEulerAngles = Vector3.zero;
          this.EffectPhase++;
        }
      } else if (this.EffectPhase == 0) {
        if (component[this.AnimName].time > 0.366666675f) {
          this.Yandere.Bloodiness += 20f;
          this.Yandere.StainWeapon();
          UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.6666667f, Quaternion.identity);
          this.EffectPhase++;
        }
      } else if (this.EffectPhase == 1 && component[this.AnimName].time > 1f) {
        UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.333333343f, Quaternion.identity);
        this.EffectPhase++;
      }
    } else if (weapon.Type == WeaponType.Bat) {
      if (!this.Stealth) {
        if (sanityType == SanityType.High) {
          if (this.EffectPhase == 0 && component[this.AnimName].time > 0.733333349f) {
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (sanityType == SanityType.Medium) {
          if (this.EffectPhase == 0) {
            if (component[this.AnimName].time > 1f) {
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 1 && component[this.AnimName].time > 2.9666667f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 0) {
          if (component[this.AnimName].time > 0.7f) {
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 1) {
          if (component[this.AnimName].time > 3.1f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 2) {
          if (component[this.AnimName].time > 3.76666665f) {
            UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 3 && component[this.AnimName].time > 4.4f) {
          UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.forward * 0.5f, Quaternion.identity);
          this.EffectPhase++;
        }
      }
    } else if (weapon.Type == WeaponType.Saw) {
      if (!this.Stealth) {
        if (sanityType == SanityType.High) {
          if (this.EffectPhase == 0) {
            if (component[this.AnimName].time > 0f) {
              weapon.Spin = true;
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 1) {
            if (component[this.AnimName].time > 0.733333349f) {
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 2 && component[this.AnimName].time > 1.43333328f) {
            weapon.Spin = false;
            weapon.BloodSpray[0].Stop();
            weapon.BloodSpray[1].Stop();
            this.EffectPhase++;
          }
        } else if (sanityType == SanityType.Medium) {
          if (this.EffectPhase == 0) {
            if (component[this.AnimName].time > 0f) {
              weapon.Spin = true;
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 1) {
            if (component[this.AnimName].time > 1.1f) {
              this.Yandere.Bloodiness += 20f;
              this.Yandere.StainWeapon();
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 2) {
            if (component[this.AnimName].time > 1.43333328f) {
              weapon.BloodSpray[0].Stop();
              weapon.BloodSpray[1].Stop();
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 3) {
            if (component[this.AnimName].time > 2.36666656f) {
              weapon.BloodSpray[0].Play();
              weapon.BloodSpray[1].Play();
              this.EffectPhase++;
            }
          } else if (this.EffectPhase == 4 && component[this.AnimName].time > 2.4f) {
            weapon.Spin = true;
            weapon.BloodSpray[0].Stop();
            weapon.BloodSpray[1].Stop();
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 0) {
          if (component[this.AnimName].time > 0f) {
            weapon.Spin = true;
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 1) {
          if (component[this.AnimName].time > 0.6666667f) {
            this.Yandere.Bloodiness += 20f;
            this.Yandere.StainWeapon();
            weapon.BloodSpray[0].Play();
            weapon.BloodSpray[1].Play();
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 2) {
          if (component[this.AnimName].time > 0.733333349f) {
            weapon.BloodSpray[0].Stop();
            weapon.BloodSpray[1].Stop();
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 3) {
          if (component[this.AnimName].time > 3f) {
            weapon.BloodSpray[0].Play();
            weapon.BloodSpray[1].Play();
            this.EffectPhase++;
          }
        } else if (this.EffectPhase == 4 && component[this.AnimName].time > 4.866667f) {
          weapon.Spin = false;
          weapon.BloodSpray[0].Stop();
          weapon.BloodSpray[1].Stop();
          this.EffectPhase++;
        }
      } else if (this.EffectPhase == 0 && component[this.AnimName].time > 1f) {
        this.Yandere.Bloodiness += 20f;
        this.Yandere.StainWeapon();
        UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, weapon.transform.position + weapon.transform.right * 0.2f + weapon.transform.forward * -0.06666667f, Quaternion.identity);
        this.EffectPhase++;
      }
    }
  }

  // Token: 0x060000D3 RID: 211 RVA: 0x0000FB38 File Offset: 0x0000DF38
  private void LoopCheck(WeaponScript weapon) {
    Animation component = this.Yandere.Character.GetComponent<Animation>();
    if (Input.GetButtonDown("X")) {
      if (weapon.Type == WeaponType.Knife) {
        if (component[this.AnimName].time > 3.5333333f && component[this.AnimName].time < 4.16666651f) {
          this.LoopStart = 106f;
          this.LoopEnd = 125f;
          this.LoopPhase = 2;
          this.Loop = true;
        }
      } else if (weapon.Type == WeaponType.Katana) {
        if (component[this.AnimName].time > 3.36666656f && component[this.AnimName].time < 3.9f) {
          this.LoopStart = 101f;
          this.LoopEnd = 117f;
          this.LoopPhase = 5;
          this.Loop = true;
        }
      } else if (weapon.Type == WeaponType.Bat) {
        if (component[this.AnimName].time > 3.76666665f && component[this.AnimName].time < 4.4f) {
          this.LoopStart = 113f;
          this.LoopEnd = 132f;
          this.LoopPhase = 2;
          this.Loop = true;
        }
      } else if (weapon.Type == WeaponType.Saw && component[this.AnimName].time > 3.0333333f && component[this.AnimName].time < 4.5666666f) {
        this.LoopStart = 91f;
        this.LoopEnd = 137f;
        this.LoopPhase = 3;
        this.PingPong = true;
      }
    }
    AudioSource component2 = weapon.gameObject.GetComponent<AudioSource>();
    Animation component3 = this.Victim.GetComponent<Animation>();
    if (this.PingPong) {
      if (component[this.AnimName].time > this.LoopEnd / 30f) {
        component2.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
        component2.time = this.LoopStart / 30f;
        component3[this.VictimAnimName].speed = -1f;
        component[this.AnimName].speed = -1f;
        this.EffectPhase = this.LoopPhase;
        this.AttackTimer = 0f;
      } else if (component[this.AnimName].time < this.LoopStart / 30f) {
        component2.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
        component2.time = this.LoopStart / 30f;
        component3[this.VictimAnimName].speed = 1f;
        component[this.AnimName].speed = 1f;
        this.EffectPhase = this.LoopPhase;
        this.AttackTimer = this.LoopStart / 30f;
        this.EffectPhase = this.LoopPhase;
        this.PingPong = false;
      }
    }
    if (this.Loop && component[this.AnimName].time > this.LoopEnd / 30f) {
      component2.pitch = 1f + UnityEngine.Random.Range(0.1f, -0.1f);
      component2.time = this.LoopStart / 30f;
      component3[this.VictimAnimName].time = this.LoopStart / 30f;
      component[this.AnimName].time = this.LoopStart / 30f;
      this.AttackTimer = this.LoopStart / 30f;
      this.EffectPhase = this.LoopPhase;
      this.Loop = false;
    }
  }

  // Token: 0x060000D4 RID: 212 RVA: 0x0000FF2B File Offset: 0x0000E32B
  private void CheckForSpecialCase(WeaponScript weapon) {
    if (weapon.WeaponID == 8) {
      this.Yandere.TargetStudent.Ragdoll.Sacrifice = true;
      if (GameGlobals.Paranormal) {
        weapon.Effect();
      }
    }
  }

  // Token: 0x040002F8 RID: 760
  public GameObject BloodEffect;

  // Token: 0x040002F9 RID: 761
  private GameObject OriginalBloodEffect;

  // Token: 0x040002FA RID: 762
  private GameObject Victim;

  // Token: 0x040002FB RID: 763
  private YandereScript Yandere;

  // Token: 0x040002FC RID: 764
  private string VictimAnimName = string.Empty;

  // Token: 0x040002FD RID: 765
  private string AnimName = string.Empty;

  // Token: 0x040002FE RID: 766
  public bool PingPong;

  // Token: 0x040002FF RID: 767
  public bool Stealth;

  // Token: 0x04000300 RID: 768
  public bool Loop;

  // Token: 0x04000301 RID: 769
  public int EffectPhase;

  // Token: 0x04000302 RID: 770
  public int LoopPhase;

  // Token: 0x04000303 RID: 771
  public float AttackTimer;

  // Token: 0x04000304 RID: 772
  public float Distance;

  // Token: 0x04000305 RID: 773
  public float Timer;

  // Token: 0x04000306 RID: 774
  public float LoopStart;

  // Token: 0x04000307 RID: 775
  public float LoopEnd;
}