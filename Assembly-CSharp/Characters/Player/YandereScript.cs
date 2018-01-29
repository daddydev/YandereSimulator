using HighlightingSystem;
using System.Collections;
using UnityEngine;

// Token: 0x02000221 RID: 545
public class YandereScript : MonoBehaviour {

  // Token: 0x06000968 RID: 2408 RVA: 0x000A50D4 File Offset: 0x000A34D4
  private void Start() {
    this.CharacterAnimation = this.Character.GetComponent<Animation>();
    this.GreyTarget = 1f - SchoolGlobals.SchoolAtmosphere;
    this.SetAnimationLayers();
    this.UpdateNumbness();
    this.RightEyeOrigin = this.RightEye.localPosition;
    this.LeftEyeOrigin = this.LeftEye.localPosition;
    this.CharacterAnimation["f02_yanderePose_00"].weight = 0f;
    this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
    this.CharacterAnimation["f02_gazerSnap_00"].speed = 2f;
    ColorCorrectionCurves[] components = Camera.main.GetComponents<ColorCorrectionCurves>();
    Vignetting[] components2 = Camera.main.GetComponents<Vignetting>();
    this.YandereColorCorrection = components[1];
    this.Vignette = components2[1];
    this.ResetYandereEffects();
    this.ResetSenpaiEffects();
    this.Sanity = 100f;
    this.Bloodiness = 0f;
    this.SetUniform();
    this.EasterEggMenu.transform.localPosition = new Vector3(this.EasterEggMenu.transform.localPosition.x, 0f, this.EasterEggMenu.transform.localPosition.z);
    this.ProgressBar.transform.parent.gameObject.SetActive(false);
    this.Smartphone.transform.parent.gameObject.SetActive(false);
    this.ObstacleDetector.gameObject.SetActive(false);
    this.SithBeam[1].gameObject.SetActive(false);
    this.SithBeam[2].gameObject.SetActive(false);
    this.PunishedAccessories.SetActive(false);
    this.SukebanAccessories.SetActive(false);
    this.FalconShoulderpad.SetActive(false);
    this.CensorSteam[0].SetActive(false);
    this.CensorSteam[1].SetActive(false);
    this.CensorSteam[2].SetActive(false);
    this.CensorSteam[3].SetActive(false);
    this.FloatingShovel.SetActive(false);
    this.BlackEyePatch.SetActive(false);
    this.EasterEggMenu.SetActive(false);
    this.FalconNipple1.SetActive(false);
    this.FalconNipple2.SetActive(false);
    this.PunishedScarf.SetActive(false);
    this.FalconBuckle.SetActive(false);
    this.FalconHelmet.SetActive(false);
    this.TornadoDress.SetActive(false);
    this.Stand.Stand.SetActive(false);
    this.TornadoHair.SetActive(false);
    this.MemeGlasses.SetActive(false);
    this.CirnoWings.SetActive(false);
    this.KONGlasses.SetActive(false);
    this.EbolaWings.SetActive(false);
    this.Microphone.SetActive(false);
    this.Poisons[1].SetActive(false);
    this.Poisons[2].SetActive(false);
    this.Poisons[3].SetActive(false);
    this.BladeHair.SetActive(false);
    this.CirnoHair.SetActive(false);
    this.EbolaHair.SetActive(false);
    this.FalconGun.SetActive(false);
    this.EyepatchL.SetActive(false);
    this.EyepatchR.SetActive(false);
    this.ZipTie[0].SetActive(false);
    this.ZipTie[1].SetActive(false);
    this.Shoes[0].SetActive(false);
    this.Shoes[1].SetActive(false);
    this.Cape.SetActive(false);
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.ID = 1;
    while (this.ID < this.Accessories.Length) {
      this.Accessories[this.ID].SetActive(false);
      this.ID++;
    }
    foreach (GameObject gameObject in this.PunishedArm) {
      gameObject.SetActive(false);
    }
    foreach (GameObject gameObject2 in this.GaloAccessories) {
      gameObject2.SetActive(false);
    }
    this.ID = 1;
    while (this.ID < this.CyborgParts.Length) {
      this.CyborgParts[this.ID].SetActive(false);
      this.ID++;
    }
    if (PlayerGlobals.PantiesEquipped == 5) {
      this.RunSpeed += 1f;
    }
    if (PlayerGlobals.Headset) {
      this.Inventory.Headset = true;
    }
    this.UpdateHair();
    this.ClubAccessory();
    if (MissionModeGlobals.MissionMode || GameGlobals.LoveSick) {
      this.NoDebug = true;
    }
  }

  // Token: 0x1700010A RID: 266
  // (get) Token: 0x06000969 RID: 2409 RVA: 0x000A55BB File Offset: 0x000A39BB
  // (set) Token: 0x0600096A RID: 2410 RVA: 0x000A55C4 File Offset: 0x000A39C4
  public float Sanity {
    get {
      return this.sanity;
    }
    set {
      this.sanity = Mathf.Clamp(value, 0f, 100f);
      if (this.sanity > 66.66666f) {
        this.HeartRate.SetHeartRateColour(this.HeartRate.NormalColour);
        this.SanityWarning = false;
      } else if (this.sanity > 33.33333f) {
        this.HeartRate.SetHeartRateColour(this.HeartRate.MediumColour);
        this.SanityWarning = false;
        if (this.PreviousSanity < 33.33333f) {
          this.StudentManager.UpdateStudents();
        }
      } else {
        this.HeartRate.SetHeartRateColour(this.HeartRate.BadColour);
        if (!this.SanityWarning) {
          this.NotificationManager.DisplayNotification(NotificationType.Insane);
          this.SanityWarning = true;
        }
      }
      this.HeartRate.BeatsPerMinute = (int)(240f - this.sanity * 1.8f);
      if (this.MyRenderer.sharedMesh != this.NudeMesh) {
        if (!this.Slender) {
          this.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f - this.sanity / 100f);
        } else {
          this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
        }
      } else {
        this.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
      }
      this.PreviousSanity = this.sanity;
      this.Hairstyles[2].GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, this.Sanity);
    }
  }

  // Token: 0x1700010B RID: 267
  // (get) Token: 0x0600096B RID: 2411 RVA: 0x000A576E File Offset: 0x000A3B6E
  // (set) Token: 0x0600096C RID: 2412 RVA: 0x000A5778 File Offset: 0x000A3B78
  public float Bloodiness {
    get {
      return this.bloodiness;
    }
    set {
      this.bloodiness = Mathf.Clamp(value, 0f, 100f);
      if (!this.BloodyWarning && this.Bloodiness > 0f) {
        this.NotificationManager.DisplayNotification(NotificationType.Bloody);
        this.BloodyWarning = true;
        if (this.Schoolwear > 0) {
          this.Police.BloodyClothing++;
        }
      }
      this.MyProjector.enabled = true;
      if (this.Bloodiness == 100f) {
        this.MyProjector.material.mainTexture = this.BloodTextures[5];
      } else if (this.Bloodiness >= 80f) {
        this.MyProjector.material.mainTexture = this.BloodTextures[4];
      } else if (this.Bloodiness >= 60f) {
        this.MyProjector.material.mainTexture = this.BloodTextures[3];
      } else if (this.Bloodiness >= 40f) {
        this.MyProjector.material.mainTexture = this.BloodTextures[2];
      } else if (this.Bloodiness >= 20f) {
        this.MyProjector.material.mainTexture = this.BloodTextures[1];
      } else {
        this.MyProjector.enabled = false;
        this.BloodyWarning = false;
      }
      this.StudentManager.UpdateBooths();
      this.MyLocker.UpdateButtons();
      this.Outline.h.ReinitMaterials();
    }
  }

  // Token: 0x1700010C RID: 268
  // (get) Token: 0x0600096D RID: 2413 RVA: 0x000A590E File Offset: 0x000A3D0E
  // (set) Token: 0x0600096E RID: 2414 RVA: 0x000A591D File Offset: 0x000A3D1D
  public WeaponScript EquippedWeapon {
    get {
      return this.Weapon[this.Equipped];
    }
    set {
      this.Weapon[this.Equipped] = value;
    }
  }

  // Token: 0x1700010D RID: 269
  // (get) Token: 0x0600096F RID: 2415 RVA: 0x000A592D File Offset: 0x000A3D2D
  public bool Armed {
    get {
      return this.EquippedWeapon != null;
    }
  }

  // Token: 0x1700010E RID: 270
  // (get) Token: 0x06000970 RID: 2416 RVA: 0x000A593B File Offset: 0x000A3D3B
  public SanityType SanityType {
    get {
      if (this.Sanity / 100f > 0.6666667f) {
        return SanityType.High;
      }
      if (this.Sanity / 100f > 0.333333343f) {
        return SanityType.Medium;
      }
      return SanityType.Low;
    }
  }

  // Token: 0x06000971 RID: 2417 RVA: 0x000A596E File Offset: 0x000A3D6E
  public string GetSanityString(SanityType sanityType) {
    if (sanityType == SanityType.High) {
      return "High";
    }
    if (sanityType == SanityType.Medium) {
      return "Med";
    }
    return "Low";
  }

  // Token: 0x1700010F RID: 271
  // (get) Token: 0x06000972 RID: 2418 RVA: 0x000A5990 File Offset: 0x000A3D90
  public Vector3 HeadPosition {
    get {
      return new Vector3(base.transform.position.x, this.Hips.position.y + 0.2f, base.transform.position.z);
    }
  }

  // Token: 0x06000973 RID: 2419 RVA: 0x000A59E4 File Offset: 0x000A3DE4
  public void SetAnimationLayers() {
    this.CharacterAnimation["f02_yanderePose_00"].layer = 1;
    this.CharacterAnimation.Play("f02_yanderePose_00");
    this.CharacterAnimation["f02_yanderePose_00"].weight = 0f;
    this.CharacterAnimation["f02_shy_00"].layer = 2;
    this.CharacterAnimation.Play("f02_shy_00");
    this.CharacterAnimation["f02_shy_00"].weight = 0f;
    this.CharacterAnimation["f02_singleSaw_00"].layer = 3;
    this.CharacterAnimation.Play("f02_singleSaw_00");
    this.CharacterAnimation["f02_singleSaw_00"].weight = 0f;
    this.CharacterAnimation["f02_fist_00"].layer = 4;
    this.CharacterAnimation.Play("f02_fist_00");
    this.CharacterAnimation["f02_fist_00"].weight = 0f;
    this.CharacterAnimation["f02_mopping_00"].layer = 5;
    this.CharacterAnimation["f02_mopping_00"].speed = 2f;
    this.CharacterAnimation.Play("f02_mopping_00");
    this.CharacterAnimation["f02_mopping_00"].weight = 0f;
    this.CharacterAnimation["f02_carry_00"].layer = 6;
    this.CharacterAnimation.Play("f02_carry_00");
    this.CharacterAnimation["f02_carry_00"].weight = 0f;
    this.CharacterAnimation["f02_mopCarry_00"].layer = 7;
    this.CharacterAnimation.Play("f02_mopCarry_00");
    this.CharacterAnimation["f02_mopCarry_00"].weight = 0f;
    this.CharacterAnimation["f02_bucketCarry_00"].layer = 8;
    this.CharacterAnimation.Play("f02_bucketCarry_00");
    this.CharacterAnimation["f02_bucketCarry_00"].weight = 0f;
    this.CharacterAnimation["f02_cameraPose_00"].layer = 9;
    this.CharacterAnimation.Play("f02_cameraPose_00");
    this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
    this.CharacterAnimation["f02_grip_00"].layer = 10;
    this.CharacterAnimation.Play("f02_grip_00");
    this.CharacterAnimation["f02_grip_00"].weight = 0f;
    this.CharacterAnimation["f02_holdHead_00"].layer = 11;
    this.CharacterAnimation.Play("f02_holdHead_00");
    this.CharacterAnimation["f02_holdHead_00"].weight = 0f;
    this.CharacterAnimation["f02_holdTorso_00"].layer = 12;
    this.CharacterAnimation.Play("f02_holdTorso_00");
    this.CharacterAnimation["f02_holdTorso_00"].weight = 0f;
    this.CharacterAnimation["f02_carryCan_00"].layer = 13;
    this.CharacterAnimation.Play("f02_carryCan_00");
    this.CharacterAnimation["f02_carryCan_00"].weight = 0f;
    this.CharacterAnimation["f02_leftGrip_00"].layer = 14;
    this.CharacterAnimation.Play("f02_leftGrip_00");
    this.CharacterAnimation["f02_leftGrip_00"].weight = 0f;
    this.CharacterAnimation["f02_carryShoulder_00"].layer = 15;
    this.CharacterAnimation.Play("f02_carryShoulder_00");
    this.CharacterAnimation["f02_carryShoulder_00"].weight = 0f;
    this.CharacterAnimation["f02_dipping_00"].speed = 2f;
    this.CharacterAnimation["f02_stripping_00"].speed = 1.5f;
    this.CharacterAnimation["f02_falconIdle_00"].speed = 2f;
    this.CharacterAnimation["f02_carryIdleA_00"].speed = 1.75f;
    this.CharacterAnimation["CyborgNinja_Run_Armed"].speed = 2f;
    this.CharacterAnimation["CyborgNinja_Run_Unarmed"].speed = 2f;
  }

  // Token: 0x06000974 RID: 2420 RVA: 0x000A5E80 File Offset: 0x000A4280
  private void Update() {
    if (Input.GetKeyDown(KeyCode.LeftAlt)) {
      this.CinematicCamera.SetActive(false);
    }
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.PauseScreen.Show) {
      this.UpdateMovement();
      this.UpdatePoisoning();
      if (!this.Laughing) {
        component.volume -= Time.deltaTime * 2f;
      }
      if (!this.Mopping) {
        this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 0f, Time.deltaTime * 10f);
      } else {
        this.CharacterAnimation["f02_mopping_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopping_00"].weight, 1f, Time.deltaTime * 10f);
        if (Input.GetButtonUp("A") || Input.GetKeyDown(KeyCode.Escape)) {
          this.Mopping = false;
        }
      }
      if (this.LaughIntensity < 10f) {
        this.ID = 0;
        while (this.ID < this.CarryAnims.Length) {
          string name = this.CarryAnims[this.ID];
          if (this.PickUp != null && this.CarryAnimID == this.ID && !this.Mopping && !this.Dipping && !this.Pouring && !this.BucketDropping && !this.Digging && !this.Burying) {
            this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 1f, Time.deltaTime * 10f);
          } else {
            this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 0f, Time.deltaTime * 10f);
          }
          this.ID++;
        }
      } else if (this.Armed) {
        this.CharacterAnimation["f02_mopCarry_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_mopCarry_00"].weight, 1f, Time.deltaTime * 10f);
      }
      if (this.Noticed && !this.Attacking) {
        if (!this.Collapse) {
          this.CharacterAnimation.CrossFade("f02_scaredIdle_00");
          this.targetRotation = Quaternion.LookRotation(this.Senpai.position - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          base.transform.localEulerAngles = new Vector3(0f, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
        } else if (this.CharacterAnimation["f02_down_22"].time >= this.CharacterAnimation["f02_down_22"].length) {
          this.CharacterAnimation.CrossFade("f02_down_23");
        }
      }
      this.UpdateEffects();
      this.UpdateTalking();
      this.UpdateAttacking();
      this.UpdateSlouch();
      if (!this.Noticed) {
        this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.RightYandereEye.material.color.g, this.RightYandereEye.material.color.b, 1f - this.Sanity / 100f);
        this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.LeftYandereEye.material.color.g, this.LeftYandereEye.material.color.b, 1f - this.Sanity / 100f);
        this.EyeShrink = Mathf.Lerp(this.EyeShrink, 0.5f * (1f - this.Sanity / 100f), Time.deltaTime * 10f);
      }
      this.UpdateTwitch();
      this.UpdateWarnings();
      this.UpdateDebugFunctionality();
      if (base.transform.position.y < 0f) {
        base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
      }
      if (base.transform.position.z < -99.5f) {
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -99.5f);
      }
      base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
    } else {
      component.volume -= 0.333333343f;
    }
  }

  // Token: 0x06000975 RID: 2421 RVA: 0x000A645C File Offset: 0x000A485C
  private void GoToPKDir(PKDirType pkDir, string sansAnim, Vector3 ragdollLocalPos) {
    this.CharacterAnimation.CrossFade(sansAnim);
    this.RagdollPK.transform.localPosition = ragdollLocalPos;
    if (this.PKDir != pkDir) {
      AudioSource.PlayClipAtPoint(this.Slam, base.transform.position + Vector3.up);
    }
    this.PKDir = pkDir;
  }

  // Token: 0x06000976 RID: 2422 RVA: 0x000A64BC File Offset: 0x000A48BC
  private void UpdateMovement() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (this.CanMove) {
      this.MyController.Move(Physics.gravity * 0.1f);
      this.v = Input.GetAxis("Vertical");
      this.h = Input.GetAxis("Horizontal");
      this.FlapSpeed = Mathf.Abs(this.v) + Mathf.Abs(this.h);
      if (!this.Aiming) {
        Vector3 a = this.MainCamera.transform.TransformDirection(Vector3.forward);
        a.y = 0f;
        a = a.normalized;
        Vector3 a2 = new Vector3(a.z, 0f, -a.x);
        this.targetDirection = this.h * a2 + this.v * a;
        if (this.targetDirection != Vector3.zero) {
          this.targetRotation = Quaternion.LookRotation(this.targetDirection);
          base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        } else {
          this.targetRotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        if (this.v != 0f || this.h != 0f) {
          if (Input.GetButton("LB") && Vector3.Distance(base.transform.position, this.Senpai.position) > 1f) {
            if (this.Stance.Current == StanceType.Crouching) {
              this.CharacterAnimation.CrossFade(this.CrouchRunAnim);
              this.MyController.Move(base.transform.forward * (this.CrouchRunSpeed + (float)(ClassGlobals.PhysicalGrade + PlayerGlobals.SpeedBonus) * 0.25f) * Time.deltaTime);
            } else if (!this.Dragging && !this.Mopping) {
              this.CharacterAnimation.CrossFade(this.RunAnim);
              this.MyController.Move(base.transform.forward * (this.RunSpeed + (float)(ClassGlobals.PhysicalGrade + PlayerGlobals.SpeedBonus) * 0.25f) * Time.deltaTime);
            } else if (this.Mopping) {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
              this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
            }
            if (this.Stance.Current == StanceType.Crouching) {
            }
            if (this.Stance.Current == StanceType.Crawling) {
              this.Stance.Current = StanceType.Crouching;
              this.Crouch();
            }
          } else if (!this.Dragging) {
            if (this.Stance.Current == StanceType.Crawling) {
              this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
              this.MyController.Move(base.transform.forward * (this.CrawlSpeed * Time.deltaTime));
            } else if (this.Stance.Current == StanceType.Crouching) {
              this.CharacterAnimation[this.CrouchWalkAnim].speed = 1f;
              this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
              this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime));
            } else {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
              this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
            }
          } else {
            this.CharacterAnimation.CrossFade("f02_dragWalk_01");
            this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime));
          }
        } else if (!this.Dragging) {
          if (this.Stance.Current == StanceType.Crawling) {
            this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
          } else if (this.Stance.Current == StanceType.Crouching) {
            this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
          } else {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
        } else {
          this.CharacterAnimation.CrossFade("f02_dragIdle_02");
        }
      } else {
        if (this.v != 0f || this.h != 0f) {
          if (this.Stance.Current == StanceType.Crawling) {
            this.CharacterAnimation.CrossFade(this.CrawlWalkAnim);
            this.MyController.Move(base.transform.forward * (this.CrawlSpeed * Time.deltaTime * this.v));
            this.MyController.Move(base.transform.right * (this.CrawlSpeed * Time.deltaTime * this.h));
          } else if (this.Stance.Current == StanceType.Crouching) {
            this.CharacterAnimation.CrossFade(this.CrouchWalkAnim);
            this.MyController.Move(base.transform.forward * (this.CrouchWalkSpeed * Time.deltaTime * this.v));
            this.MyController.Move(base.transform.right * (this.CrouchWalkSpeed * Time.deltaTime * this.h));
          } else {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            this.MyController.Move(base.transform.forward * (this.WalkSpeed * Time.deltaTime * this.v));
            this.MyController.Move(base.transform.right * (this.WalkSpeed * Time.deltaTime * this.h));
          }
        } else if (this.Stance.Current == StanceType.Crawling) {
          this.CharacterAnimation.CrossFade(this.CrawlIdleAnim);
        } else if (this.Stance.Current == StanceType.Crouching) {
          this.CharacterAnimation.CrossFade(this.CrouchIdleAnim);
        } else {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
        }
        this.Bend += Input.GetAxis("Mouse Y") * 8f;
        if (this.Stance.Current == StanceType.Crawling) {
          if (this.Bend < 0f) {
            this.Bend = 0f;
          }
        } else if (this.Stance.Current == StanceType.Crouching) {
          if (this.Bend < -45f) {
            this.Bend = -45f;
          }
        } else if (this.Bend < -85f) {
          this.Bend = -85f;
        }
        if (this.Bend > 85f) {
          this.Bend = 85f;
        }
        base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 8f, base.transform.localEulerAngles.z);
      }
      if (!this.NearSenpai) {
        if (!Input.GetButton("A") && !Input.GetButton("B") && !Input.GetButton("X") && !Input.GetButton("Y") && (Input.GetAxis("LT") > 0.5f || Input.GetMouseButton(1))) {
          if (this.Inventory.RivalPhone && Input.GetButtonDown("LB")) {
            this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
            if (!this.RivalPhone) {
              this.SmartphoneRenderer.material.mainTexture = this.RivalPhoneTexture;
              this.RivalPhone = true;
            } else {
              this.SmartphoneRenderer.material.mainTexture = this.YanderePhoneTexture;
              this.RivalPhone = false;
            }
          }
          if (Input.GetAxis("LT") > 0.5f) {
            this.UsingController = true;
          }
          if (!this.Aiming) {
            if (this.CameraEffects.OneCamera) {
              this.MainCamera.clearFlags = CameraClearFlags.Color;
              this.MainCamera.farClipPlane = 0.02f;
              this.HandCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Color;
            } else {
              this.MainCamera.clearFlags = CameraClearFlags.Skybox;
              this.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
              this.HandCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
            }
            base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, this.MainCamera.transform.eulerAngles.y, base.transform.eulerAngles.z);
            this.CharacterAnimation.Play(this.IdleAnim);
            this.Smartphone.transform.parent.gameObject.SetActive(true);
            this.DisableHairAndAccessories();
            this.ShoulderCamera.AimingCamera = true;
            this.Obscurance.enabled = false;
            this.HandCamera.SetActive(true);
            this.YandereVision = false;
            this.Blur.enabled = true;
            this.Mopping = false;
            this.Aiming = true;
            this.EmptyHands();
            if (this.Inventory.RivalPhone) {
              this.PhonePromptBar.Panel.enabled = true;
              this.PhonePromptBar.Show = true;
            }
            Time.timeScale = 1f;
          }
        }
        if (!this.Aiming && !this.Accessories[9].activeInHierarchy && !this.Accessories[16].activeInHierarchy) {
          if (Input.GetButton("RB")) {
            if (this.BlackRobe.activeInHierarchy) {
              this.SithTrailEnd1.localPosition = new Vector3(-1f, 0f, 0f);
              this.SithTrailEnd2.localPosition = new Vector3(1f, 0f, 0f);
              this.Beam[0].Play();
              this.Beam[1].Play();
              this.Beam[2].Play();
              this.Beam[3].Play();
              if (Input.GetButtonDown("X")) {
                this.CharacterAnimation.Play("f02_sithAttack_00");
                this.SithBeam[1].gameObject.SetActive(true);
                this.SithBeam[2].gameObject.SetActive(true);
                this.SithBeam[1].Damage = 10f;
                this.SithBeam[2].Damage = 10f;
                this.SithAttacking = true;
                this.CanMove = false;
                this.SithPrefix = string.Empty;
              }
              if (Input.GetButtonDown("Y")) {
                this.CharacterAnimation.Play("f02_sithAttackHard_00");
                this.SithBeam[1].gameObject.SetActive(true);
                this.SithBeam[2].gameObject.SetActive(true);
                this.SithBeam[1].Damage = 20f;
                this.SithBeam[2].Damage = 20f;
                this.SithAttacking = true;
                this.CanMove = false;
                this.SithPrefix = "Hard";
              }
            }
            this.YandereTimer += Time.deltaTime;
            if (this.YandereTimer > 0.5f) {
              if (!this.Sans && !this.BlackRobe.activeInHierarchy) {
                this.YandereVision = true;
              } else if (this.Sans) {
                this.SansEyes[0].SetActive(true);
                this.SansEyes[1].SetActive(true);
                this.GlowEffect.Play();
                this.SummonBones = true;
                this.YandereTimer = 0f;
                this.CanMove = false;
              }
            }
          } else {
            if (this.BlackRobe.activeInHierarchy) {
              this.SithTrailEnd1.localPosition = new Vector3(0f, 0f, 0f);
              this.SithTrailEnd2.localPosition = new Vector3(0f, 0f, 0f);
              this.Beam[0].Stop();
              this.Beam[1].Stop();
              this.Beam[2].Stop();
              this.Beam[3].Stop();
            }
            if (this.YandereVision) {
              this.Obscurance.enabled = false;
              this.YandereVision = false;
            }
          }
          if (Input.GetButtonUp("RB")) {
            if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling && this.YandereTimer < 0.5f && !this.Dragging && !this.Carrying && !this.Laughing) {
              if (this.Sans) {
                this.BlasterStage++;
                if (this.BlasterStage > 5) {
                  this.BlasterStage = 1;
                }
                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BlasterSet[this.BlasterStage], base.transform.position, Quaternion.identity);
                gameObject.transform.position = base.transform.position;
                gameObject.transform.rotation = base.transform.rotation;
                AudioSource.PlayClipAtPoint(this.BlasterClip, base.transform.position + Vector3.up);
                this.CharacterAnimation["f02_sansBlaster_00"].time = 0f;
                this.CharacterAnimation.Play("f02_sansBlaster_00");
                this.SansEyes[0].SetActive(true);
                this.SansEyes[1].SetActive(true);
                this.GlowEffect.Play();
                this.Blasting = true;
                this.CanMove = false;
              } else if (!this.BlackRobe.activeInHierarchy) {
                if (this.Gazing) {
                  this.CharacterAnimation["f02_gazerSnap_00"].time = 0f;
                  this.CharacterAnimation.CrossFade("f02_gazerSnap_00");
                  this.Snapping = true;
                  this.CanMove = false;
                } else if (!this.FalconHelmet.activeInHierarchy && this.Barcode.activeInHierarchy) {
                  if (!this.Xtan) {
                    if (!this.CirnoHair.activeInHierarchy && !this.TornadoHair.activeInHierarchy && !this.BladeHair.activeInHierarchy) {
                      this.LaughAnim = "f02_laugh_01";
                      this.LaughClip = this.Laugh1;
                      this.LaughIntensity += 1f;
                      component.clip = this.LaughClip;
                      component.time = 0f;
                      component.Play();
                    }
                    UnityEngine.Object.Instantiate<GameObject>(this.GiggleDisc, base.transform.position + Vector3.up, Quaternion.identity);
                    component.volume = 1f;
                    this.LaughTimer = 0.5f;
                    this.Laughing = true;
                    this.CanMove = false;
                  } else if (this.LongHair[0].gameObject.activeInHierarchy) {
                    this.LongHair[0].gameObject.SetActive(false);
                    this.BlackEyePatch.SetActive(false);
                    this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
                    this.SlenderHair[0].SetActive(true);
                    this.SlenderHair[1].SetActive(true);
                  } else {
                    this.LongHair[0].gameObject.SetActive(true);
                    this.BlackEyePatch.SetActive(true);
                    this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
                    this.SlenderHair[0].SetActive(false);
                    this.SlenderHair[1].SetActive(false);
                  }
                } else if (!this.Punching) {
                  if (this.FalconHelmet.activeInHierarchy) {
                    GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.FalconWindUp);
                    gameObject2.transform.parent = this.ItemParent;
                    gameObject2.transform.localPosition = Vector3.zero;
                    AudioClipPlayer.PlayAttached(this.FalconPunchVoice, this.MainCamera.transform, 5f, 10f);
                    this.CharacterAnimation["f02_falconPunch_00"].time = 0f;
                    this.CharacterAnimation.Play("f02_falconPunch_00");
                    this.FalconSpeed = 0f;
                  } else {
                    GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.FalconWindUp);
                    gameObject3.transform.parent = this.ItemParent;
                    gameObject3.transform.localPosition = Vector3.zero;
                    AudioSource.PlayClipAtPoint(this.OnePunchVoices[UnityEngine.Random.Range(0, this.OnePunchVoices.Length)], base.transform.position + Vector3.up);
                    this.CharacterAnimation["f02_onePunch_00"].time = 0f;
                    this.CharacterAnimation.CrossFade("f02_onePunch_00", 0.15f);
                  }
                  this.Punching = true;
                  this.CanMove = false;
                }
              }
            }
            this.YandereTimer = 0f;
          }
        }
        if (!Input.GetButton("LB")) {
          if (this.Stance.Current != StanceType.Crouching && this.Stance.Current != StanceType.Crawling) {
            if (Input.GetButtonDown("RS")) {
              this.Obscurance.enabled = false;
              this.CrouchButtonDown = true;
              this.YandereVision = false;
              this.Stance.Current = StanceType.Crouching;
              this.Crouch();
              this.EmptyHands();
            }
          } else {
            if (this.Stance.Current == StanceType.Crouching) {
              if (Input.GetButton("RS") && !this.CameFromCrouch) {
                this.CrawlTimer += Time.deltaTime;
              }
              if (this.CrawlTimer > 0.5f) {
                this.EmptyHands();
                this.Obscurance.enabled = false;
                this.YandereVision = false;
                this.Stance.Current = StanceType.Crawling;
                this.CrawlTimer = 0f;
                this.Crawl();
              } else if (Input.GetButtonUp("RS") && !this.CrouchButtonDown && !this.CameFromCrouch) {
                this.Stance.Current = StanceType.Standing;
                this.CrawlTimer = 0f;
                this.Uncrouch();
              }
            } else if (Input.GetButtonDown("RS")) {
              this.CameFromCrouch = true;
              this.Stance.Current = StanceType.Crouching;
              this.Crouch();
            }
            if (Input.GetButtonUp("RS")) {
              this.CrouchButtonDown = false;
              this.CameFromCrouch = false;
              this.CrawlTimer = 0f;
            }
          }
        }
      }
      if (this.Aiming) {
        this.CharacterAnimation["f02_cameraPose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_cameraPose_00"].weight, 1f, Time.deltaTime * 10f);
        if (this.ClubAccessories[7].activeInHierarchy && (Input.GetAxis("DpadY") != 0f || Input.GetAxis("Mouse ScrollWheel") != 0f)) {
          this.Smartphone.fieldOfView -= Input.GetAxis("DpadY");
          this.Smartphone.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 10f;
          if (this.Smartphone.fieldOfView > 60f) {
            this.Smartphone.fieldOfView = 60f;
          }
          if (this.Smartphone.fieldOfView < 30f) {
            this.Smartphone.fieldOfView = 30f;
          }
        }
        if (Input.GetAxis("RT") != 0f || Input.GetMouseButtonDown(0) || Input.GetButtonDown("RB")) {
          this.FixCamera();
          this.PauseScreen.CorrectingTime = false;
          Time.timeScale = 0f;
          this.CanMove = false;
          this.Shutter.Snap();
        }
        if (Time.timeScale > 0f && ((this.UsingController && Input.GetAxis("LT") < 0.5f) || (!this.UsingController && !Input.GetMouseButton(1)))) {
          this.StopAiming();
        }
        if (Input.GetKey(KeyCode.LeftAlt)) {
          if (!this.CinematicCamera.activeInHierarchy) {
            if (this.CinematicTimer > 0f) {
              this.CinematicCamera.transform.eulerAngles = this.Smartphone.transform.eulerAngles;
              this.CinematicCamera.transform.position = this.Smartphone.transform.position;
              this.CinematicCamera.SetActive(true);
              this.CinematicTimer = 0f;
              this.StopAiming();
            }
            this.CinematicTimer += 1f;
          }
        } else {
          this.CinematicTimer = 0f;
        }
      }
      if (this.Gloved) {
        if (this.InputDevice.Type == InputDeviceType.Gamepad) {
          if (Input.GetAxis("DpadY") < -0.5f) {
            this.GloveTimer += Time.deltaTime;
            if (this.GloveTimer > 0.5f) {
              this.CharacterAnimation.CrossFade("f02_removeGloves_00");
              this.Degloving = true;
              this.CanMove = false;
            }
          } else {
            this.GloveTimer = 0f;
          }
        } else if (Input.GetKey(KeyCode.Alpha1)) {
          this.GloveTimer += Time.deltaTime;
          if (this.GloveTimer > 0.1f) {
            this.CharacterAnimation.CrossFade("f02_removeGloves_00");
            this.Degloving = true;
            this.CanMove = false;
          }
        } else {
          this.GloveTimer = 0f;
        }
      }
      if (this.Weapon[1] != null && this.DropTimer[2] == 0f) {
        if (this.InputDevice.Type == InputDeviceType.Gamepad) {
          if (Input.GetAxis("DpadX") < -0.5f) {
            this.DropWeapon(1);
          } else {
            this.DropTimer[1] = 0f;
          }
        } else if (Input.GetKey(KeyCode.Alpha2)) {
          this.DropWeapon(1);
        } else {
          this.DropTimer[1] = 0f;
        }
      }
      if (this.Weapon[2] != null && this.DropTimer[1] == 0f) {
        if (this.InputDevice.Type == InputDeviceType.Gamepad) {
          if (Input.GetAxis("DpadX") > 0.5f) {
            this.DropWeapon(2);
          } else {
            this.DropTimer[2] = 0f;
          }
        } else if (Input.GetKey(KeyCode.Alpha3)) {
          this.DropWeapon(2);
        } else {
          this.DropTimer[2] = 0f;
        }
      }
      if (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T)) {
        if (this.NewTrail != null) {
          UnityEngine.Object.Destroy(this.NewTrail);
        }
        this.NewTrail = UnityEngine.Object.Instantiate<GameObject>(this.Trail, base.transform.position + base.transform.forward * 0.5f + Vector3.up * 0.1f, Quaternion.identity);
        this.NewTrail.GetComponent<AIPath>().target = this.Homeroom;
      }
      if (this.Armed) {
        this.ID = 0;
        while (this.ID < this.ArmedAnims.Length) {
          string name = this.ArmedAnims[this.ID];
          this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, (this.EquippedWeapon.AnimID != this.ID) ? 0f : 1f, Time.deltaTime * 10f);
          this.ID++;
        }
      } else {
        this.StopArmedAnim();
      }
      if (this.TheftTimer > 0f) {
        this.TheftTimer = Mathf.MoveTowards(this.TheftTimer, 0f, Time.deltaTime);
      }
    } else {
      this.StopArmedAnim();
      if (this.Dumping) {
        this.targetRotation = Quaternion.LookRotation(this.Incinerator.transform.position - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.Incinerator.transform.position + Vector3.right * -2f);
        if (this.DumpTimer == 0f && this.Carrying) {
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        }
        this.DumpTimer += Time.deltaTime;
        if (this.DumpTimer > 1f) {
          if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped) {
            this.DumpRagdoll(RagdollDumpType.Incinerator);
          }
          this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
          if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length) {
            this.Incinerator.Prompt.enabled = true;
            this.Incinerator.Ready = true;
            this.Incinerator.Open = false;
            this.Dragging = false;
            this.Dumping = false;
            this.CanMove = true;
            this.Ragdoll = null;
            this.StopCarrying();
            this.DumpTimer = 0f;
          }
        }
      }
      if (this.Chipping) {
        this.targetRotation = Quaternion.LookRotation(this.WoodChipper.gameObject.transform.position - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.WoodChipper.DumpPoint.position);
        if (this.DumpTimer == 0f && this.Carrying) {
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        }
        this.DumpTimer += Time.deltaTime;
        if (this.DumpTimer > 1f) {
          if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped) {
            this.DumpRagdoll(RagdollDumpType.WoodChipper);
          }
          this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
          if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length) {
            this.WoodChipper.Prompt.HideButton[0] = false;
            this.WoodChipper.Prompt.HideButton[3] = true;
            this.WoodChipper.Occupied = true;
            this.WoodChipper.Open = false;
            this.Dragging = false;
            this.Chipping = false;
            this.CanMove = true;
            this.Ragdoll = null;
            this.StopCarrying();
            this.DumpTimer = 0f;
          }
        }
      }
      if (this.TranquilHiding) {
        this.targetRotation = Quaternion.LookRotation(this.TranqCase.transform.position - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.TranqCase.transform.position + Vector3.right * 1.4f);
        if (this.DumpTimer == 0f && this.Carrying) {
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        }
        this.DumpTimer += Time.deltaTime;
        if (this.DumpTimer > 1f) {
          if (!this.Ragdoll.GetComponent<RagdollScript>().Dumped) {
            this.DumpRagdoll(RagdollDumpType.TranqCase);
          }
          this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
          if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length) {
            this.TranquilHiding = false;
            this.Dragging = false;
            this.Dumping = false;
            this.CanMove = true;
            this.Ragdoll = null;
            this.StopCarrying();
            this.DumpTimer = 0f;
          }
        }
      }
      if (this.Dipping) {
        if (this.Bucket != null) {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Bucket.transform.position.x, base.transform.position.y, this.Bucket.transform.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        }
        this.CharacterAnimation.CrossFade("f02_dipping_00");
        if (this.CharacterAnimation["f02_dipping_00"].time >= this.CharacterAnimation["f02_dipping_00"].length * 0.5f) {
          this.Mop.Bleached = true;
          this.Mop.Sparkles.Play();
          if (this.Mop.Bloodiness > 0f) {
            if (this.Bucket != null) {
              this.Bucket.Bloodiness += this.Mop.Bloodiness / 2f;
              this.Bucket.UpdateAppearance = true;
            }
            this.Mop.Bloodiness = 0f;
            this.Mop.UpdateBlood();
          }
        }
        if (this.CharacterAnimation["f02_dipping_00"].time >= this.CharacterAnimation["f02_dipping_00"].length) {
          this.CharacterAnimation["f02_dipping_00"].time = 0f;
          this.Mop.Prompt.enabled = true;
          this.Dipping = false;
          this.CanMove = true;
        }
      }
      if (this.Pouring) {
        this.MoveTowardsTarget(this.Stool.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Stool.rotation, 10f * Time.deltaTime);
        string text = "f02_bucketDump" + this.PourHeight + "_00";
        AnimationState animationState = this.CharacterAnimation[text];
        this.CharacterAnimation.CrossFade(text, 0f);
        if (animationState.time >= this.PourTime && !this.PickUp.Bucket.Poured) {
          var PickupBucket = PickUp.Bucket;
          var PourEffect = PickupBucket.PourEffect;
          var PourEffectMain = PourEffect.main;
          if (PickupBucket.Gasoline) {
            PourEffectMain.startColor = new Color(1f, 1f, 0f, 0.5f);
            UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.GasCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
          } else if (this.PickUp.Bucket.Bloodiness < 50f) {
            PourEffectMain.startColor = new Color(0f, 1f, 1f, 0.5f);
            UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.WaterCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
          } else {
            PourEffectMain.startColor = new Color(0.5f, 0f, 0f, 0.5f);
            UnityEngine.Object.Instantiate<GameObject>(this.PickUp.Bucket.BloodCollider, this.PickUp.Bucket.PourEffect.transform.position + this.PourDistance * base.transform.forward, Quaternion.identity);
          }
          this.PickUp.Bucket.PourEffect.Play();
          this.PickUp.Bucket.Poured = true;
          this.PickUp.Bucket.Empty();
        }
        if (animationState.time >= animationState.length) {
          animationState.time = 0f;
          this.PickUp.Bucket.Poured = false;
          this.Pouring = false;
          this.CanMove = true;
        }
      }
      if (this.Laughing) {
        if (this.Hairstyles[14].activeInHierarchy) {
          this.LaughAnim = "storepower_20";
          this.LaughClip = this.ChargeUp;
        }
        if (this.Stand.Stand.activeInHierarchy) {
          this.LaughAnim = "f02_jojoAttack_00";
          this.LaughClip = this.YanYan;
        } else if (this.FlameDemonic) {
          float axis = Input.GetAxis("Vertical");
          float axis2 = Input.GetAxis("Horizontal");
          Vector3 a3 = this.MainCamera.transform.TransformDirection(Vector3.forward);
          a3.y = 0f;
          a3 = a3.normalized;
          Vector3 a4 = new Vector3(a3.z, 0f, -a3.x);
          Vector3 vector = axis2 * a4 + axis * a3;
          if (vector != Vector3.zero) {
            this.targetRotation = Quaternion.LookRotation(vector);
            base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          }
          this.LaughAnim = "f02_demonAttack_00";
          this.CirnoTimer -= Time.deltaTime;
          if (this.CirnoTimer < 0f) {
            GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.Fireball, this.RightHand.position, base.transform.rotation);
            gameObject4.transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(0f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f));
            GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(this.Fireball, this.LeftHand.position, base.transform.rotation);
            gameObject5.transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(0f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f), UnityEngine.Random.Range(-22.5f, 22.5f));
            this.CirnoTimer = 0.1f;
          }
        } else if (this.CirnoHair.activeInHierarchy) {
          float axis3 = Input.GetAxis("Vertical");
          float axis4 = Input.GetAxis("Horizontal");
          Vector3 a5 = this.MainCamera.transform.TransformDirection(Vector3.forward);
          a5.y = 0f;
          a5 = a5.normalized;
          Vector3 a6 = new Vector3(a5.z, 0f, -a5.x);
          Vector3 vector2 = axis4 * a6 + axis3 * a5;
          if (vector2 != Vector3.zero) {
            this.targetRotation = Quaternion.LookRotation(vector2);
            base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          }
          this.LaughAnim = "f02_cirnoAttack_00";
          this.CirnoTimer -= Time.deltaTime;
          if (this.CirnoTimer < 0f) {
            GameObject gameObject6 = UnityEngine.Object.Instantiate<GameObject>(this.CirnoIceAttack, base.transform.position + base.transform.up * 1.4f, base.transform.rotation);
            gameObject6.transform.localEulerAngles += new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
            component.PlayOneShot(this.CirnoIceClip);
            this.CirnoTimer = 0.1f;
          }
        } else if (this.TornadoHair.activeInHierarchy) {
          this.LaughAnim = "f02_tornadoAttack_00";
          this.CirnoTimer -= Time.deltaTime;
          if (this.CirnoTimer < 0f) {
            GameObject gameObject7 = UnityEngine.Object.Instantiate<GameObject>(this.TornadoAttack, base.transform.forward * 5f + new Vector3(base.transform.position.x + UnityEngine.Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + UnityEngine.Random.Range(-5f, 5f)), base.transform.rotation);
            while (Vector3.Distance(base.transform.position, gameObject7.transform.position) < 1f) {
              gameObject7.transform.position = base.transform.forward * 5f + new Vector3(base.transform.position.x + UnityEngine.Random.Range(-5f, 5f), base.transform.position.y, base.transform.position.z + UnityEngine.Random.Range(-5f, 5f));
            }
            this.CirnoTimer = 0.1f;
          }
        } else if (this.BladeHair.activeInHierarchy) {
          this.LaughAnim = "f02_spin_00";
          base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y + Time.deltaTime * 360f * 2f, base.transform.localEulerAngles.z);
          this.BladeHairCollider1.enabled = true;
          this.BladeHairCollider2.enabled = true;
        } else if (component.clip != this.LaughClip) {
          component.clip = this.LaughClip;
          component.time = 0f;
          component.Play();
        }
        this.CharacterAnimation.CrossFade(this.LaughAnim);
        if (Input.GetButtonDown("RB")) {
          this.LaughIntensity += 1f;
          if (this.LaughIntensity <= 5f) {
            this.LaughAnim = "f02_laugh_01";
            this.LaughClip = this.Laugh1;
            this.LaughTimer = 0.5f;
          } else if (this.LaughIntensity <= 10f) {
            this.LaughAnim = "f02_laugh_02";
            this.LaughClip = this.Laugh2;
            this.LaughTimer = 1f;
          } else if (this.LaughIntensity <= 15f) {
            this.LaughAnim = "f02_laugh_03";
            this.LaughClip = this.Laugh3;
            this.LaughTimer = 1.5f;
          } else if (this.LaughIntensity <= 20f) {
            GameObject gameObject8 = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
            gameObject8.GetComponent<AlarmDiscScript>().NoScream = true;
            this.LaughAnim = "f02_laugh_04";
            this.LaughClip = this.Laugh4;
            this.LaughTimer = 2f;
          } else {
            GameObject gameObject9 = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
            gameObject9.GetComponent<AlarmDiscScript>().NoScream = true;
            this.LaughAnim = "f02_laugh_04";
            this.LaughIntensity = 20f;
            this.LaughTimer = 2f;
          }
        }
        if (this.LaughIntensity > 15f) {
          this.Sanity += Time.deltaTime * 10f;
        }
        this.LaughTimer -= Time.deltaTime;
        if (this.LaughTimer <= 0f) {
          this.StopLaughing();
        }
      }
      if (this.TimeSkipping) {
        base.transform.position = new Vector3(base.transform.position.x, this.TimeSkipHeight, base.transform.position.z);
        this.CharacterAnimation.CrossFade("f02_timeSkip_00");
        this.MyController.Move(base.transform.up * 0.0001f);
        this.Sanity += Time.deltaTime * 0.17f;
      }
      if (this.DumpsterGrabbing) {
        if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f) {
          this.CharacterAnimation.CrossFade((this.DumpsterHandle.Direction != -1f) ? "f02_dumpsterPush_00" : "f02_dumpsterPull_00");
        } else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f) {
          this.CharacterAnimation.CrossFade((this.DumpsterHandle.Direction != -1f) ? "f02_dumpsterPull_00" : "f02_dumpsterPush_00");
        } else {
          this.CharacterAnimation.CrossFade("f02_dumpsterGrab_00");
        }
      }
      if (this.Stripping && this.CharacterAnimation["f02_stripping_00"].time >= this.CharacterAnimation["f02_stripping_00"].length) {
        this.Stripping = false;
        this.CanMove = true;
        this.MyLocker.UpdateSchoolwear();
      }
      if (this.Bathing) {
        this.MoveTowardsTarget(this.Stool.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Stool.rotation, 10f * Time.deltaTime);
        this.CharacterAnimation.CrossFade("f02_stoolBathing_00");
        if (this.CharacterAnimation["f02_stoolBathing_00"].time >= this.CharacterAnimation["f02_stoolBathing_00"].length) {
          this.Bloodiness = 0f;
          this.Bathing = false;
          this.CanMove = true;
        }
      }
      if (this.Degloving) {
        this.CharacterAnimation.CrossFade("f02_removeGloves_00");
        if (this.CharacterAnimation["f02_removeGloves_00"].time >= this.CharacterAnimation["f02_removeGloves_00"].length) {
          this.Gloves.GetComponent<Rigidbody>().isKinematic = false;
          this.Gloves.transform.parent = null;
          this.Gloves.gameObject.SetActive(true);
          this.Degloving = false;
          this.CanMove = true;
          this.Gloved = false;
          this.Gloves = null;
          this.SetUniform();
        } else if (this.InputDevice.Type == InputDeviceType.Gamepad) {
          if (Input.GetAxis("DpadY") > -0.5f) {
            this.Degloving = false;
            this.CanMove = true;
            this.GloveTimer = 0f;
          }
        } else if (Input.GetKeyUp(KeyCode.Alpha1)) {
          this.Degloving = false;
          this.CanMove = true;
          this.GloveTimer = 0f;
        }
      }
      if (this.Struggling) {
        if (!this.Won && !this.Lost) {
          this.CharacterAnimation.CrossFade((!this.TargetStudent.Teacher) ? "f02_struggleA_00" : "f02_teacherStruggleA_00");
          this.targetRotation = Quaternion.LookRotation(this.TargetStudent.transform.position - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        } else if (this.Won) {
          if (!this.TargetStudent.Teacher) {
            this.CharacterAnimation.CrossFade("f02_struggleWinA_00");
            if (this.CharacterAnimation["f02_struggleWinA_00"].time > this.CharacterAnimation["f02_struggleWinA_00"].length - 1f) {
              this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime * 3.33333f);
            }
          } else {
            this.CharacterAnimation.CrossFade("f02_teacherStruggleWinA_00");
            this.EquippedWeapon.transform.localEulerAngles = Vector3.Lerp(this.EquippedWeapon.transform.localEulerAngles, Vector3.zero, Time.deltaTime);
          }
          if (this.StrugglePhase == 0) {
            if ((!this.TargetStudent.Teacher && this.CharacterAnimation["f02_struggleWinA_00"].time > 1.3f) || (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 0.8f)) {
              UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, (!this.TargetStudent.Teacher) ? this.TargetStudent.Head.position : this.EquippedWeapon.transform.position, Quaternion.identity);
              this.Bloodiness += 20f;
              this.Sanity -= 20f * this.Numbness;
              this.StainWeapon();
              this.StrugglePhase++;
            }
          } else if (this.StrugglePhase == 1) {
            if (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 1.3f) {
              UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
              this.StrugglePhase++;
            }
          } else if (this.StrugglePhase == 2 && this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > 2.1f) {
            UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.EquippedWeapon.transform.position, Quaternion.identity);
            this.StrugglePhase++;
          }
          if ((!this.TargetStudent.Teacher && this.CharacterAnimation["f02_struggleWinA_00"].time > this.CharacterAnimation["f02_struggleWinA_00"].length) || (this.TargetStudent.Teacher && this.CharacterAnimation["f02_teacherStruggleWinA_00"].time > this.CharacterAnimation["f02_teacherStruggleWinA_00"].length)) {
            this.MyController.radius = 0.2f;
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.ShoulderCamera.Struggle = false;
            this.Struggling = false;
            this.StrugglePhase = 0;
            if (this.TargetStudent == this.Pursuer) {
              this.Pursuer = null;
              this.Chased = false;
            }
            this.TargetStudent.BecomeRagdoll();
            this.TargetStudent.DeathType = DeathType.Weapon;
          }
        } else if (this.Lost) {
          this.CharacterAnimation.CrossFade((!this.TargetStudent.Teacher) ? "f02_struggleLoseA_00" : "f02_teacherStruggleLoseA_00");
        }
      }
      if (this.ClubActivity && ClubGlobals.Club == ClubType.MartialArts) {
        this.CharacterAnimation.Play("f02_kick_23");
        if (this.CharacterAnimation["f02_kick_23"].time >= this.CharacterAnimation["f02_kick_23"].length) {
          this.CharacterAnimation["f02_kick_23"].time = 0f;
        }
      }
      if (this.Possessed) {
        this.CharacterAnimation.CrossFade("f02_possessionPose_00");
      }
      if (this.Punching) {
        if (this.FalconHelmet.activeInHierarchy) {
          if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.25f) {
            this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 2.5f, Time.deltaTime * 2.5f);
          } else if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1.25f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5f) {
            this.FalconSpeed = Mathf.MoveTowards(this.FalconSpeed, 0f, Time.deltaTime * 2.5f);
          }
          if (this.CharacterAnimation["f02_falconPunch_00"].time >= 1f && this.CharacterAnimation["f02_falconPunch_00"].time <= 1.5f) {
            if (this.NewFalconPunch == null) {
              this.NewFalconPunch = UnityEngine.Object.Instantiate<GameObject>(this.FalconPunch);
              this.NewFalconPunch.transform.parent = this.ItemParent;
              this.NewFalconPunch.transform.localPosition = Vector3.zero;
            }
            this.MyController.Move(base.transform.forward * this.FalconSpeed);
          }
          if (this.CharacterAnimation["f02_falconPunch_00"].time >= this.CharacterAnimation["f02_falconPunch_00"].length) {
            this.NewFalconPunch = null;
            this.Punching = false;
            this.CanMove = true;
          }
        } else {
          if (this.CharacterAnimation["f02_onePunch_00"].time >= 0.833333f && this.CharacterAnimation["f02_onePunch_00"].time <= 1f && this.NewOnePunch == null) {
            this.NewOnePunch = UnityEngine.Object.Instantiate<GameObject>(this.OnePunch);
            this.NewOnePunch.transform.parent = this.ItemParent;
            this.NewOnePunch.transform.localPosition = Vector3.zero;
          }
          if (this.CharacterAnimation["f02_onePunch_00"].time >= 2f) {
            this.NewOnePunch = null;
            this.Punching = false;
            this.CanMove = true;
          }
        }
      }
      if (this.PK) {
        if (Input.GetAxis("Vertical") > 0.5f) {
          this.GoToPKDir(PKDirType.Up, "f02_sansUp_00", new Vector3(0f, 3f, 2f));
        } else if (Input.GetAxis("Vertical") < -0.5f) {
          this.GoToPKDir(PKDirType.Down, "f02_sansDown_00", new Vector3(0f, 0f, 2f));
        } else if (Input.GetAxis("Horizontal") > 0.5f) {
          this.GoToPKDir(PKDirType.Right, "f02_sansRight_00", new Vector3(1.5f, 1.5f, 2f));
        } else if (Input.GetAxis("Horizontal") < -0.5f) {
          this.GoToPKDir(PKDirType.Left, "f02_sansLeft_00", new Vector3(-1.5f, 1.5f, 2f));
        } else {
          this.CharacterAnimation.CrossFade("f02_sansHold_00");
          this.RagdollPK.transform.localPosition = new Vector3(0f, 1.5f, 2f);
          this.PKDir = PKDirType.None;
        }
        if (Input.GetButtonDown("B")) {
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.CanMove = true;
          this.PK = false;
        }
      }
      if (this.SummonBones) {
        this.CharacterAnimation.CrossFade("f02_sansBones_00");
        if (this.BoneTimer == 0f) {
          UnityEngine.Object.Instantiate<GameObject>(this.Bone, base.transform.position + base.transform.right * UnityEngine.Random.Range(-2.5f, 2.5f) + base.transform.up * -2f + base.transform.forward * UnityEngine.Random.Range(1f, 6f), Quaternion.identity);
        }
        this.BoneTimer += Time.deltaTime;
        if (this.BoneTimer > 0.1f) {
          this.BoneTimer = 0f;
        }
        if (Input.GetButtonUp("RB")) {
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.SummonBones = false;
          this.CanMove = true;
        }
        if (this.PK) {
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.CanMove = true;
          this.PK = false;
        }
      }
      if (this.Blasting) {
        if (this.CharacterAnimation["f02_sansBlaster_00"].time >= this.CharacterAnimation["f02_sansBlaster_00"].length - 0.25f) {
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.Blasting = false;
          this.CanMove = true;
        }
        if (this.PK) {
          this.PromptBar.ClearButtons();
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = false;
          this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
          this.SansEyes[0].SetActive(false);
          this.SansEyes[1].SetActive(false);
          this.GlowEffect.Stop();
          this.CanMove = true;
          this.PK = false;
        }
      }
      if (this.Lifting) {
        if (!this.HeavyWeight) {
          if (this.CharacterAnimation["f02_carryLiftA_00"].time >= this.CharacterAnimation["f02_carryLiftA_00"].length) {
            this.IdleAnim = this.CarryIdleAnim;
            this.WalkAnim = this.CarryWalkAnim;
            this.RunAnim = this.CarryRunAnim;
            this.CanMove = true;
            this.Carrying = true;
            this.Lifting = false;
          }
        } else if (this.CharacterAnimation["f02_heavyWeightLift_00"].time >= this.CharacterAnimation["f02_heavyWeightLift_00"].length) {
          this.CharacterAnimation[this.CarryAnims[0]].weight = 1f;
          this.IdleAnim = this.HeavyIdleAnim;
          this.WalkAnim = this.HeavyWalkAnim;
          this.RunAnim = this.CarryRunAnim;
          this.CanMove = true;
          this.Lifting = false;
        }
      }
      if (this.Dropping) {
        this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.DropSpot.position);
        if (this.Ragdoll != null) {
          this.CurrentRagdoll = this.Ragdoll.GetComponent<RagdollScript>();
        }
        if (this.DumpTimer == 0f && this.Carrying) {
          this.CurrentRagdoll.CharacterAnimation[this.CurrentRagdoll.DumpedAnim].time = 2.5f;
          this.CharacterAnimation["f02_carryDisposeA_00"].time = 2.5f;
        }
        this.DumpTimer += Time.deltaTime;
        if (this.DumpTimer > 1f) {
          if (this.Ragdoll != null) {
            this.CurrentRagdoll.PelvisRoot.localEulerAngles = new Vector3(this.CurrentRagdoll.PelvisRoot.localEulerAngles.x, 0f, this.CurrentRagdoll.PelvisRoot.localEulerAngles.z);
            this.CurrentRagdoll.PelvisRoot.localPosition = new Vector3(this.CurrentRagdoll.PelvisRoot.localPosition.x, this.CurrentRagdoll.PelvisRoot.localPosition.y, 0f);
          }
          this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, base.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
          if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= 4.5f) {
            this.StopCarrying();
          } else {
            if (this.CurrentRagdoll.StopAnimation) {
              this.CurrentRagdoll.StopAnimation = false;
              this.ID = 0;
              while (this.ID < this.CurrentRagdoll.AllRigidbodies.Length) {
                this.CurrentRagdoll.AllRigidbodies[this.ID].isKinematic = true;
                this.ID++;
              }
            }
            this.CharacterAnimation.CrossFade("f02_carryDisposeA_00");
            this.CurrentRagdoll.CharacterAnimation.CrossFade(this.CurrentRagdoll.DumpedAnim);
            this.Ragdoll.transform.position = base.transform.position;
            this.Ragdoll.transform.eulerAngles = base.transform.eulerAngles;
          }
          if (this.CharacterAnimation["f02_carryDisposeA_00"].time >= this.CharacterAnimation["f02_carryDisposeA_00"].length) {
            this.CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
            this.Dropping = false;
            this.CanMove = true;
            this.DumpTimer = 0f;
          }
        }
      }
      if (this.Dismembering && this.CharacterAnimation["f02_dismember_00"].time >= this.CharacterAnimation["f02_dismember_00"].length) {
        this.Ragdoll.GetComponent<RagdollScript>().Dismember();
        this.RPGCamera.enabled = true;
        this.TargetStudent = null;
        this.Dismembering = false;
        this.CanMove = true;
      }
      if (this.Shoved) {
        if (this.CharacterAnimation["f02_shoveA_01"].time >= this.CharacterAnimation["f02_shoveA_01"].length) {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.Shoved = false;
          if (!this.CannotRecover) {
            this.CanMove = true;
          }
        } else if (this.CharacterAnimation["f02_shoveA_01"].time < 0.66666f) {
          this.MyController.Move(base.transform.forward * -1f * this.ShoveSpeed * Time.deltaTime);
          this.MyController.Move(Physics.gravity * 0.1f);
          if (this.ShoveSpeed > 0f) {
            this.ShoveSpeed = Mathf.MoveTowards(this.ShoveSpeed, 0f, Time.deltaTime * 3f);
          }
        }
      }
      if (this.Attacked && this.CharacterAnimation["f02_swingB_00"].time >= this.CharacterAnimation["f02_swingB_00"].length) {
        this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
        base.enabled = false;
      }
      if (this.Hiding) {
        if (!this.Exiting) {
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.HidingSpot.rotation, Time.deltaTime * 10f);
          this.MoveTowardsTarget(this.HidingSpot.position);
          this.CharacterAnimation.CrossFade(this.HideAnim);
          if (Input.GetButtonDown("B")) {
            this.PromptBar.ClearButtons();
            this.PromptBar.Show = false;
            this.Exiting = true;
          }
        } else {
          this.MoveTowardsTarget(this.ExitSpot.position);
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.ExitTimer += Time.deltaTime;
          if (this.ExitTimer > 1f || Vector3.Distance(base.transform.position, this.ExitSpot.position) < 0.1f) {
            this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
            this.MyController.radius = 0.2f;
            this.MyController.height = 1.55f;
            this.ExitTimer = 0f;
            this.Exiting = false;
            this.CanMove = true;
            this.Hiding = false;
          }
        }
      }
      if (this.Tripping) {
        if (this.CharacterAnimation["f02_bucketTrip_00"].time >= this.CharacterAnimation["f02_bucketTrip_00"].length) {
          this.CharacterAnimation["f02_bucketTrip_00"].speed = 1f;
          this.Tripping = false;
          this.CanMove = true;
        } else if (this.CharacterAnimation["f02_bucketTrip_00"].time < 0.5f) {
          this.MyController.Move(base.transform.forward * (Time.deltaTime * 2f));
          if (this.CharacterAnimation["f02_bucketTrip_00"].time > 0.333333343f && this.CharacterAnimation["f02_bucketTrip_00"].speed == 1f) {
            this.CharacterAnimation["f02_bucketTrip_00"].speed += 1E-06f;
            AudioSource.PlayClipAtPoint(this.Thud, base.transform.position);
          }
        } else if (Input.GetButtonDown("A")) {
          this.CharacterAnimation["f02_bucketTrip_00"].speed += 0.1f;
        }
      }
      if (this.BucketDropping) {
        this.targetRotation = Quaternion.LookRotation(this.DropSpot.position + this.DropSpot.forward - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.DropSpot.position);
        if (this.CharacterAnimation["f02_bucketDrop_00"].time >= this.CharacterAnimation["f02_bucketDrop_00"].length) {
          this.MyController.radius = 0.2f;
          this.BucketDropping = false;
          this.CanMove = true;
        } else if (this.CharacterAnimation["f02_bucketDrop_00"].time >= 1f && this.PickUp != null) {
          this.PickUp.Bucket.UpdateAppearance = true;
          this.PickUp.Bucket.Dropped = true;
          this.EmptyHands();
        }
      }
      if (this.Flicking) {
        if (this.CharacterAnimation["f02_flickingMatch_00"].time >= this.CharacterAnimation["f02_flickingMatch_00"].length) {
          this.PickUp.GetComponent<MatchboxScript>().Prompt.enabled = true;
          this.Arc.SetActive(true);
          this.Flicking = false;
          this.CanMove = true;
        } else if (this.CharacterAnimation["f02_flickingMatch_00"].time > 1f && this.Match != null) {
          Rigidbody component2 = this.Match.GetComponent<Rigidbody>();
          component2.isKinematic = false;
          component2.useGravity = true;
          component2.AddRelativeForce(Vector3.right * 250f);
          this.Match.transform.parent = null;
          this.Match = null;
        }
      }
      if (this.Rummaging) {
        this.MoveTowardsTarget(this.RummageSpot.Target.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.RummageSpot.Target.rotation, Time.deltaTime * 10f);
        this.RummageTimer += Time.deltaTime;
        this.ProgressBar.transform.localScale = new Vector3(this.RummageTimer / 10f, this.ProgressBar.transform.localScale.y, this.ProgressBar.transform.localScale.z);
        if (this.RummageTimer > 10f) {
          this.RummageSpot.GetReward();
          this.ProgressBar.transform.parent.gameObject.SetActive(false);
          this.RummageSpot = null;
          this.Rummaging = false;
          this.RummageTimer = 0f;
          this.CanMove = true;
        }
      }
      if (this.Digging) {
        if (this.DigPhase == 1) {
          if (this.CharacterAnimation["f02_shovelDig_00"].time >= 1.66666663f) {
            component.volume = 1f;
            component.clip = this.Dig;
            component.Play();
            this.DigPhase++;
          }
        } else if (this.DigPhase == 2) {
          if (this.CharacterAnimation["f02_shovelDig_00"].time >= 3.5f) {
            component.volume = 1f;
            component.Play();
            this.DigPhase++;
          }
        } else if (this.DigPhase == 3) {
          if (this.CharacterAnimation["f02_shovelDig_00"].time >= 5.66666651f) {
            component.volume = 1f;
            component.Play();
            this.DigPhase++;
          }
        } else if (this.DigPhase == 4 && this.CharacterAnimation["f02_shovelDig_00"].time >= this.CharacterAnimation["f02_shovelDig_00"].length) {
          this.EquippedWeapon.gameObject.SetActive(true);
          this.FloatingShovel.SetActive(false);
          this.RPGCamera.enabled = true;
          this.Digging = false;
          this.CanMove = true;
        }
      }
      if (this.Burying) {
        if (this.DigPhase == 1) {
          if (this.CharacterAnimation["f02_shovelBury_00"].time >= 2.16666675f) {
            component.volume = 1f;
            component.clip = this.Dig;
            component.Play();
            this.DigPhase++;
          }
        } else if (this.DigPhase == 2) {
          if (this.CharacterAnimation["f02_shovelBury_00"].time >= 4.66666651f) {
            component.volume = 1f;
            component.Play();
            this.DigPhase++;
          }
        } else if (this.CharacterAnimation["f02_shovelBury_00"].time >= this.CharacterAnimation["f02_shovelBury_00"].length) {
          this.EquippedWeapon.gameObject.SetActive(true);
          this.FloatingShovel.SetActive(false);
          this.RPGCamera.enabled = true;
          this.Burying = false;
          this.CanMove = true;
        }
      }
      if (this.Pickpocketing && !this.Noticed && this.Caught) {
        this.CaughtTimer += Time.deltaTime;
        if (this.CaughtTimer > 1f) {
          this.Pickpocketing = false;
          this.CaughtTimer = 0f;
          this.CanMove = true;
          this.Caught = false;
        }
      }
      if (this.Sprayed) {
        if (this.SprayPhase == 0) {
          if ((double)this.CharacterAnimation["f02_sprayed_00"].time > 0.66666) {
            this.Blur.enabled = true;
            this.Blur.blurSize += Time.deltaTime;
            if (this.Blur.blurSize > (float)this.Blur.blurIterations) {
              this.Blur.blurIterations++;
            }
          }
          if (this.CharacterAnimation["f02_sprayed_00"].time > 5f) {
            this.Police.Darkness.enabled = true;
            this.Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 1f, Time.deltaTime));
            if (this.Police.Darkness.color.a == 1f) {
              this.SprayTimer += Time.deltaTime;
              if (this.SprayTimer > 1f) {
                this.CharacterAnimation.Play("f02_tied_00");
                this.RPGCamera.enabled = false;
                this.ZipTie[0].SetActive(true);
                this.ZipTie[1].SetActive(true);
                this.Blur.enabled = false;
                this.SprayTimer = 0f;
                this.SprayPhase++;
              }
            }
          }
        } else if (this.SprayPhase == 1) {
          this.Police.Darkness.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Police.Darkness.color.a, 0f, Time.deltaTime));
          if (this.Police.Darkness.color.a == 0f) {
            this.SprayTimer += Time.deltaTime;
            if (this.SprayTimer > 1f) {
              this.ShoulderCamera.HeartbrokenCamera.SetActive(true);
              this.SprayPhase++;
            }
          }
        }
      }
      if (this.SithAttacking) {
        if (!this.SithRecovering) {
          if (this.CharacterAnimation[string.Concat(new object[]
          {
            "f02_sithAttack",
            this.SithPrefix,
            "_0",
            this.SithCombo
          })].time >= this.CharacterAnimation[string.Concat(new object[]
          {
            "f02_sithAttack",
            this.SithPrefix,
            "_0",
            this.SithCombo
          })].length) {
            if (this.SithCombo < this.SithComboLength) {
              this.SithCombo++;
              this.CharacterAnimation.CrossFade(string.Concat(new object[]
              {
                "f02_sithAttack",
                this.SithPrefix,
                "_0",
                this.SithCombo
              }));
            } else {
              this.CharacterAnimation.CrossFade(string.Concat(new object[]
              {
                "f02_sithRecover",
                this.SithPrefix,
                "_0",
                this.SithCombo
              }));
              this.SithRecovering = true;
            }
          } else {
            if (Input.GetButtonDown("X") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2) {
              this.SithComboLength++;
            }
            if (Input.GetButtonDown("Y") && this.SithComboLength < this.SithCombo + 1 && this.SithComboLength < 2) {
              this.SithComboLength++;
            }
          }
        } else if (this.CharacterAnimation[string.Concat(new object[]
          {
          "f02_sithRecover",
          this.SithPrefix,
          "_0",
          this.SithCombo
          })].time >= this.CharacterAnimation[string.Concat(new object[]
          {
          "f02_sithRecover",
          this.SithPrefix,
          "_0",
          this.SithCombo
          })].length) {
          this.SithBeam[1].gameObject.SetActive(false);
          this.SithBeam[2].gameObject.SetActive(false);
          this.SithRecovering = false;
          this.SithAttacking = false;
          this.SithComboLength = 0;
          this.SithCombo = 0;
          this.CanMove = true;
        }
      }
      if (this.Eating) {
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if (this.CharacterAnimation["f02_sixEat_00"].time > this.BloodTimes[this.EatPhase]) {
          GameObject gameObject10 = UnityEngine.Object.Instantiate<GameObject>(this.TargetStudent.StabBloodEffect, this.Mouth.position, Quaternion.identity);
          gameObject10.GetComponent<RandomStabScript>().Biting = true;
          this.Bloodiness += 20f;
          this.EatPhase++;
        }
        if (this.CharacterAnimation["f02_sixEat_00"].time >= this.CharacterAnimation["f02_sixEat_00"].length) {
          if (this.Hunger < 5) {
            this.CharacterAnimation["f02_sixRun_00"].speed += 0.1f;
            this.RunSpeed += 1f;
            this.Hunger++;
            if (this.Hunger == 5) {
              this.RunAnim = "f02_sixFastRun_00";
            }
          }
          this.FollowHips = false;
          this.Attacking = false;
          this.CanMove = true;
          this.Eating = false;
          this.EatPhase = 0;
        }
      }
      if (this.Snapping) {
        if (this.SnapPhase == 0) {
          if (this.CharacterAnimation["f02_gazerSnap_00"].time >= 0.8f) {
            AudioSource.PlayClipAtPoint(this.FingerSnap, base.transform.position + Vector3.up);
            this.GazerEyes.ChangeEffect();
            this.SnapPhase++;
          }
        } else if (this.CharacterAnimation["f02_gazerSnap_00"].time >= this.CharacterAnimation["f02_gazerSnap_00"].length) {
          this.Snapping = false;
          this.CanMove = true;
          this.SnapPhase = 0;
        }
      }
      if (this.GazeAttacking) {
        if (this.TargetStudent != null) {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
        if (this.SnapPhase == 0) {
          if (this.CharacterAnimation["f02_gazerPoint_00"].time >= 1f) {
            AudioSource.PlayClipAtPoint(this.Zap, base.transform.position + Vector3.up);
            this.GazerEyes.Attack();
            this.SnapPhase++;
          }
        } else if (this.CharacterAnimation["f02_gazerPoint_00"].time >= this.CharacterAnimation["f02_gazerPoint_00"].length) {
          this.GazerEyes.Attacking = false;
          this.GazeAttacking = false;
          this.CanMove = true;
          this.SnapPhase = 0;
        }
      }
    }
  }

  // Token: 0x06000977 RID: 2423 RVA: 0x000AB754 File Offset: 0x000A9B54
  private void UpdatePoisoning() {
    if (this.Poisoning) {
      this.MoveTowardsTarget(this.PoisonSpot.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.PoisonSpot.rotation, Time.deltaTime * 10f);
      if (this.CharacterAnimation["f02_poisoning_00"].time >= this.CharacterAnimation["f02_poisoning_00"].length) {
        this.Poisoning = false;
        this.CanMove = true;
      } else if (this.CharacterAnimation["f02_poisoning_00"].time >= 5.25f) {
        this.Poisons[this.PoisonType].SetActive(false);
      } else if ((double)this.CharacterAnimation["f02_poisoning_00"].time >= 0.75) {
        this.Poisons[this.PoisonType].SetActive(true);
      }
    }
  }

  // Token: 0x06000978 RID: 2424 RVA: 0x000AB860 File Offset: 0x000A9C60
  private void UpdateEffects() {
    if (!this.Attacking && !this.Lost && this.CanMove) {
      if (Vector3.Distance(base.transform.position, this.Senpai.position) < 1f) {
        if (!this.Talking) {
          if (!this.NearSenpai) {
            this.DepthOfField.focalSize = 150f;
            this.NearSenpai = true;
          }
          if (this.Laughing) {
            this.StopLaughing();
          }
          this.Obscurance.enabled = false;
          this.YandereVision = false;
          this.Stance.Current = StanceType.Standing;
          this.Mopping = false;
          this.Uncrouch();
          this.YandereTimer = 0f;
          this.EmptyHands();
          if (this.Aiming) {
            this.StopAiming();
          }
        }
      } else {
        this.NearSenpai = false;
      }
    }
    if (this.NearSenpai && !this.Noticed) {
      this.DepthOfField.enabled = true;
      this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, 0f, Time.deltaTime * 10f);
      this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, 20f, Time.deltaTime * 10f);
      this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, 20f, Time.deltaTime * 10f);
      this.DepthOfField.objectFocus = this.Senpai.transform;
      this.ColorCorrection.enabled = true;
      this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 0f, Time.deltaTime * 10f);
      this.SenpaiTint = 1f - this.SenpaiFade / 100f;
      this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.SenpaiTint * 0.5f));
      this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.SenpaiTint * 0.5f));
      this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.SenpaiTint * 0.5f));
      this.ColorCorrection.redChannel.SmoothTangents(1, 0f);
      this.ColorCorrection.greenChannel.SmoothTangents(1, 0f);
      this.ColorCorrection.blueChannel.SmoothTangents(1, 0f);
      this.ColorCorrection.UpdateTextures();
      if (!this.Attacking) {
        this.CharacterAnimation["f02_shy_00"].weight = this.SenpaiTint;
      }
      this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, 0f, Time.deltaTime * 10f);
      this.HeartBeat.volume = this.SenpaiTint;
      this.Sanity += Time.deltaTime * 10f;
    } else if (this.SenpaiFade < 99f) {
      this.DepthOfField.focalSize = Mathf.Lerp(this.DepthOfField.focalSize, 150f, Time.deltaTime * 10f);
      this.DepthOfField.focalZStartCurve = Mathf.Lerp(this.DepthOfField.focalZStartCurve, 0f, Time.deltaTime * 10f);
      this.DepthOfField.focalZEndCurve = Mathf.Lerp(this.DepthOfField.focalZEndCurve, 0f, Time.deltaTime * 10f);
      this.SenpaiFade = Mathf.Lerp(this.SenpaiFade, 100f, Time.deltaTime * 10f);
      this.SenpaiTint = this.SenpaiFade / 100f;
      this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.SenpaiTint * 0.5f));
      this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.SenpaiTint * 0.5f));
      this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.SenpaiTint * 0.5f));
      this.ColorCorrection.redChannel.SmoothTangents(1, 0f);
      this.ColorCorrection.greenChannel.SmoothTangents(1, 0f);
      this.ColorCorrection.blueChannel.SmoothTangents(1, 0f);
      this.ColorCorrection.UpdateTextures();
      this.SelectGrayscale.desaturation = Mathf.Lerp(this.SelectGrayscale.desaturation, this.GreyTarget, Time.deltaTime * 10f);
      this.CharacterAnimation["f02_shy_00"].weight = 1f - this.SenpaiTint;
      this.HeartBeat.volume = 1f - this.SenpaiTint;
    } else if (this.SenpaiFade < 100f) {
      this.ResetSenpaiEffects();
    }
    if (this.YandereVision) {
      if (!this.HighlightingR.enabled) {
        this.YandereColorCorrection.enabled = true;
        this.HighlightingR.enabled = true;
        this.HighlightingB.enabled = true;
        this.Obscurance.enabled = true;
        this.Vignette.enabled = true;
      }
      Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, Time.unscaledDeltaTime * 10f);
      this.YandereFade = Mathf.Lerp(this.YandereFade, 0f, Time.deltaTime * 10f);
      this.YandereTint = 1f - this.YandereFade / 100f;
      this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.YandereTint * 0.25f));
      this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f - this.YandereTint * 0.25f));
      this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f + this.YandereTint * 0.25f));
      this.YandereColorCorrection.redChannel.SmoothTangents(1, 0f);
      this.YandereColorCorrection.greenChannel.SmoothTangents(1, 0f);
      this.YandereColorCorrection.blueChannel.SmoothTangents(1, 0f);
      this.YandereColorCorrection.UpdateTextures();
      this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, this.YandereTint * 5f, Time.deltaTime * 10f);
      this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, this.YandereTint, Time.deltaTime * 10f);
      this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, this.YandereTint * 5f, Time.deltaTime * 10f);
    } else {
      if (this.HighlightingR.enabled) {
        this.HighlightingR.enabled = false;
        this.HighlightingB.enabled = false;
      }
      if (this.YandereFade < 99f) {
        if (!this.Aiming) {
          Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.unscaledDeltaTime * 10f);
        }
        this.YandereFade = Mathf.Lerp(this.YandereFade, 100f, Time.deltaTime * 10f);
        this.YandereTint = this.YandereFade / 100f;
        this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, this.YandereTint * 0.5f));
        this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, this.YandereTint * 0.5f));
        this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 1f - this.YandereTint * 0.5f));
        this.YandereColorCorrection.redChannel.SmoothTangents(1, 0f);
        this.YandereColorCorrection.greenChannel.SmoothTangents(1, 0f);
        this.YandereColorCorrection.blueChannel.SmoothTangents(1, 0f);
        this.YandereColorCorrection.UpdateTextures();
        this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, 0f, Time.deltaTime * 10f);
        this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, 0f, Time.deltaTime * 10f);
        this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, 0f, Time.deltaTime * 10f);
      } else if (this.YandereFade < 100f) {
        this.ResetYandereEffects();
      }
    }
    this.RightRedEye.material.color = new Color(this.RightRedEye.material.color.r, this.RightRedEye.material.color.g, this.RightRedEye.material.color.b, 1f - this.YandereFade / 100f);
    this.LeftRedEye.material.color = new Color(this.LeftRedEye.material.color.r, this.LeftRedEye.material.color.g, this.LeftRedEye.material.color.b, 1f - this.YandereFade / 100f);
    this.RightYandereEye.material.color = new Color(this.RightYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.RightYandereEye.material.color.a);
    this.LeftYandereEye.material.color = new Color(this.LeftYandereEye.material.color.r, this.YandereFade / 100f, this.YandereFade / 100f, this.LeftYandereEye.material.color.a);
  }

  // Token: 0x06000979 RID: 2425 RVA: 0x000AC368 File Offset: 0x000AA768
  private void UpdateTalking() {
    if (this.Talking) {
      if (this.TargetStudent != null) {
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      }
      if (this.Interaction == YandereInteractionType.Idle) {
        this.CharacterAnimation.CrossFade(this.IdleAnim);
      } else if (this.Interaction == YandereInteractionType.Apologizing) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_greet_00");
          if (this.TargetStudent.Witnessed == StudentWitnessType.Insanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndInsanity || this.TargetStudent.Witnessed == StudentWitnessType.BloodAndInsanity) {
            this.Subtitle.UpdateLabel(SubtitleType.InsanityApology, 0, 3f);
          } else if (this.TargetStudent.Witnessed == StudentWitnessType.WeaponAndBlood) {
            this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodApology, 0, 3f);
          } else if (this.TargetStudent.Witnessed == StudentWitnessType.Weapon) {
            this.Subtitle.UpdateLabel(SubtitleType.WeaponApology, 0, 3f);
          } else if (this.TargetStudent.Witnessed == StudentWitnessType.Blood) {
            this.Subtitle.UpdateLabel(SubtitleType.BloodApology, 0, 3f);
          } else if (this.TargetStudent.Witnessed == StudentWitnessType.Lewd) {
            this.Subtitle.UpdateLabel(SubtitleType.LewdApology, 0, 3f);
          } else if (this.TargetStudent.Witnessed == StudentWitnessType.Accident) {
            this.Subtitle.UpdateLabel(SubtitleType.AccidentApology, 0, 3f);
          } else if (this.TargetStudent.Witnessed == StudentWitnessType.Suspicious) {
            this.Subtitle.UpdateLabel(SubtitleType.SuspiciousApology, 0, 3f);
          }
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_00"].time >= this.CharacterAnimation["f02_greet_00"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.Forgiving;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.Compliment) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_greet_01");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerCompliment, 0, 3f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.ReceivingCompliment;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.Gossip) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_lookdown_00");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerGossip, 0, 3f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_lookdown_00"].time >= this.CharacterAnimation["f02_lookdown_00"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.Gossiping;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.Bye) {
        if (this.TalkTimer == 2f) {
          this.CharacterAnimation.CrossFade("f02_greet_00");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerFarewell, 0, 2f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_00"].time >= this.CharacterAnimation["f02_greet_00"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.Bye;
            this.TargetStudent.TalkTimer = 2f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.FollowMe) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_greet_01");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerFollow, 0, 3f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.FollowingPlayer;
            this.TargetStudent.TalkTimer = 2f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.GoAway) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_lookdown_00");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerLeave, 0, 3f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_lookdown_00"].time >= this.CharacterAnimation["f02_lookdown_00"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.GoingAway;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.DistractThem) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_lookdown_00");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerDistract, 0, 3f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_lookdown_00"].time >= this.CharacterAnimation["f02_lookdown_00"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.DistractingTarget;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.NamingCrush) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_greet_01");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 0, 3f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.NamingCrush;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.ChangingAppearance) {
        if (this.TalkTimer == 3f) {
          this.CharacterAnimation.CrossFade("f02_greet_01");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 2, 3f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.ChangingAppearance;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.Court) {
        if (this.TalkTimer == 5f) {
          this.CharacterAnimation.CrossFade("f02_greet_01");
          if (!this.TargetStudent.Male) {
            this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 3, 5f);
          } else {
            this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 4, 5f);
          }
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.Court;
            this.TargetStudent.TalkTimer = 3f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      } else if (this.Interaction == YandereInteractionType.Confess) {
        if (this.TalkTimer == 5f) {
          this.CharacterAnimation.CrossFade("f02_greet_01");
          this.Subtitle.UpdateLabel(SubtitleType.PlayerLove, 5, 5f);
        } else {
          if (Input.GetButtonDown("A")) {
            this.TalkTimer = 0f;
          }
          if (this.CharacterAnimation["f02_greet_01"].time >= this.CharacterAnimation["f02_greet_01"].length) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
          }
          if (this.TalkTimer <= 0f) {
            this.TargetStudent.Interaction = StudentInteractionType.Gift;
            this.TargetStudent.TalkTimer = 5f;
            this.Interaction = YandereInteractionType.Idle;
          }
        }
        this.TalkTimer -= Time.deltaTime;
      }
    }
  }

  // Token: 0x0600097A RID: 2426 RVA: 0x000ACFA8 File Offset: 0x000AB3A8
  private void UpdateAttacking() {
    if (this.Attacking) {
      if (this.TargetStudent != null) {
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.TargetStudent.transform.position.x, base.transform.position.y, this.TargetStudent.transform.position.z) - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      }
      if (this.Drown) {
        this.MoveTowardsTarget(this.TargetStudent.transform.position + this.TargetStudent.transform.forward * -0.0001f);
        this.CharacterAnimation.CrossFade(this.DrownAnim);
        if (this.CharacterAnimation[this.DrownAnim].time > this.CharacterAnimation[this.DrownAnim].length) {
          this.TargetStudent.DeathType = DeathType.Drowning;
          this.Attacking = false;
          this.CanMove = true;
          this.Drown = false;
          this.Sanity -= ((PlayerGlobals.PantiesEquipped != 10) ? 20f : 10f) * this.Numbness;
        }
        if (this.CharacterAnimation[this.DrownAnim].time > 9f) {
          this.StudentManager.FemaleDrownSplashes.Stop();
        } else if (this.CharacterAnimation[this.DrownAnim].time > 3f) {
          this.StudentManager.FemaleDrownSplashes.Play();
        }
      } else if (this.RoofPush) {
        this.CameraTarget.position = Vector3.MoveTowards(this.CameraTarget.position, new Vector3(this.Hips.position.x, base.transform.position.y + 1f, this.Hips.position.z), Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.TargetStudent.transform.position - this.TargetStudent.transform.forward);
        this.CharacterAnimation.CrossFade("f02_roofPushA_00");
        if (this.CharacterAnimation["f02_roofPushA_00"].time > 4.33333349f) {
          if (this.Shoes[0].activeInHierarchy) {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ShoePair, base.transform.position + new Vector3(-1.6f, 0.045f, 0f), Quaternion.identity);
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, -90f, gameObject.transform.eulerAngles.z);
            this.Shoes[0].SetActive(false);
            this.Shoes[1].SetActive(false);
          }
        } else if (this.CharacterAnimation["f02_roofPushA_00"].time > 2.16666675f && !this.Shoes[0].activeInHierarchy) {
          this.TargetStudent.RemoveShoes();
          this.Shoes[0].SetActive(true);
          this.Shoes[1].SetActive(true);
        }
        if (this.CharacterAnimation["f02_roofPushA_00"].time > this.CharacterAnimation["f02_roofPushA_00"].length) {
          this.CameraTarget.localPosition = new Vector3(0f, 1f, 0f);
          this.TargetStudent.DeathType = DeathType.Falling;
          this.Attacking = false;
          this.RoofPush = false;
          this.CanMove = true;
          this.Sanity -= 20f * this.Numbness;
        }
        if (Input.GetButtonDown("B")) {
          this.SplashCamera.Show = true;
          this.SplashCamera.MyCamera.enabled = true;
          this.SplashCamera.transform.position = new Vector3(-33f, 1.35f, 30f);
          this.SplashCamera.transform.eulerAngles = new Vector3(0f, 135f, 0f);
        }
      } else if (this.TargetStudent.Teacher) {
        this.CharacterAnimation.CrossFade("f02_counterA_00");
        this.Character.transform.position = new Vector3(this.Character.transform.position.x, this.TargetStudent.transform.position.y, this.Character.transform.position.z);
      } else if (!this.SanityBased) {
        if (this.EquippedWeapon.WeaponID == 11) {
          this.CharacterAnimation.CrossFade("CyborgNinja_Slash");
          if (this.CharacterAnimation["CyborgNinja_Slash"].time == 0f) {
            this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0f;
            this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
          }
          if (this.CharacterAnimation["CyborgNinja_Slash"].time >= this.CharacterAnimation["CyborgNinja_Slash"].length) {
            this.Bloodiness += 20f;
            this.StainWeapon();
            this.CharacterAnimation["CyborgNinja_Slash"].time = 0f;
            this.CharacterAnimation.Stop("CyborgNinja_Slash");
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Attacking = false;
            if (!this.Noticed) {
              this.CanMove = true;
            } else {
              this.EquippedWeapon.Drop();
            }
          }
        } else if (this.EquippedWeapon.WeaponID == 7) {
          this.CharacterAnimation.CrossFade("f02_buzzSawKill_A_00");
          if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time == 0f) {
            this.TargetStudent.CharacterAnimation[this.TargetStudent.PhoneAnim].weight = 0f;
            this.EquippedWeapon.gameObject.GetComponent<AudioSource>().Play();
          }
          if (this.AttackPhase == 1) {
            if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.333333343f) {
              this.TargetStudent.LiquidProjector.enabled = true;
              this.EquippedWeapon.Effect();
              this.StainWeapon();
              this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[1];
              this.Bloodiness += 20f;
              this.AttackPhase++;
            }
          } else if (this.AttackPhase < 6 && this.CharacterAnimation["f02_buzzSawKill_A_00"].time > 0.333333343f * (float)this.AttackPhase) {
            this.TargetStudent.LiquidProjector.material.mainTexture = this.BloodTextures[this.AttackPhase];
            this.Bloodiness += 20f;
            this.AttackPhase++;
          }
          if (this.CharacterAnimation["f02_buzzSawKill_A_00"].time > this.CharacterAnimation["f02_buzzSawKill_A_00"].length) {
            if (this.TargetStudent == this.StudentManager.Reporter) {
              this.StudentManager.Reporter = null;
            }
            this.CharacterAnimation["f02_buzzSawKill_A_00"].time = 0f;
            this.CharacterAnimation.Stop("f02_buzzSawKill_A_00");
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.MyController.radius = 0.2f;
            this.Attacking = false;
            this.AttackPhase = 1;
            this.Sanity -= 20f * this.Numbness;
            this.TargetStudent.DeathType = DeathType.Weapon;
            this.TargetStudent.BecomeRagdoll();
            if (!this.Noticed) {
              this.CanMove = true;
            } else {
              this.EquippedWeapon.Drop();
            }
          }
        } else if (!this.EquippedWeapon.Concealable) {
          if (this.AttackPhase == 1) {
            this.CharacterAnimation.CrossFade("f02_swingA_00");
            if (this.CharacterAnimation["f02_swingA_00"].time > this.CharacterAnimation["f02_swingA_00"].length * 0.3f) {
              if (this.TargetStudent == this.StudentManager.Reporter) {
                this.StudentManager.Reporter = null;
              }
              UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
              this.EquippedWeapon.Effect();
              this.AttackPhase = 2;
              this.Bloodiness += 20f;
              this.StainWeapon();
              this.Sanity -= 20f * this.Numbness;
            }
          } else if (this.CharacterAnimation["f02_swingA_00"].time >= this.CharacterAnimation["f02_swingA_00"].length * 0.9f) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.TargetStudent.DeathType = DeathType.Weapon;
            this.TargetStudent.BecomeRagdoll();
            this.MyController.radius = 0.2f;
            this.Attacking = false;
            this.AttackPhase = 1;
            this.AttackTimer = 0f;
            if (!this.Noticed) {
              this.CanMove = true;
            } else {
              this.EquippedWeapon.Drop();
            }
          }
        } else if (this.AttackPhase == 1) {
          this.CharacterAnimation.CrossFade("f02_stab_00");
          if (this.CharacterAnimation["f02_stab_00"].time > this.CharacterAnimation["f02_stab_00"].length * 0.35f) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            if (this.EquippedWeapon.Flaming) {
              this.TargetStudent.Combust();
            } else if (this.CanTranq && !this.TargetStudent.Male && this.TargetStudent.Club != ClubType.Council) {
              this.TargetStudent.Tranquil = true;
              this.CanTranq = false;
              this.Followers--;
            } else {
              this.TargetStudent.BloodSpray.SetActive(true);
              this.TargetStudent.DeathType = DeathType.Weapon;
              this.Bloodiness += 20f;
            }
            if (this.TargetStudent == this.StudentManager.Reporter) {
              this.StudentManager.Reporter = null;
            }
            AudioSource.PlayClipAtPoint(this.Stabs[UnityEngine.Random.Range(0, this.Stabs.Length)], base.transform.position + Vector3.up);
            UnityEngine.Object.Destroy(this.TargetStudent.DeathScream);
            this.AttackPhase = 2;
            this.Sanity -= 20f * this.Numbness;
            if (this.EquippedWeapon.WeaponID == 8) {
              this.TargetStudent.Ragdoll.Sacrifice = true;
              if (GameGlobals.Paranormal) {
                this.EquippedWeapon.Effect();
              }
            }
          }
        } else {
          this.AttackTimer += Time.deltaTime;
          if (this.AttackTimer > 0.3f) {
            if (!this.CanTranq) {
              this.StainWeapon();
            }
            this.MyController.radius = 0.2f;
            this.SanityBased = true;
            this.Attacking = false;
            this.AttackPhase = 1;
            this.AttackTimer = 0f;
            if (!this.Noticed) {
              this.CanMove = true;
            } else {
              this.EquippedWeapon.Drop();
            }
          }
        }
      }
    }
  }

  // Token: 0x0600097B RID: 2427 RVA: 0x000ADC88 File Offset: 0x000AC088
  private void UpdateSlouch() {
    if (this.CanMove && !this.Attacking && !this.Dragging && this.PickUp == null && !this.Aiming && this.Stance.Current != StanceType.Crawling && !this.Possessed && !this.Carrying && !this.CirnoWings.activeInHierarchy && this.LaughIntensity < 16f) {
      this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 1f - this.Sanity / 100f, Time.deltaTime * 10f);
      if (this.Hairstyle == 2 && this.Stance.Current == StanceType.Crouching) {
        this.Slouch = Mathf.Lerp(this.Slouch, 0f, Time.deltaTime * 20f);
      } else {
        this.Slouch = Mathf.Lerp(this.Slouch, 5f * (1f - this.Sanity / 100f), Time.deltaTime * 10f);
      }
    } else {
      this.CharacterAnimation["f02_yanderePose_00"].weight = Mathf.Lerp(this.CharacterAnimation["f02_yanderePose_00"].weight, 0f, Time.deltaTime * 10f);
      this.Slouch = Mathf.Lerp(this.Slouch, 0f, Time.deltaTime * 10f);
    }
  }

  // Token: 0x0600097C RID: 2428 RVA: 0x000ADE44 File Offset: 0x000AC244
  private void UpdateTwitch() {
    if (this.Sanity < 100f) {
      this.TwitchTimer += Time.deltaTime;
      if (this.TwitchTimer > this.NextTwitch) {
        this.Twitch = new Vector3((1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f));
        this.NextTwitch = UnityEngine.Random.Range(0f, 1f);
        this.TwitchTimer = 0f;
      }
      this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
    }
  }

  // Token: 0x0600097D RID: 2429 RVA: 0x000ADF38 File Offset: 0x000AC338
  private void UpdateWarnings() {
    if (this.NearBodies > 0) {
      if (!this.CorpseWarning) {
        this.NotificationManager.DisplayNotification(NotificationType.Body);
        this.StudentManager.UpdateStudents();
        this.CorpseWarning = true;
      }
    } else if (this.CorpseWarning) {
      this.StudentManager.UpdateStudents();
      this.CorpseWarning = false;
    }
  }

  // Token: 0x0600097E RID: 2430 RVA: 0x000ADF9C File Offset: 0x000AC39C
  private void UpdateDebugFunctionality() {
    if (!this.EasterEggMenu.activeInHierarchy) {
      if (!this.Aiming && this.CanMove && Time.timeScale > 0f && Input.GetKeyDown(KeyCode.Escape)) {
        this.PauseScreen.JumpToQuit();
      }
      if (Input.GetKeyDown(KeyCode.P)) {
        this.CyborgParts[1].SetActive(false);
        this.MemeGlasses.SetActive(false);
        this.KONGlasses.SetActive(false);
        this.EyepatchR.SetActive(false);
        this.EyepatchL.SetActive(false);
        this.EyewearID++;
        if (this.EyewearID == 1) {
          this.EyepatchR.SetActive(true);
        } else if (this.EyewearID == 2) {
          this.EyepatchL.SetActive(true);
        } else if (this.EyewearID == 3) {
          this.EyepatchR.SetActive(true);
          this.EyepatchL.SetActive(true);
        } else if (this.EyewearID == 4) {
          this.KONGlasses.SetActive(true);
        } else if (this.EyewearID == 5) {
          this.MemeGlasses.SetActive(true);
        } else if (this.EyewearID == 6) {
          if (this.CyborgParts[2].activeInHierarchy) {
            this.CyborgParts[1].SetActive(true);
          } else {
            this.EyewearID = 0;
          }
        } else {
          this.EyewearID = 0;
        }
      }
      if (Input.GetKeyDown(KeyCode.H)) {
        if (Input.GetButton("LB")) {
          this.Hairstyle += 10;
        } else {
          this.Hairstyle++;
        }
        this.UpdateHair();
      }
      if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.LeftArrow)) {
        this.Hairstyle--;
        this.UpdateHair();
      }
      if (Input.GetKeyDown(KeyCode.O) && !this.EasterEggMenu.activeInHierarchy) {
        if (this.AccessoryID > 0) {
          this.Accessories[this.AccessoryID].SetActive(false);
        }
        if (Input.GetButton("LB")) {
          this.AccessoryID += 10;
        } else {
          this.AccessoryID++;
        }
        this.UpdateAccessory();
      }
      if (Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.LeftArrow)) {
        if (this.AccessoryID > 0) {
          this.Accessories[this.AccessoryID].SetActive(false);
        }
        this.AccessoryID--;
        this.UpdateAccessory();
      }
      if (!this.NoDebug && !this.DebugMenu.activeInHierarchy && this.CanMove) {
        if (Input.GetKeyDown("-")) {
          if (Time.timeScale < 6f) {
            Time.timeScale = 1f;
          } else {
            Time.timeScale -= 5f;
          }
        }
        if (Input.GetKeyDown("=")) {
          if (Time.timeScale < 5f) {
            Time.timeScale = 5f;
          } else {
            Time.timeScale += 5f;
            if (Time.timeScale > 25f) {
              Time.timeScale = 25f;
            }
          }
        }
      }
      if (Input.GetKey(KeyCode.Period)) {
        this.BreastSize += Time.deltaTime;
        if (this.BreastSize > 2f) {
          this.BreastSize = 2f;
        }
        this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      }
      if (Input.GetKey(KeyCode.Comma)) {
        this.BreastSize -= Time.deltaTime;
        if (this.BreastSize < 0.5f) {
          this.BreastSize = 0.5f;
        }
        this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      }
    }
    if (!this.NoDebug) {
      if (this.CanMove && !this.Egg && base.transform.position.y < 1000f) {
        if (Input.GetKeyDown(KeyCode.Slash)) {
          this.DebugMenu.SetActive(false);
          this.EasterEggMenu.SetActive(!this.EasterEggMenu.activeInHierarchy);
        }
        if (this.EasterEggMenu.activeInHierarchy && !this.Egg) {
          if (Input.GetKeyDown(KeyCode.P)) {
            this.Punish();
          } else if (Input.GetKeyDown(KeyCode.Z)) {
            this.Slend();
          } else if (Input.GetKeyDown(KeyCode.B)) {
            this.Sukeban();
          } else if (Input.GetKeyDown(KeyCode.C)) {
            this.Cirno();
          } else if (Input.GetKeyDown(KeyCode.H)) {
            this.EmptyHands();
            this.Hate();
          } else if (Input.GetKeyDown(KeyCode.T)) {
            this.StudentManager.AttackOnTitan();
            this.AttackOnTitan();
          } else if (Input.GetKeyDown(KeyCode.G)) {
            this.GaloSengen();
          } else if (!Input.GetKeyDown(KeyCode.J)) {
            if (Input.GetKeyDown(KeyCode.K)) {
              this.EasterEggMenu.SetActive(false);
              this.StudentManager.Kong();
              this.DK = true;
            } else if (Input.GetKeyDown(KeyCode.L)) {
              this.Agent();
            } else if (Input.GetKeyDown(KeyCode.N)) {
              this.Nude();
            } else if (Input.GetKeyDown(KeyCode.S)) {
              this.EasterEggMenu.SetActive(false);
              this.Egg = true;
              this.StudentManager.Spook();
            } else if (Input.GetKeyDown(KeyCode.F)) {
              this.EasterEggMenu.SetActive(false);
              this.Falcon();
            } else if (Input.GetKeyDown(KeyCode.X)) {
              this.EasterEggMenu.SetActive(false);
              this.X();
            } else if (Input.GetKeyDown(KeyCode.O)) {
              this.EasterEggMenu.SetActive(false);
              this.Punch();
            } else if (Input.GetKeyDown(KeyCode.U)) {
              this.EasterEggMenu.SetActive(false);
              this.BadTime();
            } else if (Input.GetKeyDown(KeyCode.Y)) {
              this.EasterEggMenu.SetActive(false);
              this.CyborgNinja();
            } else if (Input.GetKeyDown(KeyCode.E)) {
              this.EasterEggMenu.SetActive(false);
              this.Ebola();
            } else if (Input.GetKeyDown(KeyCode.Q)) {
              this.EasterEggMenu.SetActive(false);
              this.Samus();
            } else if (!Input.GetKeyDown(KeyCode.W)) {
              if (Input.GetKeyDown(KeyCode.R)) {
                this.EasterEggMenu.SetActive(false);
                this.Pose();
              } else if (Input.GetKeyDown(KeyCode.V)) {
                this.EasterEggMenu.SetActive(false);
                this.Long();
              } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                this.EasterEggMenu.SetActive(false);
                this.HairBlades();
              } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
                this.EasterEggMenu.SetActive(false);
                this.Tornado();
              } else if (Input.GetKeyDown(KeyCode.Alpha8)) {
                this.EasterEggMenu.SetActive(false);
                this.GenderSwap();
              } else if (Input.GetKeyDown("[5]")) {
                this.EasterEggMenu.SetActive(false);
                this.SwapMesh();
              } else if (Input.GetKeyDown(KeyCode.A)) {
                this.StudentManager.ChangeOka();
                this.EasterEggMenu.SetActive(false);
              } else if (Input.GetKeyDown(KeyCode.I)) {
                this.StudentManager.NoGravity = true;
                this.EasterEggMenu.SetActive(false);
              } else if (!Input.GetKeyDown(KeyCode.D)) {
                if (Input.GetKeyDown(KeyCode.M)) {
                  this.EasterEggMenu.SetActive(false);
                  this.Snake();
                } else if (Input.GetKeyDown(KeyCode.Alpha1)) {
                  this.EasterEggMenu.SetActive(false);
                  this.Gazer();
                } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                  this.EasterEggMenu.SetActive(false);
                  this.Six();
                } else if (Input.GetKeyDown(KeyCode.Space)) {
                }
              }
            }
          }
        }
      }
    } else if (Input.GetKeyDown(KeyCode.Z)) {
      this.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
    }
  }

  // Token: 0x0600097F RID: 2431 RVA: 0x000AE8CC File Offset: 0x000ACCCC
  private void LateUpdate() {
    this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
    this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
    this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
    this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
    this.ID = 0;
    while (this.ID < this.Spine.Length) {
      Transform transform = this.Spine[this.ID].transform;
      transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + this.Slouch, transform.localEulerAngles.y, transform.localEulerAngles.z);
      this.ID++;
    }
    if (this.Aiming) {
      Transform transform2 = this.Spine[3].transform;
      transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x - this.Bend, transform2.localEulerAngles.y, transform2.localEulerAngles.z);
    }
    Transform transform3 = this.Arm[0].transform;
    transform3.localEulerAngles = new Vector3(transform3.localEulerAngles.x, transform3.localEulerAngles.y, transform3.localEulerAngles.z - this.Slouch * 3f);
    Transform transform4 = this.Arm[1].transform;
    transform4.localEulerAngles = new Vector3(transform4.localEulerAngles.x, transform4.localEulerAngles.y, transform4.localEulerAngles.z + this.Slouch * 3f);
    if (!this.Aiming) {
      this.Head.localEulerAngles += this.Twitch;
    }
    if (this.Aiming) {
      if (this.Stance.Current == StanceType.Crawling) {
        this.TargetHeight = -1.4f;
      } else if (this.Stance.Current == StanceType.Crouching) {
        this.TargetHeight = -0.6f;
      } else {
        this.TargetHeight = 0f;
      }
      this.Height = Mathf.Lerp(this.Height, this.TargetHeight, Time.deltaTime * 10f);
      this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, this.Height, this.PelvisRoot.transform.localPosition.z);
    }
    if (this.Slender) {
      Transform transform5 = this.Leg[0];
      transform5.localScale = new Vector3(transform5.localScale.x, 2f, transform5.localScale.z);
      Transform transform6 = this.Foot[0];
      transform6.localScale = new Vector3(transform6.localScale.x, 0.5f, transform6.localScale.z);
      Transform transform7 = this.Leg[1];
      transform7.localScale = new Vector3(transform7.localScale.x, 2f, transform7.localScale.z);
      Transform transform8 = this.Foot[1];
      transform8.localScale = new Vector3(transform8.localScale.x, 0.5f, transform8.localScale.z);
      Transform transform9 = this.Arm[0];
      transform9.localScale = new Vector3(2f, transform9.localScale.y, transform9.localScale.z);
      Transform transform10 = this.Arm[1];
      transform10.localScale = new Vector3(2f, transform10.localScale.y, transform10.localScale.z);
    }
    if (this.DK) {
      this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
      this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
      this.Head.localScale = new Vector3(2f, 2f, 2f);
    }
    if (this.CirnoWings.activeInHierarchy) {
      if (Input.GetButton("LB")) {
        this.FlapSpeed = 5f;
      } else if (this.FlapSpeed == 0f) {
        this.FlapSpeed = 1f;
      } else {
        this.FlapSpeed = 3f;
      }
      Transform transform11 = this.CirnoWing[0];
      Transform transform12 = this.CirnoWing[1];
      if (!this.FlapOut) {
        this.CirnoRotation += Time.deltaTime * 100f * this.FlapSpeed;
        transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, this.CirnoRotation, transform11.localEulerAngles.z);
        transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, -this.CirnoRotation, transform12.localEulerAngles.z);
        if (this.CirnoRotation > 15f) {
          this.FlapOut = true;
        }
      } else {
        this.CirnoRotation -= Time.deltaTime * 100f * this.FlapSpeed;
        transform11.localEulerAngles = new Vector3(transform11.localEulerAngles.x, this.CirnoRotation, transform11.localEulerAngles.z);
        transform12.localEulerAngles = new Vector3(transform12.localEulerAngles.x, -this.CirnoRotation, transform12.localEulerAngles.z);
        if (this.CirnoRotation < -15f) {
          this.FlapOut = false;
        }
      }
    }
  }

  // Token: 0x06000980 RID: 2432 RVA: 0x000AF014 File Offset: 0x000AD414
  public void StainWeapon() {
    if (this.EquippedWeapon != null) {
      if (this.TargetStudent != null && this.TargetStudent.StudentID < this.EquippedWeapon.Victims.Length) {
        this.EquippedWeapon.Victims[this.TargetStudent.StudentID] = true;
      }
      this.EquippedWeapon.Blood.enabled = true;
      if (this.Gloved && !this.Gloves.Blood.enabled) {
        this.Gloves.PickUp.Evidence = true;
        this.Gloves.Blood.enabled = true;
        this.Police.BloodyClothing++;
      }
      if (this.Mask != null && !this.Mask.Blood.enabled) {
        this.Mask.PickUp.Evidence = true;
        this.Mask.Blood.enabled = true;
        this.Police.BloodyClothing++;
      }
      if (!this.EquippedWeapon.Evidence) {
        this.EquippedWeapon.Evidence = true;
        this.Police.MurderWeapons++;
      }
    }
  }

  // Token: 0x06000981 RID: 2433 RVA: 0x000AF168 File Offset: 0x000AD568
  public void MoveTowardsTarget(Vector3 target) {
    Vector3 a = target - base.transform.position;
    this.MyController.Move(a * (Time.deltaTime * 10f));
  }

  // Token: 0x06000982 RID: 2434 RVA: 0x000AF1A4 File Offset: 0x000AD5A4
  public void StopAiming() {
    this.UpdateAccessory();
    this.UpdateHair();
    this.CharacterAnimation["f02_cameraPose_00"].weight = 0f;
    this.PelvisRoot.transform.localPosition = new Vector3(this.PelvisRoot.transform.localPosition.x, 0f, this.PelvisRoot.transform.localPosition.z);
    this.ShoulderCamera.AimingCamera = false;
    if (!Input.GetButtonDown("Start") && !Input.GetKeyDown(KeyCode.Escape)) {
      this.FixCamera();
    }
    if (this.ShoulderCamera.Timer == 0f) {
      this.RPGCamera.enabled = true;
    }
    if (!OptionGlobals.Fog) {
      this.MainCamera.clearFlags = CameraClearFlags.Skybox;
    }
    this.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
    this.Smartphone.transform.parent.gameObject.SetActive(false);
    this.PhonePromptBar.Show = false;
    this.Smartphone.fieldOfView = 60f;
    this.Shutter.TargetStudent = 0;
    this.HandCamera.SetActive(false);
    this.UsingController = false;
    this.Aiming = false;
    this.Lewd = false;
    this.Height = 0f;
    this.Bend = 0f;
  }

  // Token: 0x06000983 RID: 2435 RVA: 0x000AF310 File Offset: 0x000AD710
  public void FixCamera() {
    this.RPGCamera.enabled = true;
    this.RPGCamera.UpdateRotation();
    this.RPGCamera.mouseSmoothingFactor = 0f;
    this.RPGCamera.GetInput();
    this.RPGCamera.GetDesiredPosition();
    this.RPGCamera.PositionUpdate();
    this.RPGCamera.mouseSmoothingFactor = 0.08f;
    this.Blur.enabled = false;
  }

  // Token: 0x06000984 RID: 2436 RVA: 0x000AF384 File Offset: 0x000AD784
  private void ResetSenpaiEffects() {
    this.DepthOfField.focalSize = 150f;
    this.DepthOfField.focalZStartCurve = 0f;
    this.DepthOfField.focalZEndCurve = 0f;
    this.DepthOfField.enabled = false;
    this.ColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
    this.ColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
    this.ColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
    this.ColorCorrection.redChannel.SmoothTangents(1, 0f);
    this.ColorCorrection.greenChannel.SmoothTangents(1, 0f);
    this.ColorCorrection.blueChannel.SmoothTangents(1, 0f);
    this.ColorCorrection.UpdateTextures();
    this.ColorCorrection.enabled = false;
    this.CharacterAnimation["f02_shy_00"].weight = 0f;
    this.HeartBeat.volume = 0f;
    this.SelectGrayscale.desaturation = this.GreyTarget;
    this.SenpaiFade = 100f;
  }

  // Token: 0x06000985 RID: 2437 RVA: 0x000AF4D0 File Offset: 0x000AD8D0
  private void ResetYandereEffects() {
    this.Vignette.intensity = 0f;
    this.Vignette.blur = 0f;
    this.Vignette.chromaticAberration = 0f;
    this.Vignette.enabled = false;
    this.YandereColorCorrection.redChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
    this.YandereColorCorrection.greenChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
    this.YandereColorCorrection.blueChannel.MoveKey(1, new Keyframe(0.5f, 0.5f));
    this.YandereColorCorrection.redChannel.SmoothTangents(1, 0f);
    this.YandereColorCorrection.greenChannel.SmoothTangents(1, 0f);
    this.YandereColorCorrection.blueChannel.SmoothTangents(1, 0f);
    this.YandereColorCorrection.UpdateTextures();
    this.YandereColorCorrection.enabled = false;
    Time.timeScale = 1f;
    this.YandereFade = 100f;
  }

  // Token: 0x06000986 RID: 2438 RVA: 0x000AF5EC File Offset: 0x000AD9EC
  private void DumpRagdoll(RagdollDumpType Type) {
    this.Ragdoll.transform.position = base.transform.position;
    if (Type == RagdollDumpType.Incinerator) {
      this.Ragdoll.transform.LookAt(this.Incinerator.transform.position);
      this.Ragdoll.transform.eulerAngles = new Vector3(this.Ragdoll.transform.eulerAngles.x, this.Ragdoll.transform.eulerAngles.y + 180f, this.Ragdoll.transform.eulerAngles.z);
    } else if (Type == RagdollDumpType.TranqCase) {
      this.Ragdoll.transform.LookAt(this.TranqCase.transform.position);
    } else if (Type == RagdollDumpType.WoodChipper) {
      this.Ragdoll.transform.LookAt(this.WoodChipper.transform.position);
    }
    RagdollScript component = this.Ragdoll.GetComponent<RagdollScript>();
    component.DumpType = Type;
    component.Dump();
  }

  // Token: 0x06000987 RID: 2439 RVA: 0x000AF710 File Offset: 0x000ADB10
  public void Unequip() {
    if (this.CanMove || this.Noticed) {
      if (this.Equipped < 3) {
        if (this.EquippedWeapon != null) {
          this.EquippedWeapon.gameObject.SetActive(false);
        }
      } else {
        this.Weapon[3].Drop();
      }
      this.Equipped = 0;
      this.Mopping = false;
      this.StudentManager.UpdateStudents();
      this.WeaponManager.UpdateLabels();
      this.WeaponMenu.UpdateSprites();
      this.WeaponWarning = false;
    }
  }

  // Token: 0x06000988 RID: 2440 RVA: 0x000AF7AC File Offset: 0x000ADBAC
  public void DropWeapon(int ID) {
    this.DropTimer[ID] += Time.deltaTime;
    if (this.DropTimer[ID] > 0.5f) {
      this.Weapon[ID].Drop();
      this.Weapon[ID] = null;
      this.Unequip();
      this.DropTimer[ID] = 0f;
    }
  }

  // Token: 0x06000989 RID: 2441 RVA: 0x000AF80C File Offset: 0x000ADC0C
  public void EmptyHands() {
    if (this.Carrying || this.HeavyWeight) {
      this.StopCarrying();
    }
    if (this.Armed) {
      this.Unequip();
    }
    if (this.PickUp != null) {
      this.PickUp.Drop();
    }
    if (this.Dragging) {
      this.Ragdoll.GetComponent<RagdollScript>().StopDragging();
    }
    this.Mopping = false;
  }

  // Token: 0x0600098A RID: 2442 RVA: 0x000AF884 File Offset: 0x000ADC84
  public void UpdateNumbness() {
    this.Numbness = 1f - 0.1f * (float)(PlayerGlobals.Numbness + PlayerGlobals.NumbnessBonus);
  }

  // Token: 0x0600098B RID: 2443 RVA: 0x000AF8A4 File Offset: 0x000ADCA4
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "BloodPool(Clone)" && other.transform.localScale.x > 0.3f) {
      if (PlayerGlobals.PantiesEquipped == 8) {
        this.RightFootprintSpawner.Bloodiness = 5;
        this.LeftFootprintSpawner.Bloodiness = 5;
      } else {
        this.RightFootprintSpawner.Bloodiness = 10;
        this.LeftFootprintSpawner.Bloodiness = 10;
      }
    }
  }

  // Token: 0x0600098C RID: 2444 RVA: 0x000AF92C File Offset: 0x000ADD2C
  public void UpdateHair() {
    if (this.Hairstyle > this.Hairstyles.Length - 1) {
      this.Hairstyle = 0;
    }
    if (this.Hairstyle < 0) {
      this.Hairstyle = this.Hairstyles.Length - 1;
    }
    this.ID = 1;
    while (this.ID < this.Hairstyles.Length) {
      this.Hairstyles[this.ID].SetActive(false);
      this.ID++;
    }
    if (this.Hairstyle > 0) {
      this.Hairstyles[this.Hairstyle].SetActive(true);
    }
  }

  // Token: 0x0600098D RID: 2445 RVA: 0x000AF9D0 File Offset: 0x000ADDD0
  public void StopLaughing() {
    this.BladeHairCollider1.enabled = false;
    this.BladeHairCollider2.enabled = false;
    this.LaughIntensity = 0f;
    this.Laughing = false;
    this.LaughClip = null;
    if (!this.Stand.Stand.activeInHierarchy) {
      this.CanMove = true;
    }
  }

  // Token: 0x0600098E RID: 2446 RVA: 0x000AFA2C File Offset: 0x000ADE2C
  private void SetUniform() {
    if (StudentGlobals.FemaleUniform == 0) {
      StudentGlobals.FemaleUniform = 1;
    }
    this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
    if (this.Casual) {
      this.TextureToUse = this.UniformTextures[StudentGlobals.FemaleUniform];
    } else {
      this.TextureToUse = this.CasualTextures[StudentGlobals.FemaleUniform];
    }
    this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
    this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    base.StartCoroutine(this.ApplyCustomCostume());
  }

  // Token: 0x0600098F RID: 2447 RVA: 0x000AFAEC File Offset: 0x000ADEEC
  private IEnumerator ApplyCustomCostume() {
    if (StudentGlobals.FemaleUniform == 1) {
      WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
      yield return CustomUniform;
      if (CustomUniform.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
        this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
      }
    } else if (StudentGlobals.FemaleUniform == 2) {
      WWW CustomLong = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
      yield return CustomLong;
      if (CustomLong.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomLong.texture;
        this.MyRenderer.materials[1].mainTexture = CustomLong.texture;
      }
    } else if (StudentGlobals.FemaleUniform == 3) {
      WWW CustomSweater = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
      yield return CustomSweater;
      if (CustomSweater.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomSweater.texture;
        this.MyRenderer.materials[1].mainTexture = CustomSweater.texture;
      }
    } else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5) {
      WWW CustomBlazer = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
      yield return CustomBlazer;
      if (CustomBlazer.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomBlazer.texture;
        this.MyRenderer.materials[1].mainTexture = CustomBlazer.texture;
      }
    }
    WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
    yield return CustomFace;
    if (CustomFace.error == null) {
      this.MyRenderer.materials[2].mainTexture = CustomFace.texture;
      this.FaceTexture = CustomFace.texture;
    }
    WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
    yield return CustomHair;
    if (CustomHair.error == null) {
      this.PonytailRenderer.material.mainTexture = CustomHair.texture;
      this.PigtailR.material.mainTexture = CustomHair.texture;
      this.PigtailL.material.mainTexture = CustomHair.texture;
    }
    WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
    yield return CustomDrills;
    if (CustomDrills.error == null) {
      this.Drills.materials[0].mainTexture = CustomDrills.texture;
      this.Drills.material.mainTexture = CustomDrills.texture;
    }
    WWW CustomSwimsuit = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSwimsuit.png");
    yield return CustomSwimsuit;
    if (CustomSwimsuit.error == null) {
      this.SwimsuitTexture = CustomSwimsuit.texture;
    }
    WWW CustomGym = new WWW("file:///" + Application.streamingAssetsPath + "/CustomGym.png");
    yield return CustomGym;
    if (CustomGym.error == null) {
      this.GymTexture = CustomGym.texture;
    }
    WWW CustomNude = new WWW("file:///" + Application.streamingAssetsPath + "/CustomNude.png");
    yield return CustomNude;
    if (CustomNude.error == null) {
      this.NudeTexture = CustomNude.texture;
    }
    WWW CustomLongHairA = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairA.png");
    yield return CustomDrills;
    WWW CustomLongHairB = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairB.png");
    yield return CustomDrills;
    WWW CustomLongHairC = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLongHairC.png");
    yield return CustomDrills;
    if (CustomLongHairA.error == null && CustomLongHairB.error == null && CustomLongHairC.error == null) {
      this.LongHairRenderer.materials[0].mainTexture = CustomLongHairA.texture;
      this.LongHairRenderer.materials[1].mainTexture = CustomLongHairB.texture;
      this.LongHairRenderer.materials[2].mainTexture = CustomLongHairC.texture;
    }
    yield break;
  }

  // Token: 0x06000990 RID: 2448 RVA: 0x000AFB08 File Offset: 0x000ADF08
  public void WearGloves() {
    if (this.Bloodiness > 0f && !this.Gloves.Blood.enabled) {
      this.Gloves.PickUp.Evidence = true;
      this.Gloves.Blood.enabled = true;
      this.Police.BloodyClothing++;
    }
    this.Gloved = true;
    if (StudentGlobals.FemaleUniform == 1) {
      this.MyRenderer.materials[1].mainTexture = this.GloveTextures[StudentGlobals.FemaleUniform];
    } else {
      this.MyRenderer.materials[0].mainTexture = this.GloveTextures[StudentGlobals.FemaleUniform];
    }
  }

  // Token: 0x06000991 RID: 2449 RVA: 0x000AFBC4 File Offset: 0x000ADFC4
  private void AttackOnTitan() {
    this.MusicCredit.SongLabel.text = "Now Playing: This Is My Choice";
    this.MusicCredit.BandLabel.text = "By: The Kira Justice";
    this.MusicCredit.Panel.enabled = true;
    this.MusicCredit.Slide = true;
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.TitanTexture;
    this.MyRenderer.materials[1].mainTexture = this.TitanTexture;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.Outline.h.ReinitMaterials();
  }

  // Token: 0x06000992 RID: 2450 RVA: 0x000AFC98 File Offset: 0x000AE098
  private void KON() {
    this.MyRenderer.sharedMesh = this.Uniforms[4];
    this.MyRenderer.materials[0].mainTexture = this.KONTexture;
    this.MyRenderer.materials[1].mainTexture = this.KONTexture;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.Outline.h.ReinitMaterials();
  }

  // Token: 0x06000993 RID: 2451 RVA: 0x000AFD10 File Offset: 0x000AE110
  private void Punish() {
    this.PunishedShader = Shader.Find("Toon/Cutoff");
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    this.PunishedAccessories.SetActive(true);
    this.PunishedScarf.SetActive(true);
    this.EyepatchL.SetActive(false);
    this.EyepatchR.SetActive(false);
    this.ID = 0;
    while (this.ID < this.PunishedArm.Length) {
      this.PunishedArm[this.ID].SetActive(true);
      this.ID++;
    }
    this.MyRenderer.sharedMesh = this.PunishedMesh;
    this.MyRenderer.materials[0].mainTexture = this.PunishedTextures[1];
    this.MyRenderer.materials[1].mainTexture = this.PunishedTextures[1];
    this.MyRenderer.materials[2].mainTexture = this.PunishedTextures[0];
    this.MyRenderer.materials[1].shader = this.PunishedShader;
    this.MyRenderer.materials[1].SetFloat("_Shininess", 1f);
    this.MyRenderer.materials[1].SetFloat("_ShadowThreshold", 0f);
    this.MyRenderer.materials[1].SetFloat("_Cutoff", 0.9f);
    this.Outline.h.ReinitMaterials();
  }

  // Token: 0x06000994 RID: 2452 RVA: 0x000AFE8C File Offset: 0x000AE28C
  private void Hate() {
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.HatefulUniform;
    this.MyRenderer.materials[1].mainTexture = this.HatefulUniform;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    RenderSettings.skybox = this.HatefulSkybox;
    this.SelectGrayscale.desaturation = 1f;
    this.HeartRate.gameObject.SetActive(false);
    this.Sanity = 0f;
    this.Hairstyle = 15;
    this.UpdateHair();
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
  }

  // Token: 0x06000995 RID: 2453 RVA: 0x000AFF4C File Offset: 0x000AE34C
  private void Sukeban() {
    this.IdleAnim = "f02_idle_00";
    this.SukebanAccessories.SetActive(true);
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[1].mainTexture = this.SukebanBandages;
    this.MyRenderer.materials[0].mainTexture = this.SukebanUniform;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
  }

  // Token: 0x06000996 RID: 2454 RVA: 0x000AFFE0 File Offset: 0x000AE3E0
  private void Slend() {
    RenderSettings.skybox = this.SlenderSkybox;
    this.SelectGrayscale.desaturation = 0.5f;
    this.SelectGrayscale.enabled = true;
    this.EasterEggMenu.SetActive(false);
    this.Slender = true;
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.SlenderHair[0].transform.parent.gameObject.SetActive(true);
    this.SlenderHair[0].SetActive(true);
    this.SlenderHair[1].SetActive(true);
    this.RightYandereEye.gameObject.SetActive(false);
    this.LeftYandereEye.gameObject.SetActive(false);
    this.Character.transform.localPosition = new Vector3(this.Character.transform.localPosition.x, 0.822f, this.Character.transform.localPosition.z);
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.SlenderUniform;
    this.MyRenderer.materials[1].mainTexture = this.SlenderUniform;
    this.MyRenderer.materials[2].mainTexture = this.SlenderSkin;
    this.Sanity = 0f;
  }

  // Token: 0x06000997 RID: 2455 RVA: 0x000B0148 File Offset: 0x000AE548
  private void X() {
    this.Xtan = true;
    this.Egg = true;
    this.Hairstyle = 9;
    this.UpdateHair();
    this.BlackEyePatch.SetActive(true);
    this.XSclera.SetActive(true);
    this.XEye.SetActive(true);
    this.Schoolwear = 2;
    this.ChangeSchoolwear();
    this.CanMove = true;
    this.MyRenderer.materials[0].mainTexture = this.XBody;
    this.MyRenderer.materials[1].mainTexture = this.XBody;
    this.MyRenderer.materials[2].mainTexture = this.XFace;
  }

  // Token: 0x06000998 RID: 2456 RVA: 0x000B01F4 File Offset: 0x000AE5F4
  private void GaloSengen() {
    this.IdleAnim = "f02_gruntIdle_00";
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    this.ID = 0;
    while (this.ID < this.GaloAccessories.Length) {
      this.GaloAccessories[this.ID].SetActive(true);
      this.ID++;
    }
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.UniformTextures[1];
    this.MyRenderer.materials[1].mainTexture = this.GaloArms;
    this.MyRenderer.materials[2].mainTexture = this.GaloFace;
    this.Hairstyle = 14;
    this.UpdateHair();
  }

  // Token: 0x06000999 RID: 2457 RVA: 0x000B02CC File Offset: 0x000AE6CC
  public void Jojo() {
    this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
    this.ShoulderCamera.Summoning = true;
    this.RPGCamera.enabled = false;
    AudioSource.PlayClipAtPoint(this.SummonStand, base.transform.position);
    this.IdleAnim = "f02_jojoPose_00";
    this.WalkAnim = "f02_jojoWalk_00";
    this.EasterEggMenu.SetActive(false);
    this.CanMove = false;
    this.Egg = true;
    this.CharacterAnimation.CrossFade("f02_summonStand_00");
    this.Laugh1 = this.YanYan;
    this.Laugh2 = this.YanYan;
    this.Laugh3 = this.YanYan;
    this.Laugh4 = this.YanYan;
  }

  // Token: 0x0600099A RID: 2458 RVA: 0x000B0394 File Offset: 0x000AE794
  private void Agent() {
    this.MyRenderer.sharedMesh = this.Uniforms[4];
    this.MyRenderer.materials[0].mainTexture = this.AgentSuit;
    this.MyRenderer.materials[1].mainTexture = this.AgentSuit;
    this.MyRenderer.materials[2].mainTexture = this.AgentFace;
    this.EasterEggMenu.SetActive(false);
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  // Token: 0x0600099B RID: 2459 RVA: 0x000B041C File Offset: 0x000AE81C
  private void Cirno() {
    this.MyRenderer.sharedMesh = this.Uniforms[3];
    this.MyRenderer.materials[0].mainTexture = this.CirnoUniform;
    this.MyRenderer.materials[1].mainTexture = this.CirnoUniform;
    this.MyRenderer.materials[2].mainTexture = this.CirnoFace;
    this.CirnoWings.SetActive(true);
    this.CirnoHair.SetActive(true);
    this.IdleAnim = "f02_cirnoIdle_00";
    this.WalkAnim = "f02_cirnoWalk_00";
    this.RunAnim = "f02_cirnoRun_00";
    this.EasterEggMenu.SetActive(false);
    this.Stance.Current = StanceType.Standing;
    this.Uncrouch();
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  // Token: 0x0600099C RID: 2460 RVA: 0x000B04F0 File Offset: 0x000AE8F0
  private void Falcon() {
    this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
    this.MyRenderer.materials[0].mainTexture = this.FalconBody;
    this.MyRenderer.materials[1].mainTexture = this.FalconBody;
    this.MyRenderer.materials[2].mainTexture = this.FalconFace;
    this.FalconShoulderpad.SetActive(true);
    this.FalconNipple1.SetActive(true);
    this.FalconNipple2.SetActive(true);
    this.FalconBuckle.SetActive(true);
    this.FalconHelmet.SetActive(true);
    this.FalconGun.SetActive(true);
    this.CharacterAnimation[this.RunAnim].speed = 5f;
    this.IdleAnim = "f02_falconIdle_00";
    this.RunSpeed *= 5f;
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  // Token: 0x0600099D RID: 2461 RVA: 0x000B05EC File Offset: 0x000AE9EC
  private void Punch() {
    this.MusicCredit.SongLabel.text = "Now Playing: Unknown Hero";
    this.MusicCredit.BandLabel.text = "By: The Kira Justice";
    this.MusicCredit.Panel.enabled = true;
    this.MusicCredit.Slide = true;
    this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
    this.MyRenderer.materials[0].mainTexture = this.SaitamaSuit;
    this.MyRenderer.materials[1].mainTexture = this.SaitamaSuit;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    this.EasterEggMenu.SetActive(false);
    this.Barcode.SetActive(false);
    this.Cape.SetActive(true);
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  // Token: 0x0600099E RID: 2462 RVA: 0x000B06D4 File Offset: 0x000AEAD4
  private void BadTime() {
    this.MyRenderer.sharedMesh = this.Jersey;
    this.MyRenderer.materials[0].mainTexture = this.SansFace;
    this.MyRenderer.materials[1].mainTexture = this.SansTexture;
    this.MyRenderer.materials[2].mainTexture = this.SansTexture;
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
    this.EasterEggMenu.SetActive(false);
    this.IdleAnim = "f02_sansIdle_00";
    this.WalkAnim = "f02_sansWalk_00";
    this.RunAnim = "f02_sansRun_00";
    this.StudentManager.BadTime();
    this.Barcode.SetActive(false);
    this.Sans = true;
    this.Egg = true;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  // Token: 0x0600099F RID: 2463 RVA: 0x000B07D4 File Offset: 0x000AEBD4
  private void CyborgNinja() {
    this.EnergySword.SetActive(true);
    this.IdleAnim = "CyborgNinja_Idle_Unarmed";
    this.RunAnim = "CyborgNinja_Run_Unarmed";
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.CyborgFace;
    this.MyRenderer.materials[1].mainTexture = this.CyborgBody;
    this.MyRenderer.materials[2].mainTexture = this.CyborgBody;
    this.ID = 1;
    while (this.ID < this.CyborgParts.Length) {
      this.CyborgParts[this.ID].SetActive(true);
      this.ID++;
    }
    this.ID = 1;
    while (this.ID < this.StudentManager.Students.Length) {
      StudentScript studentScript = this.StudentManager.Students[this.ID];
      if (studentScript != null) {
        studentScript.Teacher = false;
      }
      this.ID++;
    }
    this.RunSpeed *= 2f;
    this.EyewearID = 6;
    this.Hairstyle = 45;
    this.UpdateHair();
    this.Egg = true;
  }

  // Token: 0x060009A0 RID: 2464 RVA: 0x000B0924 File Offset: 0x000AED24
  private void Ebola() {
    this.IdleAnim = "f02_ebolaIdle_00";
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.EbolaUniform;
    this.MyRenderer.materials[1].mainTexture = this.EbolaUniform;
    this.MyRenderer.materials[2].mainTexture = this.EbolaFace;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.EbolaWings.SetActive(true);
    this.EbolaHair.SetActive(true);
    this.Egg = true;
  }

  // Token: 0x060009A1 RID: 2465 RVA: 0x000B09C3 File Offset: 0x000AEDC3
  private void Long() {
    this.MyRenderer.sharedMesh = this.LongUniform;
  }

  // Token: 0x060009A2 RID: 2466 RVA: 0x000B09D8 File Offset: 0x000AEDD8
  private void SwapMesh() {
    this.MyRenderer.sharedMesh = this.NewMesh;
    this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
    this.MyRenderer.materials[1].mainTexture = this.NewFace;
    this.MyRenderer.materials[2].mainTexture = this.TextureToUse;
    this.RightYandereEye.gameObject.SetActive(false);
    this.LeftYandereEye.gameObject.SetActive(false);
  }

  // Token: 0x060009A3 RID: 2467 RVA: 0x000B0A60 File Offset: 0x000AEE60
  private void Nude() {
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.ID = 0;
    while (this.ID < this.CensorSteam.Length) {
      this.CensorSteam[this.ID].SetActive(true);
      this.ID++;
    }
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
    this.EasterEggMenu.SetActive(false);
    this.ClubAttire = false;
    this.Schoolwear = 0;
    this.ClubAccessory();
  }

  // Token: 0x060009A4 RID: 2468 RVA: 0x000B0B48 File Offset: 0x000AEF48
  private void Samus() {
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.SamusFace;
    this.MyRenderer.materials[1].mainTexture = this.SamusBody;
    this.PonytailRenderer.material.mainTexture = this.SamusFace;
    this.Egg = true;
  }

  // Token: 0x060009A5 RID: 2469 RVA: 0x000B0BB4 File Offset: 0x000AEFB4
  private void Witch() {
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.WitchFace;
    this.MyRenderer.materials[1].mainTexture = this.WitchBody;
    this.PonytailRenderer.material.mainTexture = this.WitchFace;
    this.Egg = true;
  }

  // Token: 0x060009A6 RID: 2470 RVA: 0x000B0C1F File Offset: 0x000AF01F
  private void Pose() {
    if (!this.StudentManager.Pose) {
      this.StudentManager.Pose = true;
    } else {
      this.StudentManager.Pose = false;
    }
    this.StudentManager.UpdateStudents();
  }

  // Token: 0x060009A7 RID: 2471 RVA: 0x000B0C59 File Offset: 0x000AF059
  private void HairBlades() {
    this.Hairstyle = 0;
    this.UpdateHair();
    this.BladeHair.SetActive(true);
    this.Egg = true;
  }

  // Token: 0x060009A8 RID: 2472 RVA: 0x000B0C7C File Offset: 0x000AF07C
  private void Tornado() {
    this.Hairstyle = 0;
    this.UpdateHair();
    this.IdleAnim = "f02_tornadoIdle_00";
    this.WalkAnim = "f02_tornadoWalk_00";
    this.RunAnim = "f02_tornadoRun_00";
    this.TornadoHair.SetActive(true);
    this.TornadoDress.SetActive(true);
    this.RiggedAccessory.SetActive(true);
    this.MyRenderer.sharedMesh = this.NoTorsoMesh;
    this.Sanity = 100f;
    this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudePanties;
    this.MyRenderer.materials[2].mainTexture = this.NudePanties;
    this.TheDebugMenuScript.UpdateCensor();
    this.Stance.Current = StanceType.Standing;
    this.Egg = true;
  }

  // Token: 0x060009A9 RID: 2473 RVA: 0x000B0D60 File Offset: 0x000AF160
  private void GenderSwap() {
    this.Kun.SetActive(true);
    this.KunHair.SetActive(true);
    this.MyRenderer.enabled = false;
    this.IdleAnim = "idleShort_00";
    this.WalkAnim = "walk_00";
    this.RunAnim = "newSprint_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  // Token: 0x060009AA RID: 2474 RVA: 0x000B0DE4 File Offset: 0x000AF1E4
  private void KizunaAI() {
    AudioSource.PlayClipAtPoint(this.HaiDomo, base.transform.position);
    this.RightYandereEye.enabled = false;
    this.LeftYandereEye.enabled = false;
    this.Kizuna.SetActive(true);
    this.MyRenderer.enabled = false;
    this.IdleAnim = "f02_idleGirly_00";
    this.OriginalIdleAnim = this.IdleAnim;
    this.OriginalWalkAnim = this.WalkAnim;
    this.OriginalRunAnim = this.RunAnim;
    this.Hairstyle = 0;
    this.UpdateHair();
  }

  // Token: 0x060009AB RID: 2475 RVA: 0x000B0E74 File Offset: 0x000AF274
  private void Sith() {
    this.Hairstyle = 67;
    this.UpdateHair();
    this.SithTrail1.SetActive(true);
    this.SithTrail2.SetActive(true);
    this.IdleAnim = "f02_sithIdle_00";
    this.WalkAnim = "f02_sithWalk_00";
    this.RunAnim = "f02_sithRun_00";
    this.BlackRobe.SetActive(true);
    this.MyRenderer.sharedMesh = this.NoUpperBodyMesh;
    this.MyRenderer.materials[0].mainTexture = this.NudePanties;
    this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudePanties;
    this.TheDebugMenuScript.UpdateCensor();
    this.Stance.Current = StanceType.Standing;
    this.FollowHips = true;
    this.SithLord = true;
    this.Egg = true;
    this.WalkSpeed = 0.5f;
    this.RunSpeed *= 2f;
    this.Zoom.TargetZoom = 0.4f;
  }

  // Token: 0x060009AC RID: 2476 RVA: 0x000B0F88 File Offset: 0x000AF388
  private void Snake() {
    this.MyRenderer.sharedMesh = this.Uniforms[1];
    this.MyRenderer.materials[0].mainTexture = this.SnakeBody;
    this.MyRenderer.materials[1].mainTexture = this.SnakeBody;
    this.MyRenderer.materials[2].mainTexture = this.SnakeFace;
    this.Hairstyle = 162;
    this.UpdateHair();
    this.Medusa = true;
    this.Egg = true;
  }

  // Token: 0x060009AD RID: 2477 RVA: 0x000B1010 File Offset: 0x000AF410
  private void Gazer() {
    this.GazerEyes.gameObject.SetActive(true);
    this.MyRenderer.sharedMesh = this.NudeMesh;
    this.MyRenderer.materials[0].mainTexture = this.GazerFace;
    this.MyRenderer.materials[1].mainTexture = this.GazerBody;
    this.MyRenderer.materials[2].mainTexture = this.GazerBody;
    this.IdleAnim = "f02_gazerIdle_00";
    this.WalkAnim = "f02_gazerWalk_00";
    this.RunAnim = "f02_gazerRun_00";
    this.Hairstyle = 158;
    this.UpdateHair();
    this.StudentManager.Gaze = true;
    this.StudentManager.UpdateStudents();
    this.Gazing = true;
    this.Egg = true;
  }

  // Token: 0x060009AE RID: 2478 RVA: 0x000B10E0 File Offset: 0x000AF4E0
  private void Six() {
    RenderSettings.skybox = this.HatefulSkybox;
    this.Hairstyle = 0;
    this.UpdateHair();
    this.IdleAnim = "f02_sixIdle_00";
    this.WalkAnim = "f02_sixWalk_00";
    this.RunAnim = "f02_sixRun_00";
    this.SixRaincoat.SetActive(true);
    this.MyRenderer.sharedMesh = this.SixBodyMesh;
    this.MyRenderer.materials[0].mainTexture = this.SixFaceTexture;
    this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
    this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
    this.TheDebugMenuScript.UpdateCensor();
    SchoolGlobals.SchoolAtmosphere = 0f;
    this.StudentManager.SetAtmosphere();
    this.StudentManager.Six = true;
    this.StudentManager.UpdateStudents();
    this.WalkSpeed = 0.75f;
    this.RunSpeed = 2f;
    this.Hungry = true;
    this.Egg = true;
  }

  // Token: 0x060009AF RID: 2479 RVA: 0x000B11E8 File Offset: 0x000AF5E8
  public void ChangeSchoolwear() {
    if (this.ClubAttire && this.Bloodiness == 0f) {
      this.Schoolwear = this.PreviousSchoolwear;
    }
    this.Paint = false;
    this.ID = 0;
    while (this.ID < this.CensorSteam.Length) {
      this.CensorSteam[this.ID].SetActive(false);
      this.ID++;
    }
    if (this.Casual) {
      this.TextureToUse = this.UniformTextures[StudentGlobals.FemaleUniform];
    } else {
      this.TextureToUse = this.CasualTextures[StudentGlobals.FemaleUniform];
    }
    if ((this.ClubAttire && this.Bloodiness > 0f) || this.Schoolwear == 0) {
      this.Nude();
    } else if (this.Schoolwear == 1) {
      this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
      if (this.StudentManager.Censor) {
        this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
        this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
      }
      this.MyRenderer.materials[0].mainTexture = this.TextureToUse;
      this.MyRenderer.materials[1].mainTexture = this.TextureToUse;
      this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
      base.StartCoroutine(this.ApplyCustomCostume());
    } else if (this.Schoolwear == 2) {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
      this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
      this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
      this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
      this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    } else if (this.Schoolwear == 3) {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
      this.MyRenderer.sharedMesh = this.GymUniform;
      this.MyRenderer.materials[0].mainTexture = this.GymTexture;
      this.MyRenderer.materials[1].mainTexture = this.GymTexture;
      this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    }
    this.CanMove = false;
    this.Outline.h.ReinitMaterials();
    this.ClubAccessory();
  }

  // Token: 0x060009B0 RID: 2480 RVA: 0x000B14EC File Offset: 0x000AF8EC
  public void ChangeClubwear() {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
    this.Paint = false;
    if (!this.ClubAttire) {
      this.ClubAttire = true;
      if (ClubGlobals.Club == ClubType.Art) {
        this.MyRenderer.sharedMesh = this.ApronMesh;
        this.MyRenderer.materials[0].mainTexture = this.ApronTexture;
        this.MyRenderer.materials[1].mainTexture = this.ApronTexture;
        this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        this.Schoolwear = 4;
        this.Paint = true;
      } else if (ClubGlobals.Club == ClubType.MartialArts) {
        this.MyRenderer.sharedMesh = this.JudoGiMesh;
        this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
        this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
        this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        this.Schoolwear = 5;
      } else if (ClubGlobals.Club == ClubType.Science) {
        this.MyRenderer.sharedMesh = this.LabCoatMesh;
        this.MyRenderer.materials[0].mainTexture = this.LabCoatTexture;
        this.MyRenderer.materials[1].mainTexture = this.LabCoatTexture;
        this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        this.Schoolwear = 6;
      }
    } else {
      this.ChangeSchoolwear();
      this.ClubAttire = false;
    }
    this.MyLocker.UpdateButtons();
  }

  // Token: 0x060009B1 RID: 2481 RVA: 0x000B16BC File Offset: 0x000AFABC
  public void ClubAccessory() {
    this.ID = 0;
    while (this.ID < this.ClubAccessories.Length) {
      GameObject gameObject = this.ClubAccessories[this.ID];
      if (gameObject != null) {
        gameObject.SetActive(false);
      }
      this.ID++;
    }
    if (!this.CensorSteam[0].activeInHierarchy && ClubGlobals.Club > ClubType.None && this.ClubAccessories[(int)ClubGlobals.Club] != null) {
      this.ClubAccessories[(int)ClubGlobals.Club].SetActive(true);
    }
  }

  // Token: 0x060009B2 RID: 2482 RVA: 0x000B1760 File Offset: 0x000AFB60
  public void StopCarrying() {
    if (this.Ragdoll != null) {
      this.Ragdoll.GetComponent<RagdollScript>().Fall();
    }
    this.HeavyWeight = false;
    this.Carrying = false;
    this.IdleAnim = this.OriginalIdleAnim;
    this.WalkAnim = this.OriginalWalkAnim;
    this.RunAnim = this.OriginalRunAnim;
  }

  // Token: 0x060009B3 RID: 2483 RVA: 0x000B17C0 File Offset: 0x000AFBC0
  private void Crouch() {
    this.MyController.center = new Vector3(this.MyController.center.x, 0.55f, this.MyController.center.z);
    this.MyController.height = 0.9f;
  }

  // Token: 0x060009B4 RID: 2484 RVA: 0x000B1818 File Offset: 0x000AFC18
  private void Crawl() {
    this.MyController.center = new Vector3(this.MyController.center.x, 0.25f, this.MyController.center.z);
    this.MyController.height = 0.1f;
  }

  // Token: 0x060009B5 RID: 2485 RVA: 0x000B1870 File Offset: 0x000AFC70
  private void Uncrouch() {
    this.MyController.center = new Vector3(this.MyController.center.x, 0.875f, this.MyController.center.z);
    this.MyController.height = 1.55f;
  }

  // Token: 0x060009B6 RID: 2486 RVA: 0x000B18C8 File Offset: 0x000AFCC8
  private void StopArmedAnim() {
    this.ID = 0;
    while (this.ID < this.ArmedAnims.Length) {
      string name = this.ArmedAnims[this.ID];
      this.CharacterAnimation[name].weight = Mathf.Lerp(this.CharacterAnimation[name].weight, 0f, Time.deltaTime * 10f);
      this.ID++;
    }
  }

  // Token: 0x060009B7 RID: 2487 RVA: 0x000B1948 File Offset: 0x000AFD48
  private void UpdateAccessory() {
    if (this.AccessoryGroup != null) {
      this.AccessoryGroup.SetPartsActive(false);
    }
    if (this.AccessoryID > this.Accessories.Length - 1) {
      this.AccessoryID = 0;
    }
    if (this.AccessoryID < 0) {
      this.AccessoryID = this.Accessories.Length - 1;
    }
    if (this.AccessoryID > 0) {
      this.Accessories[this.AccessoryID].SetActive(true);
      this.AccessoryGroup = this.Accessories[this.AccessoryID].GetComponent<AccessoryGroupScript>();
      if (this.AccessoryGroup != null) {
        this.AccessoryGroup.SetPartsActive(true);
      }
    }
  }

  // Token: 0x060009B8 RID: 2488 RVA: 0x000B1A00 File Offset: 0x000AFE00
  private void DisableHairAndAccessories() {
    this.ID = 1;
    while (this.ID < this.Accessories.Length) {
      this.Accessories[this.ID].SetActive(false);
      this.ID++;
    }
    this.ID = 1;
    while (this.ID < this.Hairstyles.Length) {
      this.Hairstyles[this.ID].SetActive(false);
      this.ID++;
    }
  }

  // Token: 0x04001B89 RID: 7049
  public Quaternion targetRotation;

  // Token: 0x04001B8A RID: 7050
  private Vector3 targetDirection;

  // Token: 0x04001B8B RID: 7051
  private GameObject NewTrail;

  // Token: 0x04001B8C RID: 7052
  private int AccessoryID;

  // Token: 0x04001B8D RID: 7053
  private int ID;

  // Token: 0x04001B8E RID: 7054
  public FootprintSpawnerScript RightFootprintSpawner;

  // Token: 0x04001B8F RID: 7055
  public FootprintSpawnerScript LeftFootprintSpawner;

  // Token: 0x04001B90 RID: 7056
  public ColorCorrectionCurves YandereColorCorrection;

  // Token: 0x04001B91 RID: 7057
  public ColorCorrectionCurves ColorCorrection;

  // Token: 0x04001B92 RID: 7058
  public SelectiveGrayscale SelectGrayscale;

  // Token: 0x04001B93 RID: 7059
  public HighlightingRenderer HighlightingR;

  // Token: 0x04001B94 RID: 7060
  public HighlightingBlitter HighlightingB;

  // Token: 0x04001B95 RID: 7061
  public AmbientObscurance Obscurance;

  // Token: 0x04001B96 RID: 7062
  public DepthOfField34 DepthOfField;

  // Token: 0x04001B97 RID: 7063
  public Vignetting Vignette;

  // Token: 0x04001B98 RID: 7064
  public Blur Blur;

  // Token: 0x04001B99 RID: 7065
  public NotificationManagerScript NotificationManager;

  // Token: 0x04001B9A RID: 7066
  public ObstacleDetectorScript ObstacleDetector;

  // Token: 0x04001B9B RID: 7067
  public AccessoryGroupScript AccessoryGroup;

  // Token: 0x04001B9C RID: 7068
  public DumpsterHandleScript DumpsterHandle;

  // Token: 0x04001B9D RID: 7069
  public PhonePromptBarScript PhonePromptBar;

  // Token: 0x04001B9E RID: 7070
  public ShoulderCameraScript ShoulderCamera;

  // Token: 0x04001B9F RID: 7071
  public StudentManagerScript StudentManager;

  // Token: 0x04001BA0 RID: 7072
  public AttackManagerScript AttackManager;

  // Token: 0x04001BA1 RID: 7073
  public CameraEffectsScript CameraEffects;

  // Token: 0x04001BA2 RID: 7074
  public WeaponManagerScript WeaponManager;

  // Token: 0x04001BA3 RID: 7075
  public SplashCameraScript SplashCamera;

  // Token: 0x04001BA4 RID: 7076
  public SWP_HeartRateMonitor HeartRate;

  // Token: 0x04001BA5 RID: 7077
  public LoveManagerScript LoveManager;

  // Token: 0x04001BA6 RID: 7078
  public StruggleBarScript StruggleBar;

  // Token: 0x04001BA7 RID: 7079
  public RummageSpotScript RummageSpot;

  // Token: 0x04001BA8 RID: 7080
  public IncineratorScript Incinerator;

  // Token: 0x04001BA9 RID: 7081
  public InputDeviceScript InputDevice;

  // Token: 0x04001BAA RID: 7082
  public MusicCreditScript MusicCredit;

  // Token: 0x04001BAB RID: 7083
  public PauseScreenScript PauseScreen;

  // Token: 0x04001BAC RID: 7084
  public WoodChipperScript WoodChipper;

  // Token: 0x04001BAD RID: 7085
  public RagdollScript CurrentRagdoll;

  // Token: 0x04001BAE RID: 7086
  public StudentScript TargetStudent;

  // Token: 0x04001BAF RID: 7087
  public WeaponMenuScript WeaponMenu;

  // Token: 0x04001BB0 RID: 7088
  public PromptScript NearestPrompt;

  // Token: 0x04001BB1 RID: 7089
  public ContainerScript Container;

  // Token: 0x04001BB2 RID: 7090
  public InventoryScript Inventory;

  // Token: 0x04001BB3 RID: 7091
  public TallLockerScript MyLocker;

  // Token: 0x04001BB4 RID: 7092
  public PromptBarScript PromptBar;

  // Token: 0x04001BB5 RID: 7093
  public TranqCaseScript TranqCase;

  // Token: 0x04001BB6 RID: 7094
  public LocationScript Location;

  // Token: 0x04001BB7 RID: 7095
  public SubtitleScript Subtitle;

  // Token: 0x04001BB8 RID: 7096
  public UIPanel DetectionPanel;

  // Token: 0x04001BB9 RID: 7097
  public StudentScript Follower;

  // Token: 0x04001BBA RID: 7098
  public JukeboxScript Jukebox;

  // Token: 0x04001BBB RID: 7099
  public OutlineScript Outline;

  // Token: 0x04001BBC RID: 7100
  public StudentScript Pursuer;

  // Token: 0x04001BBD RID: 7101
  public ShutterScript Shutter;

  // Token: 0x04001BBE RID: 7102
  public UISprite ProgressBar;

  // Token: 0x04001BBF RID: 7103
  public RPG_Camera RPGCamera;

  // Token: 0x04001BC0 RID: 7104
  public BucketScript Bucket;

  // Token: 0x04001BC1 RID: 7105
  public PickUpScript PickUp;

  // Token: 0x04001BC2 RID: 7106
  public PoliceScript Police;

  // Token: 0x04001BC3 RID: 7107
  public GloveScript Gloves;

  // Token: 0x04001BC4 RID: 7108
  public UILabel PowerUp;

  // Token: 0x04001BC5 RID: 7109
  public MaskScript Mask;

  // Token: 0x04001BC6 RID: 7110
  public MopScript Mop;

  // Token: 0x04001BC7 RID: 7111
  public UIPanel HUD;

  // Token: 0x04001BC8 RID: 7112
  public CharacterController MyController;

  // Token: 0x04001BC9 RID: 7113
  public Transform LeftItemParent;

  // Token: 0x04001BCA RID: 7114
  public Transform DismemberSpot;

  // Token: 0x04001BCB RID: 7115
  public Transform CameraTarget;

  // Token: 0x04001BCC RID: 7116
  public Transform CameraFocus;

  // Token: 0x04001BCD RID: 7117
  public Transform RightBreast;

  // Token: 0x04001BCE RID: 7118
  public Transform HidingSpot;

  // Token: 0x04001BCF RID: 7119
  public Transform LeftBreast;

  // Token: 0x04001BD0 RID: 7120
  public Transform ItemParent;

  // Token: 0x04001BD1 RID: 7121
  public Transform PelvisRoot;

  // Token: 0x04001BD2 RID: 7122
  public Transform PoisonSpot;

  // Token: 0x04001BD3 RID: 7123
  public Transform CameraPOV;

  // Token: 0x04001BD4 RID: 7124
  public Transform RightHand;

  // Token: 0x04001BD5 RID: 7125
  public Transform ExitSpot;

  // Token: 0x04001BD6 RID: 7126
  public Transform LeftHand;

  // Token: 0x04001BD7 RID: 7127
  public Transform Backpack;

  // Token: 0x04001BD8 RID: 7128
  public Transform DropSpot;

  // Token: 0x04001BD9 RID: 7129
  public Transform Homeroom;

  // Token: 0x04001BDA RID: 7130
  public Transform DigSpot;

  // Token: 0x04001BDB RID: 7131
  public Transform Senpai;

  // Token: 0x04001BDC RID: 7132
  public Transform Stool;

  // Token: 0x04001BDD RID: 7133
  public Transform Eyes;

  // Token: 0x04001BDE RID: 7134
  public Transform Head;

  // Token: 0x04001BDF RID: 7135
  public Transform Hips;

  // Token: 0x04001BE0 RID: 7136
  public AudioSource HeartBeat;

  // Token: 0x04001BE1 RID: 7137
  public GameObject[] Accessories;

  // Token: 0x04001BE2 RID: 7138
  public GameObject[] Hairstyles;

  // Token: 0x04001BE3 RID: 7139
  public GameObject[] Poisons;

  // Token: 0x04001BE4 RID: 7140
  public GameObject[] Shoes;

  // Token: 0x04001BE5 RID: 7141
  public float[] DropTimer;

  // Token: 0x04001BE6 RID: 7142
  public GameObject CinematicCamera;

  // Token: 0x04001BE7 RID: 7143
  public GameObject FloatingShovel;

  // Token: 0x04001BE8 RID: 7144
  public GameObject EasterEggMenu;

  // Token: 0x04001BE9 RID: 7145
  public GameObject MemeGlasses;

  // Token: 0x04001BEA RID: 7146
  public GameObject GiggleDisc;

  // Token: 0x04001BEB RID: 7147
  public GameObject HandCamera;

  // Token: 0x04001BEC RID: 7148
  public GameObject KONGlasses;

  // Token: 0x04001BED RID: 7149
  public GameObject Microphone;

  // Token: 0x04001BEE RID: 7150
  public GameObject AlarmDisc;

  // Token: 0x04001BEF RID: 7151
  public GameObject Character;

  // Token: 0x04001BF0 RID: 7152
  public GameObject DebugMenu;

  // Token: 0x04001BF1 RID: 7153
  public GameObject EyepatchL;

  // Token: 0x04001BF2 RID: 7154
  public GameObject EyepatchR;

  // Token: 0x04001BF3 RID: 7155
  public GameObject ShoePair;

  // Token: 0x04001BF4 RID: 7156
  public GameObject Barcode;

  // Token: 0x04001BF5 RID: 7157
  public GameObject Headset;

  // Token: 0x04001BF6 RID: 7158
  public GameObject Ragdoll;

  // Token: 0x04001BF7 RID: 7159
  public GameObject Hearts;

  // Token: 0x04001BF8 RID: 7160
  public GameObject Phone;

  // Token: 0x04001BF9 RID: 7161
  public GameObject Trail;

  // Token: 0x04001BFA RID: 7162
  public GameObject Match;

  // Token: 0x04001BFB RID: 7163
  public GameObject Arc;

  // Token: 0x04001BFC RID: 7164
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x04001BFD RID: 7165
  public Animation CharacterAnimation;

  // Token: 0x04001BFE RID: 7166
  public SpringJoint RagdollDragger;

  // Token: 0x04001BFF RID: 7167
  public SpringJoint RagdollPK;

  // Token: 0x04001C00 RID: 7168
  public Projector MyProjector;

  // Token: 0x04001C01 RID: 7169
  public Camera HeartCamera;

  // Token: 0x04001C02 RID: 7170
  public Camera MainCamera;

  // Token: 0x04001C03 RID: 7171
  public Camera Smartphone;

  // Token: 0x04001C04 RID: 7172
  public Renderer SmartphoneRenderer;

  // Token: 0x04001C05 RID: 7173
  public Renderer LongHairRenderer;

  // Token: 0x04001C06 RID: 7174
  public Renderer PonytailRenderer;

  // Token: 0x04001C07 RID: 7175
  public Renderer PigtailR;

  // Token: 0x04001C08 RID: 7176
  public Renderer PigtailL;

  // Token: 0x04001C09 RID: 7177
  public Renderer Drills;

  // Token: 0x04001C0A RID: 7178
  public float CinematicTimer;

  // Token: 0x04001C0B RID: 7179
  public float RummageTimer;

  // Token: 0x04001C0C RID: 7180
  public float YandereTimer;

  // Token: 0x04001C0D RID: 7181
  public float AttackTimer;

  // Token: 0x04001C0E RID: 7182
  public float CaughtTimer;

  // Token: 0x04001C0F RID: 7183
  public float CrawlTimer;

  // Token: 0x04001C10 RID: 7184
  public float GloveTimer;

  // Token: 0x04001C11 RID: 7185
  public float LaughTimer;

  // Token: 0x04001C12 RID: 7186
  public float SprayTimer;

  // Token: 0x04001C13 RID: 7187
  public float TheftTimer;

  // Token: 0x04001C14 RID: 7188
  public float BoneTimer;

  // Token: 0x04001C15 RID: 7189
  public float DumpTimer;

  // Token: 0x04001C16 RID: 7190
  public float ExitTimer;

  // Token: 0x04001C17 RID: 7191
  public float TalkTimer;

  // Token: 0x04001C18 RID: 7192
  [SerializeField]
  private float bloodiness;

  // Token: 0x04001C19 RID: 7193
  public float PreviousSanity = 100f;

  // Token: 0x04001C1A RID: 7194
  [SerializeField]
  private float sanity;

  // Token: 0x04001C1B RID: 7195
  public float TwitchTimer;

  // Token: 0x04001C1C RID: 7196
  public float NextTwitch;

  // Token: 0x04001C1D RID: 7197
  public float LaughIntensity;

  // Token: 0x04001C1E RID: 7198
  public float TimeSkipHeight;

  // Token: 0x04001C1F RID: 7199
  public float PourDistance;

  // Token: 0x04001C20 RID: 7200
  public float TargetHeight;

  // Token: 0x04001C21 RID: 7201
  public float BreastSize;

  // Token: 0x04001C22 RID: 7202
  public float Numbness;

  // Token: 0x04001C23 RID: 7203
  public float PourTime;

  // Token: 0x04001C24 RID: 7204
  public float RunSpeed;

  // Token: 0x04001C25 RID: 7205
  public float Height;

  // Token: 0x04001C26 RID: 7206
  public float Slouch;

  // Token: 0x04001C27 RID: 7207
  public float Bend;

  // Token: 0x04001C28 RID: 7208
  public float CrouchWalkSpeed;

  // Token: 0x04001C29 RID: 7209
  public float CrouchRunSpeed;

  // Token: 0x04001C2A RID: 7210
  public float ShoveSpeed = 2f;

  // Token: 0x04001C2B RID: 7211
  public float CrawlSpeed;

  // Token: 0x04001C2C RID: 7212
  public float FlapSpeed;

  // Token: 0x04001C2D RID: 7213
  public float WalkSpeed;

  // Token: 0x04001C2E RID: 7214
  public float YandereFade;

  // Token: 0x04001C2F RID: 7215
  public float YandereTint;

  // Token: 0x04001C30 RID: 7216
  public float SenpaiFade;

  // Token: 0x04001C31 RID: 7217
  public float SenpaiTint;

  // Token: 0x04001C32 RID: 7218
  public float GreyTarget;

  // Token: 0x04001C33 RID: 7219
  public int PreviousSchoolwear;

  // Token: 0x04001C34 RID: 7220
  public int StrugglePhase;

  // Token: 0x04001C35 RID: 7221
  public int CarryAnimID;

  // Token: 0x04001C36 RID: 7222
  public int AttackPhase;

  // Token: 0x04001C37 RID: 7223
  public YandereInteractionType Interaction;

  // Token: 0x04001C38 RID: 7224
  public int NearBodies;

  // Token: 0x04001C39 RID: 7225
  public int PoisonType;

  // Token: 0x04001C3A RID: 7226
  public int Schoolwear;

  // Token: 0x04001C3B RID: 7227
  public int SprayPhase;

  // Token: 0x04001C3C RID: 7228
  public int DragState;

  // Token: 0x04001C3D RID: 7229
  public int EyewearID;

  // Token: 0x04001C3E RID: 7230
  public int Followers;

  // Token: 0x04001C3F RID: 7231
  public int Hairstyle;

  // Token: 0x04001C40 RID: 7232
  public int DigPhase;

  // Token: 0x04001C41 RID: 7233
  public int Equipped;

  // Token: 0x04001C42 RID: 7234
  public int Costume;

  // Token: 0x04001C43 RID: 7235
  public int Alerts;

  // Token: 0x04001C44 RID: 7236
  public bool BloodyWarning;

  // Token: 0x04001C45 RID: 7237
  public bool CorpseWarning;

  // Token: 0x04001C46 RID: 7238
  public bool SanityWarning;

  // Token: 0x04001C47 RID: 7239
  public bool WeaponWarning;

  // Token: 0x04001C48 RID: 7240
  public bool DumpsterGrabbing;

  // Token: 0x04001C49 RID: 7241
  public bool BucketDropping;

  // Token: 0x04001C4A RID: 7242
  public bool TranquilHiding;

  // Token: 0x04001C4B RID: 7243
  public bool Eavesdropping;

  // Token: 0x04001C4C RID: 7244
  public bool Pickpocketing;

  // Token: 0x04001C4D RID: 7245
  public bool Dismembering;

  // Token: 0x04001C4E RID: 7246
  public bool TimeSkipping;

  // Token: 0x04001C4F RID: 7247
  public bool Cauterizing;

  // Token: 0x04001C50 RID: 7248
  public bool HeavyWeight;

  // Token: 0x04001C51 RID: 7249
  public bool Trespassing;

  // Token: 0x04001C52 RID: 7250
  public bool Struggling;

  // Token: 0x04001C53 RID: 7251
  public bool Attacking;

  // Token: 0x04001C54 RID: 7252
  public bool Degloving;

  // Token: 0x04001C55 RID: 7253
  public bool Poisoning;

  // Token: 0x04001C56 RID: 7254
  public bool Rummaging;

  // Token: 0x04001C57 RID: 7255
  public bool Stripping;

  // Token: 0x04001C58 RID: 7256
  public bool Blasting;

  // Token: 0x04001C59 RID: 7257
  public bool Carrying;

  // Token: 0x04001C5A RID: 7258
  public bool Chipping;

  // Token: 0x04001C5B RID: 7259
  public bool Dragging;

  // Token: 0x04001C5C RID: 7260
  public bool Dropping;

  // Token: 0x04001C5D RID: 7261
  public bool Flicking;

  // Token: 0x04001C5E RID: 7262
  public bool Laughing;

  // Token: 0x04001C5F RID: 7263
  public bool Punching;

  // Token: 0x04001C60 RID: 7264
  public bool Throwing;

  // Token: 0x04001C61 RID: 7265
  public bool Tripping;

  // Token: 0x04001C62 RID: 7266
  public bool Bathing;

  // Token: 0x04001C63 RID: 7267
  public bool Burying;

  // Token: 0x04001C64 RID: 7268
  public bool Cooking;

  // Token: 0x04001C65 RID: 7269
  public bool Digging;

  // Token: 0x04001C66 RID: 7270
  public bool Dipping;

  // Token: 0x04001C67 RID: 7271
  public bool Dumping;

  // Token: 0x04001C68 RID: 7272
  public bool Exiting;

  // Token: 0x04001C69 RID: 7273
  public bool Lifting;

  // Token: 0x04001C6A RID: 7274
  public bool Mopping;

  // Token: 0x04001C6B RID: 7275
  public bool Pouring;

  // Token: 0x04001C6C RID: 7276
  public bool Talking;

  // Token: 0x04001C6D RID: 7277
  public bool Aiming;

  // Token: 0x04001C6E RID: 7278
  public bool Caught;

  // Token: 0x04001C6F RID: 7279
  public bool Eating;

  // Token: 0x04001C70 RID: 7280
  public bool Hiding;

  // Token: 0x04001C71 RID: 7281
  public Stance Stance = new Stance(StanceType.Standing);

  // Token: 0x04001C72 RID: 7282
  public bool CrouchButtonDown;

  // Token: 0x04001C73 RID: 7283
  public bool UsingController;

  // Token: 0x04001C74 RID: 7284
  public bool CameFromCrouch;

  // Token: 0x04001C75 RID: 7285
  public bool CannotRecover;

  // Token: 0x04001C76 RID: 7286
  public bool PossessPoison;

  // Token: 0x04001C77 RID: 7287
  public bool YandereVision;

  // Token: 0x04001C78 RID: 7288
  public bool ClubActivity;

  // Token: 0x04001C79 RID: 7289
  public bool FlameDemonic;

  // Token: 0x04001C7A RID: 7290
  public bool PossessTranq;

  // Token: 0x04001C7B RID: 7291
  public bool SanityBased;

  // Token: 0x04001C7C RID: 7292
  public bool SummonBones;

  // Token: 0x04001C7D RID: 7293
  public bool ClubAttire;

  // Token: 0x04001C7E RID: 7294
  public bool FollowHips;

  // Token: 0x04001C7F RID: 7295
  public bool NearSenpai;

  // Token: 0x04001C80 RID: 7296
  public bool RivalPhone;

  // Token: 0x04001C81 RID: 7297
  public bool Possessed;

  // Token: 0x04001C82 RID: 7298
  public bool Attacked;

  // Token: 0x04001C83 RID: 7299
  public bool CanTranq;

  // Token: 0x04001C84 RID: 7300
  public bool Collapse;

  // Token: 0x04001C85 RID: 7301
  public bool RoofPush;

  // Token: 0x04001C86 RID: 7302
  public bool Demonic;

  // Token: 0x04001C87 RID: 7303
  public bool FlapOut;

  // Token: 0x04001C88 RID: 7304
  public bool NoDebug;

  // Token: 0x04001C89 RID: 7305
  public bool Noticed;

  // Token: 0x04001C8A RID: 7306
  public bool InClass;

  // Token: 0x04001C8B RID: 7307
  public bool Slender;

  // Token: 0x04001C8C RID: 7308
  public bool Sprayed;

  // Token: 0x04001C8D RID: 7309
  public bool CanMove = true;

  // Token: 0x04001C8E RID: 7310
  public bool Chased;

  // Token: 0x04001C8F RID: 7311
  public bool Gloved;

  // Token: 0x04001C90 RID: 7312
  public bool Shoved;

  // Token: 0x04001C91 RID: 7313
  public bool Drown;

  // Token: 0x04001C92 RID: 7314
  public bool Xtan;

  // Token: 0x04001C93 RID: 7315
  public bool Lewd;

  // Token: 0x04001C94 RID: 7316
  public bool Lost;

  // Token: 0x04001C95 RID: 7317
  public bool Sans;

  // Token: 0x04001C96 RID: 7318
  public bool Egg;

  // Token: 0x04001C97 RID: 7319
  public bool Won;

  // Token: 0x04001C98 RID: 7320
  public bool DK;

  // Token: 0x04001C99 RID: 7321
  public bool PK;

  // Token: 0x04001C9A RID: 7322
  public Texture[] UniformTextures;

  // Token: 0x04001C9B RID: 7323
  public Texture[] CasualTextures;

  // Token: 0x04001C9C RID: 7324
  public Texture[] BloodTextures;

  // Token: 0x04001C9D RID: 7325
  public WeaponScript[] Weapon;

  // Token: 0x04001C9E RID: 7326
  public GameObject[] ZipTie;

  // Token: 0x04001C9F RID: 7327
  public string[] ArmedAnims;

  // Token: 0x04001CA0 RID: 7328
  public string[] CarryAnims;

  // Token: 0x04001CA1 RID: 7329
  public Transform[] Spine;

  // Token: 0x04001CA2 RID: 7330
  public AudioClip[] Stabs;

  // Token: 0x04001CA3 RID: 7331
  public Transform[] Foot;

  // Token: 0x04001CA4 RID: 7332
  public Transform[] Hand;

  // Token: 0x04001CA5 RID: 7333
  public Transform[] Arm;

  // Token: 0x04001CA6 RID: 7334
  public Transform[] Leg;

  // Token: 0x04001CA7 RID: 7335
  public Mesh[] Uniforms;

  // Token: 0x04001CA8 RID: 7336
  public Renderer RightYandereEye;

  // Token: 0x04001CA9 RID: 7337
  public Renderer LeftYandereEye;

  // Token: 0x04001CAA RID: 7338
  public Vector3 RightEyeOrigin;

  // Token: 0x04001CAB RID: 7339
  public Vector3 LeftEyeOrigin;

  // Token: 0x04001CAC RID: 7340
  public Renderer RightRedEye;

  // Token: 0x04001CAD RID: 7341
  public Renderer LeftRedEye;

  // Token: 0x04001CAE RID: 7342
  public Transform RightEye;

  // Token: 0x04001CAF RID: 7343
  public Transform LeftEye;

  // Token: 0x04001CB0 RID: 7344
  public float EyeShrink;

  // Token: 0x04001CB1 RID: 7345
  public Vector3 Twitch;

  // Token: 0x04001CB2 RID: 7346
  private AudioClip LaughClip;

  // Token: 0x04001CB3 RID: 7347
  public string PourHeight = string.Empty;

  // Token: 0x04001CB4 RID: 7348
  public string DrownAnim = string.Empty;

  // Token: 0x04001CB5 RID: 7349
  public string LaughAnim = string.Empty;

  // Token: 0x04001CB6 RID: 7350
  public string HideAnim = string.Empty;

  // Token: 0x04001CB7 RID: 7351
  public string IdleAnim = string.Empty;

  // Token: 0x04001CB8 RID: 7352
  public string WalkAnim = string.Empty;

  // Token: 0x04001CB9 RID: 7353
  public string RunAnim = string.Empty;

  // Token: 0x04001CBA RID: 7354
  public string CrouchIdleAnim = string.Empty;

  // Token: 0x04001CBB RID: 7355
  public string CrouchWalkAnim = string.Empty;

  // Token: 0x04001CBC RID: 7356
  public string CrouchRunAnim = string.Empty;

  // Token: 0x04001CBD RID: 7357
  public string CrawlIdleAnim = string.Empty;

  // Token: 0x04001CBE RID: 7358
  public string CrawlWalkAnim = string.Empty;

  // Token: 0x04001CBF RID: 7359
  public string HeavyIdleAnim = string.Empty;

  // Token: 0x04001CC0 RID: 7360
  public string HeavyWalkAnim = string.Empty;

  // Token: 0x04001CC1 RID: 7361
  public string CarryIdleAnim = string.Empty;

  // Token: 0x04001CC2 RID: 7362
  public string CarryWalkAnim = string.Empty;

  // Token: 0x04001CC3 RID: 7363
  public string CarryRunAnim = string.Empty;

  // Token: 0x04001CC4 RID: 7364
  public AudioClip ChargeUp;

  // Token: 0x04001CC5 RID: 7365
  public AudioClip Laugh1;

  // Token: 0x04001CC6 RID: 7366
  public AudioClip Laugh2;

  // Token: 0x04001CC7 RID: 7367
  public AudioClip Laugh3;

  // Token: 0x04001CC8 RID: 7368
  public AudioClip Laugh4;

  // Token: 0x04001CC9 RID: 7369
  public AudioClip Thud;

  // Token: 0x04001CCA RID: 7370
  public AudioClip Dig;

  // Token: 0x04001CCB RID: 7371
  public Vector3 PreviousPosition;

  // Token: 0x04001CCC RID: 7372
  public string OriginalIdleAnim = string.Empty;

  // Token: 0x04001CCD RID: 7373
  public string OriginalWalkAnim = string.Empty;

  // Token: 0x04001CCE RID: 7374
  public string OriginalRunAnim = string.Empty;

  // Token: 0x04001CCF RID: 7375
  public Texture YanderePhoneTexture;

  // Token: 0x04001CD0 RID: 7376
  public Texture RivalPhoneTexture;

  // Token: 0x04001CD1 RID: 7377
  public float v;

  // Token: 0x04001CD2 RID: 7378
  public float h;

  // Token: 0x04001CD3 RID: 7379
  public GameObject CreepyArms;

  // Token: 0x04001CD4 RID: 7380
  public Texture[] GloveTextures;

  // Token: 0x04001CD5 RID: 7381
  public Texture TitanTexture;

  // Token: 0x04001CD6 RID: 7382
  public Texture KONTexture;

  // Token: 0x04001CD7 RID: 7383
  public GameObject PunishedAccessories;

  // Token: 0x04001CD8 RID: 7384
  public GameObject PunishedScarf;

  // Token: 0x04001CD9 RID: 7385
  public GameObject[] PunishedArm;

  // Token: 0x04001CDA RID: 7386
  public Texture[] PunishedTextures;

  // Token: 0x04001CDB RID: 7387
  public Shader PunishedShader;

  // Token: 0x04001CDC RID: 7388
  public Mesh PunishedMesh;

  // Token: 0x04001CDD RID: 7389
  public Material HatefulSkybox;

  // Token: 0x04001CDE RID: 7390
  public Texture HatefulUniform;

  // Token: 0x04001CDF RID: 7391
  public GameObject SukebanAccessories;

  // Token: 0x04001CE0 RID: 7392
  public Texture SukebanBandages;

  // Token: 0x04001CE1 RID: 7393
  public Texture SukebanUniform;

  // Token: 0x04001CE2 RID: 7394
  public GameObject[] SlenderHair;

  // Token: 0x04001CE3 RID: 7395
  public Texture SlenderUniform;

  // Token: 0x04001CE4 RID: 7396
  public Material SlenderSkybox;

  // Token: 0x04001CE5 RID: 7397
  public Texture SlenderSkin;

  // Token: 0x04001CE6 RID: 7398
  public Transform[] LongHair;

  // Token: 0x04001CE7 RID: 7399
  public GameObject BlackEyePatch;

  // Token: 0x04001CE8 RID: 7400
  public GameObject XSclera;

  // Token: 0x04001CE9 RID: 7401
  public GameObject XEye;

  // Token: 0x04001CEA RID: 7402
  public Texture XBody;

  // Token: 0x04001CEB RID: 7403
  public Texture XFace;

  // Token: 0x04001CEC RID: 7404
  public GameObject[] GaloAccessories;

  // Token: 0x04001CED RID: 7405
  public Texture GaloArms;

  // Token: 0x04001CEE RID: 7406
  public Texture GaloFace;

  // Token: 0x04001CEF RID: 7407
  public AudioClip SummonStand;

  // Token: 0x04001CF0 RID: 7408
  public StandScript Stand;

  // Token: 0x04001CF1 RID: 7409
  public AudioClip YanYan;

  // Token: 0x04001CF2 RID: 7410
  public Texture AgentFace;

  // Token: 0x04001CF3 RID: 7411
  public Texture AgentSuit;

  // Token: 0x04001CF4 RID: 7412
  public GameObject CirnoIceAttack;

  // Token: 0x04001CF5 RID: 7413
  public AudioClip CirnoIceClip;

  // Token: 0x04001CF6 RID: 7414
  public GameObject CirnoWings;

  // Token: 0x04001CF7 RID: 7415
  public GameObject CirnoHair;

  // Token: 0x04001CF8 RID: 7416
  public Texture CirnoUniform;

  // Token: 0x04001CF9 RID: 7417
  public Texture CirnoFace;

  // Token: 0x04001CFA RID: 7418
  public Transform[] CirnoWing;

  // Token: 0x04001CFB RID: 7419
  public float CirnoRotation;

  // Token: 0x04001CFC RID: 7420
  public float CirnoTimer;

  // Token: 0x04001CFD RID: 7421
  public AudioClip FalconPunchVoice;

  // Token: 0x04001CFE RID: 7422
  public Texture FalconBody;

  // Token: 0x04001CFF RID: 7423
  public Texture FalconFace;

  // Token: 0x04001D00 RID: 7424
  public float FalconSpeed;

  // Token: 0x04001D01 RID: 7425
  public GameObject NewFalconPunch;

  // Token: 0x04001D02 RID: 7426
  public GameObject FalconWindUp;

  // Token: 0x04001D03 RID: 7427
  public GameObject FalconPunch;

  // Token: 0x04001D04 RID: 7428
  public GameObject FalconShoulderpad;

  // Token: 0x04001D05 RID: 7429
  public GameObject FalconNipple1;

  // Token: 0x04001D06 RID: 7430
  public GameObject FalconNipple2;

  // Token: 0x04001D07 RID: 7431
  public GameObject FalconBuckle;

  // Token: 0x04001D08 RID: 7432
  public GameObject FalconHelmet;

  // Token: 0x04001D09 RID: 7433
  public GameObject FalconGun;

  // Token: 0x04001D0A RID: 7434
  public AudioClip[] OnePunchVoices;

  // Token: 0x04001D0B RID: 7435
  public GameObject NewOnePunch;

  // Token: 0x04001D0C RID: 7436
  public GameObject OnePunch;

  // Token: 0x04001D0D RID: 7437
  public Texture SaitamaSuit;

  // Token: 0x04001D0E RID: 7438
  public GameObject Cape;

  // Token: 0x04001D0F RID: 7439
  public ParticleSystem GlowEffect;

  // Token: 0x04001D10 RID: 7440
  public GameObject[] BlasterSet;

  // Token: 0x04001D11 RID: 7441
  public GameObject[] SansEyes;

  // Token: 0x04001D12 RID: 7442
  public AudioClip BlasterClip;

  // Token: 0x04001D13 RID: 7443
  public Texture SansTexture;

  // Token: 0x04001D14 RID: 7444
  public Texture SansFace;

  // Token: 0x04001D15 RID: 7445
  public GameObject Bone;

  // Token: 0x04001D16 RID: 7446
  public AudioClip Slam;

  // Token: 0x04001D17 RID: 7447
  public Mesh Jersey;

  // Token: 0x04001D18 RID: 7448
  public int BlasterStage;

  // Token: 0x04001D19 RID: 7449
  public PKDirType PKDir;

  // Token: 0x04001D1A RID: 7450
  public Texture CyborgBody;

  // Token: 0x04001D1B RID: 7451
  public Texture CyborgFace;

  // Token: 0x04001D1C RID: 7452
  public GameObject[] CyborgParts;

  // Token: 0x04001D1D RID: 7453
  public GameObject EnergySword;

  // Token: 0x04001D1E RID: 7454
  public GameObject EbolaEffect;

  // Token: 0x04001D1F RID: 7455
  public GameObject EbolaWings;

  // Token: 0x04001D20 RID: 7456
  public GameObject EbolaHair;

  // Token: 0x04001D21 RID: 7457
  public Texture EbolaFace;

  // Token: 0x04001D22 RID: 7458
  public Texture EbolaUniform;

  // Token: 0x04001D23 RID: 7459
  public Mesh LongUniform;

  // Token: 0x04001D24 RID: 7460
  public Texture NewFace;

  // Token: 0x04001D25 RID: 7461
  public Mesh NewMesh;

  // Token: 0x04001D26 RID: 7462
  public GameObject[] CensorSteam;

  // Token: 0x04001D27 RID: 7463
  public Texture NudePanties;

  // Token: 0x04001D28 RID: 7464
  public Texture NudeTexture;

  // Token: 0x04001D29 RID: 7465
  public Mesh NudeMesh;

  // Token: 0x04001D2A RID: 7466
  public Texture SamusBody;

  // Token: 0x04001D2B RID: 7467
  public Texture SamusFace;

  // Token: 0x04001D2C RID: 7468
  public Texture WitchBody;

  // Token: 0x04001D2D RID: 7469
  public Texture WitchFace;

  // Token: 0x04001D2E RID: 7470
  public Collider BladeHairCollider1;

  // Token: 0x04001D2F RID: 7471
  public Collider BladeHairCollider2;

  // Token: 0x04001D30 RID: 7472
  public GameObject BladeHair;

  // Token: 0x04001D31 RID: 7473
  public DebugMenuScript TheDebugMenuScript;

  // Token: 0x04001D32 RID: 7474
  public GameObject RiggedAccessory;

  // Token: 0x04001D33 RID: 7475
  public GameObject TornadoAttack;

  // Token: 0x04001D34 RID: 7476
  public GameObject TornadoDress;

  // Token: 0x04001D35 RID: 7477
  public GameObject TornadoHair;

  // Token: 0x04001D36 RID: 7478
  public Renderer TornadoRenderer;

  // Token: 0x04001D37 RID: 7479
  public Mesh NoTorsoMesh;

  // Token: 0x04001D38 RID: 7480
  public GameObject KunHair;

  // Token: 0x04001D39 RID: 7481
  public GameObject Kun;

  // Token: 0x04001D3A RID: 7482
  public GameObject Kizuna;

  // Token: 0x04001D3B RID: 7483
  public AudioClip HaiDomo;

  // Token: 0x04001D3C RID: 7484
  public GameObject BlackRobe;

  // Token: 0x04001D3D RID: 7485
  public Mesh NoUpperBodyMesh;

  // Token: 0x04001D3E RID: 7486
  public ParticleSystem[] Beam;

  // Token: 0x04001D3F RID: 7487
  public SithBeamScript[] SithBeam;

  // Token: 0x04001D40 RID: 7488
  public bool SithRecovering;

  // Token: 0x04001D41 RID: 7489
  public bool SithAttacking;

  // Token: 0x04001D42 RID: 7490
  public bool SithLord;

  // Token: 0x04001D43 RID: 7491
  public string SithPrefix;

  // Token: 0x04001D44 RID: 7492
  public int SithComboLength;

  // Token: 0x04001D45 RID: 7493
  public int SithCombo;

  // Token: 0x04001D46 RID: 7494
  public GameObject SithTrail1;

  // Token: 0x04001D47 RID: 7495
  public GameObject SithTrail2;

  // Token: 0x04001D48 RID: 7496
  public Transform SithTrailEnd1;

  // Token: 0x04001D49 RID: 7497
  public Transform SithTrailEnd2;

  // Token: 0x04001D4A RID: 7498
  public ZoomScript Zoom;

  // Token: 0x04001D4B RID: 7499
  public Texture SnakeFace;

  // Token: 0x04001D4C RID: 7500
  public Texture SnakeBody;

  // Token: 0x04001D4D RID: 7501
  public Texture Stone;

  // Token: 0x04001D4E RID: 7502
  public AudioClip Petrify;

  // Token: 0x04001D4F RID: 7503
  public GameObject Pebbles;

  // Token: 0x04001D50 RID: 7504
  public bool Medusa;

  // Token: 0x04001D51 RID: 7505
  public Texture GazerFace;

  // Token: 0x04001D52 RID: 7506
  public Texture GazerBody;

  // Token: 0x04001D53 RID: 7507
  public GazerEyesScript GazerEyes;

  // Token: 0x04001D54 RID: 7508
  public AudioClip FingerSnap;

  // Token: 0x04001D55 RID: 7509
  public AudioClip Zap;

  // Token: 0x04001D56 RID: 7510
  public bool GazeAttacking;

  // Token: 0x04001D57 RID: 7511
  public bool Snapping;

  // Token: 0x04001D58 RID: 7512
  public bool Gazing;

  // Token: 0x04001D59 RID: 7513
  public int SnapPhase;

  // Token: 0x04001D5A RID: 7514
  public GameObject SixRaincoat;

  // Token: 0x04001D5B RID: 7515
  public Texture SixFaceTexture;

  // Token: 0x04001D5C RID: 7516
  public AudioClip SixTakedown;

  // Token: 0x04001D5D RID: 7517
  public Transform SixTarget;

  // Token: 0x04001D5E RID: 7518
  public Mesh SixBodyMesh;

  // Token: 0x04001D5F RID: 7519
  public Transform Mouth;

  // Token: 0x04001D60 RID: 7520
  public int EatPhase;

  // Token: 0x04001D61 RID: 7521
  public bool Hungry;

  // Token: 0x04001D62 RID: 7522
  public int Hunger;

  // Token: 0x04001D63 RID: 7523
  public float[] BloodTimes;

  // Token: 0x04001D64 RID: 7524
  public Mesh SchoolSwimsuit;

  // Token: 0x04001D65 RID: 7525
  public Mesh GymUniform;

  // Token: 0x04001D66 RID: 7526
  public Texture FaceTexture;

  // Token: 0x04001D67 RID: 7527
  public Texture SwimsuitTexture;

  // Token: 0x04001D68 RID: 7528
  public Texture GymTexture;

  // Token: 0x04001D69 RID: 7529
  public Texture TextureToUse;

  // Token: 0x04001D6A RID: 7530
  public bool Casual = true;

  // Token: 0x04001D6B RID: 7531
  public Mesh JudoGiMesh;

  // Token: 0x04001D6C RID: 7532
  public Texture JudoGiTexture;

  // Token: 0x04001D6D RID: 7533
  public Mesh ApronMesh;

  // Token: 0x04001D6E RID: 7534
  public Texture ApronTexture;

  // Token: 0x04001D6F RID: 7535
  public Mesh LabCoatMesh;

  // Token: 0x04001D70 RID: 7536
  public Texture LabCoatTexture;

  // Token: 0x04001D71 RID: 7537
  public bool Paint;

  // Token: 0x04001D72 RID: 7538
  public GameObject[] ClubAccessories;

  // Token: 0x04001D73 RID: 7539
  public GameObject Fireball;

  // Token: 0x04001D74 RID: 7540
  public bool LiftOff;

  // Token: 0x04001D75 RID: 7541
  public GameObject LiftOffParticles;

  // Token: 0x04001D76 RID: 7542
  public float LiftOffSpeed;

  // Token: 0x04001D77 RID: 7543
  public SkinnedMeshUpdater SkinUpdater;

  // Token: 0x04001D78 RID: 7544
  public Mesh RivalChanMesh;

  // Token: 0x04001D79 RID: 7545
  public Mesh TestMesh;
}