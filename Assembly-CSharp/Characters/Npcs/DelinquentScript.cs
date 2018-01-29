using UnityEngine;

// Token: 0x02000082 RID: 130
public class DelinquentScript : MonoBehaviour {

  // Token: 0x0600020E RID: 526 RVA: 0x0002A120 File Offset: 0x00028520
  private void Start() {
    this.EasterHair.SetActive(false);
    this.Bandanas.SetActive(false);
    this.OriginalRotation = base.transform.rotation;
    this.LookAtTarget = this.Default.position;
    if (this.Weapon != null) {
      this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, -0.145f, this.Weapon.localPosition.z);
      this.Rotation = 90f;
      this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
    }
  }

  // Token: 0x0600020F RID: 527 RVA: 0x0002A1FC File Offset: 0x000285FC
  private void Update() {
    this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.DistanceToPlayer < 7f) {
      this.Planes = GeometryUtility.CalculateFrustumPlanes(this.Eyes);
      if (GeometryUtility.TestPlanesAABB(this.Planes, this.Yandere.GetComponent<Collider>().bounds)) {
        RaycastHit raycastHit;
        if (Physics.Linecast(this.Eyes.transform.position, this.Yandere.transform.position + Vector3.up, out raycastHit)) {
          if (raycastHit.collider.gameObject == this.Yandere.gameObject) {
            this.LookAtPlayer = true;
            if (this.Yandere.Armed) {
              if (!this.Threatening) {
                component.clip = this.SurpriseClips[UnityEngine.Random.Range(0, this.SurpriseClips.Length)];
                component.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                component.Play();
              }
              this.Threatening = true;
              if (this.Cooldown) {
                this.Cooldown = false;
                this.Timer = 0f;
              }
            } else {
              if (this.Yandere.CorpseWarning) {
                if (!this.Threatening) {
                  component.clip = this.SurpriseClips[UnityEngine.Random.Range(0, this.SurpriseClips.Length)];
                  component.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                  component.Play();
                }
                this.Threatening = true;
                if (!this.Yandere.Chased) {
                  this.DelinquentManager.Attacker = this;
                  this.Run = true;
                }
                this.Yandere.Chased = true;
              } else if (!this.Threatening && this.DelinquentManager.SpeechTimer == 0f) {
                component.clip = ((!(this.Yandere.Container == null)) ? this.CaseClips[UnityEngine.Random.Range(0, this.CaseClips.Length)] : this.ProximityClips[UnityEngine.Random.Range(0, this.ProximityClips.Length)]);
                component.Play();
                this.DelinquentManager.SpeechTimer = 10f;
              }
              this.LookAtPlayer = true;
            }
          } else {
            this.LookAtPlayer = false;
          }
        }
      } else {
        this.LookAtPlayer = false;
      }
    }
    if (!this.Threatening) {
      if (this.Shoving) {
        this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if (this.Character.GetComponent<Animation>()[this.ShoveAnim].time >= this.Character.GetComponent<Animation>()[this.ShoveAnim].length) {
          this.LookAtTarget = this.Neck.position + this.Neck.forward;
          this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
          this.Shoving = false;
        }
        if (this.Weapon != null) {
          this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, 0f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
          this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
          this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
        }
      } else {
        this.Shove();
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.OriginalRotation, Time.deltaTime);
        if (this.Weapon != null) {
          this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, -0.145f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
          this.Rotation = Mathf.Lerp(this.Rotation, 90f, Time.deltaTime * 10f);
          this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
        }
      }
    } else {
      this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      if (this.Weapon != null) {
        this.Weapon.localPosition = new Vector3(this.Weapon.localPosition.x, Mathf.Lerp(this.Weapon.localPosition.y, 0f, Time.deltaTime * 10f), this.Weapon.localPosition.z);
        this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
        this.Weapon.localEulerAngles = new Vector3(this.Rotation, this.Weapon.localEulerAngles.y, this.Weapon.localEulerAngles.z);
      }
      if (this.DistanceToPlayer < 1f) {
        if (this.Yandere.Armed || this.Run) {
          if (!this.Yandere.Attacked) {
            if (this.Yandere.CanMove && (!this.Yandere.Chased || (this.Yandere.Chased && this.DelinquentManager.Attacker == this))) {
              AudioSource component2 = this.DelinquentManager.GetComponent<AudioSource>();
              if (!component2.isPlaying) {
                component2.clip = this.AttackClip;
                component2.Play();
                this.DelinquentManager.enabled = false;
              }
              if (this.Yandere.Laughing) {
                this.Yandere.StopLaughing();
              }
              if (this.Yandere.Aiming) {
                this.Yandere.StopAiming();
              }
              this.Character.GetComponent<Animation>().CrossFade(this.SwingAnim);
              this.MyWeapon.SetActive(true);
              this.Attacking = true;
              this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_swingB_00");
              this.Yandere.RPGCamera.enabled = false;
              this.Yandere.CanMove = false;
              this.Yandere.Attacked = true;
              this.Yandere.EmptyHands();
            }
          } else if (this.Attacking) {
            if (this.AudioPhase == 1) {
              if (this.Character.GetComponent<Animation>()[this.SwingAnim].time >= this.Character.GetComponent<Animation>()[this.SwingAnim].length * 0.3f) {
                this.Jukebox.SetActive(false);
                this.AudioPhase++;
                component.pitch = 1f;
                component.clip = this.Strike;
                component.Play();
              }
            } else if (this.AudioPhase == 2 && this.Character.GetComponent<Animation>()[this.SwingAnim].time >= this.Character.GetComponent<Animation>()[this.SwingAnim].length * 0.85f) {
              this.AudioPhase++;
              component.pitch = 1f;
              component.clip = this.Crumple;
              component.Play();
            }
            this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
            this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          }
        } else {
          this.Shove();
        }
      } else if (!this.ExpressedSurprise) {
        this.Character.GetComponent<Animation>().CrossFade(this.SurpriseAnim);
        if (this.Character.GetComponent<Animation>()[this.SurpriseAnim].time >= this.Character.GetComponent<Animation>()[this.SurpriseAnim].length) {
          this.ExpressedSurprise = true;
        }
      } else if (this.Run) {
        if (this.DistanceToPlayer > 1f) {
          base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.transform.position, Time.deltaTime * this.RunSpeed);
          this.Character.GetComponent<Animation>().CrossFade(this.RunAnim);
          this.RunSpeed += Time.deltaTime;
        }
      } else if (!this.Cooldown) {
        this.Character.GetComponent<Animation>().CrossFade(this.ThreatenAnim);
        if (!this.Yandere.Armed) {
          this.Timer += Time.deltaTime;
          if (this.Timer > 2.5f) {
            this.Cooldown = true;
            if (!this.DelinquentManager.GetComponent<AudioSource>().isPlaying) {
              this.DelinquentManager.SpeechTimer = Time.deltaTime;
            }
          }
        } else {
          this.Timer = 0f;
          if (this.DelinquentManager.SpeechTimer == 0f) {
            this.DelinquentManager.GetComponent<AudioSource>().clip = this.ThreatenClips[UnityEngine.Random.Range(0, this.ThreatenClips.Length)];
            this.DelinquentManager.GetComponent<AudioSource>().Play();
            this.DelinquentManager.SpeechTimer = 10f;
          }
        }
      } else {
        if (this.DelinquentManager.SpeechTimer == 0f) {
          AudioSource component3 = this.DelinquentManager.GetComponent<AudioSource>();
          if (!component3.isPlaying) {
            component3.clip = this.SurrenderClips[UnityEngine.Random.Range(0, this.SurrenderClips.Length)];
            component3.Play();
            this.DelinquentManager.SpeechTimer = 5f;
          }
        }
        this.Character.GetComponent<Animation>().CrossFade(this.CooldownAnim, 2.5f);
        this.Timer += Time.deltaTime;
        if (this.Timer > 5f) {
          this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
          this.ExpressedSurprise = false;
          this.Threatening = false;
          this.Cooldown = false;
          this.Timer = 0f;
        }
        this.Shove();
      }
    }
    if (Input.GetKeyDown(KeyCode.V) && this.LongSkirt != null) {
      this.MyRenderer.sharedMesh = this.LongSkirt;
    }
    if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(this.Yandere.transform.position, this.DelinquentManager.transform.position) < 10f) {
      this.Spaces++;
      if (this.Spaces == 9) {
        if (this.HairRenderer == null) {
          this.DefaultHair.SetActive(false);
          this.EasterHair.SetActive(true);
          this.EasterHair.GetComponent<Renderer>().material.mainTexture = this.BlondThugHair;
        }
      } else if (this.Spaces == 10) {
        this.Rapping = true;
        this.MyWeapon.SetActive(false);
        this.IdleAnim = this.Prefix + "gruntIdle_00";
        Animation component4 = this.Character.GetComponent<Animation>();
        component4.CrossFade(this.IdleAnim);
        component4[this.IdleAnim].time = UnityEngine.Random.Range(0f, component4[this.IdleAnim].length);
        this.DefaultHair.SetActive(false);
        this.Mask.SetActive(false);
        this.EasterHair.SetActive(true);
        this.Bandanas.SetActive(true);
        if (this.HairRenderer != null) {
          this.HairRenderer.material.color = this.HairColor;
        }
        this.DelinquentManager.EasterEgg();
      }
    }
  }

  // Token: 0x06000210 RID: 528 RVA: 0x0002B010 File Offset: 0x00029410
  private void Shove() {
    if (!this.Yandere.Shoved && !this.Yandere.Tripping && this.DistanceToPlayer < 0.5f) {
      AudioSource component = this.DelinquentManager.GetComponent<AudioSource>();
      component.clip = this.ShoveClips[UnityEngine.Random.Range(0, this.ShoveClips.Length)];
      component.Play();
      this.DelinquentManager.SpeechTimer = 5f;
      if (this.Yandere.transform.position.x > base.transform.position.x) {
        this.Yandere.transform.position = new Vector3(base.transform.position.x - 0.001f, this.Yandere.transform.position.y, this.Yandere.transform.position.z);
      }
      if (this.Yandere.Aiming) {
        this.Yandere.StopAiming();
      }
      Animation component2 = this.Character.GetComponent<Animation>();
      component2[this.ShoveAnim].time = 0f;
      component2.CrossFade(this.ShoveAnim);
      this.Shoving = true;
      this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_shoveA_01");
      this.Yandere.Punching = false;
      this.Yandere.CanMove = false;
      this.Yandere.Shoved = true;
      this.ExpressedSurprise = false;
      this.Threatening = false;
      this.Cooldown = false;
      this.Timer = 0f;
    }
  }

  // Token: 0x06000211 RID: 529 RVA: 0x0002B1CC File Offset: 0x000295CC
  private void LateUpdate() {
    if (!this.Threatening) {
      if (!this.Shoving && !this.Rapping) {
        this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, (!this.LookAtPlayer) ? this.Default.position : this.Yandere.Head.position, Time.deltaTime * 2f);
        this.Neck.LookAt(this.LookAtTarget);
      }
      if (this.HeadStill) {
        this.Head.transform.localEulerAngles = Vector3.zero;
      }
    }
    if (this.BustSize > 0f) {
      this.RightBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
      this.LeftBreast.localScale = new Vector3(this.BustSize, this.BustSize, this.BustSize);
    }
  }

  // Token: 0x06000212 RID: 530 RVA: 0x0002B2C6 File Offset: 0x000296C6
  private void OnEnable() {
    this.Character.GetComponent<Animation>().CrossFade(this.IdleAnim, 1f);
  }

  // Token: 0x040006FA RID: 1786
  private Quaternion targetRotation;

  // Token: 0x040006FB RID: 1787
  public DelinquentManagerScript DelinquentManager;

  // Token: 0x040006FC RID: 1788
  public YandereScript Yandere;

  // Token: 0x040006FD RID: 1789
  public Quaternion OriginalRotation;

  // Token: 0x040006FE RID: 1790
  public Vector3 LookAtTarget;

  // Token: 0x040006FF RID: 1791
  public GameObject Character;

  // Token: 0x04000700 RID: 1792
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x04000701 RID: 1793
  public GameObject MyWeapon;

  // Token: 0x04000702 RID: 1794
  public GameObject Jukebox;

  // Token: 0x04000703 RID: 1795
  public Mesh LongSkirt;

  // Token: 0x04000704 RID: 1796
  public Camera Eyes;

  // Token: 0x04000705 RID: 1797
  public Transform RightBreast;

  // Token: 0x04000706 RID: 1798
  public Transform LeftBreast;

  // Token: 0x04000707 RID: 1799
  public Transform Default;

  // Token: 0x04000708 RID: 1800
  public Transform Weapon;

  // Token: 0x04000709 RID: 1801
  public Transform Neck;

  // Token: 0x0400070A RID: 1802
  public Transform Head;

  // Token: 0x0400070B RID: 1803
  public Plane[] Planes;

  // Token: 0x0400070C RID: 1804
  public string CooldownAnim = "f02_idleShort_00";

  // Token: 0x0400070D RID: 1805
  public string ThreatenAnim = "f02_threaten_00";

  // Token: 0x0400070E RID: 1806
  public string SurpriseAnim = "f02_surprise_00";

  // Token: 0x0400070F RID: 1807
  public string ShoveAnim = "f02_shoveB_00";

  // Token: 0x04000710 RID: 1808
  public string SwingAnim = "f02_swingA_00";

  // Token: 0x04000711 RID: 1809
  public string RunAnim = "f02_spring_00";

  // Token: 0x04000712 RID: 1810
  public string IdleAnim = string.Empty;

  // Token: 0x04000713 RID: 1811
  public string Prefix = "f02_";

  // Token: 0x04000714 RID: 1812
  public bool ExpressedSurprise;

  // Token: 0x04000715 RID: 1813
  public bool LookAtPlayer;

  // Token: 0x04000716 RID: 1814
  public bool Threatening;

  // Token: 0x04000717 RID: 1815
  public bool Attacking;

  // Token: 0x04000718 RID: 1816
  public bool HeadStill;

  // Token: 0x04000719 RID: 1817
  public bool Cooldown;

  // Token: 0x0400071A RID: 1818
  public bool Shoving;

  // Token: 0x0400071B RID: 1819
  public bool Rapping;

  // Token: 0x0400071C RID: 1820
  public bool Run;

  // Token: 0x0400071D RID: 1821
  public float DistanceToPlayer;

  // Token: 0x0400071E RID: 1822
  public float RunSpeed;

  // Token: 0x0400071F RID: 1823
  public float BustSize;

  // Token: 0x04000720 RID: 1824
  public float Rotation;

  // Token: 0x04000721 RID: 1825
  public float Timer;

  // Token: 0x04000722 RID: 1826
  public int AudioPhase = 1;

  // Token: 0x04000723 RID: 1827
  public int Spaces;

  // Token: 0x04000724 RID: 1828
  public AudioClip[] ProximityClips;

  // Token: 0x04000725 RID: 1829
  public AudioClip[] SurrenderClips;

  // Token: 0x04000726 RID: 1830
  public AudioClip[] SurpriseClips;

  // Token: 0x04000727 RID: 1831
  public AudioClip[] ThreatenClips;

  // Token: 0x04000728 RID: 1832
  public AudioClip[] AggroClips;

  // Token: 0x04000729 RID: 1833
  public AudioClip[] ShoveClips;

  // Token: 0x0400072A RID: 1834
  public AudioClip[] CaseClips;

  // Token: 0x0400072B RID: 1835
  public AudioClip SurpriseClip;

  // Token: 0x0400072C RID: 1836
  public AudioClip AttackClip;

  // Token: 0x0400072D RID: 1837
  public AudioClip Crumple;

  // Token: 0x0400072E RID: 1838
  public AudioClip Strike;

  // Token: 0x0400072F RID: 1839
  public GameObject DefaultHair;

  // Token: 0x04000730 RID: 1840
  public GameObject Mask;

  // Token: 0x04000731 RID: 1841
  public GameObject EasterHair;

  // Token: 0x04000732 RID: 1842
  public GameObject Bandanas;

  // Token: 0x04000733 RID: 1843
  public Renderer HairRenderer;

  // Token: 0x04000734 RID: 1844
  public Color HairColor;

  // Token: 0x04000735 RID: 1845
  public Texture BlondThugHair;
}