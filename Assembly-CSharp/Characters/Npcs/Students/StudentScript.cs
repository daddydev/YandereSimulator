using Pathfinding;
using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001CE RID: 462
public class StudentScript : MonoBehaviour {

  // Token: 0x170000E8 RID: 232
  // (get) Token: 0x0600080F RID: 2063 RVA: 0x0007DDC4 File Offset: 0x0007C1C4
  public bool Alive {
    get {
      return this.DeathType == DeathType.None;
    }
  }

  // Token: 0x06000810 RID: 2064 RVA: 0x0007DDD0 File Offset: 0x0007C1D0
  public void Start() {
    if (!this.Started) {
      this.CharacterAnimation = this.Character.GetComponent<Animation>();
      this.CharacterAnimation[this.WalkAnim].time = UnityEngine.Random.Range(0f, this.CharacterAnimation[this.WalkAnim].length);
      this.CharacterAnimation[this.LeanAnim].speed += (float)this.StudentID * 0.01f;
      if (!GameGlobals.LoveSick && SchoolAtmosphere.Type == SchoolAtmosphereType.Low && this.Club <= ClubType.Gaming) {
        this.IdleAnim = this.ParanoidAnim;
      }
      if (ClubGlobals.Club == ClubType.Occult) {
        this.Perception = 0.5f;
      }
      var emission = Hearts.emission;
      emission.enabled = false;
      this.Prompt.OwnerType = PromptOwnerType.Person;
      this.Paranoia = 2f - SchoolGlobals.SchoolAtmosphere;
      this.VisionDistance = ((PlayerGlobals.PantiesEquipped != 4) ? 10f : 5f) * this.Paranoia;
      if (GameObject.Find("DetectionCamera") != null) {
        this.DetectionMarker = UnityEngine.Object.Instantiate<GameObject>(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity).GetComponent<DetectionMarkerScript>();
        this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
        this.DetectionMarker.Target = base.transform;
      }
      StudentJson studentJson = this.JSON.Students[this.StudentID];
      this.ScheduleBlocks = studentJson.ScheduleBlocks;
      this.Persona = studentJson.Persona;
      this.Class = studentJson.Class;
      this.Crush = studentJson.Crush;
      this.Club = studentJson.Club;
      this.BreastSize = studentJson.BreastSize;
      this.Strength = studentJson.Strength;
      this.Hairstyle = studentJson.Hairstyle;
      this.Accessory = studentJson.Accessory;
      this.Name = studentJson.Name;
      if (this.Name == "Random") {
        this.Persona = (PersonaType)UnityEngine.Random.Range(1, 7);
        studentJson.Persona = this.Persona;
        if (this.Persona == PersonaType.Heroic) {
          this.Strength = UnityEngine.Random.Range(1, 5);
          studentJson.Strength = this.Strength;
        }
      }
      this.Seat = this.StudentManager.Seats[this.Class].List[studentJson.Seat];
      base.gameObject.name = string.Concat(new string[]
      {
        "Student_",
        this.StudentID.ToString(),
        " (",
        this.Name,
        ")"
      });
      this.OriginalPersona = this.Persona;
      if (this.Persona == PersonaType.Loner || this.Persona == PersonaType.Coward) {
        this.CameraAnims = this.CowardAnims;
      } else if (this.Persona == PersonaType.TeachersPet || this.Persona == PersonaType.Heroic || this.Persona == PersonaType.Strict) {
        this.CameraAnims = this.HeroAnims;
      } else if (this.Persona == PersonaType.Evil) {
        this.CameraAnims = this.EvilAnims;
      } else if (this.Persona == PersonaType.SocialButterfly || this.Persona == PersonaType.Lovestruck) {
        this.CameraAnims = this.SocialAnims;
      }
      if (ClubGlobals.GetClubClosed(this.Club)) {
        this.Club = ClubType.None;
      }
      this.DialogueWheel = GameObject.Find("DialogueWheel").GetComponent<DialogueWheelScript>();
      this.ClubManager = GameObject.Find("ClubManager").GetComponent<ClubManagerScript>();
      this.Reputation = GameObject.Find("Reputation").GetComponent<ReputationScript>();
      this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
      this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
      this.Clock = GameObject.Find("Clock").GetComponent<ClockScript>();
      this.MainCamera = GameObject.Find("MainCamera");
      this.Subtitle = this.Yandere.Subtitle;
      this.ShoulderCamera = this.MainCamera.GetComponent<ShoulderCameraScript>();
      this.CameraEffects = this.MainCamera.GetComponent<CameraEffectsScript>();
      this.RightEyeOrigin = this.RightEye.localPosition;
      this.LeftEyeOrigin = this.LeftEye.localPosition;
      this.PickRandomAnim();
      this.HealthBar.transform.parent.gameObject.SetActive(false);
      this.Chopsticks[0].SetActive(false);
      this.Chopsticks[1].SetActive(false);
      this.SmartPhone.SetActive(false);
      this.OccultBook.SetActive(false);
      this.EventBook.SetActive(false);
      this.Scrubber.SetActive(false);
      this.Eraser.SetActive(false);
      this.Bento.SetActive(false);
      this.Pen.SetActive(false);
      this.SpeechLines.Stop();
      this.OriginalWalkAnim = this.WalkAnim;
      if (this.Persona == PersonaType.Evil) {
        this.ScaredAnim = this.EvilWitnessAnim;
      }
      if (!this.Male) {
        this.AnimatedBook.SetActive(false);
        this.PepperSpray.SetActive(false);
        this.Cigarette.SetActive(false);
        this.Lighter.SetActive(false);
        this.CharacterAnimation[this.StripAnim].speed = 1.5f;
        this.CharacterAnimation[this.GameAnim].speed = 2f;
        if (this.Club >= ClubType.Teacher) {
          this.BecomeTeacher();
        }
        if (this.StudentManager.Censor && !this.Teacher) {
          this.Cosmetic.CensorPanties();
        }
        this.CharacterAnimation["f02_topHalfTexting_00"].layer = 9;
        this.CharacterAnimation.Play("f02_topHalfTexting_00");
        this.CharacterAnimation["f02_topHalfTexting_00"].weight = 0f;
        this.CharacterAnimation[this.CarryAnim].layer = 8;
        this.CharacterAnimation.Play(this.CarryAnim);
        this.CharacterAnimation[this.CarryAnim].weight = 0f;
        this.CharacterAnimation[this.SocialSitAnim].layer = 7;
        this.CharacterAnimation.Play(this.SocialSitAnim);
        this.CharacterAnimation[this.SocialSitAnim].weight = 0f;
        this.CharacterAnimation[this.ShyAnim].layer = 6;
        this.CharacterAnimation.Play(this.ShyAnim);
        this.CharacterAnimation[this.ShyAnim].weight = 0f;
        this.CharacterAnimation[this.FistAnim].layer = 5;
        this.CharacterAnimation[this.FistAnim].weight = 0f;
        this.CharacterAnimation[this.WetAnim].layer = 4;
        this.CharacterAnimation.Play(this.WetAnim);
        this.CharacterAnimation[this.WetAnim].weight = 0f;
        this.CharacterAnimation[this.BentoAnim].layer = 3;
        this.CharacterAnimation.Play(this.BentoAnim);
        this.CharacterAnimation[this.BentoAnim].weight = 0f;
        this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
        this.CharacterAnimation.Play(this.AngryFaceAnim);
        this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
        this.DisableEffects();
        this.CharacterAnimation["f02_wetIdle_00"].speed = 1.25f;
        this.DisableEffects();
      } else {
        this.CharacterAnimation[this.CarryShoulderAnim].layer = 5;
        this.CharacterAnimation.Play(this.CarryShoulderAnim);
        this.CharacterAnimation[this.CarryShoulderAnim].weight = 0f;
        this.CharacterAnimation["scaredFace_00"].layer = 4;
        this.CharacterAnimation.Play("scaredFace_00");
        this.CharacterAnimation["scaredFace_00"].weight = 0f;
        this.CharacterAnimation[this.SadFaceAnim].layer = 3;
        this.CharacterAnimation.Play(this.SadFaceAnim);
        this.CharacterAnimation[this.SadFaceAnim].weight = 0f;
        this.CharacterAnimation[this.AngryFaceAnim].layer = 2;
        this.CharacterAnimation.Play(this.AngryFaceAnim);
        this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
        this.Earpiece.SetActive(false);
      }
      if (this.StudentID == 1) {
        this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.OsanaPhoneTexture;
      } else if (this.StudentID == 7 || this.StudentID == 13) {
        if (this.StudentID == 7) {
          this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.KokonaPhoneTexture;
        }
        if (DatingGlobals.SuitorProgress == 2) {
          this.Partner = ((this.StudentID != 7) ? this.StudentManager.Students[7] : this.StudentManager.Students[13]);
          ScheduleBlock scheduleBlock = this.ScheduleBlocks[4];
          scheduleBlock.destination = "Cuddle";
          scheduleBlock.action = "Cuddle";
        }
      } else if (this.StudentID == 16) {
        this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.MidoriPhoneTexture;
        this.SmartPhone.GetComponent<AudioSource>().playOnAwake = true;
        this.PatrolAnim = "f02_texting_00";
      } else if (this.StudentID == 17) {
        if (StudentGlobals.GetStudentDead(18) || StudentGlobals.GetStudentKidnapped(18) || this.StudentManager.Students[18].Slave) {
          ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[2];
          scheduleBlock2.destination = "Mourn";
          scheduleBlock2.action = "Mourn";
        }
      } else if (this.StudentID == 18) {
        if (StudentGlobals.GetStudentDead(17) || StudentGlobals.GetStudentKidnapped(17) || this.StudentManager.Students[17].Slave) {
          ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[2];
          scheduleBlock3.destination = "Mourn";
          scheduleBlock3.action = "Mourn";
        }
      } else if (this.StudentID == 26) {
        this.Shy = true;
      } else if (this.StudentID == 34) {
      }
      if (this.StudentID == this.StudentManager.RivalID) {
        this.RivalPrefix = "Rival ";
        if (DateGlobals.Weekday == DayOfWeek.Friday) {
          ScheduleBlock scheduleBlock4 = this.ScheduleBlocks[7];
          scheduleBlock4.time = 17f;
        }
      }
      if (this.Club == ClubType.None) {
        if (this.StudentID == 33) {
          this.SmartPhone.transform.localPosition = new Vector3(-0.0075f, -0.0025f, -0.0075f);
          this.SmartPhone.transform.localEulerAngles = new Vector3(5f, -150f, 170f);
          this.SmartPhone.GetComponent<Renderer>().material.mainTexture = this.OsanaPhoneTexture;
          this.IdleAnim = "f02_tsunIdle_00";
          this.WalkAnim = "f02_tsunWalk_00";
          this.TaskAnims[0] = "f02_Task33_Line0";
          this.TaskAnims[1] = "f02_Task33_Line1";
          this.TaskAnims[2] = "f02_Task33_Line2";
          this.TaskAnims[3] = "f02_Task33_Line3";
          this.TaskAnims[4] = "f02_Task33_Line4";
          this.TaskAnims[5] = "f02_Task33_Line5";
        }
      } else if (this.Club == ClubType.Occult) {
        if (this.StudentID == 26) {
          if (StudentGlobals.GetStudentDead(17) && StudentGlobals.GetStudentDead(18)) {
            ScheduleBlock scheduleBlock5 = this.ScheduleBlocks[2];
            scheduleBlock5.destination = "Club";
            scheduleBlock5.action = "Club";
          }
          this.ClubAnim = this.IdleAnim;
        } else if (this.Male) {
          this.CharacterAnimation[this.SadFaceAnim].weight = 1f;
        }
      } else if (this.Club == ClubType.MartialArts) {
        this.ChangingBooth = this.StudentManager.ChangingBooths[6];
        this.DressCode = true;
        if (this.StudentID == 21) {
          this.IdleAnim = "pose_03";
          this.ClubAnim = "pose_03";
        } else if (this.StudentID == 22) {
          this.ClubAnim = "idle_20";
          this.ActivityAnim = "kick_24";
        } else if (this.StudentID == 23) {
          this.ClubAnim = "sit_04";
          this.ActivityAnim = "kick_24";
        } else if (this.StudentID == 24) {
          this.ClubAnim = "f02_idle_20";
          this.ActivityAnim = "f02_kick_23";
        } else if (this.StudentID == 25) {
          this.ClubAnim = "f02_sit_05";
          this.ActivityAnim = "f02_kick_23";
        }
        this.ClubMemberID = this.StudentID - 20;
      }
      if (this.Cosmetic.Hairstyle == 20) {
        this.IdleAnim = "f02_tsunIdle_00";
      }
      if (!this.Teacher && this.Name != "Random") {
        this.StudentManager.CleaningManager.GetRole(this.StudentID);
        this.CleaningSpot = this.StudentManager.CleaningManager.Spot;
        this.CleaningRole = this.StudentManager.CleaningManager.Role;
      }
      this.GetDestinations();
      this.OriginalActions = new StudentActionType[this.Actions.Length];
      Array.Copy(this.Actions, this.OriginalActions, this.Actions.Length);
      if (this.AoT) {
        this.AttackOnTitan();
      }
      if (this.Slave) {
        this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
        this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
        this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
        this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
        this.IdleAnim = this.BrokenAnim;
        this.WalkAnim = this.BrokenWalkAnim;
        this.Phone.SetActive(false);
        this.Distracted = true;
        this.OnPhone = false;
        this.Indoors = true;
        this.Safe = false;
        this.Shy = false;
        this.ID = 0;
        while (this.ID < this.ScheduleBlocks.Length) {
          this.ScheduleBlocks[this.ID].time = 0f;
          this.ID++;
        }
      }
      if (this.Spooky) {
        this.Spook();
      }
      this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[2] = true;
      this.ID = 0;
      while (this.ID < this.Ragdoll.AllRigidbodies.Length) {
        this.Ragdoll.AllRigidbodies[this.ID].isKinematic = true;
        this.Ragdoll.AllColliders[this.ID].enabled = false;
        this.ID++;
      }
      this.Ragdoll.AllColliders[10].enabled = true;
      if (this.StudentID == 1) {
        this.DetectionMarker.GetComponent<DetectionMarkerScript>().Tex.color = new Color(1f, 0f, 0f, 0f);
        this.Yandere.Senpai = base.transform;
        this.ID = 0;
        while (this.ID < this.Outlines.Length) {
          this.Outlines[this.ID].enabled = true;
          this.Outlines[this.ID].color = new Color(1f, 0f, 1f);
          this.ID++;
        }
        this.Prompt.ButtonActive[0] = false;
        this.Prompt.ButtonActive[1] = false;
        this.Prompt.ButtonActive[2] = false;
        this.Prompt.ButtonActive[3] = false;
        if (this.StudentManager.MissionMode) {
          base.transform.position = Vector3.zero;
          base.gameObject.SetActive(false);
        }
      } else if (!StudentGlobals.GetStudentPhotographed(this.StudentID)) {
        this.ID = 0;
        while (this.ID < this.Outlines.Length) {
          this.Outlines[this.ID].enabled = false;
          this.Outlines[this.ID].color = new Color(0f, 1f, 0f);
          this.ID++;
        }
      }
      if (StudentGlobals.GetStudentGrudge(this.StudentID)) {
        if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil) {
          this.CameraAnims = this.EvilAnims;
          this.Reputation.PendingRep -= 10f;
          this.PendingRep -= 10f;
          this.ID = 0;
          while (this.ID < this.Outlines.Length) {
            this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
            this.ID++;
          }
        }
        this.Grudge = true;
        this.CameraAnims = this.EvilAnims;
      }
      if (StudentGlobals.GetStudentBroken(this.StudentID)) {
        this.Cosmetic.RightEyeRenderer.gameObject.SetActive(false);
        this.Cosmetic.LeftEyeRenderer.gameObject.SetActive(false);
        this.Cosmetic.RightIrisLight.SetActive(false);
        this.Cosmetic.LeftIrisLight.SetActive(false);
        this.RightEmptyEye.SetActive(true);
        this.LeftEmptyEye.SetActive(true);
        this.Shy = true;
      }
      if (this.Club != ClubType.None && (this.StudentID == 21 || this.StudentID == 26)) {
        this.Armband.SetActive(true);
      }
      if (!this.Teacher) {
        this.CurrentDestination = this.Destinations[this.Phase];
        this.Pathfinding.target = this.Destinations[this.Phase];
      } else {
        this.Indoors = true;
      }
      if (this.StudentID == 1 || this.StudentID == 19 || this.StudentID == 33) {
        this.BookRenderer.material.mainTexture = this.RedBookTexture;
      }
      this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
      if (this.StudentManager.MissionMode && this.StudentID == MissionModeGlobals.MissionTarget) {
        this.ID = 0;
        while (this.ID < this.Outlines.Length) {
          this.Outlines[this.ID].enabled = true;
          this.Outlines[this.ID].color = new Color(1f, 0f, 0f);
          this.ID++;
        }
      }
      UnityEngine.Object.Destroy(this.MyRigidbody);
      this.Started = true;
      if (this.Name == "Delinquent") {
        this.CharacterAnimation[this.CarryShoulderAnim].weight = 1f;
        this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
        this.Weapon.SetActive(true);
      }
      if (this.Club == ClubType.Council) {
        this.Armband.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-0.64375f, 0f));
        this.Armband.SetActive(true);
        this.Indoors = true;
        this.Spawned = true;
        string str = string.Empty;
        if (this.StudentID == 86) {
          str = "Strict";
        } else if (this.StudentID == 87) {
          str = "Casual";
        } else if (this.StudentID == 88) {
          str = "Grace";
        } else if (this.StudentID == 89) {
          str = "Edgy";
        }
        this.CharacterAnimation["f02_faceCouncil" + str + "_00"].layer = 10;
        this.CharacterAnimation.Play("f02_faceCouncil" + str + "_00");
        this.IdleAnim = "f02_idleCouncil" + str + "_00";
        this.WalkAnim = "f02_walkCouncil" + str + "_00";
        this.ShoveAnim = "f02_pushCouncil" + str + "_00";
        this.PatrolAnim = "f02_scanCouncil" + str + "_00";
        this.RelaxAnim = "f02_relaxCouncil" + str + "_00";
        this.SprayAnim = "f02_sprayCouncil" + str + "_00";
        this.ScaredAnim = this.ReadyToFightAnim;
        this.ParanoidAnim = this.GuardAnim;
        this.CameraAnims[1] = this.IdleAnim;
        this.CameraAnims[2] = this.IdleAnim;
        this.CameraAnims[3] = this.IdleAnim;
        this.Paranoia *= 2f;
      }
    }
  }

  // Token: 0x06000811 RID: 2065 RVA: 0x0007F46C File Offset: 0x0007D86C
  private float GetPerceptionPercent(float distance) {
    float num = Mathf.Clamp01(distance / this.VisionDistance);
    return 1f - num * num;
  }

  // Token: 0x170000E9 RID: 233
  // (get) Token: 0x06000812 RID: 2066 RVA: 0x0007F490 File Offset: 0x0007D890
  private SubtitleType LostPhoneSubtitleType {
    get {
      if (this.RivalPrefix == string.Empty) {
        return SubtitleType.LostPhone;
      }
      if (this.RivalPrefix == "Rival ") {
        return SubtitleType.RivalLostPhone;
      }
      throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
    }
  }

  // Token: 0x170000EA RID: 234
  // (get) Token: 0x06000813 RID: 2067 RVA: 0x0007F4E8 File Offset: 0x0007D8E8
  private SubtitleType PickpocketSubtitleType {
    get {
      if (this.RivalPrefix == string.Empty) {
        return SubtitleType.PickpocketReaction;
      }
      if (this.RivalPrefix == "Rival ") {
        return SubtitleType.RivalPickpocketReaction;
      }
      throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
    }
  }

  // Token: 0x170000EB RID: 235
  // (get) Token: 0x06000814 RID: 2068 RVA: 0x0007F540 File Offset: 0x0007D940
  private SubtitleType SplashSubtitleType {
    get {
      if (this.RivalPrefix == string.Empty) {
        return SubtitleType.SplashReaction;
      }
      if (this.RivalPrefix == "Rival ") {
        return SubtitleType.RivalSplashReaction;
      }
      throw new NotImplementedException("\"" + this.RivalPrefix + "\" case not implemented.");
    }
  }

  // Token: 0x170000EC RID: 236
  // (get) Token: 0x06000815 RID: 2069 RVA: 0x0007F598 File Offset: 0x0007D998
  public SubtitleType TaskLineResponseType {
    get {
      if (this.StudentID == 6) {
        return SubtitleType.Task6Line;
      }
      if (this.StudentID == 7) {
        return SubtitleType.Task7Line;
      }
      if (this.StudentID == 13) {
        return SubtitleType.Task13Line;
      }
      if (this.StudentID == 14) {
        return SubtitleType.Task14Line;
      }
      if (this.StudentID == 15) {
        return SubtitleType.Task15Line;
      }
      if (this.StudentID == 32) {
        return SubtitleType.Task32Line;
      }
      if (this.StudentID == 33) {
        return SubtitleType.Task33Line;
      }
      if (this.StudentID == 34) {
        return SubtitleType.Task34Line;
      }
      throw new NotImplementedException("\"" + this.StudentID.ToString() + "\" case not implemented.");
    }
  }

  // Token: 0x170000ED RID: 237
  // (get) Token: 0x06000816 RID: 2070 RVA: 0x0007F648 File Offset: 0x0007DA48
  public SubtitleType ClubInfoResponseType {
    get {
      if (this.Club == ClubType.Occult) {
        return SubtitleType.ClubOccultInfo;
      }
      if (this.Club == ClubType.MartialArts) {
        return SubtitleType.ClubMartialArtsInfo;
      }
      return SubtitleType.ClubPlaceholderInfo;
    }
  }

  // Token: 0x06000817 RID: 2071 RVA: 0x0007F66C File Offset: 0x0007DA6C
  private bool PointIsInFOV(Vector3 point) {
    Vector3 position = this.Eyes.transform.position;
    Vector3 to = point - position;
    float num = this.VisionFOV * 0.5f;
    return Vector3.Angle(this.Head.transform.forward, to) <= num;
  }

  // Token: 0x06000818 RID: 2072 RVA: 0x0007F6BC File Offset: 0x0007DABC
  public bool CanSeeObject(GameObject obj, Vector3 targetPoint, int[] layers, int mask) {
    Vector3 position = this.Eyes.transform.position;
    Vector3 vector = targetPoint - position;
    float num = this.VisionDistance * this.VisionDistance;
    bool flag = this.PointIsInFOV(targetPoint);
    bool flag2 = vector.sqrMagnitude <= num;
    if (flag && flag2) {
      RaycastHit raycastHit;
      bool flag3 = Physics.Linecast(position, targetPoint, out raycastHit, mask);
      if (flag3) {
        foreach (int num2 in layers) {
          bool flag4 = raycastHit.collider.gameObject.layer == num2;
          if (flag4) {
            return true;
          }
        }
      }
    }
    return false;
  }

  // Token: 0x06000819 RID: 2073 RVA: 0x0007F76C File Offset: 0x0007DB6C
  public bool CanSeeObject(GameObject obj, Vector3 targetPoint) {
    Debug.DrawLine(this.Eyes.position, targetPoint, Color.green);
    Vector3 position = this.Eyes.transform.position;
    Vector3 vector = targetPoint - position;
    float num = this.VisionDistance * this.VisionDistance;
    bool flag = this.PointIsInFOV(targetPoint);
    bool flag2 = vector.sqrMagnitude <= num;
    if (flag && flag2) {
      RaycastHit raycastHit;
      bool flag3 = Physics.Linecast(position, targetPoint, out raycastHit, this.Mask);
      if (flag3) {
        bool flag4 = raycastHit.collider.gameObject == obj;
        if (flag4) {
          return true;
        }
      }
    }
    return false;
  }

  // Token: 0x0600081A RID: 2074 RVA: 0x0007F815 File Offset: 0x0007DC15
  public bool CanSeeObject(GameObject obj) {
    return this.CanSeeObject(obj, obj.transform.position);
  }

  // Token: 0x0600081B RID: 2075 RVA: 0x0007F82C File Offset: 0x0007DC2C
  private bool AffectedByEbola(float distance) {
    bool flag = this.Yandere.EbolaHair != null && this.Yandere.EbolaHair.activeInHierarchy;
    return distance <= 1f && flag;
  }

  // Token: 0x0600081C RID: 2076 RVA: 0x0007F874 File Offset: 0x0007DC74
  private void Update() {
    if (!this.Stop) {
      this.DistanceToPlayer = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
      if (this.AffectedByEbola(this.DistanceToPlayer) && this.Alive) {
        UnityEngine.Object.Instantiate<GameObject>(this.Yandere.EbolaEffect, base.transform.position + Vector3.up, Quaternion.identity);
        this.SpawnAlarmDisc();
        this.BecomeRagdoll();
        this.DeathType = DeathType.EasterEgg;
      }
      this.UpdateRoutine();
      this.UpdateVision();
      this.UpdateDetectionMarker();
      this.UpdateTalkInput();
      if (this.Dying) {
        this.UpdateDying();
      } else if (this.Pushed) {
        this.UpdatePushed();
      } else if (this.Drowned) {
        this.UpdateDrowned();
      } else if (this.WitnessedMurder) {
        this.UpdateWitnessedMurder();
      } else if (this.Alarmed) {
        this.UpdateAlarmed();
      }
      if (this.Burning) {
        this.UpdateBurning();
      } else if (this.Splashed) {
        this.UpdateSplashed();
      }
      if (!this.Dying) {
        this.UpdateTurningOffRadio();
      }
      this.UpdateVomiting();
      this.UpdateConfessing();
      this.UpdateMisc();
    } else {
      if (this.StudentManager.Pose) {
        if (this.Prompt.Circle[0].fillAmount == 0f) {
          this.Pose();
        }
      } else if (!this.ClubActivity) {
        if (!this.Yandere.Talking && (this.Yandere.Noticed || this.StudentManager.YandereDying)) {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        }
      } else if (this.Police.Darkness.color.a < 1f) {
        this.CharacterAnimation.Play(this.ActivityAnim);
        if (this.Club == ClubType.MartialArts) {
          AudioSource component = base.GetComponent<AudioSource>();
          if (!this.Male) {
            if (this.CharacterAnimation["f02_kick_23"].time > 1f) {
              if (!this.PlayingAudio) {
                component.clip = this.FemaleAttacks[UnityEngine.Random.Range(0, this.FemaleAttacks.Length)];
                component.Play();
                this.PlayingAudio = true;
              }
              if (this.CharacterAnimation["f02_kick_23"].time >= this.CharacterAnimation["f02_kick_23"].length) {
                this.CharacterAnimation["f02_kick_23"].time = 0f;
                this.PlayingAudio = false;
              }
            }
          } else if (this.CharacterAnimation["kick_24"].time > 1f) {
            if (!this.PlayingAudio) {
              component.clip = this.MaleAttacks[UnityEngine.Random.Range(0, this.MaleAttacks.Length)];
              component.Play();
              this.PlayingAudio = true;
            }
            if (this.CharacterAnimation["kick_24"].time >= this.CharacterAnimation["kick_24"].length) {
              this.CharacterAnimation["kick_24"].time = 0f;
              this.PlayingAudio = false;
            }
          }
        }
      }
      this.Alarm = Mathf.MoveTowards(this.Alarm, 0f, Time.deltaTime);
      this.UpdateDetectionMarker();
    }
    if (this.AoT) {
      base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(10f, 10f, 10f), Time.deltaTime);
    }
    if (this.Prompt.Label[0] != null) {
      if (this.StudentManager.Pose) {
        this.Prompt.Label[0].text = "     Pose";
      } else if (this.BadTime) {
        this.Prompt.Label[0].text = "     Psychokinesis";
      }
    }
  }

  // Token: 0x0600081D RID: 2077 RVA: 0x0007FD54 File Offset: 0x0007E154
  private void UpdateRoutine() {
    if (this.Routine) {
      if (this.CurrentDestination != null) {
        this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
      }
      if (!this.Indoors) {
        if (this.Phase == 0) {
          if (this.DistanceToDestination < 1f) {
            this.CurrentDestination = this.MyLocker;
            this.Pathfinding.target = this.MyLocker;
            this.Phase++;
          }
        } else if (this.DistanceToDestination < 0.5f && !this.ShoeRemoval.enabled) {
          if (this.Shy) {
            this.CharacterAnimation[this.ShyAnim].weight = 0.5f;
          }
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.ShoeRemoval.enabled = true;
          this.CanTalk = false;
          this.Routine = false;
        }
      } else if (this.Phase < this.ScheduleBlocks.Length - 1 && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time && !this.InEvent && !this.Meeting) {
        this.Phase++;
        if (this.StudentID == 33) {
          Debug.Log("Osana's phase has increased to " + this.Phase.ToString() + ".");
        }
        if (this.Schoolwear > 1 && this.Destinations[this.Phase] == this.MyLocker) {
          this.Phase++;
        }
        this.CurrentDestination = this.Destinations[this.Phase];
        this.Pathfinding.target = this.Destinations[this.Phase];
        if (((this.StudentID == 7 && this.StudentManager.DatingMinigame.Affection == 100f) || (this.StudentID == this.StudentManager.RivalID && DateGlobals.Weekday == DayOfWeek.Friday)) && this.Actions[this.Phase] == StudentActionType.ChangeShoes) {
          if (this.StudentID == 7) {
            this.CurrentDestination = this.StudentManager.SuitorLocker;
            this.Pathfinding.target = this.StudentManager.SuitorLocker;
          } else {
            this.CurrentDestination = this.StudentManager.SenpaiLocker;
            this.Pathfinding.target = this.StudentManager.SenpaiLocker;
          }
          this.Confessing = true;
          this.Routine = false;
          this.CanTalk = false;
        }
        if (this.CurrentDestination != null) {
          this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
        }
        if (this.Bento != null && this.Bento.activeInHierarchy) {
          this.Bento.SetActive(false);
          this.Chopsticks[0].SetActive(false);
          this.Chopsticks[1].SetActive(false);
        }
        if (this.Male) {
          this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
        }
        if (this.StudentID == 32) {
          this.Cigarette.SetActive(false);
          this.Lighter.SetActive(false);
        }
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.OccultBook.SetActive(false);
        this.SmartPhone.SetActive(false);
        this.Scrubber.SetActive(false);
        this.Eraser.SetActive(false);
        this.Phone.SetActive(false);
        this.Pen.SetActive(false);
        this.SpeechLines.Stop();
        this.GoAway = false;
        this.ReadPhase = 0;
        this.PatrolID = 0;
        if (this.Actions[this.Phase] == StudentActionType.Clean) {
          this.Scrubber.SetActive(true);
          if (this.CleaningRole == 5) {
            this.Scrubber.GetComponent<Renderer>().material.mainTexture = this.Eraser.GetComponent<Renderer>().material.mainTexture;
            this.Eraser.SetActive(true);
          }
        }
        if (!this.Teacher && (this.Clock.Period == 2 || this.Clock.Period == 4)) {
          this.Pathfinding.speed = 4f;
        }
      }
      if (this.MeetTime > 0f && this.Clock.HourTime > this.MeetTime) {
        this.CurrentDestination = this.MeetSpot;
        this.Pathfinding.target = this.MeetSpot;
        this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.Pathfinding.speed = 4f;
        this.Meeting = true;
        this.MeetTime = 0f;
      }
      if (this.DistanceToDestination > this.TargetDistance) {
        if (((this.Clock.Period == 1 && this.Clock.HourTime > 8.483334f) || (this.Clock.Period == 3 && this.Clock.HourTime > 13.4833336f)) && !this.Teacher) {
          this.Pathfinding.speed = 4f;
        }
        if (!this.InEvent && !this.Meeting && this.DressCode) {
          if (this.Actions[this.Phase] == StudentActionType.ClubAction) {
            if (!this.ClubAttire) {
              if (!this.ChangingBooth.Occupied) {
                this.CurrentDestination = this.ChangingBooth.transform;
                this.Pathfinding.target = this.ChangingBooth.transform;
              } else {
                this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
                this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
              }
            } else if (this.Indoors) {
              this.CurrentDestination = this.Destinations[this.Phase];
              this.Pathfinding.target = this.Destinations[this.Phase];
            }
          } else if (this.ClubAttire) {
            if (!this.ChangingBooth.Occupied) {
              this.CurrentDestination = this.ChangingBooth.transform;
              this.Pathfinding.target = this.ChangingBooth.transform;
            } else {
              this.CurrentDestination = this.ChangingBooth.WaitSpots[this.ClubMemberID];
              this.Pathfinding.target = this.ChangingBooth.WaitSpots[this.ClubMemberID];
            }
          } else if (this.Indoors && this.Actions[this.Phase] != StudentActionType.Clean) {
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
          }
        }
        if (!this.Pathfinding.canMove) {
          if (!this.Spawned) {
            base.transform.position = this.StudentManager.SpawnPositions[this.StudentID].position;
            this.Spawned = true;
          }
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Obstacle.enabled = false;
        }
        if (this.Pathfinding.speed > 0f) {
          if (this.Pathfinding.speed == 1f) {
            if (!this.CharacterAnimation.IsPlaying(this.WalkAnim)) {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
            }
          } else if (!this.Dying) {
            this.CharacterAnimation.CrossFade(this.SprintAnim);
          }
        }
        if (this.Club == ClubType.Occult && this.Actions[this.Phase] != StudentActionType.ClubAction) {
          this.OccultBook.SetActive(false);
        }
        if (this.Actions[this.Phase] == StudentActionType.Clean && this.CurrentDestination != this.CleaningSpot.GetChild(this.CleanID)) {
          this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
          this.Pathfinding.target = this.CurrentDestination;
        }
        if (this.Actions[this.Phase] == StudentActionType.Patrol && this.CurrentDestination != this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID)) {
          this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
          this.Pathfinding.target = this.CurrentDestination;
        }
      } else {
        if (this.CurrentDestination != null) {
          this.MoveTowardsTarget(this.CurrentDestination.position);
          float num = Quaternion.Angle(base.transform.rotation, this.CurrentDestination.rotation);
          if (num > 1f && !this.StopRotating) {
            base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, 10f * Time.deltaTime);
          }
          if (!this.Hurry) {
            this.Pathfinding.speed = 1f;
          } else {
            this.Pathfinding.speed = 4f;
          }
        }
        if (this.Pathfinding.canMove) {
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.Obstacle.enabled = true;
        }
        if (!this.InEvent && !this.Meeting && this.DressCode) {
          if (this.Actions[this.Phase] == StudentActionType.ClubAction) {
            if (!this.ClubAttire) {
              if (!this.ChangingBooth.Occupied) {
                if (this.CurrentDestination == this.ChangingBooth.transform) {
                  this.ChangingBooth.Occupied = true;
                  this.ChangingBooth.Student = this;
                  this.ChangingBooth.CheckYandereClub();
                }
                this.CurrentDestination = this.ChangingBooth.transform;
                this.Pathfinding.target = this.ChangingBooth.transform;
              } else {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
              }
            } else {
              this.CurrentDestination = this.Destinations[this.Phase];
              this.Pathfinding.target = this.Destinations[this.Phase];
            }
          } else if (this.ClubAttire) {
            if (!this.ChangingBooth.Occupied) {
              if (this.CurrentDestination == this.ChangingBooth.transform) {
                this.ChangingBooth.Occupied = true;
                this.ChangingBooth.Student = this;
                this.ChangingBooth.CheckYandereClub();
              }
              this.CurrentDestination = this.ChangingBooth.transform;
              this.Pathfinding.target = this.ChangingBooth.transform;
            } else {
              this.CharacterAnimation.CrossFade(this.IdleAnim);
            }
          } else if (this.Actions[this.Phase] != StudentActionType.Clean) {
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
          }
        }
        if (!this.InEvent) {
          if (!this.Meeting) {
            if (!this.GoAway) {
              if (this.Actions[this.Phase] == StudentActionType.AtLocker) {
                this.CharacterAnimation.CrossFade(this.IdleAnim);
              } else if (this.Actions[this.Phase] == StudentActionType.Socializing) {
                if (this.Paranoia > 1.66666f && !GameGlobals.LoveSick) {
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                } else {
                  this.StudentManager.ConvoManager.CheckMe(this.StudentID);
                  if (this.Alone) {
                    if (!this.Male) {
                      this.CharacterAnimation.CrossFade("f02_texting_00");
                    } else {
                      this.CharacterAnimation.CrossFade("standTexting_00");
                    }
                    if (!this.SmartPhone.activeInHierarchy) {
                      this.SmartPhone.SetActive(true);
                      this.SpeechLines.Stop();
                    }
                  } else {
                    if (!this.SpeechLines.isPlaying) {
                      this.SmartPhone.SetActive(false);
                      this.SpeechLines.Play();
                    }
                    this.CharacterAnimation.CrossFade(this.RandomAnim);
                    if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length) {
                      this.PickRandomAnim();
                    }
                  }
                }
              } else if (this.Actions[this.Phase] == StudentActionType.Gaming) {
                this.CharacterAnimation.CrossFade(this.GameAnim);
              } else if (this.Actions[this.Phase] == StudentActionType.Shamed) {
                this.CharacterAnimation.CrossFade(this.SadSitAnim);
              } else if (this.Actions[this.Phase] == StudentActionType.Slave) {
                this.CharacterAnimation.CrossFade(this.BrokenSitAnim);
              } else if (this.Actions[this.Phase] == StudentActionType.Relax) {
                this.CharacterAnimation.CrossFade(this.RelaxAnim);
              } else if (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes) {
                if (this.Rival && this.Phoneless && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch && this.Yandere.CanMove) {
                  this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
                  this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
                  this.EndSearch = true;
                  this.Routine = false;
                }
                if (!this.EndSearch) {
                  if (this.Clock.Period != 2 && this.Clock.Period != 4) {
                    if (this.DressCode && this.ClubAttire) {
                      this.CharacterAnimation.CrossFade(this.IdleAnim);
                    } else if ((double)Vector3.Distance(base.transform.position, this.Seat.position) < 0.5) {
                      if (!this.Phoneless) {
                        if (!this.Phone.activeInHierarchy) {
                          this.Phone.transform.localPosition = new Vector3(0.02f, 0.01f, 0.02f);
                          this.Phone.transform.localEulerAngles = new Vector3(-15f, 30f, 0f);
                          this.Phone.SetActive(true);
                        }
                        this.CharacterAnimation.CrossFade(this.DeskTextAnim);
                      } else {
                        this.CharacterAnimation.CrossFade("f02_sadDeskSit_00");
                      }
                    }
                  } else if (this.StudentManager.Teachers[this.Class].SpeechLines.isPlaying) {
                    if (this.DressCode && this.ClubAttire) {
                      this.CharacterAnimation.CrossFade(this.IdleAnim);
                    } else {
                      if (!this.Depressed && !this.Pen.activeInHierarchy) {
                        this.Pen.SetActive(true);
                      }
                      if (this.Phone.activeInHierarchy) {
                        this.Phone.SetActive(false);
                      }
                      if (this.MyPaper == null) {
                        if (base.transform.position.x < 0f) {
                          this.MyPaper = UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(-0.4f, 0.772f, 0f), Quaternion.identity);
                        } else {
                          this.MyPaper = UnityEngine.Object.Instantiate<GameObject>(this.Paper, this.Seat.position + new Vector3(0.4f, 0.772f, 0f), Quaternion.identity);
                        }
                        this.MyPaper.transform.eulerAngles = new Vector3(0f, 0f, -90f);
                        this.MyPaper.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
                        this.MyPaper.transform.parent = this.StudentManager.Papers;
                      }
                      this.CharacterAnimation.CrossFade(this.SitAnim);
                    }
                  } else {
                    this.CharacterAnimation.CrossFade(this.DeskTextAnim);
                  }
                }
              } else if (this.Actions[this.Phase] == StudentActionType.Stalk) {
                this.CharacterAnimation.CrossFade(this.StalkAnim);
                if (this.Male) {
                  this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
                }
              } else if (this.Actions[this.Phase] == StudentActionType.ClubAction) {
                if (this.DressCode && !this.ClubAttire) {
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                } else {
                  this.CharacterAnimation.CrossFade(this.ClubAnim);
                }
                if (this.Club == ClubType.Occult && this.StudentID != 26) {
                  this.OccultBook.SetActive(true);
                }
              } else if (this.Actions[this.Phase] == StudentActionType.SitAndSocialize) {
                if (this.Paranoia > 1.66666f) {
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                } else {
                  if (!this.SpeechLines.isPlaying) {
                    this.SpeechLines.Play();
                  }
                  this.CharacterAnimation.CrossFade(this.RandomAnim);
                  if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length) {
                    this.PickRandomAnim();
                  }
                }
              } else if (this.Actions[this.Phase] == StudentActionType.SitAndEatBento) {
                if (!this.Ragdoll.Poisoned && !this.Bento.activeInHierarchy) {
                  this.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
                  this.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
                  this.Chopsticks[0].SetActive(true);
                  this.Chopsticks[1].SetActive(true);
                  this.Bento.SetActive(true);
                  this.Lid.SetActive(false);
                }
                if (!this.Emetic && !this.Lethal) {
                  this.CharacterAnimation.CrossFade(this.EatAnim);
                } else if (this.Emetic) {
                  if (!this.Distracted) {
                    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                    this.CharacterAnimation.CrossFade(this.EmeticAnim);
                    this.Distracted = true;
                    this.CanTalk = false;
                  }
                  if (this.CharacterAnimation[this.EmeticAnim].time >= this.CharacterAnimation[this.EmeticAnim].length) {
                    this.WalkAnim = "f02_stomachPainWalk_00";
                    this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                    this.Pathfinding.target = this.StudentManager.FemaleVomitSpot;
                    this.CurrentDestination = this.StudentManager.FemaleVomitSpot;
                    this.CharacterAnimation.CrossFade(this.WalkAnim);
                    this.Pathfinding.canSearch = true;
                    this.DistanceToDestination = 100f;
                    this.Pathfinding.canMove = true;
                    this.Pathfinding.speed = 2f;
                    this.Routine = false;
                    this.Vomiting = true;
                    this.Private = true;
                    this.Chopsticks[0].SetActive(false);
                    this.Chopsticks[1].SetActive(false);
                    this.Bento.SetActive(false);
                  }
                } else {
                  if (!this.Distracted) {
                    this.StudentManager.Students[1].CharacterAnimation.CrossFade("witnessPoisoning_00");
                    this.StudentManager.Students[1].Distracted = true;
                    this.StudentManager.Students[1].Routine = false;
                    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                    this.CharacterAnimation.CrossFade("f02_poisonDeath_00");
                    this.Ragdoll.Poisoned = true;
                    this.Distracted = true;
                    this.Prompt.Hide();
                    this.Prompt.enabled = false;
                  }
                  if (this.CharacterAnimation["f02_poisonDeath_00"].time >= 17.5f && this.Bento.activeInHierarchy) {
                    this.StudentManager.Students[1].Chopsticks[0].SetActive(false);
                    this.StudentManager.Students[1].Chopsticks[1].SetActive(false);
                    this.StudentManager.Students[1].Bento.SetActive(false);
                    this.Chopsticks[0].SetActive(false);
                    this.Chopsticks[1].SetActive(false);
                    this.Bento.SetActive(false);
                  }
                  if (this.CharacterAnimation["f02_poisonDeath_00"].time >= this.CharacterAnimation["f02_poisonDeath_00"].length) {
                    this.BecomeRagdoll();
                    this.DeathType = DeathType.Poison;
                  }
                }
              } else if (this.Actions[this.Phase] == StudentActionType.ChangeShoes) {
                if (this.MeetTime == 0f) {
                  if (this.StudentManager.LoveManager.Suitor == this && this.StudentManager.LoveManager.LeftNote) {
                    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                    this.CharacterAnimation.CrossFade("keepNote_00");
                    this.ShoeRemoval.Locker.GetComponent<Animation>().CrossFade("lockerKeepNote");
                    this.Pathfinding.canSearch = false;
                    this.Pathfinding.canMove = false;
                    this.Confessing = true;
                    this.CanTalk = false;
                    this.Routine = false;
                  } else {
                    this.Pathfinding.canSearch = false;
                    this.Pathfinding.canMove = false;
                    this.ShoeRemoval.enabled = true;
                    this.CanTalk = false;
                    this.Routine = false;
                    this.ShoeRemoval.LeavingSchool();
                  }
                } else {
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                }
              } else if (this.Actions[this.Phase] == StudentActionType.GradePapers) {
                this.CharacterAnimation.CrossFade("f02_deskWrite");
                this.GradingPaper.Writing = true;
                this.Obstacle.enabled = true;
                this.Pen.SetActive(true);
              } else if (this.Actions[this.Phase] == StudentActionType.Patrol) {
                this.PatrolTimer += Time.deltaTime;
                this.CharacterAnimation.CrossFade(this.PatrolAnim);
                if (this.PatrolTimer >= this.CharacterAnimation[this.PatrolAnim].length) {
                  this.PatrolID++;
                  if (this.PatrolID == this.StudentManager.Patrols.List[this.StudentID].childCount) {
                    this.PatrolID = 0;
                  }
                  this.CurrentDestination = this.StudentManager.Patrols.List[this.StudentID].GetChild(this.PatrolID);
                  this.Pathfinding.target = this.CurrentDestination;
                  if (this.StudentID == 16) {
                    this.CharacterAnimation["f02_topHalfTexting_00"].weight = 1f;
                  }
                  this.PatrolTimer = 0f;
                }
              } else if (this.Actions[this.Phase] == StudentActionType.Read) {
                if (this.ReadPhase == 0) {
                  this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  this.CharacterAnimation.CrossFade(this.BookSitAnim);
                  if (this.CharacterAnimation[this.BookSitAnim].time > this.CharacterAnimation[this.BookSitAnim].length) {
                    this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                    this.CharacterAnimation.CrossFade(this.BookReadAnim);
                    this.ReadPhase++;
                  } else if (this.CharacterAnimation[this.BookSitAnim].time > 1f) {
                    this.OccultBook.SetActive(true);
                  }
                }
              } else if (this.Actions[this.Phase] == StudentActionType.Texting) {
                this.CharacterAnimation.CrossFade("f02_texting_00");
                if (!this.SmartPhone.activeInHierarchy && base.transform.position.y > 11f) {
                  this.SmartPhone.SetActive(true);
                }
              } else if (this.Actions[this.Phase] == StudentActionType.Mourn) {
                this.CharacterAnimation.CrossFade("f02_brokenSit_00");
              } else if (this.Actions[this.Phase] == StudentActionType.Cuddle) {
                if (Vector3.Distance(base.transform.position, this.Partner.transform.position) < 1f) {
                  ParticleSystem.EmissionModule emission = this.Hearts.emission;
                  if (!emission.enabled) {
                    emission.enabled = true;
                    if (!this.Male) {
                      this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
                    } else {
                      this.Cosmetic.MyRenderer.materials[this.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
                    }
                  }
                  this.CharacterAnimation.CrossFade(this.CuddleAnim);
                } else {
                  this.CharacterAnimation.CrossFade(this.IdleAnim);
                }
              } else if (this.Actions[this.Phase] == StudentActionType.Teaching) {
                if (this.Clock.Period != 2 && this.Clock.Period != 4) {
                  this.CharacterAnimation.CrossFade("f02_teacherPodium_00");
                } else {
                  if (!this.SpeechLines.isPlaying) {
                    this.SpeechLines.Play();
                  }
                  this.CharacterAnimation.CrossFade(this.TeachAnim);
                }
              } else if (this.Actions[this.Phase] == StudentActionType.SearchPatrol) {
                if (this.PatrolID == 0 && this.StudentManager.CommunalLocker.RivalPhone.gameObject.activeInHierarchy && !this.EndSearch) {
                  this.CharacterAnimation.CrossFade(this.DiscoverPhoneAnim);
                  this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 2, 5f);
                  this.EndSearch = true;
                  this.Routine = false;
                }
                if (!this.EndSearch) {
                  this.PatrolTimer += Time.deltaTime;
                  this.CharacterAnimation.CrossFade(this.SearchPatrolAnim);
                  if (this.PatrolTimer >= this.CharacterAnimation[this.SearchPatrolAnim].length) {
                    this.PatrolID++;
                    if (this.PatrolID == this.StudentManager.SearchPatrols.List[this.StudentID].childCount) {
                      this.PatrolID = 0;
                    }
                    this.CurrentDestination = this.StudentManager.SearchPatrols.List[this.StudentID].GetChild(this.PatrolID);
                    this.Pathfinding.target = this.CurrentDestination;
                    this.DistanceToDestination = 100f;
                    if (this.StudentID == 16) {
                      this.CharacterAnimation["f02_topHalfTexting_00"].weight = 1f;
                    }
                    this.PatrolTimer = 0f;
                  }
                }
              } else if (this.Actions[this.Phase] == StudentActionType.Wait) {
                if (!this.Cigarette.active && TaskGlobals.GetTaskStatus(32) == 3) {
                  this.WaitAnim = "f02_smokeAttempt_00";
                  this.Cigarette.SetActive(true);
                  this.Lighter.SetActive(true);
                }
                this.CharacterAnimation.CrossFade(this.WaitAnim);
              } else if (this.Actions[this.Phase] == StudentActionType.Clean) {
                this.CleanTimer += Time.deltaTime;
                if (this.CleaningRole == 5) {
                  if (this.CleanID == 0) {
                    this.CharacterAnimation.CrossFade(this.CleanAnims[1]);
                  } else {
                    this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
                    if ((double)this.CleanTimer >= 1.166666 && (double)this.CleanTimer <= 6.166666 && !this.ChalkDust.isPlaying) {
                      this.ChalkDust.Play();
                    }
                  }
                } else {
                  this.CharacterAnimation.CrossFade(this.CleanAnims[this.CleaningRole]);
                }
                if (this.CleanTimer >= this.CharacterAnimation[this.CleanAnims[this.CleaningRole]].length) {
                  this.CleanID++;
                  if (this.CleanID == this.CleaningSpot.childCount) {
                    this.CleanID = 0;
                  }
                  this.CurrentDestination = this.CleaningSpot.GetChild(this.CleanID);
                  this.Pathfinding.target = this.CurrentDestination;
                  this.DistanceToDestination = 100f;
                  this.CleanTimer = 0f;
                }
              }
            } else {
              this.CharacterAnimation.CrossFade(this.IdleAnim);
              this.GoAwayTimer += Time.deltaTime;
              if (this.GoAwayTimer > 60f) {
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.GoAwayTimer = 0f;
                this.GoAway = false;
              }
            }
          } else {
            if (this.MeetTimer == 0f) {
              if (PlayerGlobals.GetStudentFriend(7) && this.Yandere.Bloodiness == 0f && (double)this.Yandere.Sanity >= 66.66666 && (this.CurrentDestination == this.StudentManager.MeetSpots.List[8] || this.CurrentDestination == this.StudentManager.MeetSpots.List[9] || this.CurrentDestination == this.StudentManager.MeetSpots.List[10])) {
                this.StudentManager.OfferHelp.UpdateLocation();
                this.StudentManager.OfferHelp.enabled = true;
              }
              if (base.transform.position.y > 11f) {
                this.Prompt.Label[0].text = "     Push";
                this.Prompt.HideButton[0] = false;
                this.Pushable = true;
              }
              if (this.CurrentDestination == this.StudentManager.FountainSpot) {
                this.Prompt.Label[0].text = "     Drown";
                this.Prompt.HideButton[0] = false;
                this.Drownable = true;
              }
            }
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.MeetTimer += Time.deltaTime;
            if (this.MeetTimer > 60f) {
              if (!this.Male) {
                this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 4, 3f);
              } else {
                this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 6, 3f);
              }
              while (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time) {
                this.Phase++;
              }
              this.CurrentDestination = this.Destinations[this.Phase];
              this.Pathfinding.target = this.Destinations[this.Phase];
              this.StopMeeting();
            }
          }
        }
      }
    } else {
      if (this.CurrentDestination != null) {
        this.DistanceToDestination = Vector3.Distance(base.transform.position, this.CurrentDestination.position);
      }
      if (this.Fleeing && !this.Dying) {
        if (!this.PinningDown) {
          if (this.Yandere.Chased) {
            this.Pathfinding.speed += Time.deltaTime;
          }
          this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
          if (this.AlarmTimer > 0f) {
            this.AlarmTimer = Mathf.MoveTowards(this.AlarmTimer, 0f, Time.deltaTime);
            if (this.StudentID == 1) {
              Debug.Log("Senpai entered his scared animation.");
            }
            this.CharacterAnimation.CrossFade(this.ScaredAnim);
            if (this.AlarmTimer == 0f) {
              this.WalkBack = false;
              this.Alarmed = false;
            }
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            if (this.WitnessedMurder) {
              this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
              base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
            } else if (this.WitnessedCorpse) {
              this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
              base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
            }
          } else {
            if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called) {
              this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
              this.StudentManager.Reporter = this;
              this.Reporting = true;
              this.DetermineCorpseLocation();
            }
            if (base.transform.position.y < -2f) {
              if (this.Persona != PersonaType.Coward && this.Persona != PersonaType.Evil && this.OriginalPersona != PersonaType.Evil) {
                this.Police.Witnesses--;
                this.Police.Show = true;
              }
              base.transform.position = new Vector3(base.transform.position.x, -100f, base.transform.position.z);
              base.gameObject.SetActive(false);
            }
            if (base.transform.position.z < -99f) {
              this.Prompt.Hide();
              this.Prompt.enabled = false;
              this.Safe = true;
            }
            if (this.DistanceToDestination > this.TargetDistance) {
              this.CharacterAnimation.CrossFade(this.SprintAnim);
              this.Pathfinding.canSearch = true;
              this.Pathfinding.canMove = true;
              if (this.Yandere.Chased) {
                this.Pathfinding.repathRate = 0f;
                this.Pathfinding.speed = 7.5f;
              } else {
                this.Pathfinding.speed = 4f;
              }
            } else {
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              if (!this.Halt) {
                this.MoveTowardsTarget(this.Pathfinding.target.position);
                if (!this.Teacher) {
                  base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
                }
              } else if (this.Persona == PersonaType.TeachersPet) {
                this.targetRotation = Quaternion.LookRotation(new Vector3(this.StudentManager.Teachers[this.Class].transform.position.x, base.transform.position.y, this.StudentManager.Teachers[this.Class].transform.position.z) - base.transform.position);
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
              } else if (this.Persona == PersonaType.Dangerous) {
                this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
              }
              if (this.Persona == PersonaType.TeachersPet) {
                if (this.Reporting) {
                  if (this.StudentManager.Teachers[this.Class].Alarmed) {
                    if (this.Club == ClubType.Council) {
                      this.Pathfinding.target = this.StudentManager.CorpseLocation;
                      this.CurrentDestination = this.StudentManager.CorpseLocation;
                    } else {
                      this.Pathfinding.target = this.Seat;
                      this.CurrentDestination = this.Seat;
                    }
                    this.ReportPhase = 2;
                  }
                  if (this.ReportPhase == 0) {
                    this.CharacterAnimation.CrossFade(this.ScaredAnim);
                    if (this.WitnessedCorpse) {
                      this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 2, 3f);
                    } else {
                      this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 2, 3f);
                    }
                    this.StudentManager.Teachers[this.Class].CharacterAnimation.CrossFade(this.StudentManager.Teachers[this.Class].IdleAnim);
                    this.StudentManager.Teachers[this.Class].Routine = false;
                    if (this.StudentManager.Teachers[this.Class].Investigating) {
                      this.StudentManager.Teachers[this.Class].StopInvestigating();
                    }
                    this.Halt = true;
                    this.ReportPhase++;
                  } else if (this.ReportPhase == 1) {
                    this.CharacterAnimation.CrossFade(this.ScaredAnim);
                    this.StudentManager.Teachers[this.Class].targetRotation = Quaternion.LookRotation(base.transform.position - this.StudentManager.Teachers[this.Class].transform.position);
                    this.StudentManager.Teachers[this.Class].transform.rotation = Quaternion.Slerp(this.StudentManager.Teachers[this.Class].transform.rotation, this.StudentManager.Teachers[this.Class].targetRotation, 10f * Time.deltaTime);
                    this.ReportTimer += Time.deltaTime;
                    if (this.ReportTimer >= 3f) {
                      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
                      this.StudentManager.Teachers[this.Class].MyReporter = base.transform;
                      this.StudentManager.Teachers[this.Class].Routine = false;
                      this.StudentManager.Teachers[this.Class].Fleeing = true;
                      this.ReportTimer = 0f;
                      this.ReportPhase++;
                    }
                  } else if (this.ReportPhase < 100) {
                    this.CharacterAnimation.CrossFade(this.ParanoidAnim);
                  } else {
                    this.CharacterAnimation.CrossFade(this.ScaredAnim);
                    this.ReportTimer += Time.deltaTime;
                    if (this.ReportTimer >= 5f) {
                      if (this.StudentManager.Reporter == this) {
                        this.StudentManager.Reporter = null;
                        this.StudentManager.StopFleeing();
                        this.StudentManager.UpdateStudents();
                      }
                      this.Pathfinding.target = this.Destinations[this.Phase];
                      this.Pathfinding.speed = 1f;
                      this.TargetDistance = 1f;
                      this.ReportPhase = 0;
                      this.ReportTimer = 0f;
                      this.AlarmTimer = 0f;
                      this.WitnessedCorpse = false;
                      this.WitnessedMurder = false;
                      this.Reporting = false;
                      this.Reacted = false;
                      this.Alarmed = false;
                      this.Fleeing = false;
                      this.Routine = true;
                      this.Halt = false;
                      this.ID = 0;
                      while (this.ID < this.Outlines.Length) {
                        this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
                        this.ID++;
                      }
                    }
                  }
                } else if (this.Club == ClubType.Council) {
                  this.CharacterAnimation.CrossFade(this.GuardAnim);
                  this.Persona = PersonaType.Dangerous;
                  this.Guarding = true;
                  this.Fleeing = false;
                }
              } else if (this.Persona == PersonaType.Heroic) {
                if (!this.Yandere.Attacking && !this.StudentManager.PinningDown) {
                  if (!this.Yandere.Struggling) {
                    this.BeginStruggle();
                  }
                  if (!this.Teacher) {
                    this.CharacterAnimation[this.StruggleAnim].time = this.Yandere.CharacterAnimation["f02_struggleA_00"].time;
                  } else {
                    this.CharacterAnimation[this.StruggleAnim].time = this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time;
                  }
                  base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Yandere.transform.rotation, 10f * Time.deltaTime);
                  this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.425f);
                  if (!this.Yandere.Armed || !this.Yandere.EquippedWeapon.Concealable) {
                    this.Yandere.StruggleBar.HeroWins();
                  }
                  if (this.Lost) {
                    this.CharacterAnimation.CrossFade(this.StruggleWonAnim);
                    if (this.CharacterAnimation[this.StruggleWonAnim].time > 1f) {
                      this.EyeShrink = 1f;
                    }
                    if (this.CharacterAnimation[this.StruggleWonAnim].time >= this.CharacterAnimation[this.StruggleWonAnim].length) {
                    }
                  } else if (this.Won) {
                    this.CharacterAnimation.CrossFade(this.StruggleLostAnim);
                  }
                } else {
                  this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
                }
              } else if (this.Persona == PersonaType.Coward) {
                this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                this.CharacterAnimation.CrossFade(this.CowardAnim);
                this.ReactionTimer += Time.deltaTime;
                if (this.ReactionTimer > 5f) {
                  this.CurrentDestination = this.StudentManager.Exit;
                  this.Pathfinding.target = this.StudentManager.Exit;
                }
              } else if (this.Persona == PersonaType.Evil) {
                this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
                this.CharacterAnimation.CrossFade(this.EvilAnim);
                this.ReactionTimer += Time.deltaTime;
                if (this.ReactionTimer > 5f) {
                  this.CurrentDestination = this.StudentManager.Exit;
                  this.Pathfinding.target = this.StudentManager.Exit;
                }
              } else if (this.Persona == PersonaType.SocialButterfly) {
                if (this.ReportPhase < 4) {
                  base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
                }
                if (this.ReportPhase == 1) {
                  if (!this.Phone.activeInHierarchy) {
                    if (this.StudentManager.Reporter == null && !Police.Called) {
                      CharacterAnimation.CrossFade(SocialReportAnim);
                      Subtitle.UpdateLabel(SubtitleType.SocialReport, 1, 5f);
                      StudentManager.Reporter = this;
                      Phone.SetActive(true);
                    } else {
                      ReportTimer = 5f;
                    }
                  }
                  ReportTimer += Time.deltaTime;
                  if (ReportTimer > 5f) {
                    if (StudentManager.Reporter == this) {
                      Police.Called = true;
                      Police.Show = true;
                    }
                    CharacterAnimation.CrossFade(ParanoidAnim);
                    Phone.SetActive(false);
                    ReportPhase++;
                    Halt = false;
                  }
                } else if (ReportPhase == 2) {
                  if (WitnessedMurder && (!SawMask || (SawMask && Yandere.Mask != null))) {
                    LookForYandere();
                  }
                } else if (ReportPhase == 3) {
                  CharacterAnimation.CrossFade(SocialFearAnim);
                  Subtitle.UpdateLabel(SubtitleType.SocialFear, 1, 5f);
                  SpawnAlarmDisc();
                  ReportPhase++;
                } else if (ReportPhase == 4) {
                  targetRotation = Quaternion.LookRotation(new Vector3(Yandere.Hips.transform.position.x, base.transform.position.y, Yandere.Hips.transform.position.z) - base.transform.position);
                  base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
                  if (Yandere.Attacking) {
                    LookForYandere();
                  }
                } else if (ReportPhase == 5) {
                  CharacterAnimation.CrossFade(SocialTerrorAnim);
                  Subtitle.UpdateLabel(SubtitleType.SocialTerror, 1, 5f);
                  VisionDistance = 0f;
                  SpawnAlarmDisc();
                  ReportPhase++;
                }
              } else if (Persona == PersonaType.Lovestruck) {
                if (ReportPhase < 3 && StudentManager.Students[1].Fleeing) {
                  Pathfinding.target = StudentManager.Exit;
                  CurrentDestination = StudentManager.Exit;
                  ReportPhase = 3;
                }
                if (ReportPhase == 1) {
                  StudentManager.Students[1].CharacterAnimation.CrossFade("surprised_00");
                  CharacterAnimation.CrossFade(ScaredAnim);
                  StudentManager.Students[1].Pathfinding.canSearch = false;
                  StudentManager.Students[1].Pathfinding.canMove = false;
                  StudentManager.Students[1].Pathfinding.enabled = false;
                  StudentManager.Students[1].Routine = false;
                  Pathfinding.enabled = false;
                  if (WitnessedMurder && !SawMask) {
                    Yandere.Jukebox.gameObject.active = false;
                    Yandere.MainCamera.enabled = false;
                    Yandere.RPGCamera.enabled = false;
                    Yandere.Jukebox.Volume = 0f;
                    Yandere.CanMove = false;
                    StudentManager.LovestruckCamera.transform.parent = base.transform;
                    StudentManager.LovestruckCamera.transform.localPosition = new Vector3(1f, 1f, -1f);
                    StudentManager.LovestruckCamera.transform.localEulerAngles = new Vector3(0f, -30f, 0f);
                    StudentManager.LovestruckCamera.active = true;
                  }
                  if (WitnessedMurder && !SawMask) {
                    Subtitle.UpdateLabel(SubtitleType.LovestruckMurderReport, 1, 5f);
                  } else {
                    Subtitle.UpdateLabel(SubtitleType.LovestruckCorpseReport, 1, 5f);
                  }
                  ReportPhase++;
                } else if (ReportPhase == 2) {
                  targetRotation = Quaternion.LookRotation(new Vector3(StudentManager.Students[1].transform.position.x, base.transform.position.y, StudentManager.Students[1].transform.position.z) - base.transform.position);
                  base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
                  targetRotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, StudentManager.Students[1].transform.position.y, base.transform.position.z) - StudentManager.Students[1].transform.position);
                  StudentManager.Students[1].transform.rotation = Quaternion.Slerp(StudentManager.Students[1].transform.rotation, targetRotation, 10f * Time.deltaTime);
                  ReportTimer += Time.deltaTime;
                  if (ReportTimer > 5f) {
                    if (WitnessedMurder && !SawMask) {
                      Yandere.ShoulderCamera.HeartbrokenCamera.SetActive(true);
                      Yandere.Police.EndOfDay.Heartbroken.Exposed = true;
                      Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
                      Yandere.Collapse = true;
                      ReportPhase++;
                    } else {
                      StudentManager.Students[1].Pathfinding.target = StudentManager.Exit;
                      StudentManager.Students[1].CurrentDestination = StudentManager.Exit;
                      StudentManager.Students[1].CharacterAnimation.CrossFade(StudentManager.Students[1].SprintAnim);
                      StudentManager.Students[1].Pathfinding.canSearch = true;
                      StudentManager.Students[1].Pathfinding.canMove = true;
                      StudentManager.Students[1].Pathfinding.enabled = true;
                      StudentManager.Students[1].Pathfinding.speed = 4f;
                      Pathfinding.target = StudentManager.Exit;
                      CurrentDestination = StudentManager.Exit;
                      Pathfinding.enabled = true;
                      ReportPhase++;
                    }
                  }
                }
              } else if (Persona == PersonaType.Dangerous) {
                if (!Yandere.Attacking && !StudentManager.PinningDown) {
                  if (!Yandere.Struggling) {
                    Spray();
                  }
                } else {
                  CharacterAnimation.CrossFade(ReadyToFightAnim);
                }
              } else if (Persona == PersonaType.Strict) {
                if (!WitnessedMurder) {
                  if (ReportPhase == 0) {
                    Subtitle.UpdateLabel(SubtitleType.TeacherReportReaction, 1, 3f);
                    ReportPhase++;
                  } else if (ReportPhase == 1) {
                    CharacterAnimation.CrossFade(IdleAnim);
                    ReportTimer += Time.deltaTime;
                    if (ReportTimer >= 3f) {
                      base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
                      if (!StudentManager.Reporter.Teacher) {
                        StudentManager.Reporter.Pathfinding.target = StudentManager.CorpseLocation;
                      }
                      Pathfinding.target = StudentManager.CorpseLocation;
                      StudentManager.Reporter.TargetDistance = 2f;
                      TargetDistance = 1f;
                      ReportTimer = 0f;
                      ReportPhase++;
                    }
                  } else if (ReportPhase == 2) {
                    if (WitnessedCorpse) {
                      DetermineCorpseLocation();
                      if (!Corpse.Poisoned) {
                        Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 1, 5f);
                      } else {
                        Subtitle.UpdateLabel(SubtitleType.TeacherCorpseInspection, 2, 2f);
                      }
                      ReportPhase++;
                    } else {
                      CharacterAnimation.CrossFade(IdleAnim);
                      ReportTimer += Time.deltaTime;
                      if (ReportTimer > 5f) {
                        Subtitle.UpdateLabel(SubtitleType.TeacherPrankReaction, 1, 7f);
                        ReportPhase = 98;
                        ReportTimer = 0f;
                      }
                    }
                  } else if (ReportPhase == 3) {
                    targetRotation = Quaternion.LookRotation(new Vector3(Corpse.AllColliders[0].transform.position.x, base.transform.position.y, Corpse.AllColliders[0].transform.position.z) - base.transform.position);
                    base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
                    CharacterAnimation.CrossFade(InspectAnim);
                    ReportTimer += Time.deltaTime;
                    if (ReportTimer >= 6f) {
                      ReportTimer = 0f;
                      ReportPhase++;
                    }
                  } else if (ReportPhase == 4) {
                    Subtitle.UpdateLabel(SubtitleType.TeacherPoliceReport, 1, 5f);
                    Phone.SetActive(true);
                    ReportPhase++;
                  } else if ((float)ReportPhase == 5f) {
                    CharacterAnimation.CrossFade(CallAnim);
                    ReportTimer += Time.deltaTime;
                    if (ReportTimer >= 5f) {
                      CharacterAnimation.CrossFade(GuardAnim);
                      Phone.SetActive(false);
                      Police.Called = true;
                      Police.Show = true;
                      ReportTimer = 0f;
                      Guarding = true;
                      Fleeing = false;
                      Reacted = false;
                      ReportPhase++;
                    }
                  } else if (ReportPhase == 98) {
                    targetRotation = Quaternion.LookRotation(MyReporter.transform.position - base.transform.position);
                    base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
                    ReportTimer += Time.deltaTime;
                    if (ReportTimer > 7f) {
                      ReportPhase++;
                    }
                  } else if (ReportPhase == 99) {
                    Subtitle.UpdateLabel(SubtitleType.PrankReaction, 1, 5f);
                    StudentManager.Reporter.ReportPhase = 100;
                    Pathfinding.target = Destinations[Phase];
                    ReportTimer = 0f;
                    ReportPhase++;
                  } else if (ReportPhase == 100) {
                    ReportPhase = 0;
                    Fleeing = false;
                    Routine = true;
                  }
                } else if (!Yandere.Dumping && !Yandere.Attacking) {
                  if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus == 0) {
                    Debug.Log("A teacher is taking down Yandere-chan.");
                    if (Yandere.Aiming) {
                      Yandere.StopAiming();
                    }
                    this.Yandere.Mopping = false;
                    this.Yandere.EmptyHands();
                    this.AttackReaction();
                    this.CharacterAnimation[this.CounterAnim].time = 5f;
                    this.Yandere.CharacterAnimation["f02_counterA_00"].time = 5f;
                    this.Yandere.ShoulderCamera.DoNotMove = true;
                    this.Yandere.ShoulderCamera.Timer = 5f;
                    this.Yandere.ShoulderCamera.Phase = 3;
                    this.Police.Show = false;
                    this.Yandere.CameraEffects.MurderWitnessed();
                    this.Yandere.Jukebox.GameOver();
                  } else {
                    this.Persona = PersonaType.Heroic;
                  }
                } else {
                  this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
                }
              }
            }
          }
        } else if (this.PinPhase == 0) {
          if (this.DistanceToDestination < 1f) {
            if (this.Pathfinding.canSearch) {
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
            }
            this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
            base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
            this.CharacterAnimation.CrossFade(this.ReadyToFightAnim);
            this.MoveTowardsTarget(this.CurrentDestination.position);
          } else {
            this.CharacterAnimation.CrossFade(this.SprintAnim);
            if (!this.Pathfinding.canSearch) {
              this.Pathfinding.canSearch = true;
              this.Pathfinding.canMove = true;
            }
          }
        } else {
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
          this.MoveTowardsTarget(this.CurrentDestination.position);
        }
      }
      if (this.Following && !this.Waiting) {
        this.DistanceToDestination = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
        if (this.DistanceToDestination > 2f) {
          this.CharacterAnimation.CrossFade(this.RunAnim);
          this.Pathfinding.speed = 4f;
          this.Obstacle.enabled = false;
        } else if (this.DistanceToDestination > 1f) {
          this.CharacterAnimation.CrossFade(this.WalkAnim);
          this.Pathfinding.canMove = true;
          this.Pathfinding.speed = 1f;
          this.Obstacle.enabled = false;
        } else {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.Pathfinding.canMove = false;
          this.Obstacle.enabled = true;
        }
        if (this.Phase < this.ScheduleBlocks.Length - 1 && this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time) {
          this.Phase++;
          this.CurrentDestination = this.Destinations[this.Phase];
          Pathfinding.target = Destinations[Phase];
          var emission = Hearts.emission;
          emission.enabled = false;
          Pathfinding.canSearch = true;
          Pathfinding.canMove = true;
          Pathfinding.speed = 1f;
          Yandere.Followers--;
          Following = false;
          Routine = true;
          Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
          Prompt.Label[0].text = "     Talk";
        }
      }
      if (Wet) {
        if (DistanceToDestination < TargetDistance) {
          if (!Splashed) {
            if (!InDarkness) {
              if (BathePhase == 1) {
                StudentManager.CommunalLocker.Open = true;
                StudentManager.CommunalLocker.Student = this;
                StudentManager.CommunalLocker.SpawnSteam();
                Pathfinding.speed = 1f;
                Schoolwear = 0;
                BathePhase++;
              } else if (BathePhase == 2) {
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
                MoveTowardsTarget(CurrentDestination.position);
              } else if (BathePhase == 3) {
                StudentManager.CommunalLocker.Open = false;
                CharacterAnimation.CrossFade(WalkAnim);
                if (!BatheFast) {
                  CurrentDestination = StudentManager.BatheSpot;
                  Pathfinding.target = StudentManager.BatheSpot;
                } else {
                  CurrentDestination = StudentManager.FastBatheSpot;
                  Pathfinding.target = StudentManager.FastBatheSpot;
                }
                Pathfinding.canSearch = true;
                Pathfinding.canMove = true;
                BathePhase++;
              } else if (BathePhase == 4) {
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, CurrentDestination.rotation, Time.deltaTime * 10f);
                MoveTowardsTarget(CurrentDestination.position);
                if (!BatheFast) {
                  CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
                  CharacterAnimation.CrossFade("f02_bathEnter_00");
                  if (CharacterAnimation["f02_bathEnter_00"].time >= CharacterAnimation["f02_bathEnter_00"].length) {
                    CharacterAnimation.CrossFade("f02_bathIdle_00");
                    BathePhase++;
                  }
                  Pathfinding.canSearch = false;
                  this.Pathfinding.canMove = false;
                  this.MyController.radius = 0f;
                  this.Distracted = true;
                } else {
                  this.CharacterAnimation.CrossFade("f02_stoolBathing_00");
                  if (this.CharacterAnimation["f02_stoolBathing_00"].time >= this.CharacterAnimation["f02_stoolBathing_00"].length) {
                    this.LiquidProjector.enabled = false;
                    this.Bloody = false;
                    this.BathePhase = 7;
                    this.GoChange();
                    this.UnWet();
                  }
                }
              } else if (this.BathePhase == 5) {
                if (this.CharacterAnimation["f02_bathIdle_00"].time >= this.CharacterAnimation["f02_bathIdle_00"].length) {
                  this.CharacterAnimation.CrossFade("f02_bathExit_00");
                  this.LiquidProjector.enabled = false;
                  this.Bloody = false;
                  this.BathePhase++;
                  this.UnWet();
                }
              } else if (this.BathePhase == 6) {
                if (this.CharacterAnimation["f02_bathExit_00"].time >= this.CharacterAnimation["f02_bathExit_00"].length) {
                  this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
                  this.MyController.radius = 0.12f;
                  this.BathePhase++;
                  this.GoChange();
                }
              } else if (this.BathePhase == 7) {
                this.StudentManager.CommunalLocker.Open = true;
                this.StudentManager.CommunalLocker.Student = this;
                this.StudentManager.CommunalLocker.SpawnSteam();
                this.Schoolwear = ((!this.InEvent) ? 3 : 1);
                this.BathePhase++;
              } else if (this.BathePhase == 8) {
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
                this.MoveTowardsTarget(this.CurrentDestination.position);
              } else if (this.BathePhase == 9) {
                if (this.StudentID == this.StudentManager.RivalID) {
                  if (this.StudentManager.CommunalLocker.RivalPhone.Stolen) {
                    this.CharacterAnimation.CrossFade("f02_losingPhone_00");
                    this.Subtitle.UpdateLabel(this.LostPhoneSubtitleType, 1, 5f);
                    this.RealizePhoneIsMissing();
                    this.BatheTimer = 6f;
                    this.BathePhase++;
                  } else {
                    this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
                    this.BathePhase++;
                  }
                } else {
                  this.BathePhase += 2;
                }
              } else if (this.BathePhase == 10) {
                if (this.BatheTimer == 0f) {
                  this.BathePhase++;
                } else {
                  this.BatheTimer = Mathf.MoveTowards(this.BatheTimer, 0f, Time.deltaTime);
                }
              } else if (this.BathePhase == 11) {
                this.StudentManager.CommunalLocker.Open = false;
                if (this.Phase == 1) {
                  this.Phase++;
                }
                this.CurrentDestination = this.Destinations[this.Phase];
                this.Pathfinding.target = this.Destinations[this.Phase];
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.DistanceToDestination = 100f;
                this.Routine = true;
                this.Wet = false;
                if (this.FleeWhenClean) {
                  this.CurrentDestination = this.StudentManager.Exit;
                  this.Pathfinding.target = this.StudentManager.Exit;
                  this.TargetDistance = 0f;
                  this.Routine = false;
                  this.Fleeing = true;
                }
              }
            } else if (this.BathePhase == -1) {
              this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
              this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 2, 5f);
              this.CharacterAnimation.CrossFade("f02_electrocution_00");
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              this.Distracted = true;
              this.BathePhase++;
            } else if (this.BathePhase == 0) {
              base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
              this.MoveTowardsTarget(this.CurrentDestination.position);
              if (this.CharacterAnimation["f02_electrocution_00"].time > 2f && this.CharacterAnimation["f02_electrocution_00"].time < 5.95000029f) {
                if (!this.LightSwitch.Panel.useGravity) {
                  if (!this.Bloody) {
                    this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
                  } else {
                    this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
                  }
                  this.CurrentDestination = this.StudentManager.StripSpot;
                  this.Pathfinding.target = this.StudentManager.StripSpot;
                  this.Pathfinding.canSearch = true;
                  this.Pathfinding.canMove = true;
                  this.Pathfinding.speed = 4f;
                  this.CharacterAnimation.CrossFade(this.WalkAnim);
                  this.BathePhase++;
                  this.LightSwitch.Prompt.Label[0].text = "     Turn Off";
                  this.LightSwitch.BathroomLight.SetActive(true);
                  this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[0];
                  this.LightSwitch.GetComponent<AudioSource>().Play();
                  this.InDarkness = false;
                } else {
                  if (!this.LightSwitch.Flicker) {
                    this.CharacterAnimation["f02_electrocution_00"].speed = 0.85f;
                    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LightSwitch.Electricity, base.transform.position, Quaternion.identity);
                    gameObject.transform.parent = this.Bones[1].transform;
                    gameObject.transform.localPosition = Vector3.zero;
                    this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 3, 0f);
                    this.LightSwitch.GetComponent<AudioSource>().clip = this.LightSwitch.Flick[2];
                    this.LightSwitch.Flicker = true;
                    this.LightSwitch.GetComponent<AudioSource>().Play();
                    this.EyeShrink = 1f;
                    this.ElectroSteam[0].SetActive(true);
                    this.ElectroSteam[1].SetActive(true);
                    this.ElectroSteam[2].SetActive(true);
                    this.ElectroSteam[3].SetActive(true);
                  }
                  this.RightDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
                  this.LeftDrill.eulerAngles = new Vector3(UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f), UnityEngine.Random.Range(-360f, 360f));
                  this.ElectroTimer += Time.deltaTime;
                  if (this.ElectroTimer > 0.1f) {
                    this.ElectroTimer = 0f;
                    if (this.MyRenderer.enabled) {
                      this.Spook();
                    } else {
                      this.Unspook();
                    }
                  }
                }
              } else if (this.CharacterAnimation["f02_electrocution_00"].time > 5.95000029f && this.CharacterAnimation["f02_electrocution_00"].time < this.CharacterAnimation["f02_electrocution_00"].length) {
                if (this.LightSwitch.Flicker) {
                  this.CharacterAnimation["f02_electrocution_00"].speed = 1f;
                  this.Prompt.Label[0].text = "     Turn Off";
                  this.LightSwitch.BathroomLight.SetActive(true);
                  this.RightDrill.localEulerAngles = new Vector3(0f, 0f, 68.30447f);
                  this.LeftDrill.localEulerAngles = new Vector3(0f, -180f, -159.417f);
                  this.LightSwitch.Flicker = false;
                  this.Unspook();
                  this.UnWet();
                }
              } else if (this.CharacterAnimation["f02_electrocution_00"].time >= this.CharacterAnimation["f02_electrocution_00"].length) {
                this.Police.ElectrocutedStudentName = this.Name;
                this.Police.ElectroScene = true;
                this.Electrocuted = true;
                this.BecomeRagdoll();
                this.DeathType = DeathType.Electrocution;
              }
            }
          }
        } else if (this.Pathfinding.canMove) {
          if (this.BathePhase == 1 || this.FleeWhenClean) {
            this.CharacterAnimation.CrossFade(this.SprintAnim);
            this.Pathfinding.speed = 4f;
          } else {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            this.Pathfinding.speed = 1f;
          }
        }
      }
      if (this.Distracting) {
        if (this.DistractionTarget.Dying) {
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.DistractionTarget.TargetedForDistraction = false;
          this.DistractionTarget.Pathfinding.canSearch = true;
          this.DistractionTarget.Pathfinding.canMove = true;
          this.DistractionTarget.Pathfinding.speed = 1f;
          this.DistractionTarget.Distraction = null;
          this.DistractionTarget.Distracted = false;
          this.DistractionTarget.CanTalk = true;
          this.DistractionTarget.Routine = true;
          this.Pathfinding.speed = 1f;
          this.Distracting = false;
          this.Distracted = false;
          this.CanTalk = true;
          this.Routine = true;
        } else if (this.DistractionTarget.InEvent || this.DistractionTarget.Talking || this.DistractionTarget.Following || this.DistractionTarget.TurnOffRadio || this.DistractionTarget.Splashed) {
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.DistractionTarget.TargetedForDistraction = false;
          this.Pathfinding.speed = 1f;
          this.Distracting = false;
          this.Distracted = false;
          this.CanTalk = true;
          this.Routine = true;
        } else if (this.DistanceToDestination < this.TargetDistance) {
          if (!this.DistractionTarget.Distracted) {
            this.DistractionTarget.Prompt.Label[0].text = "     Talk";
            this.DistractionTarget.Pathfinding.canSearch = false;
            this.DistractionTarget.Pathfinding.canMove = false;
            this.DistractionTarget.OccultBook.SetActive(false);
            this.DistractionTarget.Distraction = base.transform;
            this.DistractionTarget.CameraReacting = false;
            this.DistractionTarget.Pathfinding.speed = 0f;
            this.DistractionTarget.Pen.SetActive(false);
            this.DistractionTarget.Drownable = false;
            this.DistractionTarget.Distracted = true;
            this.DistractionTarget.Pushable = false;
            this.DistractionTarget.Routine = false;
            this.DistractionTarget.CanTalk = false;
            this.DistractionTarget.ReadPhase = 0;
            this.DistractionTarget.SpeechLines.Play();
            this.SpeechLines.Play();
            this.Pathfinding.speed = 0f;
            this.Distracted = true;
          }
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.DistractionTarget.transform.position.x, base.transform.position.y, this.DistractionTarget.transform.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.CharacterAnimation.CrossFade(this.RandomAnim);
          if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length) {
            this.PickRandomAnim();
          }
          this.DistractTimer -= Time.deltaTime;
          if (this.DistractTimer <= 0f) {
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
            this.DistractionTarget.TargetedForDistraction = false;
            this.DistractionTarget.Pathfinding.canSearch = true;
            this.DistractionTarget.Pathfinding.canMove = true;
            this.DistractionTarget.Pathfinding.speed = 1f;
            this.DistractionTarget.Distraction = null;
            this.DistractionTarget.Distracted = false;
            this.DistractionTarget.CanTalk = true;
            this.DistractionTarget.Routine = true;
            this.DistractionTarget.SpeechLines.Stop();
            this.SpeechLines.Stop();
            this.Pathfinding.speed = 1f;
            this.Distracting = false;
            this.Distracted = false;
            this.CanTalk = true;
            this.Routine = true;
          }
        } else {
          this.CharacterAnimation.CrossFade(this.RunAnim);
        }
      }
      if (this.Hunting) {
        if (this.HuntTarget != null) {
          if (this.HuntTarget.Prompt.enabled) {
            this.HuntTarget.Prompt.Hide();
            this.HuntTarget.Prompt.enabled = false;
          }
          this.Pathfinding.target = this.HuntTarget.transform;
          this.CurrentDestination = this.HuntTarget.transform;
          if (this.HuntTarget.Alive && !this.HuntTarget.Tranquil) {
            if (this.DistanceToDestination > this.TargetDistance) {
              if (this.MurderSuicidePhase == 0) {
                if (this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length) {
                  this.MurderSuicidePhase++;
                  this.Pathfinding.canSearch = true;
                  this.Pathfinding.canMove = true;
                  this.CharacterAnimation.CrossFade(this.WalkAnim);
                  this.Pathfinding.speed = 1f;
                }
              } else if (this.MurderSuicidePhase > 1) {
                this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
              }
            } else if (!this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position)) {
              if (!this.NEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.NWStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SEStairs.bounds.Contains(this.HuntTarget.transform.position) && !this.SWStairs.bounds.Contains(this.HuntTarget.transform.position)) {
                if (this.Pathfinding.canMove) {
                  this.CharacterAnimation.CrossFade("f02_murderSuicide_00");
                  this.Pathfinding.canSearch = false;
                  this.Pathfinding.canMove = false;
                  this.Broken.Subtitle.text = string.Empty;
                  this.MyController.radius = 0f;
                  this.Broken.Done = true;
                  AudioSource.PlayClipAtPoint(this.MurderSuicideSounds, base.transform.position + new Vector3(0f, 1f, 0f));
                  AudioSource component = base.GetComponent<AudioSource>();
                  component.clip = this.MurderSuicideKiller;
                  component.Play();
                  this.HuntTarget.DetectionMarker.Tex.enabled = false;
                  this.HuntTarget.TargetedForDistraction = false;
                  this.HuntTarget.Pathfinding.canSearch = false;
                  this.HuntTarget.Pathfinding.canMove = false;
                  this.HuntTarget.WitnessCamera.Show = false;
                  this.HuntTarget.CameraReacting = false;
                  this.HuntTarget.Investigating = false;
                  this.HuntTarget.Distracting = false;
                  this.HuntTarget.Splashed = false;
                  this.HuntTarget.Alarmed = false;
                  this.HuntTarget.Burning = false;
                  this.HuntTarget.Fleeing = false;
                  this.HuntTarget.Routine = false;
                  this.HuntTarget.Wet = false;
                  this.HuntTarget.Prompt.Hide();
                  this.HuntTarget.Prompt.enabled = false;
                  if (!this.HuntTarget.Male) {
                    this.HuntTarget.CharacterAnimation.CrossFade("f02_murderSuicide_01");
                  } else {
                    this.HuntTarget.CharacterAnimation.CrossFade("murderSuicide_01");
                  }
                  this.HuntTarget.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
                  this.HuntTarget.MyController.radius = 0f;
                  this.HuntTarget.SpeechLines.Stop();
                  this.HuntTarget.EyeShrink = 1f;
                  this.HuntTarget.GetComponent<AudioSource>().clip = this.MurderSuicideVictim;
                  this.HuntTarget.GetComponent<AudioSource>().Play();
                  this.Police.CorpseList[this.Police.Corpses] = this.HuntTarget.Ragdoll;
                  this.Police.Corpses++;
                  GameObjectUtils.SetLayerRecursively(this.HuntTarget.gameObject, 11);
                  this.HuntTarget.tag = "Blood";
                  this.HuntTarget.Ragdoll.Disturbing = true;
                  this.HuntTarget.Dying = true;
                  this.HuntTarget.SpawnAlarmDisc();
                  if (this.HuntTarget.Following) {
                    this.Yandere.Followers--;
                    var emission = this.Hearts.emission;
                    emission.enabled = false;
                    this.HuntTarget.Following = false;
                  }
                  this.OriginalYPosition = this.HuntTarget.transform.position.y;
                } else {
                  if (this.MurderSuicidePhase > 0) {
                    this.HuntTarget.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - base.transform.position);
                    this.HuntTarget.transform.rotation = Quaternion.Slerp(this.HuntTarget.transform.rotation, this.HuntTarget.targetRotation, Time.deltaTime * 10f);
                    this.HuntTarget.MoveTowardsTarget(base.transform.position + base.transform.forward * 0.01f);
                    this.HuntTarget.transform.position = new Vector3(this.HuntTarget.transform.position.x, this.OriginalYPosition, this.HuntTarget.transform.position.z);
                    this.targetRotation = Quaternion.LookRotation(this.HuntTarget.transform.position - base.transform.position);
                    base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
                  }
                  if (this.MurderSuicidePhase == 1) {
                    if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 2.4f) {
                      this.MyWeapon.transform.parent = this.ItemParent;
                      this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
                      this.MyWeapon.transform.localPosition = Vector3.zero;
                      this.MyWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                      this.MurderSuicidePhase++;
                    }
                  } else if (this.MurderSuicidePhase == 2) {
                    if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 3.3f) {
                      GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Ragdoll.BloodPoolSpawner.BloodPool, base.transform.position + base.transform.up * 0.012f + base.transform.forward, Quaternion.identity);
                      gameObject2.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
                      gameObject2.transform.parent = this.Police.BloodParent;
                      this.MyWeapon.Victims[this.HuntTarget.StudentID] = true;
                      this.MyWeapon.Blood.enabled = true;
                      if (!this.MyWeapon.Evidence) {
                        this.MyWeapon.Evidence = true;
                        this.Police.MurderWeapons++;
                      }
                      UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                      this.KnifeDown = true;
                      this.MurderSuicidePhase++;
                    }
                  } else if (this.MurderSuicidePhase == 3) {
                    if (!this.KnifeDown) {
                      if (this.MyWeapon.transform.position.y < base.transform.position.y + 0.333333343f) {
                        UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                        this.KnifeDown = true;
                        Debug.Log("Stab!");
                      }
                    } else if (this.MyWeapon.transform.position.y > base.transform.position.y + 0.333333343f) {
                      this.KnifeDown = false;
                    }
                    if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 16.666666f) {
                      Debug.Log("Released knife!");
                      this.MyWeapon.transform.parent = null;
                      this.MurderSuicidePhase++;
                    }
                  } else if (this.MurderSuicidePhase == 4) {
                    if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 18.9f) {
                      Debug.Log("Yanked out knife!");
                      UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                      this.MyWeapon.transform.parent = this.ItemParent;
                      this.MyWeapon.transform.localPosition = Vector3.zero;
                      this.MyWeapon.transform.localEulerAngles = Vector3.zero;
                      this.MurderSuicidePhase++;
                    }
                  } else if (this.MurderSuicidePhase == 5) {
                    if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 26.166666f) {
                      Debug.Log("Stabbed neck!");
                      UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
                      this.MyWeapon.Victims[this.StudentID] = true;
                      this.MurderSuicidePhase++;
                    }
                  } else if (this.MurderSuicidePhase == 6) {
                    if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 30.5f) {
                      Debug.Log("BLOOD FOUNTAIN!");
                      this.BloodFountain.Play();
                      this.MurderSuicidePhase++;
                    }
                  } else if (this.MurderSuicidePhase == 7) {
                    if (this.CharacterAnimation["f02_murderSuicide_00"].time >= 31.5f) {
                      this.BloodSprayCollider.SetActive(true);
                      this.MurderSuicidePhase++;
                    }
                  } else if (this.CharacterAnimation["f02_murderSuicide_00"].time >= this.CharacterAnimation["f02_murderSuicide_00"].length) {
                    this.MyWeapon.transform.parent = null;
                    this.MyWeapon.Drop();
                    this.MyWeapon = null;
                    this.StudentManager.StopHesitating();
                    this.HuntTarget.BecomeRagdoll();
                    this.HuntTarget.Ragdoll.MurderSuicide = true;
                    this.HuntTarget.DeathType = DeathType.Weapon;
                    if (this.BloodSprayCollider != null) {
                      this.BloodSprayCollider.SetActive(false);
                    }
                    this.BecomeRagdoll();
                    this.DeathType = DeathType.Weapon;
                    this.StudentManager.MurderTakingPlace = false;
                    this.Police.MurderSuicideScene = true;
                    this.Ragdoll.MurderSuicide = true;
                    this.MurderSuicide = true;
                    this.Broken.HairPhysics[0].enabled = true;
                    this.Broken.HairPhysics[1].enabled = true;
                    this.Broken.enabled = false;
                  }
                }
              }
            }
          } else {
            this.Hunting = false;
            this.Suicide = true;
          }
        } else {
          this.Hunting = false;
          this.Suicide = true;
        }
      }
      if (this.Suicide) {
        if (this.MurderSuicidePhase == 0) {
          if (this.CharacterAnimation["f02_brokenStandUp_00"].time >= this.CharacterAnimation["f02_brokenStandUp_00"].length) {
            this.MurderSuicidePhase++;
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Pathfinding.speed = 0f;
            this.CharacterAnimation.CrossFade("f02_suicide_00");
          }
        } else if (this.MurderSuicidePhase == 1) {
          if (this.Pathfinding.speed > 0f) {
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Pathfinding.speed = 0f;
            this.CharacterAnimation.CrossFade("f02_suicide_00");
          }
          if (this.CharacterAnimation["f02_suicide_00"].time >= 0.733333349f) {
            this.MyWeapon.transform.parent = this.ItemParent;
            this.MyWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
            this.MyWeapon.transform.localPosition = Vector3.zero;
            this.MyWeapon.transform.localEulerAngles = Vector3.zero;
            this.Broken.Subtitle.text = string.Empty;
            this.Broken.Done = true;
            this.MurderSuicidePhase++;
          }
        } else if (this.MurderSuicidePhase == 2) {
          if (this.CharacterAnimation["f02_suicide_00"].time >= 4.16666651f) {
            Debug.Log("Stabbed neck!");
            UnityEngine.Object.Instantiate<GameObject>(this.StabBloodEffect, this.MyWeapon.transform.position, Quaternion.identity);
            this.MyWeapon.Victims[this.StudentID] = true;
            this.MyWeapon.Blood.enabled = true;
            if (!this.MyWeapon.Evidence) {
              this.MyWeapon.Evidence = true;
              this.Police.MurderWeapons++;
            }
            this.MurderSuicidePhase++;
          }
        } else if (this.MurderSuicidePhase == 3) {
          if (this.CharacterAnimation["f02_suicide_00"].time >= 6.16666651f) {
            Debug.Log("BLOOD FOUNTAIN!");
            this.BloodFountain.gameObject.GetComponent<AudioSource>().Play();
            this.BloodFountain.Play();
            this.MurderSuicidePhase++;
          }
        } else if (this.MurderSuicidePhase == 4) {
          if (this.CharacterAnimation["f02_suicide_00"].time >= 7f) {
            this.Ragdoll.BloodPoolSpawner.SpawnPool(base.transform);
            this.BloodSprayCollider.SetActive(true);
            this.MurderSuicidePhase++;
          }
        } else if (this.MurderSuicidePhase == 5 && this.CharacterAnimation["f02_suicide_00"].time >= this.CharacterAnimation["f02_suicide_00"].length) {
          this.MyWeapon.transform.parent = null;
          this.MyWeapon.Drop();
          this.MyWeapon = null;
          this.StudentManager.StopHesitating();
          if (this.BloodSprayCollider != null) {
            this.BloodSprayCollider.SetActive(false);
          }
          this.BecomeRagdoll();
          this.DeathType = DeathType.Weapon;
          this.Broken.HairPhysics[0].enabled = true;
          this.Broken.HairPhysics[1].enabled = true;
          this.Broken.enabled = false;
        }
      }
      if (this.CameraReacting) {
        this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if (!this.Yandere.ClubAccessories[7].activeInHierarchy) {
          if (this.CameraReactPhase == 1) {
            if (this.CharacterAnimation[this.CameraAnims[1]].time >= this.CharacterAnimation[this.CameraAnims[1]].length) {
              this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
              this.CameraReactPhase = 2;
              this.CameraPoseTimer = 1f;
            }
          } else if (this.CameraReactPhase == 2) {
            this.CameraPoseTimer -= Time.deltaTime;
            if (this.CameraPoseTimer <= 0f) {
              this.CharacterAnimation.CrossFade(this.CameraAnims[3]);
              this.CameraReactPhase = 3;
            }
          } else if (this.CameraReactPhase == 3) {
            if (this.CameraPoseTimer == 1f) {
              this.CharacterAnimation.CrossFade(this.CameraAnims[2]);
              this.CameraReactPhase = 2;
            }
            if (this.CharacterAnimation[this.CameraAnims[3]].time >= this.CharacterAnimation[this.CameraAnims[3]].length) {
              this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
              this.Obstacle.enabled = false;
              this.CameraReacting = false;
              this.Routine = true;
              this.ReadPhase = 0;
            }
          }
        } else if (this.Yandere.Shutter.TargetStudent != this.StudentID) {
          this.CameraPoseTimer -= Time.deltaTime;
          if (this.CameraPoseTimer <= 0f) {
            this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
            this.Obstacle.enabled = false;
            this.CameraReacting = false;
            this.Routine = true;
            this.ReadPhase = 0;
          }
        } else {
          this.CameraPoseTimer = 1f;
        }
        if (this.InEvent) {
          this.CameraReacting = false;
          this.ReadPhase = 0;
        }
      }
      if (this.Investigating) {
        if (!this.YandereInnocent && this.InvestigationPhase < 100 && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition)) {
          if (Vector3.Distance(this.Yandere.transform.position, this.Giggle.transform.position) > 2.5f) {
            this.YandereInnocent = true;
          } else {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.InvestigationPhase = 100;
            this.InvestigationTimer = 0f;
          }
        }
        if (this.InvestigationPhase == 0) {
          if (this.InvestigationTimer < 5f) {
            this.InvestigationTimer += Time.deltaTime;
            this.targetRotation = Quaternion.LookRotation(new Vector3(this.Giggle.transform.position.x, base.transform.position.y, this.Giggle.transform.position.z) - base.transform.position);
            base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          } else {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.target = this.Giggle.transform;
            this.CurrentDestination = this.Giggle.transform;
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.Pathfinding.speed = 1f;
            this.InvestigationPhase++;
          }
        } else if (this.InvestigationPhase == 1) {
          if (this.DistanceToDestination > 1f) {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
          } else if (this.InvestigationPhase == 1) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.InvestigationPhase++;
          }
        } else if (this.InvestigationPhase == 2) {
          this.InvestigationTimer += Time.deltaTime;
          if (this.InvestigationTimer > 10f) {
            this.StopInvestigating();
          }
        } else if (this.InvestigationPhase == 100) {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.InvestigationTimer += Time.deltaTime;
          if (this.InvestigationTimer > 2f) {
            this.StopInvestigating();
          }
        }
      }
      if (this.EndSearch) {
        this.MoveTowardsTarget(this.Pathfinding.target.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Pathfinding.target.rotation, 10f * Time.deltaTime);
        this.PatrolTimer += Time.deltaTime;
        if (this.PatrolTimer > 5f) {
          this.StudentManager.CommunalLocker.RivalPhone.gameObject.SetActive(false);
          ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
          scheduleBlock.destination = "Hangout";
          scheduleBlock.action = "Hangout";
          ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
          scheduleBlock2.destination = "LunchSpot";
          scheduleBlock2.action = "Eat";
          ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[7];
          scheduleBlock3.destination = "Hangout";
          scheduleBlock3.action = "Hangout";
          this.GetDestinations();
          Array.Copy(this.OriginalActions, this.Actions, this.OriginalActions.Length);
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.DistanceToDestination = 100f;
          this.LewdPhotos = this.StudentManager.CommunalLocker.RivalPhone.LewdPhotos;
          this.EndSearch = false;
          this.Phoneless = false;
          this.Routine = true;
        }
      }
      if (this.Shoving && this.CharacterAnimation[this.ShoveAnim].time > this.CharacterAnimation[this.ShoveAnim].length) {
        if (this.Patience > 0) {
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Shoving = false;
          this.Routine = true;
        } else {
          this.Shoving = false;
          this.Spray();
        }
      }
      if (this.Spraying && (double)this.CharacterAnimation[this.SprayAnim].time > 0.66666) {
        if (this.Yandere.Armed) {
          this.Yandere.EquippedWeapon.Drop();
        }
        this.Yandere.EmptyHands();
        this.PepperSprayEffect.Play();
        this.Spraying = false;
      }
      if (this.HitReacting && this.CharacterAnimation[this.SithReactAnim].time >= this.CharacterAnimation[this.SithReactAnim].length) {
        this.Persona = PersonaType.SocialButterfly;
        this.PersonaReaction();
        this.HitReacting = false;
      }
      if (this.Eaten) {
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        if (this.CharacterAnimation[this.EatVictimAnim].time >= this.CharacterAnimation[this.EatVictimAnim].length) {
          this.BecomeRagdoll();
        }
      }
      if (this.Electrified && this.CharacterAnimation["f02_electrocution_00"].time >= this.CharacterAnimation["f02_electrocution_00"].length) {
        this.BecomeRagdoll();
        this.DeathType = DeathType.Electrocution;
      }
    }
  }

  // Token: 0x0600081E RID: 2078 RVA: 0x00086D0C File Offset: 0x0008510C
  private void UpdateVisibleCorpses() {
    this.VisibleCorpses.Clear();
    this.ID = 0;
    while (this.ID < this.Police.Corpses) {
      RagdollScript ragdollScript = this.Police.CorpseList[this.ID];
      if (ragdollScript != null && !ragdollScript.Hidden) {
        Collider collider = ragdollScript.AllColliders[0];
        if (this.CanSeeObject(collider.gameObject, collider.transform.position, this.CorpseLayers, this.Mask)) {
          this.VisibleCorpses.Add(ragdollScript.StudentID);
          this.Corpse = ragdollScript;
          if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called) {
            this.StudentManager.CorpseLocation.position = this.Corpse.AllColliders[0].transform.position;
            this.StudentManager.CorpseLocation.LookAt(base.transform.position);
            this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward);
            this.StudentManager.LowerCorpsePosition();
            this.StudentManager.Reporter = this;
            this.Reporting = true;
          }
        }
      }
      this.ID++;
    }
  }

  // Token: 0x0600081F RID: 2079 RVA: 0x00086E80 File Offset: 0x00085280
  private void UpdateVision() {
    if (!this.Dying) {
      if (!this.Distracted) {
        if (!this.WitnessedMurder && !this.CheckingNote) {
          this.UpdateVisibleCorpses();
          if (this.VisibleCorpses.Count > 0) {
            if (!this.WitnessedCorpse) {
              if (!this.Male) {
                this.CharacterAnimation["f02_smile_00"].weight = 0f;
              }
              this.AlarmTimer = 0f;
              this.Alarm = 200f;
              this.LastKnownCorpse = this.Corpse.AllColliders[0].transform.position;
              this.WitnessedCorpse = true;
              this.Investigating = false;
              this.ForgetRadio();
              if (this.Wet) {
                this.Persona = PersonaType.Loner;
              }
              if (this.Corpse.Burning) {
                this.WalkBackTimer = 5f;
                this.WalkBack = true;
                this.Hesitation = 0.5f;
              }
              if (this.Corpse.Disturbing) {
                this.WalkBackTimer = 5f;
                this.WalkBack = true;
                this.Hesitation = 1f;
              }
              this.StudentManager.UpdateMe(this.StudentID);
              if (!this.Teacher) {
                this.SpawnAlarmDisc();
              } else {
                this.AlarmTimer = 3f;
              }
              ParticleSystem.EmissionModule emission = this.Hearts.emission;
              if (this.Talking) {
                this.DialogueWheel.End();
                emission.enabled = false;
                this.Pathfinding.canSearch = true;
                this.Pathfinding.canMove = true;
                this.Obstacle.enabled = false;
                this.Talking = false;
                this.Waiting = false;
                this.StudentManager.EnablePrompts();
              }
              if (this.Following) {
                emission.enabled = false;
                this.Yandere.Followers--;
                this.Following = false;
              }
            }
            if (this.Corpse.Dragged || this.Corpse.Dumped) {
              if (this.Teacher) {
                this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, UnityEngine.Random.Range(1, 3), 3f);
                this.StudentManager.Portal.SetActive(false);
              }
              if (!this.Yandere.Egg) {
                this.WitnessMurder();
              }
            }
          }
          this.PreviousAlarm = this.Alarm;
          if (this.DistanceToPlayer < this.VisionDistance) {
            if (!this.Talking && !this.Spraying) {
              if (!this.Yandere.Noticed) {
                if (!this.Yandere.Chased) {
                  if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || (!this.Teacher && this.StudentID > 1 && this.Yandere.PickUp != null && this.Yandere.PickUp.Suspicious) || (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || this.Yandere.Carrying || this.Yandere.Medusa || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null)) || (this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f) || (this.Private && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Trespassing) || (this.Teacher && this.Yandere.Rummaging) || (this.Teacher && this.Yandere.TheftTimer > 0f) || (this.StudentID == 1 && this.Yandere.NearSenpai && !this.Yandere.Talking) || (this.StudentID == 1 && this.Yandere.Eavesdropping) || (this.StudentID == 33 && this.Yandere.Eavesdropping)) {
                    if (this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition)) {
                      this.YandereVisible = true;
                      if (this.Yandere.Attacking || this.Yandere.Struggling || (this.Yandere.NearBodies > 0 && this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) || (this.Yandere.NearBodies > 0 && this.Yandere.Armed) || (this.Yandere.NearBodies > 0 && this.Yandere.Sanity < 66.66666f) || (this.Yandere.Carrying || this.Yandere.Dragging || (this.Guarding && this.Yandere.Bloodiness > 0f && !this.Yandere.Paint)) || (this.Guarding && this.Yandere.Armed) || (this.Guarding && this.Yandere.Sanity < 66.66666f)) {
                        if (this.Yandere.Hungry || !this.Yandere.Egg) {
                          Debug.Log(base.name + " has just witnessed a murder!");
                          this.WitnessMurder();
                        }
                      } else if (!this.Fleeing && !this.Alarmed) {
                        if (this.Teacher && (this.Yandere.Rummaging || this.Yandere.TheftTimer > 0f)) {
                          this.Alarm = 200f;
                        }
                        if (this.IgnoreTimer <= 0f) {
                          this.Alarm += Time.deltaTime * (100f / this.DistanceToPlayer) * this.Paranoia * this.Perception;
                          if (this.StudentID == 1 && this.Yandere.TimeSkipping) {
                            this.Clock.EndTimeSkip();
                          }
                        }
                      }
                    } else {
                      this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
                    }
                  } else {
                    this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
                  }
                } else {
                  this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
                }
              } else {
                this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
              }
            } else {
              this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
            }
          } else {
            this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
          }
          if (this.PreviousAlarm > this.Alarm && this.Alarm < 100f) {
            this.YandereVisible = false;
          }
          if (this.Teacher && !this.Yandere.Medusa && this.Yandere.Egg) {
            this.Alarm = 0f;
          }
          if (this.Alarm > 100f) {
            if (this.Yandere.Medusa && this.YandereVisible) {
              this.TurnToStone();
              return;
            }
            if (!this.Alarmed || this.DiscCheck) {
              this.Yandere.Alerts++;
              if (this.StudentID > 1) {
                this.ID = 0;
                while (this.ID < this.Outlines.Length) {
                  this.Outlines[this.ID].color = new Color(1f, 1f, 0f, 1f);
                  this.ID++;
                }
              }
              if (this.DistractionTarget != null) {
                this.DistractionTarget.TargetedForDistraction = false;
              }
              this.CharacterAnimation.CrossFade(this.IdleAnim);
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              this.CameraReacting = false;
              this.Distracting = false;
              this.Distracted = false;
              this.DiscCheck = false;
              this.Routine = false;
              this.Alarmed = true;
              this.Witness = true;
              this.ReadPhase = 0;
              if (this.Witnessed != StudentWitnessType.None) {
                this.PreviouslyWitnessed = this.Witnessed;
              }
              bool flag = this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious;
              bool flag2 = this.Yandere.PickUp != null && this.Yandere.PickUp.Suspicious;
              if (this.WitnessedCorpse && !this.WitnessedMurder) {
                this.Witnessed = StudentWitnessType.Corpse;
                this.EyeShrink = 0.9f;
              }
              if (this.YandereVisible) {
                Debug.Log(this.Name + " saw Yandere-chan doing something bad.");
                if (this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Carrying || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart)) {
                  if (!this.Yandere.Egg) {
                    this.WitnessMurder();
                  }
                } else {
                  this.WitnessedBlood = false;
                  if (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) {
                    this.WitnessedBlood = true;
                  }
                  if (this.Yandere.Rummaging || this.Yandere.TheftTimer > 0f) {
                    this.Witnessed = StudentWitnessType.Theft;
                    this.Concern = 5;
                  } else if (this.Yandere.Pickpocketing || this.Yandere.Caught) {
                    Debug.Log("Saw Yandere-chan pickpocketing.");
                    this.Yandere.Pickpocketing = false;
                    this.Witnessed = StudentWitnessType.Pickpocketing;
                    this.Concern = 5;
                  } else if (flag && this.WitnessedBlood && this.Yandere.Sanity < 33.333f) {
                    this.Witnessed = StudentWitnessType.WeaponAndBloodAndInsanity;
                    this.RepLoss = 30f;
                    this.Concern = 5;
                  } else if (flag && this.Yandere.Sanity < 33.333f) {
                    this.Witnessed = StudentWitnessType.WeaponAndInsanity;
                    this.RepLoss = 20f;
                    this.Concern = 5;
                  } else if (this.WitnessedBlood && this.Yandere.Sanity < 33.333f) {
                    this.Witnessed = StudentWitnessType.BloodAndInsanity;
                    this.RepLoss = 20f;
                    this.Concern = 5;
                  } else if (flag && this.WitnessedBlood) {
                    this.Witnessed = StudentWitnessType.WeaponAndBlood;
                    this.RepLoss = 20f;
                    this.Concern = 5;
                  } else if (flag) {
                    this.WeaponWitnessed = this.Yandere.EquippedWeapon.WeaponID;
                    this.Witnessed = StudentWitnessType.Weapon;
                    this.RepLoss = 10f;
                    this.Concern = 5;
                  } else if (flag2) {
                    this.Witnessed = StudentWitnessType.Suspicious;
                    this.RepLoss = 10f;
                    this.Concern = 5;
                  } else if (this.WitnessedBlood) {
                    this.Witnessed = StudentWitnessType.Blood;
                    if (!this.Bloody) {
                      this.RepLoss = 10f;
                      this.Concern = 5;
                    } else {
                      this.RepLoss = 0f;
                      this.Concern = 0;
                    }
                  } else if (this.Yandere.Sanity < 33.333f) {
                    this.Witnessed = StudentWitnessType.Insanity;
                    this.RepLoss = 10f;
                    this.Concern = 5;
                  } else if (this.Yandere.Laughing && this.Yandere.LaughIntensity == 20f) {
                    this.Witnessed = StudentWitnessType.Insanity;
                    this.RepLoss = 10f;
                    this.Concern = 5;
                  } else if (this.Yandere.Lewd) {
                    this.Witnessed = StudentWitnessType.Lewd;
                    this.RepLoss = 10f;
                    this.Concern = 5;
                  } else if (this.Yandere.Trespassing && this.StudentID > 1) {
                    this.Witnessed = ((!this.Private) ? StudentWitnessType.Trespassing : StudentWitnessType.Interruption);
                    this.Witness = false;
                    this.Concern++;
                  } else if (this.Yandere.NearSenpai) {
                    this.Witnessed = StudentWitnessType.Stalking;
                    this.Concern++;
                  } else if (this.Yandere.Eavesdropping) {
                    if (this.StudentID == 1) {
                      this.Witnessed = StudentWitnessType.Stalking;
                      this.Concern++;
                    } else if (this.StudentID == 33) {
                      this.Witnessed = StudentWitnessType.Eavesdropping;
                      this.RepLoss = 10f;
                      this.Concern = 5;
                    }
                  } else if (this.Yandere.Aiming) {
                    this.Witnessed = StudentWitnessType.Stalking;
                    this.Concern++;
                  } else {
                    Debug.Log("Apparently, we didn't even see anything! 1");
                    this.Witnessed = StudentWitnessType.None;
                    this.DiscCheck = true;
                    this.Witness = false;
                  }
                }
                if (this.Teacher && this.WitnessedCorpse) {
                  this.Concern = 1;
                }
                if (this.StudentID == 1 && this.Yandere.Mask == null && !this.Yandere.Egg) {
                  if (this.Concern == 5) {
                    Debug.Log("Senpai noticed stalking or lewdness.");
                    this.SenpaiNoticed();
                    if (this.Witnessed == StudentWitnessType.Stalking || this.Witnessed == StudentWitnessType.Lewd) {
                      this.CharacterAnimation.CrossFade(this.IdleAnim);
                      this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
                    } else {
                      if (this.StudentID == 1) {
                        Debug.Log("Senpai entered his scared animation.");
                      }
                      this.CharacterAnimation.CrossFade(this.ScaredAnim);
                      this.CharacterAnimation["scaredFace_00"].weight = 1f;
                    }
                    this.CameraEffects.MurderWitnessed();
                  } else {
                    this.CharacterAnimation.CrossFade("suspicious_00");
                    this.CameraEffects.Alarm();
                  }
                } else if (!this.Teacher) {
                  this.CameraEffects.Alarm();
                } else {
                  Debug.Log("A teacher has just witnessed Yandere-chan doing something bad.");
                  if (!this.Fleeing) {
                    if (this.Concern < 5) {
                      this.CameraEffects.Alarm();
                    } else {
                      if (!this.Yandere.Struggling) {
                        this.SenpaiNoticed();
                      }
                      this.CameraEffects.MurderWitnessed();
                    }
                  } else {
                    this.PersonaReaction();
                    this.AlarmTimer = 0f;
                    if (this.Concern < 5) {
                      this.CameraEffects.Alarm();
                    } else {
                      this.CameraEffects.MurderWitnessed();
                    }
                  }
                }
                if (!this.Teacher && this.Witnessed == this.PreviouslyWitnessed) {
                  this.RepeatReaction = true;
                }
                if (this.Yandere.Mask == null) {
                  this.RepDeduction = 0f;
                  this.CalculateReputationPenalty();
                  if (this.RepDeduction >= 0f) {
                    this.RepLoss -= this.RepDeduction;
                  }
                  this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
                  this.PendingRep -= this.RepLoss * this.Paranoia;
                }
                if (this.ToiletEvent != null && this.ToiletEvent.EventDay == DayOfWeek.Monday) {
                  this.ToiletEvent.EndEvent();
                }
              } else if (!this.WitnessedCorpse) {
                if (this.Yandere.Caught) {
                  this.Witnessed = StudentWitnessType.Theft;
                } else {
                  Debug.Log("Someone was alarmed by something, but didn't see what it was.");
                  this.Witnessed = StudentWitnessType.None;
                }
                this.DiscCheck = true;
                this.Witness = false;
              } else {
                Debug.Log(this.Name + " discovered a corpse.");
              }
            }
          }
        } else {
          this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
        }
      } else {
        if (this.Distraction != null) {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Distraction.position.x, base.transform.position.y, this.Distraction.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.CharacterAnimation.CrossFade(this.RandomAnim);
          if (this.CharacterAnimation[this.RandomAnim].time >= this.CharacterAnimation[this.RandomAnim].length) {
            this.PickRandomAnim();
          }
        }
        if (this.OnPhone) {
          this.CharacterAnimation.CrossFade(this.PhoneAnim);
          this.CharacterAnimation[this.WalkAnim].time = this.CharacterAnimation[this.PhoneAnim].time;
          if (base.transform.position.z > -49.3351f) {
            if (!this.Slave) {
              this.CharacterAnimation.CrossFade(this.WalkAnim);
              this.Distracted = false;
            }
            this.Phone.SetActive(false);
            this.OnPhone = false;
            this.Safe = false;
            this.StudentManager.UpdateStudents();
          }
        }
      }
    }
  }

  // Token: 0x06000820 RID: 2080 RVA: 0x00088248 File Offset: 0x00086648
  private void UpdateDetectionMarker() {
    if (this.Alarm < 0f) {
      this.Alarm = 0f;
    }
    if (this.DetectionMarker != null) {
      this.DetectionMarker.Tex.transform.localScale = new Vector3(this.DetectionMarker.Tex.transform.localScale.x, (this.Alarm > 100f) ? 1f : (this.Alarm / 100f), this.DetectionMarker.Tex.transform.localScale.z);
      if (this.Alarm > 0f) {
        if (!this.DetectionMarker.Tex.enabled) {
          this.DetectionMarker.Tex.enabled = true;
        }
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, this.Alarm / 100f);
      } else if (this.DetectionMarker.Tex.color.a != 0f) {
        this.DetectionMarker.Tex.enabled = false;
        this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
      }
    }
  }

  // Token: 0x06000821 RID: 2081 RVA: 0x0008843C File Offset: 0x0008683C
  private void UpdateTalkInput() {
    if (this.StudentID > 1) {
      if (!this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy) {
        this.Warned = false;
      }
      if ((this.Alarm > 0f || this.AlarmTimer > 0f || this.Yandere.Armed) && !this.Slave && !this.BadTime && !this.Yandere.Gazing) {
        this.Prompt.Circle[0].fillAmount = 1f;
      }
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.OccultBook.SetActive(false);
        this.SpeechLines.Stop();
        this.Pen.SetActive(false);
        if (this.StudentManager.Pose) {
          this.MyController.enabled = false;
          this.Pathfinding.enabled = false;
          this.Stop = true;
          this.Pose();
        } else if (this.BadTime) {
          this.Yandere.EmptyHands();
          this.BecomeRagdoll();
          this.Yandere.RagdollPK.connectedBody = this.Ragdoll.AllRigidbodies[5];
          this.Yandere.RagdollPK.connectedAnchor = this.Ragdoll.LimbAnchor[4];
          this.DialogueWheel.PromptBar.ClearButtons();
          this.DialogueWheel.PromptBar.Label[1].text = "Back";
          this.DialogueWheel.PromptBar.UpdateButtons();
          this.DialogueWheel.PromptBar.Show = true;
          this.Yandere.Ragdoll = this.Ragdoll.gameObject;
          this.Yandere.SansEyes[0].SetActive(true);
          this.Yandere.SansEyes[1].SetActive(true);
          this.Yandere.GlowEffect.Play();
          this.Yandere.CanMove = false;
          this.Yandere.PK = true;
          this.DeathType = DeathType.EasterEgg;
        } else if (this.Slave) {
          this.Yandere.TargetStudent = this;
          this.Yandere.PauseScreen.StudentInfoMenu.Targeting = true;
          this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
          this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
          this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
          this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
          base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
          this.Yandere.PauseScreen.MainMenu.SetActive(false);
          this.Yandere.PauseScreen.Panel.enabled = true;
          this.Yandere.PauseScreen.Sideways = true;
          this.Yandere.PauseScreen.Show = true;
          Time.timeScale = 0f;
          this.Yandere.PromptBar.ClearButtons();
          this.Yandere.PromptBar.Label[1].text = "Cancel";
          this.Yandere.PromptBar.UpdateButtons();
          this.Yandere.PromptBar.Show = true;
        } else if (this.Following) {
          this.Subtitle.UpdateLabel(SubtitleType.StudentFarewell, 0, 3f);
          this.Prompt.Label[0].text = "     Talk";
          this.Prompt.Circle[0].fillAmount = 1f;
          var emission = Hearts.emission;
          emission.enabled = false;
          this.Yandere.Followers--;
          this.Following = false;
          this.Routine = true;
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Pathfinding.speed = 1f;
        } else if (this.Pushable) {
          this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.Subtitle.UpdateLabel(SubtitleType.NoteReaction, 5, 3f);
          this.Prompt.Label[0].text = "     Talk";
          this.Prompt.Circle[0].fillAmount = 1f;
          this.Yandere.TargetStudent = this;
          this.Yandere.Attacking = true;
          this.Yandere.RoofPush = true;
          this.Yandere.CanMove = false;
          this.Distracted = true;
          this.Routine = false;
          this.Pushed = true;
          this.CharacterAnimation.CrossFade(this.PushedAnim);
        } else if (this.Drownable) {
          Debug.Log("Just began to drown someone.");
          if (!this.Male) {
            this.StudentManager.FemaleVomitDoor.Prompt.enabled = true;
          }
          this.Yandere.EmptyHands();
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.Prompt.Circle[0].fillAmount = 1f;
          this.StudentManager.Fountain.Drowning = true;
          this.Police.DrownedStudentName = this.Name;
          this.MyController.enabled = false;
          this.Police.DrownScene = true;
          this.VomitEmitter.Stop();
          this.Distracted = true;
          this.Drownable = false;
          this.Routine = false;
          this.Drowned = true;
          this.Subtitle.UpdateLabel(SubtitleType.DrownReaction, 0, 3f);
          this.Yandere.TargetStudent = this;
          this.Yandere.Attacking = true;
          this.Yandere.CanMove = false;
          this.Yandere.Drown = true;
          this.Yandere.DrownAnim = "f02_fountainDrownA_00";
          this.DrownAnim = "f02_fountainDrownB_00";
          this.CharacterAnimation.CrossFade(this.DrownAnim);
        } else if (this.Clock.Period == 2 || this.Clock.Period == 4) {
          this.Subtitle.UpdateLabel(SubtitleType.ClassApology, 0, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
        } else if (this.InEvent || !this.CanTalk || this.GoAway || (this.Meeting && !this.Drownable) || this.Wet || this.TurnOffRadio) {
          this.Subtitle.UpdateLabel(SubtitleType.EventApology, 1, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
        } else if (this.Warned) {
          this.Subtitle.UpdateLabel(SubtitleType.GrudgeRefusal, 0, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
        } else if (this.Ignoring) {
          this.Subtitle.UpdateLabel(SubtitleType.PhotoAnnoyance, 0, 3f);
          this.Prompt.Circle[0].fillAmount = 1f;
        } else if (this.StudentManager.Six) {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
          gameObject.GetComponent<AlarmDiscScript>().Originator = this;
          AudioSource.PlayClipAtPoint(this.Yandere.SixTakedown, base.transform.position);
          this.Yandere.CharacterAnimation.CrossFade("f02_sixEat_00");
          this.Yandere.TargetStudent = this;
          this.Yandere.FollowHips = true;
          this.Yandere.Attacking = true;
          this.Yandere.CanMove = false;
          this.Yandere.Eating = true;
          this.CharacterAnimation.CrossFade(this.EatVictimAnim);
          this.Pathfinding.enabled = false;
          this.Routine = false;
          this.Dying = true;
          this.Eaten = true;
          GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
          this.Yandere.SixTarget = gameObject2.transform;
          this.Yandere.SixTarget.LookAt(this.Yandere.transform.position);
          this.Yandere.SixTarget.Translate(this.Yandere.SixTarget.forward);
        } else if (this.StudentManager.Gaze) {
          this.Yandere.CharacterAnimation.CrossFade("f02_gazerPoint_00");
          this.Yandere.GazerEyes.Attacking = true;
          this.Yandere.TargetStudent = this;
          this.Yandere.GazeAttacking = true;
          this.Yandere.CanMove = false;
          this.Routine = false;
        } else {
          this.WitnessedBlood = false;
          if (this.Yandere.Bloodiness > 0f && !this.Yandere.Paint) {
            this.WitnessedBlood = true;
          }
          if (!this.Witness && this.WitnessedBlood) {
            this.Prompt.Circle[0].fillAmount = 1f;
            this.YandereVisible = true;
            this.Alarm = 200f;
          } else {
            this.Yandere.TargetStudent = this;
            if (!this.Grudge) {
              this.ClubManager.CheckGrudge(this.Club);
              if (ClubGlobals.GetClubKicked(this.Club) && !this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy) {
                this.Interaction = StudentInteractionType.ClubUnwelcome;
                this.TalkTimer = 5f;
                this.Warned = true;
              } else if (ClubGlobals.Club == this.Club && !this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy && this.ClubManager.ClubGrudge) {
                this.Interaction = StudentInteractionType.ClubKick;
                this.TalkTimer = 5f;
                this.Warned = true;
              } else if (this.Prompt.Label[0].text == "     Feed") {
                this.Interaction = StudentInteractionType.Feeding;
                this.TalkTimer = 3f;
              } else {
                if (!this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy) {
                  this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)this.Club, 4f);
                  this.DialogueWheel.ClubLeader = true;
                } else {
                  this.Subtitle.UpdateLabel(SubtitleType.Greeting, 0, 3f);
                }
                if (this.Yandere.TargetStudent.Club != ClubType.Council && ((this.Male && PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 0) || PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 4)) {
                  ParticleSystem.EmissionModule emission = this.Hearts.emission;
                  emission.rateOverTime = (float)PlayerGlobals.Seduction;
                  emission.enabled = true;
                  this.Hearts.Play();
                }
                this.StudentManager.DisablePrompts();
                this.DialogueWheel.HideShadows();
                this.DialogueWheel.Show = true;
                this.DialogueWheel.Panel.enabled = true;
                this.TalkTimer = 0f;
              }
            } else if (!this.Pathfinding.canMove && this.Actions[this.Phase] == StudentActionType.ClubAction && this.Armband.activeInHierarchy) {
              this.Interaction = StudentInteractionType.ClubUnwelcome;
              this.TalkTimer = 5f;
              this.Warned = true;
            } else {
              this.Interaction = StudentInteractionType.PersonalGrudge;
              this.TalkTimer = 5f;
              this.Warned = true;
            }
            this.ShoulderCamera.OverShoulder = true;
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Obstacle.enabled = true;
            this.Giggle = null;
            this.Yandere.WeaponMenu.KeyboardShow = false;
            this.Yandere.Obscurance.enabled = false;
            this.Yandere.WeaponMenu.Show = false;
            this.Yandere.YandereVision = false;
            this.Yandere.CanMove = false;
            this.Yandere.Talking = true;
            this.Investigating = false;
            this.Reacted = false;
            this.Routine = false;
            this.Talking = true;
            this.ReadPhase = 0;
            if (!this.Male) {
              this.SmartPhone.SetActive(false);
            }
          }
        }
      }
      if (this.Prompt.Circle[2].fillAmount == 0f && !this.Yandere.NearSenpai && !this.Yandere.Attacking && this.Yandere.Stance.Current != StanceType.Crouching) {
        if (this.Yandere.EquippedWeapon.Flaming || this.Yandere.CyborgParts[1].activeInHierarchy) {
          this.Yandere.SanityBased = false;
        }
        this.AttackReaction();
      }
    }
  }

  // Token: 0x06000822 RID: 2082 RVA: 0x00089250 File Offset: 0x00087650
  private void UpdateDying() {
    this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
    if (this.Attacked) {
      if (!this.Teacher) {
        this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
        if (this.Alive && !this.Tranquil) {
          if (!this.Yandere.SanityBased) {
            this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
            base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
            if (this.Yandere.EquippedWeapon.WeaponID == 11) {
              this.CharacterAnimation.CrossFade(this.CyborgDeathAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
              if (this.CharacterAnimation[this.CyborgDeathAnim].time >= this.CharacterAnimation[this.CyborgDeathAnim].length - 0.25f && this.Yandere.EquippedWeapon.WeaponID == 11) {
                UnityEngine.Object.Instantiate<GameObject>(this.BloodyScream, base.transform.position + Vector3.up, Quaternion.identity);
                this.DeathType = DeathType.EasterEgg;
                this.BecomeRagdoll();
                this.Ragdoll.Dismember();
              }
            } else if (this.Yandere.EquippedWeapon.WeaponID == 7) {
              this.CharacterAnimation.CrossFade(this.BuzzSawDeathAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
            } else if (!this.Yandere.EquippedWeapon.Concealable) {
              this.CharacterAnimation.CrossFade(this.SwingDeathAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
            } else {
              this.CharacterAnimation.CrossFade(this.DefendAnim);
              this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * 0.1f);
            }
          } else {
            this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward * this.Yandere.AttackManager.Distance);
            if (!this.Yandere.AttackManager.Stealth) {
              this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
            } else {
              this.targetRotation = Quaternion.LookRotation(base.transform.position - new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z));
            }
            base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
          }
        } else {
          this.CharacterAnimation.CrossFade(this.DeathAnim);
          if (this.CharacterAnimation[this.DeathAnim].time < 1f) {
            base.transform.Translate(Vector3.back * Time.deltaTime);
          } else {
            this.BecomeRagdoll();
          }
        }
      } else {
        if (!this.StudentManager.Stop) {
          this.StudentManager.StopMoving();
          this.Yandere.Laughing = false;
          this.Yandere.Dipping = false;
          this.Yandere.RPGCamera.enabled = false;
          this.Phone.SetActive(false);
          this.Police.Show = false;
        }
        this.CharacterAnimation.CrossFade(this.CounterAnim);
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.Yandere.transform.position + this.Yandere.transform.forward);
        base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
    }
  }

  // Token: 0x06000823 RID: 2083 RVA: 0x00089860 File Offset: 0x00087C60
  private void UpdatePushed() {
    this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
    this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
    if (this.CharacterAnimation[this.PushedAnim].time >= this.CharacterAnimation[this.PushedAnim].length) {
      this.BecomeRagdoll();
    }
  }

  // Token: 0x06000824 RID: 2084 RVA: 0x000898EC File Offset: 0x00087CEC
  private void UpdateDrowned() {
    this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
    this.EyeShrink = Mathf.Lerp(this.EyeShrink, 1f, Time.deltaTime * 10f);
    if (this.CharacterAnimation[this.DrownAnim].time >= this.CharacterAnimation[this.DrownAnim].length) {
      this.BecomeRagdoll();
    }
  }

  // Token: 0x06000825 RID: 2085 RVA: 0x00089978 File Offset: 0x00087D78
  private void UpdateWitnessedMurder() {
    if (!this.Fleeing) {
      if (this.StudentID > 1 && this.Persona != PersonaType.Evil) {
        this.EyeShrink += Time.deltaTime * 0.2f;
      }
      if (this.Yandere.TargetStudent != null && this.LovedOneIsTargeted(this.Yandere.TargetStudent.StudentID)) {
        this.Strength = 5;
        this.Persona = PersonaType.Heroic;
      }
      if (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart != null && this.Yandere.PickUp.BodyPart.Type == 1 && this.LovedOneIsTargeted(this.Yandere.PickUp.BodyPart.StudentID)) {
        this.Strength = 5;
        this.Persona = PersonaType.Heroic;
      }
      if (this.StudentID == 1) {
        Debug.Log("Senpai entered his scared animation.");
      }
      this.CharacterAnimation.CrossFade(this.ScaredAnim);
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.position.x, base.transform.position.y, this.Yandere.Hips.position.z) - base.transform.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      if (!this.Yandere.Struggling) {
        if (this.Persona != PersonaType.Heroic && this.Persona != PersonaType.Dangerous) {
          this.AlarmTimer += Time.deltaTime * (float)this.MurdersWitnessed;
        } else {
          this.AlarmTimer += Time.deltaTime * ((float)this.MurdersWitnessed * 5f);
        }
      }
      if (this.AlarmTimer > 5f) {
        this.PersonaReaction();
        this.AlarmTimer = 0f;
      } else if (this.AlarmTimer > 1f && !this.Reacted) {
        if (this.StudentID > 1 || this.Yandere.Mask != null) {
          if (!this.Teacher) {
            this.Subtitle.UpdateLabel(SubtitleType.MurderReaction, 1, 3f);
          } else {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, UnityEngine.Random.Range(1, 3), 3f);
            this.StudentManager.Portal.SetActive(false);
          }
        } else {
          Debug.Log("Senpai witnessed murder, and entered a specific murder reaction animation.");
          this.MurderReaction = UnityEngine.Random.Range(1, 6);
          this.CharacterAnimation.CrossFade("senpaiMurderReaction_0" + this.MurderReaction);
          this.GameOverCause = GameOverType.Murder;
          this.SenpaiNoticed();
          this.CharacterAnimation["scaredFace_00"].weight = 0f;
          this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
          this.Yandere.ShoulderCamera.enabled = true;
          this.Yandere.ShoulderCamera.Noticed = true;
          this.Yandere.RPGCamera.enabled = false;
          this.Stop = true;
        }
        this.Reacted = true;
      }
    }
  }

  // Token: 0x06000826 RID: 2086 RVA: 0x00089D08 File Offset: 0x00088108
  private void UpdateAlarmed() {
    if (Yandere.Medusa && YandereVisible) {
      TurnToStone();
      return;
    }
    if (!Male) {
      SpeechLines.Stop();
    }
    SmartPhone.SetActive(false);
    this.OccultBook.SetActive(false);
    this.SpeechLines.Stop();
    this.Pen.SetActive(false);
    this.ReadPhase = 0;
    if (this.WitnessedCorpse) {
      if (!this.WalkBack) {
        if (this.StudentID == 1) {
          Debug.Log("Senpai entered his scared animation.");
        }
        this.CharacterAnimation.CrossFade(this.ScaredAnim);
      } else {
        this.MyController.Move(base.transform.forward * (-0.5f * Time.deltaTime));
        this.CharacterAnimation.CrossFade(this.WalkBackAnim);
        this.WalkBackTimer -= Time.deltaTime;
        if (this.WalkBackTimer <= 0f) {
          this.WalkBack = false;
        }
      }
    } else if (this.StudentID > 1) {
      if (this.Witness) {
        this.CharacterAnimation.CrossFade(this.LeanAnim);
      } else {
        this.CharacterAnimation.CrossFade(this.IdleAnim);
        if (this.FocusOnYandere) {
          if (this.DistanceToPlayer < 1f) {
            this.AlarmTimer = 0f;
            this.ThreatTimer += Time.deltaTime;
            if (this.ThreatTimer > 5f) {
              this.ThreatTimer = 0f;
              this.Shove();
            }
          }
          this.DistractionSpot = new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z);
        }
      }
    }
    if (this.WitnessedMurder) {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
    } else if (this.WitnessedCorpse) {
      if (this.Corpse != null && this.Corpse.AllColliders[0] != null) {
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z) - base.transform.position);
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
      }
    } else if (!this.DiscCheck) {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
    } else {
      this.targetRotation = Quaternion.LookRotation(this.DistractionSpot - base.transform.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
    }
    if (!this.Fleeing) {
      this.AlarmTimer += Time.deltaTime * (1f - this.Hesitation);
    }
    this.Alarm -= Time.deltaTime * 100f * (1f / this.Paranoia);
    if (this.AlarmTimer > 5f) {
      this.Pathfinding.canSearch = true;
      this.Pathfinding.canMove = true;
      if (this.StudentID == 1 || this.Teacher) {
        this.IgnoreTimer = 0.0001f;
      } else {
        this.IgnoreTimer = 5f;
      }
      this.FocusOnYandere = false;
      this.DiscCheck = false;
      this.Alarmed = false;
      this.Reacted = false;
      this.Hesitation = 0f;
      this.AlarmTimer = 0f;
      if (this.WitnessedCorpse) {
        this.PersonaReaction();
      } else if (!this.Following && !this.Wet && !this.Investigating) {
        this.Routine = true;
      }
    } else if (this.AlarmTimer > 1f && !this.Reacted) {
      if (this.Teacher) {
        if (!this.WitnessedCorpse) {
          Debug.Log("A teacher's reaction is now being determined.");
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
          } else if (this.Witnessed == StudentWitnessType.WeaponAndBlood) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponReaction, 1, 6f);
            this.GameOverCause = GameOverType.Weapon;
          } else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
          } else if (this.Witnessed == StudentWitnessType.BloodAndInsanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
          } else if (this.Witnessed == StudentWitnessType.Weapon) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponReaction, 1, 6f);
            this.GameOverCause = GameOverType.Weapon;
          } else if (this.Witnessed == StudentWitnessType.Blood) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodReaction, 1, 6f);
            this.GameOverCause = GameOverType.Blood;
          } else if (this.Witnessed == StudentWitnessType.Insanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityReaction, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
          } else if (this.Witnessed == StudentWitnessType.Lewd) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
            this.GameOverCause = GameOverType.Lewd;
          } else if (this.Witnessed == StudentWitnessType.Trespassing) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
          } else if (this.Witnessed == StudentWitnessType.Theft) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherTheftReaction, 1, 6f);
          } else if (this.Witnessed == StudentWitnessType.Pickpocketing) {
            this.Subtitle.UpdateLabel(this.PickpocketSubtitleType, 1, 5f);
          }
        } else {
          this.Concern = 1;
          if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
            this.WitnessedMurder = true;
          } else if (this.Witnessed == StudentWitnessType.WeaponAndBlood) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
            this.GameOverCause = GameOverType.Weapon;
            this.WitnessedMurder = true;
          } else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
            this.WitnessedMurder = true;
          } else if (this.Witnessed == StudentWitnessType.BloodAndInsanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
            this.WitnessedMurder = true;
          } else if (this.Witnessed == StudentWitnessType.Weapon) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherWeaponHostile, 1, 6f);
            this.GameOverCause = GameOverType.Weapon;
            this.WitnessedMurder = true;
          } else if (this.Witnessed == StudentWitnessType.Blood) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherBloodHostile, 1, 6f);
            this.GameOverCause = GameOverType.Blood;
            this.WitnessedMurder = true;
          } else if (this.Witnessed == StudentWitnessType.Insanity) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherInsanityHostile, 1, 6f);
            this.GameOverCause = GameOverType.Insanity;
            this.WitnessedMurder = true;
          } else if (this.Witnessed == StudentWitnessType.Lewd) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherLewdReaction, 1, 6f);
            this.GameOverCause = GameOverType.Lewd;
          } else if (this.Witnessed == StudentWitnessType.Trespassing) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherTrespassingReaction, this.Concern, 5f);
          } else if (this.Witnessed == StudentWitnessType.Corpse) {
            this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
            this.Police.Called = true;
          }
          if (this.WitnessedMurder) {
            this.MurdersWitnessed++;
            if (!this.Yandere.Chased) {
              Debug.Log("A teacher has reached ChaseYandere() through Alarm.");
              this.ChaseYandere();
            }
          }
        }
        if (this.Concern == 5) {
          Debug.Log("A Game Over will now occur.");
          this.CharacterAnimation[this.AngryFaceAnim].weight = 1f;
          this.Yandere.ShoulderCamera.enabled = true;
          this.Yandere.ShoulderCamera.Noticed = true;
          this.Yandere.RPGCamera.enabled = false;
          this.Stop = true;
        }
      } else if (this.StudentID > 1 || this.Yandere.Mask != null) {
        if (this.RepeatReaction) {
          this.Subtitle.UpdateLabel(SubtitleType.RepeatReaction, 1, 3f);
          this.RepeatReaction = false;
        } else if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity) {
          this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodAndInsanityReaction, 1, 3f);
        } else if (this.Witnessed == StudentWitnessType.WeaponAndBlood) {
          this.Subtitle.UpdateLabel(SubtitleType.WeaponAndBloodReaction, 1, 3f);
        } else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity) {
          this.Subtitle.UpdateLabel(SubtitleType.WeaponAndInsanityReaction, 1, 3f);
        } else if (this.Witnessed == StudentWitnessType.BloodAndInsanity) {
          this.Subtitle.UpdateLabel(SubtitleType.BloodAndInsanityReaction, 1, 3f);
        } else if (this.Witnessed == StudentWitnessType.Weapon) {
          this.Subtitle.UpdateLabel(SubtitleType.WeaponReaction, this.WeaponWitnessed, 3f);
        } else if (this.Witnessed == StudentWitnessType.Blood) {
          if (!this.Bloody) {
            this.Subtitle.UpdateLabel(SubtitleType.BloodReaction, 1, 3f);
          } else {
            this.Subtitle.UpdateLabel(SubtitleType.WetBloodReaction, 1, 3f);
            this.Witnessed = StudentWitnessType.None;
            this.Witness = false;
          }
        } else if (this.Witnessed == StudentWitnessType.Insanity) {
          this.Subtitle.UpdateLabel(SubtitleType.InsanityReaction, 1, 3f);
        } else if (this.Witnessed == StudentWitnessType.Lewd) {
          this.Subtitle.UpdateLabel(SubtitleType.LewdReaction, 1, 3f);
        } else if (this.Witnessed == StudentWitnessType.Suspicious) {
          this.Subtitle.UpdateLabel(SubtitleType.SuspiciousReaction, 1, 3f);
        } else if (this.Witnessed == StudentWitnessType.Corpse) {
          if (this.Club == ClubType.Council) {
            if (this.StudentID == 86) {
              this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 1, 5f);
            } else if (this.StudentID == 87) {
              this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 2, 5f);
            } else if (this.StudentID == 88) {
              this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 3, 5f);
            } else if (this.StudentID == 89) {
              this.Subtitle.UpdateLabel(SubtitleType.CouncilCorpseReaction, 4, 5f);
            }
          } else if (this.Persona == PersonaType.Evil) {
            this.Subtitle.UpdateLabel(SubtitleType.EvilCorpseReaction, 1, 5f);
          } else {
            this.Subtitle.UpdateLabel(SubtitleType.CorpseReaction, 1, 5f);
          }
        } else if (this.Witnessed == StudentWitnessType.Interruption) {
          this.Subtitle.UpdateLabel(SubtitleType.InterruptionReaction, 1, 5f);
        } else if (this.Witnessed == StudentWitnessType.Eavesdropping) {
          this.Subtitle.UpdateLabel(SubtitleType.EavesdropReaction, 1, 5f);
        } else if (this.Witnessed == StudentWitnessType.Pickpocketing) {
          this.Subtitle.UpdateLabel(this.PickpocketSubtitleType, 1, 5f);
        } else {
          this.Subtitle.UpdateLabel(SubtitleType.HmmReaction, 1, 3f);
        }
      } else if (!this.Yandere.Egg) {
        if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity) {
          this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
          this.GameOverCause = GameOverType.Insanity;
        } else if (this.Witnessed == StudentWitnessType.WeaponAndBlood) {
          this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
          this.GameOverCause = GameOverType.Weapon;
        } else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity) {
          this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
          this.GameOverCause = GameOverType.Insanity;
        } else if (this.Witnessed == StudentWitnessType.BloodAndInsanity) {
          this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
          this.GameOverCause = GameOverType.Insanity;
        } else if (this.Witnessed == StudentWitnessType.Weapon) {
          this.CharacterAnimation.CrossFade("senpaiWeaponReaction_00");
          this.GameOverCause = GameOverType.Weapon;
        } else if (this.Witnessed == StudentWitnessType.Blood) {
          this.CharacterAnimation.CrossFade("senpaiBloodReaction_00");
          this.GameOverCause = GameOverType.Blood;
        } else if (this.Witnessed == StudentWitnessType.Insanity) {
          this.CharacterAnimation.CrossFade("senpaiInsanityReaction_00");
          this.GameOverCause = GameOverType.Insanity;
        } else if (this.Witnessed == StudentWitnessType.Lewd) {
          this.CharacterAnimation.CrossFade("senpaiLewdReaction_00");
          this.GameOverCause = GameOverType.Lewd;
        } else if (this.Witnessed == StudentWitnessType.Stalking) {
          if (this.Concern < 5) {
            this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
          } else {
            this.CharacterAnimation.CrossFade("senpaiCreepyReaction_00");
            this.GameOverCause = GameOverType.Stalking;
          }
          this.Witnessed = StudentWitnessType.None;
        } else if (this.Witnessed == StudentWitnessType.Corpse) {
          this.Subtitle.UpdateLabel(SubtitleType.SenpaiCorpseReaction, 1, 5f);
        }
        if (this.Concern == 5) {
          this.CharacterAnimation["scaredFace_00"].weight = 0f;
          this.CharacterAnimation[this.AngryFaceAnim].weight = 0f;
          this.Yandere.ShoulderCamera.enabled = true;
          this.Yandere.ShoulderCamera.Noticed = true;
          this.Yandere.RPGCamera.enabled = false;
          this.Stop = true;
        }
      }
      this.Reacted = true;
    }
    if (this.Club == ClubType.Council && (double)this.DistanceToPlayer < 1.1 && this.Yandere.Armed) {
      this.Spray();
    }
  }

  // Token: 0x06000827 RID: 2087 RVA: 0x0008AD3C File Offset: 0x0008913C
  private void UpdateBurning() {
    if (this.BurnTarget != Vector3.zero) {
      this.MoveTowardsTarget(this.BurnTarget);
    }
    if (this.CharacterAnimation[this.BurningAnim].time > this.CharacterAnimation[this.BurningAnim].length) {
      this.DeathType = DeathType.Burning;
      this.BecomeRagdoll();
    }
  }

  // Token: 0x06000828 RID: 2088 RVA: 0x0008ADA8 File Offset: 0x000891A8
  private void UpdateSplashed() {
    if (this.Yandere.Tripping) {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
      base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
    }
    if (!this.Alarmed) {
      this.SplashTimer += Time.deltaTime;
      if (this.SplashTimer > 2f && this.SplashPhase == 1) {
        if (this.Gas) {
          this.Subtitle.UpdateLabel(this.SplashSubtitleType, 5, 5f);
        } else if (this.Bloody) {
          this.Subtitle.UpdateLabel(this.SplashSubtitleType, 3, 5f);
        } else if (this.Yandere.Tripping) {
          this.Subtitle.UpdateLabel(this.SplashSubtitleType, 7, 5f);
        } else {
          this.Subtitle.UpdateLabel(this.SplashSubtitleType, 1, 5f);
        }
        this.CharacterAnimation[this.SplashedAnim].speed = 0.5f;
        this.SplashPhase++;
      }
      if (this.SplashTimer > 12f && this.SplashPhase == 2) {
        if (this.LightSwitch == null) {
          if (this.Gas) {
            this.Subtitle.UpdateLabel(this.SplashSubtitleType, 6, 5f);
          } else if (this.Bloody) {
            this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
          } else {
            this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
          }
          this.SplashPhase++;
          this.CurrentDestination = this.StudentManager.StripSpot;
          this.Pathfinding.target = this.StudentManager.StripSpot;
        } else if (!this.LightSwitch.BathroomLight.activeInHierarchy) {
          if (this.LightSwitch.Panel.useGravity) {
            this.LightSwitch.Prompt.Hide();
            this.LightSwitch.Prompt.enabled = false;
            this.Prompt.Hide();
            this.Prompt.enabled = false;
          }
          this.Subtitle.UpdateLabel(SubtitleType.LightSwitchReaction, 1, 5f);
          this.CurrentDestination = this.LightSwitch.ElectrocutionSpot;
          this.Pathfinding.target = this.LightSwitch.ElectrocutionSpot;
          this.Pathfinding.speed = 1f;
          this.BathePhase = -1;
          this.InDarkness = true;
        } else {
          if (!this.Bloody) {
            this.Subtitle.UpdateLabel(this.SplashSubtitleType, 2, 5f);
          } else {
            this.Subtitle.UpdateLabel(this.SplashSubtitleType, 4, 5f);
          }
          this.SplashPhase++;
          this.CurrentDestination = this.StudentManager.StripSpot;
          this.Pathfinding.target = this.StudentManager.StripSpot;
        }
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.Splashed = false;
      }
    }
  }

  // Token: 0x06000829 RID: 2089 RVA: 0x0008B170 File Offset: 0x00089570
  private void UpdateTurningOffRadio() {
    if (this.TurnOffRadio) {
      if (this.Radio.On || (this.RadioPhase == 3 && this.Radio.transform.parent == null)) {
        if (this.RadioPhase == 1) {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.RadioTimer += Time.deltaTime;
          if (this.RadioTimer > 3f) {
            this.CharacterAnimation.CrossFade(this.WalkAnim);
            this.CurrentDestination = this.Radio.transform;
            this.Pathfinding.target = this.Radio.transform;
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.RadioTimer = 0f;
            this.RadioPhase++;
          }
        } else if (this.RadioPhase == 2) {
          if (this.DistanceToDestination < 0.5f) {
            this.CharacterAnimation.CrossFade(this.RadioAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.RadioPhase++;
          }
        } else if (this.RadioPhase == 3) {
          this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
          this.RadioTimer += Time.deltaTime;
          if (this.RadioTimer > 4f) {
            this.CurrentDestination = this.Destinations[this.Phase];
            this.Pathfinding.target = this.Destinations[this.Phase];
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.ForgetRadio();
          } else if (this.RadioTimer > 2f) {
            this.Radio.Victim = null;
            this.Radio.TurnOff();
          }
        }
      } else {
        if (this.RadioPhase < 100) {
          this.CharacterAnimation.CrossFade(this.IdleAnim);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.RadioPhase = 100;
          this.RadioTimer = 0f;
        }
        this.targetRotation = Quaternion.LookRotation(new Vector3(this.Radio.transform.position.x, base.transform.position.y, this.Radio.transform.position.z) - base.transform.position);
        this.RadioTimer += Time.deltaTime;
        if (this.RadioTimer > 1f || this.Radio.transform.parent != null) {
          this.CurrentDestination = this.Destinations[this.Phase];
          this.Pathfinding.target = this.Destinations[this.Phase];
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.ForgetRadio();
        }
      }
    }
  }

  // Token: 0x0600082A RID: 2090 RVA: 0x0008B5B0 File Offset: 0x000899B0
  private void UpdateVomiting() {
    if (this.Vomiting) {
      if (this.VomitPhase != 0 && this.VomitPhase != 4) {
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.CurrentDestination.position);
      }
      if (this.VomitPhase == 0) {
        if (this.DistanceToDestination < 0.5f) {
          if (this.StudentID == 33) {
            this.Prompt.Label[0].text = "     Drown";
            this.Drownable = true;
          }
          if (!this.Male) {
            this.StudentManager.FemaleVomitDoor.Prompt.enabled = false;
            this.StudentManager.FemaleVomitDoor.Prompt.Hide();
          }
          this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
          this.CharacterAnimation.CrossFade(this.VomitAnim);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.VomitPhase++;
        }
      } else if (this.VomitPhase == 1) {
        if (this.CharacterAnimation[this.VomitAnim].time > 1f) {
          this.VomitEmitter.Play();
          this.VomitPhase++;
        }
      } else if (this.VomitPhase == 2) {
        if (this.CharacterAnimation[this.VomitAnim].time > 13f) {
          this.VomitEmitter.Stop();
          this.VomitPhase++;
        }
      } else if (this.VomitPhase == 3) {
        if (this.CharacterAnimation[this.VomitAnim].time >= this.CharacterAnimation[this.VomitAnim].length) {
          this.Prompt.Label[0].text = "     Talk";
          this.Drownable = false;
          this.WalkAnim = this.OriginalWalkAnim;
          this.CharacterAnimation.CrossFade(this.WalkAnim);
          if (this.Male) {
            this.Pathfinding.target = this.StudentManager.MaleWashSpot;
            this.CurrentDestination = this.StudentManager.MaleWashSpot;
          } else {
            this.Pathfinding.target = this.StudentManager.FemaleWashSpot;
            this.CurrentDestination = this.StudentManager.FemaleWashSpot;
          }
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Pathfinding.speed = 1f;
          this.DistanceToDestination = 100f;
          this.VomitPhase++;
        }
      } else if (this.VomitPhase == 4) {
        if (this.DistanceToDestination < 0.5f) {
          this.CharacterAnimation.CrossFade(this.WashFaceAnim);
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.VomitPhase++;
        }
      } else if (this.VomitPhase == 5 && this.CharacterAnimation[this.WashFaceAnim].time > this.CharacterAnimation[this.WashFaceAnim].length) {
        this.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
        this.Prompt.Label[0].text = "     Talk";
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.Distracted = false;
        this.Drownable = false;
        this.Vomiting = false;
        this.Private = false;
        this.CanTalk = true;
        this.Routine = true;
        this.Emetic = false;
        this.VomitPhase = 0;
        this.Pathfinding.target = this.Destinations[this.Phase];
        this.CurrentDestination = this.Destinations[this.Phase];
        this.DistanceToDestination = 100f;
        if (!this.Male) {
          this.StudentManager.FemaleVomitDoor.Prompt.enabled = false;
          this.StudentManager.FemaleVomitDoor.Prompt.Hide();
        }
      }
    }
  }

  // Token: 0x0600082B RID: 2091 RVA: 0x0008BA0C File Offset: 0x00089E0C
  private void UpdateConfessing() {
    if (this.Confessing) {
      if (!this.Male) {
        if (this.ConfessPhase == 1) {
          if (this.DistanceToDestination < 0.5f) {
            this.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
            this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
            this.CharacterAnimation.CrossFade("f02_insertNote_00");
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.Note.SetActive(true);
            this.ConfessPhase++;
          }
        } else if (this.ConfessPhase == 2) {
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
          this.MoveTowardsTarget(this.CurrentDestination.position);
          if (this.CharacterAnimation["f02_insertNote_00"].time >= 9f) {
            this.Note.SetActive(false);
            this.ConfessPhase++;
          }
        } else if (this.ConfessPhase == 3) {
          if (this.CharacterAnimation["f02_insertNote_00"].time >= this.CharacterAnimation["f02_insertNote_00"].length) {
            this.CurrentDestination = this.StudentManager.RivalConfessionSpot;
            this.Pathfinding.target = this.StudentManager.RivalConfessionSpot;
            this.Pathfinding.canSearch = true;
            this.Pathfinding.canMove = true;
            this.Pathfinding.speed = 4f;
            this.StudentManager.LoveManager.LeftNote = true;
            this.CharacterAnimation.CrossFade(this.SprintAnim);
            this.ConfessPhase++;
          }
        } else if (this.ConfessPhase == 4) {
          if (this.DistanceToDestination < 0.5f) {
            this.CharacterAnimation.CrossFade(this.IdleAnim);
            this.Pathfinding.canSearch = false;
            this.Pathfinding.canMove = false;
            this.ConfessPhase++;
          }
        } else if (this.ConfessPhase == 5) {
          base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
          this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
          this.MoveTowardsTarget(this.CurrentDestination.position);
        }
      } else if (this.ConfessPhase == 1) {
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.CurrentDestination.position);
        if (this.CharacterAnimation["keepNote_00"].time > 14f) {
          this.Note.SetActive(false);
        } else if ((double)this.CharacterAnimation["keepNote_00"].time > 4.5) {
          this.Note.SetActive(true);
        }
        if (this.CharacterAnimation["keepNote_00"].time >= this.CharacterAnimation["keepNote_00"].length) {
          this.CurrentDestination = this.StudentManager.SuitorConfessionSpot;
          this.Pathfinding.target = this.StudentManager.SuitorConfessionSpot;
          this.Pathfinding.canSearch = true;
          this.Pathfinding.canMove = true;
          this.Pathfinding.speed = 4f;
          this.CharacterAnimation.CrossFade(this.SprintAnim);
          this.ConfessPhase++;
        }
      } else if (this.ConfessPhase == 2) {
        if (this.DistanceToDestination < 0.5f) {
          this.CharacterAnimation.CrossFade("exhausted_00");
          this.Pathfinding.canSearch = false;
          this.Pathfinding.canMove = false;
          this.ConfessPhase++;
        }
      } else if (this.ConfessPhase == 3) {
        base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.CurrentDestination.rotation, Time.deltaTime * 10f);
        this.MoveTowardsTarget(this.CurrentDestination.position);
      }
    }
  }

  // Token: 0x0600082C RID: 2092 RVA: 0x0008BEE8 File Offset: 0x0008A2E8
  private void UpdateMisc() {
    if (this.IgnoreTimer > 0f) {
      this.IgnoreTimer -= Time.deltaTime;
    }
    if (!this.Fleeing) {
      if (base.transform.position.z < -100f) {
        if (base.transform.position.y < -2f && this.StudentID > 1) {
          UnityEngine.Object.Destroy(base.gameObject);
        }
      } else {
        if (base.transform.position.y < -0f) {
          base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
        }
        if ((this.Club == ClubType.Council || this.Club == ClubType.Delinquent) && (double)this.DistanceToPlayer < 0.5 && (this.Yandere.h != 0f || this.Yandere.v != 0f)) {
          this.Shove();
        }
        if (!this.Dying && !this.Yandere.Egg && this.Club == ClubType.Council) {
          if (this.DistanceToPlayer < 5f) {
            float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
            if (Mathf.Abs(f) <= 45f && this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && (this.Yandere.h != 0f || this.Yandere.v != 0f) && (Input.GetButton("LB") || this.DistanceToPlayer < 2f)) {
              this.DistractionSpot = this.Yandere.transform.position;
              this.Alarm = 100f + Time.deltaTime * 100f * (1f / this.Paranoia);
              this.FocusOnYandere = true;
              this.Pathfinding.canSearch = false;
              this.Pathfinding.canMove = false;
              this.StopInvestigating();
            }
          }
          if (this.DistanceToPlayer < 1f) {
            float f2 = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
            if (Mathf.Abs(f2) > 45f && this.Yandere.Armed) {
              this.Spray();
            }
          }
        }
      }
    }
    if (!this.Male) {
      if (!this.Splashed && this.Wet && !this.Burning && !this.Dying && Mathf.Abs(this.BathePhase) == 1) {
        if (this.CharacterAnimation[this.WetAnim].weight < 1f) {
          this.CharacterAnimation[this.WetAnim].weight = 1f;
        }
      } else if (this.CharacterAnimation[this.WetAnim].weight > 0f) {
        this.CharacterAnimation[this.WetAnim].weight = 0f;
      }
    }
    if (this.Dying) {
      this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    }
    if (this.Pathfinding.canMove && base.transform.position == this.LastPosition) {
      this.StuckTimer += Time.deltaTime;
      if (this.StuckTimer > 1f) {
        this.MyController.Move(base.transform.right * (Time.timeScale * 0.0001f));
        this.StuckTimer = 0f;
      }
    }
    this.LastPosition = base.transform.position;
  }

  // Token: 0x0600082D RID: 2093 RVA: 0x0008C35C File Offset: 0x0008A75C
  private void LateUpdate() {
    this.CharacterAnimation.enabled = (this.CharacterAnimation.cullingType != AnimationCullingType.BasedOnRenderers || !this.StudentManager.DisableFarAnims || this.DistanceToPlayer <= 15f);
    if (this.EyeShrink > 1f) {
      this.EyeShrink = 1f;
    }
    this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
    this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
    this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
    this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
    this.PreviousEyeShrink = this.EyeShrink;
    if (!this.Male) {
      if (this.Shy) {
        if (this.Routine) {
          if ((this.Phase == 2 && this.DistanceToDestination < 1f) || (this.Phase == 4 && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.SitAndTakeNotes && this.DistanceToDestination < 1f) || (this.Actions[this.Phase] == StudentActionType.Clean && this.DistanceToDestination < 1f)) {
            this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
          } else {
            this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 1f, Time.deltaTime);
          }
        } else {
          this.CharacterAnimation[this.ShyAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.ShyAnim].weight, 0f, Time.deltaTime);
        }
      }
      if (this.Routine && !this.InEvent && !this.Meeting) {
        if (this.DistanceToDestination < this.TargetDistance && this.Actions[this.Phase] == StudentActionType.SitAndSocialize) {
          this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 1f, Time.deltaTime * 10f);
        } else {
          this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
        }
      } else {
        this.CharacterAnimation[this.SocialSitAnim].weight = Mathf.Lerp(this.CharacterAnimation[this.SocialSitAnim].weight, 0f, Time.deltaTime * 10f);
      }
      if (!this.BoobsResized) {
        this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
        this.RightBreast.gameObject.name = "RightBreastRENAMED";
        this.LeftBreast.gameObject.name = "LeftBreastRENAMED";
        this.BoobsResized = true;
      }
      if (this.Following) {
        if (this.Gush) {
          this.Neck.LookAt(this.GushTarget);
        } else {
          this.Neck.LookAt(this.DefaultTarget);
        }
      }
    }
    if (this.DK) {
      this.Arm[0].localScale = new Vector3(2f, 2f, 2f);
      this.Arm[1].localScale = new Vector3(2f, 2f, 2f);
      this.Head.localScale = new Vector3(2f, 2f, 2f);
    }
    if (this.StudentID == 32) {
      for (int i = 0; i < 4; i++) {
        Transform transform = this.Skirt[i].transform;
        transform.localScale = new Vector3(transform.localScale.x, 0.6666667f, transform.localScale.z);
      }
    }
  }

  // Token: 0x0600082E RID: 2094 RVA: 0x0008C8F8 File Offset: 0x0008ACF8
  public void CalculateReputationPenalty() {
    if ((this.Male && PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 2) || PlayerGlobals.Seduction + PlayerGlobals.SeductionBonus > 4) {
      this.RepDeduction += this.RepLoss * 0.2f;
    }
    if (PlayerGlobals.Reputation < -33.33333f) {
      this.RepDeduction += this.RepLoss * 0.2f;
    }
    if (PlayerGlobals.Reputation > 33.33333f) {
      this.RepDeduction -= this.RepLoss * 0.2f;
    }
    if (PlayerGlobals.GetStudentFriend(this.StudentID)) {
      this.RepDeduction += this.RepLoss * 0.2f;
    }
    if (PlayerGlobals.PantiesEquipped == 1) {
      this.RepDeduction += this.RepLoss * 0.2f;
    }
    if (PlayerGlobals.SocialBonus > 0) {
      this.RepDeduction += this.RepLoss * 0.2f;
    }
  }

  // Token: 0x0600082F RID: 2095 RVA: 0x0008CA0C File Offset: 0x0008AE0C
  public void MoveTowardsTarget(Vector3 target) {
    if (Time.timeScale > 0f && this.MyController.enabled) {
      Vector3 a = target - base.transform.position;
      float sqrMagnitude = a.sqrMagnitude;
      if (sqrMagnitude > 1E-06f) {
        this.MyController.Move(a * (Time.deltaTime * 5f / Time.timeScale));
      }
    }
  }

  // Token: 0x06000830 RID: 2096 RVA: 0x0008CA80 File Offset: 0x0008AE80
  private void LookTowardsTarget(Vector3 target) {
    if (Time.timeScale > 0f) {
    }
  }

  // Token: 0x06000831 RID: 2097 RVA: 0x0008CA94 File Offset: 0x0008AE94
  public void AttackReaction() {
    if (!this.WitnessedMurder) {
      float f = Vector3.Angle(-base.transform.forward, this.Yandere.transform.position - base.transform.position);
      this.Yandere.AttackManager.Stealth = (Mathf.Abs(f) <= 45f);
    }
    if (!this.Male) {
      if (this.Club != ClubType.Council) {
        this.StudentManager.TranqDetector.TranqCheck();
      }
      this.CharacterAnimation["f02_smile_00"].weight = 0f;
      this.SmartPhone.SetActive(false);
    }
    this.WitnessCamera.Show = false;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Yandere.CharacterAnimation["f02_idleShort_00"].time = 0f;
    this.Yandere.CharacterAnimation["f02_swingA_00"].time = 0f;
    this.Yandere.MyController.radius = 0f;
    this.Yandere.TargetStudent = this;
    this.Yandere.Obscurance.enabled = false;
    this.Yandere.YandereVision = false;
    this.Yandere.Attacking = true;
    this.Yandere.CanMove = false;
    if (this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon.AnimID == 2) {
      this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[2]].weight = 0f;
    }
    if (this.DetectionMarker != null) {
      this.DetectionMarker.Tex.enabled = false;
    }
    this.OccultBook.SetActive(false);
    this.MyController.radius = 0f;
    this.Investigating = false;
    this.Pen.SetActive(false);
    this.SpeechLines.Stop();
    this.Attacked = true;
    this.Alarmed = false;
    this.Fleeing = false;
    this.Routine = false;
    this.ReadPhase = 0;
    this.Dying = true;
    this.Wet = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    if (this.Following) {
      var emission = Hearts.emission;
      emission.enabled = false;
      this.Yandere.Followers--;
      this.Following = false;
    }
    if (this.Distracting) {
      this.DistractionTarget.TargetedForDistraction = false;
      this.DistractionTarget.Distracted = false;
      this.Distracting = false;
    }
    if (this.Teacher) {
      if (ClassGlobals.PhysicalGrade + ClassGlobals.PhysicalBonus > 0 && this.Yandere.EquippedWeapon.Type == WeaponType.Knife) {
        Debug.Log("A teacher has entered the ''Fleeing'' protocol and called the ''BeginStruggle'' function.");
        this.Pathfinding.target = this.Yandere.transform;
        this.CurrentDestination = this.Yandere.transform;
        this.Yandere.Attacking = false;
        this.Attacked = false;
        this.Fleeing = true;
        this.Dying = false;
        this.Persona = PersonaType.Heroic;
        this.BeginStruggle();
      } else {
        this.Yandere.HeartRate.gameObject.SetActive(false);
        this.Yandere.ShoulderCamera.Counter = true;
        this.ShoulderCamera.OverShoulder = false;
        this.Yandere.RPGCamera.enabled = false;
        this.Yandere.Senpai = base.transform;
        this.Yandere.Attacking = true;
        this.Yandere.CanMove = false;
        this.Yandere.Talking = false;
        this.Yandere.Noticed = true;
        this.Yandere.HUD.alpha = 0f;
      }
    } else {
      if (!this.Yandere.AttackManager.Stealth) {
        this.Subtitle.UpdateLabel(SubtitleType.Dying, 0, 1f);
        this.SpawnAlarmDisc();
      }
      if (this.Yandere.SanityBased) {
        this.Yandere.AttackManager.Attack(this.Character, this.Yandere.EquippedWeapon);
      }
    }
    if (this.StudentManager.Reporter == this) {
      this.StudentManager.Reporter = null;
      if (this.ReportPhase == 0) {
        Debug.Log("A reporter died before being able to report a corpse. Corpse position reset.");
        this.StudentManager.CorpseLocation.position = Vector3.zero;
      }
    }
  }

  // Token: 0x06000832 RID: 2098 RVA: 0x0008CF40 File Offset: 0x0008B340
  public void SenpaiNoticed() {
    Debug.Log("The ''SenpaiNoticed'' function has been called.");
    if (!this.Yandere.Attacking) {
      this.Yandere.EmptyHands();
    }
    this.Yandere.Senpai = base.transform;
    if (this.Yandere.Aiming) {
      this.Yandere.StopAiming();
    }
    this.Yandere.DetectionPanel.alpha = 0f;
    this.Yandere.RPGCamera.mouseSpeed = 0f;
    this.Yandere.LaughIntensity = 0f;
    this.Yandere.HUD.alpha = 0f;
    this.Yandere.EyeShrink = 0f;
    this.Yandere.Sanity = 100f;
    this.Yandere.HeartRate.gameObject.SetActive(false);
    this.ShoulderCamera.OverShoulder = false;
    this.Yandere.Obscurance.enabled = false;
    this.Yandere.YandereVision = false;
    this.Yandere.Police.Show = false;
    this.Yandere.Stance.Current = StanceType.Standing;
    this.Yandere.Rummaging = false;
    this.Yandere.Laughing = false;
    this.Yandere.CanMove = false;
    this.Yandere.Dipping = false;
    this.Yandere.Mopping = false;
    this.Yandere.Talking = false;
    this.Yandere.Noticed = true;
    this.Yandere.Jukebox.GameOver();
    this.StudentManager.StopMoving();
    if (this.Teacher || this.StudentID == 1) {
      base.enabled = true;
      this.Stop = false;
    }
  }

  // Token: 0x06000833 RID: 2099 RVA: 0x0008D104 File Offset: 0x0008B504
  private void WitnessMurder() {
    Debug.Log("An NPC has witnessed murder.");
    if (!this.Male) {
      this.CharacterAnimation["f02_smile_00"].weight = 0f;
    }
    if (this.Yandere.Mask == null) {
      this.SawMask = false;
      this.Grudge = true;
    } else {
      this.SawMask = true;
    }
    if (this.Persona != this.OriginalPersona) {
      this.Persona = this.OriginalPersona;
      this.SwitchBack = false;
      this.PersonaReaction();
    }
    if (this.StudentID > 1 || this.Yandere.Mask != null) {
      this.ID = 0;
      while (this.ID < this.Outlines.Length) {
        this.Outlines[this.ID].color = new Color(1f, 0f, 0f, 1f);
        this.Outlines[this.ID].enabled = true;
        this.ID++;
      }
      this.WitnessCamera.transform.parent = this.WitnessPOV;
      this.WitnessCamera.transform.localPosition = Vector3.zero;
      this.WitnessCamera.transform.localEulerAngles = Vector3.zero;
      this.WitnessCamera.MyCamera.enabled = true;
      this.WitnessCamera.Show = true;
      this.CameraEffects.MurderWitnessed();
      this.Witnessed = StudentWitnessType.Murder;
      if (this.Persona != PersonaType.Evil) {
        this.Police.Witnesses++;
      }
      if (this.Teacher) {
        this.StudentManager.Reporter = this;
      }
      if (this.Talking) {
        this.DialogueWheel.End();
        var emission = Hearts.emission;
        emission.enabled = false;
        this.Pathfinding.canSearch = true;
        this.Pathfinding.canMove = true;
        this.Obstacle.enabled = false;
        this.Talking = false;
        this.Waiting = false;
        this.StudentManager.EnablePrompts();
      }
      if (this.Prompt.Label[0] != null) {
        this.Prompt.Label[0].text = "     Talk";
        this.Prompt.HideButton[0] = true;
      }
    } else {
      if (!this.Yandere.Attacking) {
        this.SenpaiNoticed();
      }
      this.Fleeing = false;
      this.EyeShrink = 0f;
      this.Yandere.Noticed = true;
      this.Yandere.Talking = false;
      this.CameraEffects.MurderWitnessed();
      this.ShoulderCamera.OverShoulder = false;
      this.CharacterAnimation.CrossFade(this.ScaredAnim);
      this.CharacterAnimation["scaredFace_00"].weight = 1f;
      if (this.StudentID == 1) {
        Debug.Log("Senpai entered his scared animation.");
      }
    }
    if (this.Persona == PersonaType.TeachersPet && this.StudentManager.Reporter == null && !this.Police.Called) {
      this.StudentManager.CorpseLocation.position = this.Yandere.transform.position;
      this.StudentManager.LowerCorpsePosition();
      this.StudentManager.Reporter = this;
      this.Reporting = true;
    }
    if (this.Following) {
      var emission = Hearts.emission;
      emission.enabled = false;
      this.Yandere.Followers--;
      this.Following = false;
    }
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    if (this.SmartPhone != null) {
      this.SmartPhone.SetActive(false);
    }
    this.OccultBook.SetActive(false);
    this.Phone.SetActive(false);
    this.WitnessedMurder = true;
    this.Investigating = false;
    this.MurdersWitnessed++;
    this.SpeechLines.Stop();
    this.Reacted = false;
    this.Routine = false;
    this.Alarmed = true;
    this.Wet = false;
    if (this.Persona != PersonaType.Heroic) {
      this.AlarmTimer = 0f;
      this.Alarm = 0f;
    }
    if (this.Teacher) {
      if (!this.Yandere.Chased) {
        Debug.Log("A teacher has reached ChaseYandere through WitnessMurder.");
        this.ChaseYandere();
      }
    } else {
      this.SpawnAlarmDisc();
    }
    if (!this.PinDownWitness) {
      this.StudentManager.Witnesses++;
      this.StudentManager.WitnessList[this.StudentManager.Witnesses] = this;
      this.StudentManager.PinDownCheck();
      this.PinDownWitness = true;
    }
    this.StudentManager.UpdateMe(this.StudentID);
  }

  // Token: 0x06000834 RID: 2100 RVA: 0x0008D5F8 File Offset: 0x0008B9F8
  private void ChaseYandere() {
    Debug.Log("A character has begun to chase Yandere-chan.");
    this.CurrentDestination = this.Yandere.transform;
    this.Pathfinding.target = this.Yandere.transform;
    this.Pathfinding.speed = 7.5f;
    this.StudentManager.Portal.SetActive(false);
    if (this.Yandere.Pursuer == null) {
      this.Yandere.Pursuer = this;
    }
    this.TargetDistance = 0.5f;
    this.Fleeing = false;
    this.AlarmTimer = 0f;
    this.StudentManager.UpdateStudents();
  }

  // Token: 0x06000835 RID: 2101 RVA: 0x0008D6A4 File Offset: 0x0008BAA4
  private void PersonaReaction() {
    if (!this.Indoors && this.WitnessedMurder && this.StudentID != this.StudentManager.RivalID && this.Persona != PersonaType.Heroic) {
      this.Persona = PersonaType.Loner;
    }
    if (!this.WitnessedMurder) {
      if (this.Persona == PersonaType.Heroic) {
        this.SwitchBack = true;
        this.Persona = ((!(this.Corpse != null)) ? PersonaType.Loner : PersonaType.TeachersPet);
      } else if (this.Persona == PersonaType.Coward || this.Persona == PersonaType.Evil) {
        this.Persona = PersonaType.Loner;
      }
    }
    if (this.Persona == PersonaType.Loner) {
      if (this.WitnessedMurder) {
        this.Subtitle.UpdateLabel(SubtitleType.LonerMurderReaction, 1, 3f);
      } else {
        this.Subtitle.UpdateLabel(SubtitleType.LonerCorpseReaction, 1, 3f);
      }
      if (this.Schoolwear > 0) {
        if (!this.Bloody) {
          this.Pathfinding.target = this.StudentManager.Exit;
          this.TargetDistance = 0f;
          this.Routine = false;
          this.Fleeing = true;
        } else {
          this.FleeWhenClean = true;
          this.TargetDistance = 1f;
          this.BatheFast = true;
        }
      } else {
        this.FleeWhenClean = true;
        if (!this.Bloody) {
          this.BathePhase = 7;
          this.GoChange();
        } else {
          this.CurrentDestination = this.StudentManager.FastBatheSpot;
          this.Pathfinding.target = this.StudentManager.FastBatheSpot;
          this.TargetDistance = 1f;
          this.BatheFast = true;
        }
      }
    } else if (this.Persona == PersonaType.TeachersPet) {
      if (this.StudentManager.Reporter == null && !this.Police.Called) {
        Debug.Log("A student has become a ''reporter''.");
        this.StudentManager.Reporter = this;
        this.Reporting = true;
        this.DetermineCorpseLocation();
      }
      if (this.StudentManager.Reporter == this) {
        Debug.Log("A student is running to a teacher.");
        this.Pathfinding.target = this.StudentManager.Teachers[this.Class].transform;
        this.CurrentDestination = this.StudentManager.Teachers[this.Class].transform;
        this.TargetDistance = 2f;
        if (this.WitnessedMurder) {
          this.Subtitle.UpdateLabel(SubtitleType.PetMurderReport, 1, 3f);
        } else {
          this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReport, 1, 3f);
        }
      } else {
        if (this.Club == ClubType.Council) {
          Debug.Log("A student council member has been told to travel to ''CorpseLocation''.");
          if (this.StudentID == 86) {
            this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[1];
          } else if (this.StudentID == 87) {
            this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[2];
          } else if (this.StudentID == 88) {
            this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[3];
          } else if (this.StudentID == 89) {
            this.Pathfinding.target = this.StudentManager.CorpseGuardLocation[4];
          }
          this.CurrentDestination = this.Pathfinding.target;
        } else {
          this.Pathfinding.target = this.Seat;
          this.CurrentDestination = this.Seat;
        }
        if (this.WitnessedMurder) {
          this.Subtitle.UpdateLabel(SubtitleType.PetMurderReaction, 1, 3f);
        } else {
          this.Subtitle.UpdateLabel(SubtitleType.PetCorpseReaction, 1, 3f);
        }
        this.TargetDistance = 1f;
      }
      this.Routine = false;
      this.Fleeing = true;
    } else if (this.Persona == PersonaType.Heroic) {
      if (!this.Yandere.Chased) {
        Debug.Log("Began fleeing because Hero persona reaction was called.");
        this.Subtitle.UpdateLabel(SubtitleType.HeroMurderReaction, 3, 3f);
        this.Pathfinding.target = this.Yandere.transform;
        this.Pathfinding.speed = 7.5f;
        this.StudentManager.Portal.SetActive(false);
        this.Yandere.Chased = true;
        this.TargetDistance = 0.5f;
        this.StudentManager.UpdateStudents();
        this.Routine = false;
        this.Fleeing = true;
      }
    } else if (this.Persona == PersonaType.Coward) {
      this.CurrentDestination = base.transform;
      this.Pathfinding.target = base.transform;
      this.Subtitle.UpdateLabel(SubtitleType.CowardMurderReaction, 1, 5f);
      this.Routine = false;
      this.Fleeing = true;
    } else if (this.Persona == PersonaType.Evil) {
      this.CurrentDestination = base.transform;
      this.Pathfinding.target = base.transform;
      this.Subtitle.UpdateLabel(SubtitleType.EvilMurderReaction, 1, 5f);
      this.Routine = false;
      this.Fleeing = true;
    } else if (this.Persona == PersonaType.SocialButterfly) {
      Debug.Log("A social butterfly is reacting.");
      this.CurrentDestination = this.StudentManager.HidingSpots.List[this.StudentID];
      this.Pathfinding.target = this.StudentManager.HidingSpots.List[this.StudentID];
      this.Subtitle.UpdateLabel(SubtitleType.SocialDeathReaction, 1, 5f);
      this.ReportPhase = 1;
      this.Routine = false;
      this.Fleeing = true;
      this.Halt = true;
    } else if (this.Persona == PersonaType.Lovestruck) {
      if (!this.StudentManager.Students[1].WitnessedMurder) {
        this.CurrentDestination = this.StudentManager.Students[1].transform;
        this.Pathfinding.target = this.StudentManager.Students[1].transform;
        this.TargetDistance = 1f;
        this.ReportPhase = 1;
      } else {
        this.CurrentDestination = this.StudentManager.Exit;
        this.Pathfinding.target = this.StudentManager.Exit;
        this.TargetDistance = 0f;
        this.ReportPhase = 3;
      }
      this.Subtitle.UpdateLabel(SubtitleType.LovestruckDeathReaction, 1, 5f);
      this.Routine = false;
      this.Fleeing = true;
      this.Halt = true;
    } else if (this.Persona == PersonaType.Dangerous) {
      if (this.WitnessedMurder) {
        if (!this.Yandere.Chased) {
          Debug.Log("Began fleeing because Dangerous persona reaction was called.");
          if (this.StudentID == 86) {
            this.Subtitle.UpdateLabel(SubtitleType.Chasing, 1, 5f);
          } else if (this.StudentID == 87) {
            this.Subtitle.UpdateLabel(SubtitleType.Chasing, 2, 5f);
          } else if (this.StudentID == 88) {
            this.Subtitle.UpdateLabel(SubtitleType.Chasing, 3, 5f);
          } else if (this.StudentID == 89) {
            this.Subtitle.UpdateLabel(SubtitleType.Chasing, 4, 5f);
          }
          this.Pathfinding.target = this.Yandere.transform;
          this.Pathfinding.speed = 7.5f;
          this.StudentManager.Portal.SetActive(false);
          this.Yandere.Chased = true;
          this.TargetDistance = 1f;
          this.StudentManager.UpdateStudents();
          this.Routine = false;
          this.Fleeing = true;
          this.Halt = true;
        }
      } else {
        this.Persona = PersonaType.TeachersPet;
        this.PersonaReaction();
      }
    } else if (this.Persona == PersonaType.Strict) {
      if (this.Yandere.Pursuer == this) {
        Debug.Log("This teacher is now pursuing Yandere-chan.");
      }
      if (this.WitnessedMurder) {
        if (this.Yandere.Pursuer == this) {
          Debug.Log("A teacher is now reacting to the sight of murder.");
          this.Subtitle.UpdateLabel(SubtitleType.TeacherMurderReaction, 3, 3f);
          this.Pathfinding.target = this.Yandere.transform;
          this.Pathfinding.speed = 7.5f;
          this.StudentManager.Portal.SetActive(false);
          this.Yandere.Chased = true;
          this.TargetDistance = 0.5f;
          this.StudentManager.UpdateStudents();
          base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
          this.Routine = false;
          this.Fleeing = true;
        } else if (!this.Yandere.Chased) {
          Debug.Log("A teacher has reached ChaseYandere through PersonaReaction.");
          this.ChaseYandere();
        }
      } else if (this.WitnessedCorpse) {
        Debug.Log("A teacher is now reacting to the sight of a corpse.");
        if (this.ReportPhase == 0) {
          this.Subtitle.UpdateLabel(SubtitleType.TeacherCorpseReaction, 1, 3f);
        }
        this.Pathfinding.target = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(this.Corpse.AllColliders[0].transform.position.x, base.transform.position.y, this.Corpse.AllColliders[0].transform.position.z), Quaternion.identity).transform;
        this.TargetDistance = 1f;
        this.ReportPhase = 2;
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.1f, base.transform.position.z);
        this.Routine = false;
        this.Fleeing = true;
      }
    }
  }

  // Token: 0x06000836 RID: 2102 RVA: 0x0008E0F4 File Offset: 0x0008C4F4
  private void BeginStruggle() {
    Debug.Log("My name is " + this.Name + " and now I am fighting Yandere-chan.");
    if (this.Yandere.Dragging) {
      this.Yandere.Ragdoll.GetComponent<RagdollScript>().StopDragging();
    }
    if (this.Yandere.Armed) {
      this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
    this.Yandere.StruggleBar.Strength = (float)this.Strength;
    this.Yandere.StruggleBar.Struggling = true;
    this.Yandere.StruggleBar.Student = this;
    this.Yandere.StruggleBar.gameObject.SetActive(true);
    this.CharacterAnimation.CrossFade(this.StruggleAnim);
    this.ShoulderCamera.LastPosition = this.ShoulderCamera.transform.position;
    this.ShoulderCamera.Struggle = true;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Obstacle.enabled = true;
    this.Struggling = true;
    this.Alarmed = false;
    this.Halt = true;
    if (!this.Teacher) {
      this.Yandere.CharacterAnimation["f02_struggleA_00"].time = 0f;
    } else {
      this.Yandere.CharacterAnimation["f02_teacherStruggleA_00"].time = 0f;
      base.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    if (this.Yandere.Aiming) {
      this.Yandere.StopAiming();
    }
    this.Yandere.StopLaughing();
    this.Yandere.TargetStudent = this;
    this.Yandere.Obscurance.enabled = false;
    this.Yandere.YandereVision = false;
    this.Yandere.NearSenpai = false;
    this.Yandere.Struggling = true;
    this.Yandere.CanMove = false;
    this.Yandere.EmptyHands();
    this.Yandere.MyController.enabled = false;
    this.Yandere.RPGCamera.enabled = false;
    this.MyController.radius = 0f;
    this.TargetDistance = 100f;
    this.AlarmTimer = 0f;
    this.SpawnAlarmDisc();
  }

  // Token: 0x06000837 RID: 2103 RVA: 0x0008E374 File Offset: 0x0008C774
  public void GetDestinations() {
    if (!this.Teacher) {
      this.MyLocker = this.StudentManager.LockerPositions[this.StudentID];
    }
    if (this.Slave) {
      foreach (ScheduleBlock scheduleBlock in this.ScheduleBlocks) {
        scheduleBlock.destination = "Slave";
        scheduleBlock.action = "Slave";
      }
    }
    this.ID = 1;
    while (this.ID < this.JSON.Students[this.StudentID].ScheduleBlocks.Length) {
      ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[this.ID];
      if (scheduleBlock2.destination == "Locker") {
        this.Destinations[this.ID] = this.MyLocker;
      } else if (scheduleBlock2.destination == "Seat") {
        this.Destinations[this.ID] = this.Seat;
      } else if (scheduleBlock2.destination == "Podium") {
        this.Destinations[this.ID] = this.StudentManager.Podiums.List[this.Class];
      } else if (scheduleBlock2.destination == "Exit") {
        this.Destinations[this.ID] = this.StudentManager.Hangouts.List[0];
      } else if (scheduleBlock2.destination == "Hangout") {
        this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
      } else if (scheduleBlock2.destination == "LunchSpot") {
        this.Destinations[this.ID] = this.StudentManager.LunchSpots.List[this.StudentID];
      } else if (scheduleBlock2.destination == "Slave") {
        this.Destinations[this.ID] = this.StudentManager.SlaveSpot;
      } else if (scheduleBlock2.destination == "Patrol") {
        this.Destinations[this.ID] = this.StudentManager.Patrols.List[this.StudentID].GetChild(0);
      } else if (scheduleBlock2.destination == "Search Patrol") {
        this.Destinations[this.ID] = this.StudentManager.SearchPatrols.List[this.StudentID].GetChild(0);
      } else if (scheduleBlock2.destination == "Mourn") {
        this.Destinations[this.ID] = this.StudentManager.MournSpot;
      } else if (scheduleBlock2.destination == "Clean") {
        this.Destinations[this.ID] = this.CleaningSpot.GetChild(0);
      } else if (scheduleBlock2.destination == "Cuddle") {
        if (!this.Male) {
          this.Destinations[this.ID] = this.StudentManager.FemaleCoupleSpot;
        } else {
          this.Destinations[this.ID] = this.StudentManager.MaleCoupleSpot;
        }
      } else if (scheduleBlock2.destination == "Stalk") {
        if (!this.Male) {
          this.Destinations[this.ID] = this.StudentManager.FemaleStalkSpot;
        } else {
          this.Destinations[this.ID] = this.StudentManager.MaleStalkSpot;
        }
      } else if (scheduleBlock2.destination == "Club") {
        if (this.Club > ClubType.None) {
          this.Destinations[this.ID] = this.StudentManager.Clubs.List[this.StudentID];
        } else {
          this.Destinations[this.ID] = this.StudentManager.Hangouts.List[this.StudentID];
        }
      }
      if (scheduleBlock2.action == "Stand") {
        this.Actions[this.ID] = StudentActionType.AtLocker;
      } else if (scheduleBlock2.action == "Socialize") {
        this.Actions[this.ID] = StudentActionType.Socializing;
      } else if (scheduleBlock2.action == "Game") {
        this.Actions[this.ID] = StudentActionType.Gaming;
      } else if (scheduleBlock2.action == "Slave") {
        this.Actions[this.ID] = StudentActionType.Slave;
      } else if (scheduleBlock2.action == "Relax") {
        this.Actions[this.ID] = StudentActionType.Relax;
      } else if (scheduleBlock2.action == "Sit") {
        this.Actions[this.ID] = StudentActionType.SitAndTakeNotes;
      } else if (scheduleBlock2.action == "Stalk") {
        this.Actions[this.ID] = StudentActionType.Stalk;
      } else if (scheduleBlock2.action == "SocialSit") {
        this.Actions[this.ID] = StudentActionType.SitAndSocialize;
      } else if (scheduleBlock2.action == "Eat") {
        this.Actions[this.ID] = StudentActionType.SitAndEatBento;
      } else if (scheduleBlock2.action == "Shoes") {
        this.Actions[this.ID] = StudentActionType.ChangeShoes;
      } else if (scheduleBlock2.action == "Grade") {
        this.Actions[this.ID] = StudentActionType.GradePapers;
      } else if (scheduleBlock2.action == "Patrol") {
        this.Actions[this.ID] = StudentActionType.Patrol;
      } else if (scheduleBlock2.destination == "Search Patrol") {
        this.Actions[this.ID] = StudentActionType.SearchPatrol;
      } else if (scheduleBlock2.action == "Read") {
        this.Actions[this.ID] = StudentActionType.Read;
      } else if (scheduleBlock2.action == "Text") {
        this.Actions[this.ID] = StudentActionType.Texting;
      } else if (scheduleBlock2.action == "Mourn") {
        this.Actions[this.ID] = StudentActionType.Mourn;
      } else if (scheduleBlock2.action == "Cuddle") {
        this.Actions[this.ID] = StudentActionType.Cuddle;
      } else if (scheduleBlock2.action == "Teach") {
        this.Actions[this.ID] = StudentActionType.Teaching;
      } else if (scheduleBlock2.action == "Wait") {
        this.Actions[this.ID] = StudentActionType.Wait;
      } else if (scheduleBlock2.action == "Clean") {
        this.Actions[this.ID] = StudentActionType.Clean;
      } else if (scheduleBlock2.action == "Club") {
        if (this.Club > ClubType.None) {
          if (this.Club == ClubType.MartialArts) {
            this.Actions[this.ID] = StudentActionType.ClubAction;
          } else if (this.Club == ClubType.Occult) {
            if (this.StudentID == 26) {
              this.Actions[this.ID] = StudentActionType.ClubAction;
            } else {
              this.Actions[this.ID] = StudentActionType.Read;
            }
          }
        } else {
          this.Actions[this.ID] = StudentActionType.Socializing;
        }
      }
      this.ID++;
    }
    if (this.StudentID == 7 && (float)StudentGlobals.GetStudentReputation(7) < -33.33333f) {
      this.Destinations[2] = this.StudentManager.ShameSpot;
      this.Destinations[4] = this.StudentManager.ShameSpot;
      this.Actions[2] = StudentActionType.Shamed;
      this.Actions[4] = StudentActionType.Shamed;
    }
    if (this.StudentID == 26 && ClubGlobals.GetClubClosed(ClubType.Occult) && StudentGlobals.GetStudentDead(17) && StudentGlobals.GetStudentDead(18)) {
      this.Destinations[2] = this.StudentManager.Hangouts.List[this.StudentID];
      this.Actions[2] = StudentActionType.Socializing;
    }
    if (this.StudentID == 32 && StudentGlobals.GetStudentBroken(32)) {
      this.Destinations[2] = this.StudentManager.BrokenSpot;
      this.Destinations[4] = this.StudentManager.BrokenSpot;
      this.Actions[2] = StudentActionType.Shamed;
      this.Actions[4] = StudentActionType.Shamed;
    }
  }

  // Token: 0x06000838 RID: 2104 RVA: 0x0008EC78 File Offset: 0x0008D078
  private void UpdateOutlines() {
    this.ID = 0;
    while (this.ID < this.Outlines.Length) {
      this.Outlines[this.ID].color = new Color(1f, 0.5f, 0f, 1f);
      this.Outlines[this.ID].enabled = true;
      this.ID++;
    }
  }

  // Token: 0x06000839 RID: 2105 RVA: 0x0008ECF0 File Offset: 0x0008D0F0
  private void PickRandomAnim() {
    this.RandomAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
    if (this.Actions[this.Phase] == StudentActionType.Socializing && this.DistanceToPlayer < 3f) {
      if (!ConversationGlobals.GetTopicDiscovered(11)) {
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
        ConversationGlobals.SetTopicDiscovered(11, true);
      }
      if (!ConversationGlobals.GetTopicLearnedByStudent(11, this.StudentID)) {
        this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
        ConversationGlobals.SetTopicLearnedByStudent(11, this.StudentID, true);
      }
    }
  }

  // Token: 0x0600083A RID: 2106 RVA: 0x0008ED94 File Offset: 0x0008D194
  private void BecomeTeacher() {
    base.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    this.StudentManager.Teachers[this.Class] = this;
    this.SkirtCollider.gameObject.SetActive(false);
    this.LowPoly.MyMesh = this.LowPoly.TeacherMesh;
    this.PantyCollider.enabled = false;
    if (this.Class != 1) {
      this.GradingPaper = this.StudentManager.FacultyDesks[this.Class];
      this.GradingPaper.LeftHand = this.LeftHand.parent;
      this.GradingPaper.Character = this.Character;
      this.GradingPaper.Teacher = this;
    }
    if (this.Class > 1) {
      this.VisionDistance = 12f * this.Paranoia;
      base.name = "Teacher_" + this.Class.ToString();
    } else if (this.Class == 1) {
      this.VisionDistance = 12f * this.Paranoia;
      this.PatrolAnim = "f02_idle_00";
      base.name = "Nurse";
    } else {
      this.VisionDistance = 16f * this.Paranoia;
      this.PatrolAnim = "f02_stretch_00";
      this.IdleAnim = "f02_tsunIdle_00";
      base.name = "Coach";
    }
    this.StruggleAnim = "f02_teacherStruggleB_00";
    this.StruggleWonAnim = "f02_teacherStruggleWinB_00";
    this.StruggleLostAnim = "f02_teacherStruggleLoseB_00";
    this.OriginallyTeacher = true;
    this.Spawned = true;
    this.Teacher = true;
  }

  // Token: 0x0600083B RID: 2107 RVA: 0x0008EF44 File Offset: 0x0008D344
  public void RemoveShoes() {
    if (this.Schoolwear == 1) {
      this.MyRenderer.materials[0].mainTexture = this.SocksTextures[StudentGlobals.FemaleUniform];
      this.MyRenderer.materials[1].mainTexture = this.SocksTextures[StudentGlobals.FemaleUniform];
    } else if (this.Schoolwear == 3) {
      this.MyRenderer.materials[0].mainTexture = this.SocksTextures[0];
      this.MyRenderer.materials[1].mainTexture = this.SocksTextures[0];
    }
  }

  // Token: 0x0600083C RID: 2108 RVA: 0x0008EFE0 File Offset: 0x0008D3E0
  public void BecomeRagdoll() {
    if (!this.Ragdoll.enabled) {
      if (this.Club == ClubType.Council) {
        this.Police.CouncilDeath = true;
      }
      ParticleSystem.EmissionModule emission = this.Hearts.emission;
      if (this.Following) {
        emission.enabled = false;
        this.Yandere.Followers--;
        this.Following = false;
      }
      if (this == this.StudentManager.Reporter) {
        this.StudentManager.Reporter = null;
      }
      if (this.Pushed) {
        this.Police.SuicideStudent = base.gameObject;
        this.Police.SuicideScene = true;
        this.Ragdoll.Suicide = true;
        this.Police.Suicide = true;
      }
      if (!this.Tranquil) {
        StudentGlobals.SetStudentDying(this.StudentID, true);
        if (!this.Ragdoll.Burning && !this.Ragdoll.Disturbing) {
          this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
          this.Police.Corpses++;
        }
      }
      if (!this.Male) {
        this.LiquidProjector.ignoreLayers = -2049;
        this.RightHandCollider.enabled = false;
        this.LeftHandCollider.enabled = false;
        this.PantyCollider.enabled = false;
        this.SkirtCollider.gameObject.SetActive(false);
      }
      this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
      this.Ragdoll.AllColliders[10].isTrigger = false;
      this.NotFaceCollider.enabled = false;
      this.FaceCollider.enabled = false;
      this.MyController.enabled = false;
      emission.enabled = false;
      this.SpeechLines.Stop();
      if (this.MyRenderer.enabled) {
        this.MyRenderer.updateWhenOffscreen = true;
      }
      this.Pathfinding.enabled = false;
      this.HipCollider.enabled = true;
      base.enabled = false;
      this.UnWet();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.Ragdoll.CharacterAnimation = this.CharacterAnimation;
      this.Ragdoll.DetectionMarker = this.DetectionMarker;
      this.Ragdoll.RightEyeOrigin = this.RightEyeOrigin;
      this.Ragdoll.LeftEyeOrigin = this.LeftEyeOrigin;
      this.Ragdoll.Electrocuted = this.Electrocuted;
      this.Ragdoll.BreastSize = this.BreastSize;
      this.Ragdoll.EyeShrink = this.EyeShrink;
      this.Ragdoll.StudentID = this.StudentID;
      this.Ragdoll.Tranquil = this.Tranquil;
      this.Ragdoll.Burning = this.Burning;
      this.Ragdoll.Drowned = this.Drowned;
      this.Ragdoll.Yandere = this.Yandere;
      this.Ragdoll.Police = this.Police;
      this.Ragdoll.Pushed = this.Pushed;
      this.Ragdoll.Male = this.Male;
      this.Police.Deaths++;
      this.Ragdoll.enabled = true;
      this.Reputation.PendingRep -= this.PendingRep;
      if (this.WitnessedMurder && this.Persona != PersonaType.Evil) {
        this.Police.Witnesses--;
      }
      this.UpdateOutlines();
      if (this.DetectionMarker != null) {
        this.DetectionMarker.Tex.enabled = false;
      }
      GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
      base.tag = "Blood";
    }
  }

  // Token: 0x0600083D RID: 2109 RVA: 0x0008F3C4 File Offset: 0x0008D7C4
  public void GetWet() {
    this.LiquidProjector.enabled = true;
    if (this.Gas) {
      this.LiquidProjector.material.mainTexture = this.GasTexture;
    } else if (this.Bloody) {
      this.LiquidProjector.material.mainTexture = this.BloodTexture;
    } else {
      this.LiquidProjector.material.mainTexture = this.WaterTexture;
    }
    this.ID = 0;
    while (this.ID < this.LiquidEmitters.Length) {
      ParticleSystem particleSystem = this.LiquidEmitters[this.ID];
      particleSystem.gameObject.SetActive(true);
      ParticleSystem.MainModule main = particleSystem.main;
      if (this.Gas) {
        main.startColor = new Color(1f, 1f, 0f, 1f);
      } else if (this.Bloody) {
        main.startColor = new Color(1f, 0f, 0f, 1f);
      } else {
        main.startColor = new Color(0f, 1f, 1f, 1f);
      }
      this.ID++;
    }
    if (!this.Slave) {
      if (this.Yandere.Tripping && this.Yandere.Mask == null) {
        this.Witnessed = StudentWitnessType.Accident;
        this.Witness = true;
        this.RepLoss = 10f;
        this.RepDeduction = 0f;
        this.CalculateReputationPenalty();
        if (this.RepDeduction >= 0f) {
          this.RepLoss -= this.RepDeduction;
        }
        this.Reputation.PendingRep -= this.RepLoss * this.Paranoia;
        this.PendingRep -= this.RepLoss * this.Paranoia;
      }
      this.CharacterAnimation[this.SplashedAnim].speed = 1f;
      this.CharacterAnimation.CrossFade(this.SplashedAnim);
      this.Subtitle.UpdateLabel(this.SplashSubtitleType, 0, 1f);
      this.SpeechLines.Stop();
      this.Hearts.Stop();
      this.StopMeeting();
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      this.SplashTimer = 0f;
      this.SplashPhase = 1;
      this.BathePhase = 1;
      this.ForgetRadio();
      if (this.Distracting) {
        this.DistractionTarget.TargetedForDistraction = false;
        this.DistractionTarget.Distracted = false;
        this.Distracting = false;
        this.CanTalk = true;
      }
      this.Distracted = false;
      this.Splashed = true;
      this.Routine = false;
      this.Wet = true;
      if (this.Following) {
        this.Yandere.Followers--;
        this.Following = false;
      }
      this.SpawnAlarmDisc();
    }
  }

  // Token: 0x0600083E RID: 2110 RVA: 0x0008F6E4 File Offset: 0x0008DAE4
  public void UnWet() {
    this.ID = 0;
    while (this.ID < this.LiquidEmitters.Length) {
      this.LiquidEmitters[this.ID].gameObject.SetActive(false);
      this.ID++;
    }
  }

  // Token: 0x0600083F RID: 2111 RVA: 0x0008F738 File Offset: 0x0008DB38
  private void StopMeeting() {
    this.Prompt.Label[0].text = "     Talk";
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.StudentManager.OfferHelp.gameObject.SetActive(false);
    this.Drownable = false;
    this.Pushable = false;
    this.Meeting = false;
    this.MeetTimer = 0f;
    if (this.StudentID == 7) {
      this.StudentManager.LoveManager.RivalWaiting = false;
    }
  }

  // Token: 0x06000840 RID: 2112 RVA: 0x0008F7C8 File Offset: 0x0008DBC8
  public void Combust() {
    this.Police.CorpseList[this.Police.Corpses] = this.Ragdoll;
    this.Police.Corpses++;
    GameObjectUtils.SetLayerRecursively(base.gameObject, 11);
    base.tag = "Blood";
    this.Dying = true;
    this.SpawnAlarmDisc();
    this.Character.GetComponent<Animation>().CrossFade(this.BurningAnim);
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Ragdoll.Burning = true;
    this.WitnessedCorpse = false;
    this.Investigating = false;
    this.DiscCheck = false;
    this.WalkBack = false;
    this.Alarmed = false;
    this.CanTalk = false;
    this.Fleeing = false;
    this.Routine = false;
    this.Reacted = false;
    this.Burning = true;
    this.Wet = false;
    AudioSource component = base.GetComponent<AudioSource>();
    component.clip = this.BurningClip;
    component.Play();
    this.LiquidProjector.enabled = false;
    this.UnWet();
    if (this.Following) {
      this.Yandere.Followers--;
      this.Following = false;
    }
    this.ID = 0;
    while (this.ID < this.FireEmitters.Length) {
      this.FireEmitters[this.ID].gameObject.SetActive(true);
      this.ID++;
    }
    if (this.Attacked) {
      this.BurnTarget = this.Yandere.transform.position + this.Yandere.transform.forward;
      this.Attacked = false;
    }
  }

  // Token: 0x06000841 RID: 2113 RVA: 0x0008F984 File Offset: 0x0008DD84
  public void JojoReact() {
    UnityEngine.Object.Instantiate<GameObject>(this.JojoHitEffect, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
    if (!this.Dying) {
      this.Dying = true;
      this.SpawnAlarmDisc();
      this.Character.GetComponent<Animation>().CrossFade(this.JojoReactAnim);
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      this.WitnessedCorpse = false;
      this.Investigating = false;
      this.DiscCheck = false;
      this.WalkBack = false;
      this.Alarmed = false;
      this.CanTalk = false;
      this.Fleeing = false;
      this.Routine = false;
      this.Reacted = false;
      this.Wet = false;
      AudioSource component = base.GetComponent<AudioSource>();
      component.Play();
      if (this.Following) {
        this.Yandere.Followers--;
        this.Following = false;
      }
    }
  }

  // Token: 0x06000842 RID: 2114 RVA: 0x0008FA84 File Offset: 0x0008DE84
  private void Nude() {
    if (!this.Male) {
      this.PantyCollider.enabled = false;
      this.SkirtCollider.gameObject.SetActive(false);
    }
    this.MyRenderer.sharedMesh = this.BaldNudeMesh;
    if (!this.Male) {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
      this.MyRenderer.materials[0].mainTexture = this.Cosmetic.FaceTexture;
      this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
      this.Cosmetic.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
    } else {
      this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
      this.MyRenderer.materials[1].mainTexture = null;
      this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTextures[this.SkinColor];
    }
    this.Cosmetic.RemoveCensor();
    if (!this.AoT) {
      this.ID = 0;
      while (this.ID < this.CensorSteam.Length) {
        this.CensorSteam[this.ID].SetActive(true);
        this.ID++;
      }
    }
  }

  // Token: 0x06000843 RID: 2115 RVA: 0x0008FBF4 File Offset: 0x0008DFF4
  public void ChangeSchoolwear() {
    this.ID = 0;
    while (this.ID < this.CensorSteam.Length) {
      this.CensorSteam[this.ID].SetActive(false);
      this.ID++;
    }
    if (this.Schoolwear == 0) {
      this.Nude();
    } else if (this.Schoolwear == 1) {
      if (!this.Male) {
        this.Cosmetic.SetFemaleUniform();
        this.SkirtCollider.gameObject.SetActive(true);
        this.PantyCollider.enabled = true;
      } else {
        this.Cosmetic.SetMaleUniform();
      }
    } else if (this.Schoolwear == 2) {
      this.MyRenderer.sharedMesh = this.SchoolSwimsuit;
      this.MyRenderer.materials[0].mainTexture = this.SwimsuitTexture;
      this.MyRenderer.materials[1].mainTexture = this.SwimsuitTexture;
      this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
    } else if (this.Schoolwear == 3) {
      this.MyRenderer.sharedMesh = this.GymUniform;
      this.MyRenderer.materials[0].mainTexture = this.GymTexture;
      this.MyRenderer.materials[1].mainTexture = this.GymTexture;
      this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
    }
    if (!this.Male) {
      this.Cosmetic.Stockings = ((this.Schoolwear != 1) ? string.Empty : this.Cosmetic.OriginalStockings);
      base.StartCoroutine(this.Cosmetic.PutOnStockings());
      if (this.StudentManager.Censor) {
        this.Cosmetic.CensorPanties();
      }
    }
    while (this.ID < this.Outlines.Length) {
      if (this.Outlines[this.ID].h != null) {
        this.Outlines[this.ID].h.ReinitMaterials();
      }
      this.ID++;
    }
  }

  // Token: 0x06000844 RID: 2116 RVA: 0x0008FE44 File Offset: 0x0008E244
  public void AttackOnTitan() {
    this.CharacterAnimation.CrossFade(this.WalkAnim);
    this.Phone.SetActive(false);
    this.OnPhone = false;
    this.AoT = true;
    this.MyController.center = new Vector3(this.MyController.center.x, 0.0825f, this.MyController.center.z);
    this.MyController.radius = 0.015f;
    this.MyController.height = 0.15f;
    if (!this.Male) {
      this.Cosmetic.FaceTexture = this.TitanFaceTexture;
    } else {
      this.Cosmetic.FaceTextures[this.SkinColor] = this.TitanFaceTexture;
    }
    this.NudeTexture = this.TitanBodyTexture;
    this.Nude();
    this.ID = 0;
    while (this.ID < this.Outlines.Length) {
      OutlineScript outlineScript = this.Outlines[this.ID];
      if (outlineScript.h == null) {
        outlineScript.Awake();
      }
      outlineScript.h.ReinitMaterials();
      this.ID++;
    }
    if (!this.Male && !this.Teacher) {
      this.PantyCollider.enabled = false;
      this.SkirtCollider.gameObject.SetActive(false);
    }
  }

  // Token: 0x06000845 RID: 2117 RVA: 0x0008FFB4 File Offset: 0x0008E3B4
  public void Spook() {
    if (!this.Male) {
      this.RightEye.gameObject.SetActive(false);
      this.LeftEye.gameObject.SetActive(false);
      this.MyRenderer.enabled = false;
      this.ID = 0;
      while (this.ID < this.Bones.Length) {
        this.Bones[this.ID].SetActive(true);
        this.ID++;
      }
    }
  }

  // Token: 0x06000846 RID: 2118 RVA: 0x0009003C File Offset: 0x0008E43C
  private void Unspook() {
    this.MyRenderer.enabled = true;
    this.ID = 0;
    while (this.ID < this.Bones.Length) {
      this.Bones[this.ID].SetActive(false);
      this.ID++;
    }
  }

  // Token: 0x06000847 RID: 2119 RVA: 0x00090098 File Offset: 0x0008E498
  private void GoChange() {
    this.CurrentDestination = this.StudentManager.StripSpot;
    this.Pathfinding.target = this.StudentManager.StripSpot;
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.Distracted = false;
  }

  // Token: 0x06000848 RID: 2120 RVA: 0x000900EC File Offset: 0x0008E4EC
  public void SpawnAlarmDisc() {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position + Vector3.up, Quaternion.identity);
    gameObject.GetComponent<AlarmDiscScript>().Male = this.Male;
    gameObject.GetComponent<AlarmDiscScript>().Originator = this;
    if (this.Splashed) {
      gameObject.GetComponent<AlarmDiscScript>().Shocking = true;
      gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
    }
    if (this.Struggling) {
      gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
    }
    if (this.Dying && this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon.WeaponID == 7) {
      gameObject.GetComponent<AlarmDiscScript>().Long = true;
    }
  }

  // Token: 0x06000849 RID: 2121 RVA: 0x000901B4 File Offset: 0x0008E5B4
  public void ChangeClubwear() {
    if (!this.ClubAttire) {
      this.Cosmetic.RemoveCensor();
      this.ClubAttire = true;
      if (this.Club == ClubType.MartialArts) {
        this.MyRenderer.sharedMesh = this.JudoGiMesh;
        if (!this.Male) {
          this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
          this.MyRenderer.materials[1].mainTexture = this.JudoGiTexture;
          this.MyRenderer.materials[2].mainTexture = this.Cosmetic.FaceTexture;
          this.SkirtCollider.gameObject.SetActive(false);
          this.PantyCollider.enabled = false;
        } else {
          this.MyRenderer.materials[0].mainTexture = this.JudoGiTexture;
          this.MyRenderer.materials[1].mainTexture = this.Cosmetic.FaceTexture;
          this.MyRenderer.materials[2].mainTexture = this.JudoGiTexture;
        }
      }
      if (this.StudentID == 21) {
        this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.01f);
        this.Armband.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
      }
    } else {
      this.ClubAttire = false;
      this.ChangeSchoolwear();
      if (this.StudentID == 21) {
        this.Armband.transform.localPosition = new Vector3(this.Armband.transform.localPosition.x, this.Armband.transform.localPosition.y, 0.012f);
        this.Armband.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
      }
    }
  }

  // Token: 0x0600084A RID: 2122 RVA: 0x000903CC File Offset: 0x0008E7CC
  public void AttachRiggedAccessory() {
    this.RiggedAccessory.GetComponent<RiggedAccessoryAttacher>().ID = this.StudentID;
    if (this.Cosmetic.Accessory > 0) {
      this.Cosmetic.FemaleAccessories[this.Cosmetic.Accessory].SetActive(false);
    }
    if (this.StudentID == 26) {
      this.MyRenderer.sharedMesh = this.NoArmsNoTorso;
    } else if (this.Cosmetic.EyeType == "Gentle") {
      this.MyRenderer.sharedMesh = null;
    }
    this.RiggedAccessory.SetActive(true);
  }

  // Token: 0x0600084B RID: 2123 RVA: 0x00090474 File Offset: 0x0008E874
  public void CameraReact() {
    this.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Obstacle.enabled = true;
    this.CameraReacting = true;
    this.CameraReactPhase = 1;
    this.SpeechLines.Stop();
    this.OccultBook.SetActive(false);
    this.SmartPhone.SetActive(false);
    this.Phone.SetActive(false);
    this.Pen.SetActive(false);
    this.Routine = false;
    if (!this.Yandere.ClubAccessories[7].activeInHierarchy) {
      this.CharacterAnimation.CrossFade(this.CameraAnims[1]);
    } else {
      this.CharacterAnimation.CrossFade(this.IdleAnim);
    }
  }

  // Token: 0x0600084C RID: 2124 RVA: 0x00090544 File Offset: 0x0008E944
  private void LookForYandere() {
    if (!this.Yandere.Chased && this.CanSeeObject(this.Yandere.gameObject, this.Yandere.HeadPosition)) {
      this.ReportPhase++;
    }
  }

  // Token: 0x0600084D RID: 2125 RVA: 0x00090590 File Offset: 0x0008E990
  public void UpdatePerception() {
    if (ClubGlobals.Club == ClubType.Occult || PlayerGlobals.StealthBonus > 0) {
      this.Perception = 0.5f;
    } else {
      this.Perception = 1f;
    }
  }

  // Token: 0x0600084E RID: 2126 RVA: 0x000905C4 File Offset: 0x0008E9C4
  public void StopInvestigating() {
    UnityEngine.Object.Destroy(this.Giggle);
    this.CurrentDestination = this.Destinations[this.Phase];
    this.Pathfinding.target = this.Destinations[this.Phase];
    this.InvestigationTimer = 0f;
    this.InvestigationPhase = 0;
    this.YandereInnocent = false;
    this.Investigating = false;
    this.DiscCheck = false;
    this.Routine = true;
  }

  // Token: 0x170000EE RID: 238
  // (get) Token: 0x0600084F RID: 2127 RVA: 0x00090635 File Offset: 0x0008EA35
  public bool InCouple {
    get {
      return this.CoupleID > 0;
    }
  }

  // Token: 0x06000850 RID: 2128 RVA: 0x00090640 File Offset: 0x0008EA40
  private bool LovedOneIsTargeted(int yandereTargetID) {
    bool flag = this.InCouple && this.CoupleID == yandereTargetID;
    bool flag2 = this.StudentID == 14 && yandereTargetID == 15;
    bool flag3 = this.StudentID == 15 && yandereTargetID == 14;
    bool flag4 = this.StudentID == 17 && yandereTargetID == 18;
    bool flag5 = this.StudentID == 18 && yandereTargetID == 17;
    bool flag6 = this.StudentID == 6 && yandereTargetID == 7;
    bool flag7 = this.StudentID == 7 && yandereTargetID == 6;
    return flag || flag2 || flag3 || flag4 || flag5 || flag6 || flag7;
  }

  // Token: 0x06000851 RID: 2129 RVA: 0x00090714 File Offset: 0x0008EB14
  private void Pose() {
    this.StudentManager.PoseMode.Panel.enabled = true;
    this.StudentManager.PoseMode.Student = this;
    this.StudentManager.PoseMode.UpdateLabels();
    this.StudentManager.PoseMode.Show = true;
    this.DialogueWheel.PromptBar.ClearButtons();
    this.DialogueWheel.PromptBar.Label[0].text = "Confirm";
    this.DialogueWheel.PromptBar.Label[1].text = "Back";
    this.DialogueWheel.PromptBar.Label[4].text = "Change";
    this.DialogueWheel.PromptBar.Label[5].text = "Increase/Decrease";
    this.DialogueWheel.PromptBar.UpdateButtons();
    this.DialogueWheel.PromptBar.Show = true;
    this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
    this.Yandere.CanMove = false;
  }

  // Token: 0x06000852 RID: 2130 RVA: 0x00090838 File Offset: 0x0008EC38
  public void DisableEffects() {
    this.LiquidProjector.enabled = false;
    this.ElectroSteam[0].SetActive(false);
    this.ElectroSteam[1].SetActive(false);
    this.ElectroSteam[2].SetActive(false);
    this.ElectroSteam[3].SetActive(false);
    this.CensorSteam[0].SetActive(false);
    this.CensorSteam[1].SetActive(false);
    this.CensorSteam[2].SetActive(false);
    this.CensorSteam[3].SetActive(false);
    foreach (ParticleSystem particleSystem in this.LiquidEmitters) {
      particleSystem.gameObject.SetActive(false);
    }
    foreach (ParticleSystem particleSystem2 in this.FireEmitters) {
      particleSystem2.gameObject.SetActive(false);
    }
    this.ID = 0;
    while (this.ID < this.Bones.Length) {
      this.Bones[this.ID].SetActive(false);
      this.ID++;
    }
    this.SmartPhone.SetActive(false);
    this.Note.SetActive(false);
    if (!this.Slave) {
      this.RightEmptyEye.SetActive(false);
      this.LeftEmptyEye.SetActive(false);
      UnityEngine.Object.Destroy(this.Broken);
    }
  }

  // Token: 0x06000853 RID: 2131 RVA: 0x000909A8 File Offset: 0x0008EDA8
  public void DetermineSenpaiReaction() {
    Debug.Log("We are now determining Senpai's reaction to Yandere-chan's behavior.");
    if (this.Witnessed == StudentWitnessType.WeaponAndBloodAndInsanity) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    } else if (this.Witnessed == StudentWitnessType.WeaponAndBlood) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
    } else if (this.Witnessed == StudentWitnessType.WeaponAndInsanity) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    } else if (this.Witnessed == StudentWitnessType.BloodAndInsanity) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    } else if (this.Witnessed == StudentWitnessType.Weapon) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiWeaponReaction, 1, 4.5f);
    } else if (this.Witnessed == StudentWitnessType.Blood) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiBloodReaction, 1, 4.5f);
    } else if (this.Witnessed == StudentWitnessType.Insanity) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiInsanityReaction, 1, 4.5f);
    } else if (this.Witnessed == StudentWitnessType.Lewd) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiLewdReaction, 1, 4.5f);
    } else if (this.GameOverCause == GameOverType.Stalking) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiStalkingReaction, this.Concern, 4.5f);
    } else if (this.GameOverCause == GameOverType.Murder) {
      this.Subtitle.UpdateLabel(SubtitleType.SenpaiMurderReaction, this.MurderReaction, 4.5f);
    }
  }

  // Token: 0x06000854 RID: 2132 RVA: 0x00090B30 File Offset: 0x0008EF30
  public void ForgetRadio() {
    this.TurnOffRadio = false;
    this.RadioTimer = 0f;
    this.RadioPhase = 1;
    this.Routine = true;
    this.Radio = null;
  }

  // Token: 0x06000855 RID: 2133 RVA: 0x00090B5C File Offset: 0x0008EF5C
  public void RealizePhoneIsMissing() {
    ScheduleBlock scheduleBlock = this.ScheduleBlocks[2];
    scheduleBlock.destination = "Search Patrol";
    scheduleBlock.action = "Search Patrol";
    this.GetDestinations();
    ScheduleBlock scheduleBlock2 = this.ScheduleBlocks[4];
    scheduleBlock2.destination = "Search Patrol";
    scheduleBlock2.action = "Search Patrol";
    this.GetDestinations();
    ScheduleBlock scheduleBlock3 = this.ScheduleBlocks[7];
    scheduleBlock3.destination = "Search Patrol";
    scheduleBlock3.action = "Search Patrol";
    this.GetDestinations();
    this.Phoneless = true;
  }

  // Token: 0x06000856 RID: 2134 RVA: 0x00090BE0 File Offset: 0x0008EFE0
  public void TeleportToDestination() {
    if (this.Clock.HourTime >= this.ScheduleBlocks[this.Phase].time) {
      this.Phase++;
      this.CurrentDestination = this.Destinations[this.Phase];
      this.Pathfinding.target = this.Destinations[this.Phase];
      base.transform.position = this.CurrentDestination.position;
    }
  }

  // Token: 0x06000857 RID: 2135 RVA: 0x00090C60 File Offset: 0x0008F060
  public void GoCommitMurder() {
    this.StudentManager.MurderTakingPlace = true;
    this.Yandere.EquippedWeapon.transform.parent = this.HipCollider.transform;
    this.Yandere.EquippedWeapon.transform.localPosition = Vector3.zero;
    this.Yandere.EquippedWeapon.transform.localScale = Vector3.zero;
    this.MyWeapon = this.Yandere.EquippedWeapon;
    this.MyWeapon.FingerprintID = this.StudentID;
    this.Yandere.EquippedWeapon = null;
    this.Yandere.Equipped = 0;
    this.StudentManager.UpdateStudents();
    this.Yandere.WeaponManager.UpdateLabels();
    this.Yandere.WeaponMenu.UpdateSprites();
    this.Yandere.WeaponWarning = false;
    this.CharacterAnimation.CrossFade("f02_brokenStandUp_00");
    if (this.HuntTarget != this) {
      this.DistanceToDestination = 100f;
      this.Broken.Hunting = true;
      this.TargetDistance = 1f;
      this.Routine = false;
      this.Hunting = true;
    } else {
      this.Broken.Done = true;
      this.Routine = false;
      this.Suicide = true;
    }
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }

  // Token: 0x06000858 RID: 2136 RVA: 0x00090DC8 File Offset: 0x0008F1C8
  public void Shove() {
    if (!this.Yandere.Shoved && !this.Dying && !this.Yandere.Egg) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.StudentID == 86) {
        this.Subtitle.UpdateLabel(SubtitleType.Shoving, 1, 5f);
      } else if (this.StudentID == 87) {
        this.Subtitle.UpdateLabel(SubtitleType.Shoving, 2, 5f);
      } else if (this.StudentID == 88) {
        this.Subtitle.UpdateLabel(SubtitleType.Shoving, 3, 5f);
      } else if (this.StudentID == 89) {
        this.Subtitle.UpdateLabel(SubtitleType.Shoving, 4, 5f);
      }
      if (this.Yandere.Aiming) {
        this.Yandere.StopAiming();
      }
      if (this.Yandere.Laughing) {
        this.Yandere.StopLaughing();
      }
      base.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
      this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
      this.CharacterAnimation[this.ShoveAnim].time = 0f;
      this.CharacterAnimation.CrossFade(this.ShoveAnim);
      this.FocusOnYandere = false;
      this.Alarmed = false;
      this.Routine = false;
      this.Shoving = true;
      this.Patience--;
      if (this.Patience < 1) {
        this.Yandere.CannotRecover = true;
      }
      this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
      this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
      this.Yandere.YandereVision = false;
      this.Yandere.NearSenpai = false;
      this.Yandere.Punching = false;
      this.Yandere.CanMove = false;
      this.Yandere.Shoved = true;
      this.Yandere.ShoveSpeed = 2f;
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
    }
  }

  // Token: 0x06000859 RID: 2137 RVA: 0x000910CC File Offset: 0x0008F4CC
  public void Spray() {
    if (!this.Yandere.Sprayed && !this.Dying && !this.Yandere.Egg) {
      AudioSource.PlayClipAtPoint(this.PepperSpraySFX, base.transform.position);
      if (this.StudentID == 86) {
        this.Subtitle.UpdateLabel(SubtitleType.Spraying, 1, 5f);
      } else if (this.StudentID == 87) {
        this.Subtitle.UpdateLabel(SubtitleType.Spraying, 2, 5f);
      } else if (this.StudentID == 88) {
        this.Subtitle.UpdateLabel(SubtitleType.Spraying, 3, 5f);
      } else if (this.StudentID == 89) {
        this.Subtitle.UpdateLabel(SubtitleType.Spraying, 4, 5f);
      }
      if (this.Yandere.Aiming) {
        this.Yandere.StopAiming();
      }
      if (this.Yandere.Laughing) {
        this.Yandere.StopLaughing();
      }
      base.transform.rotation = Quaternion.LookRotation(new Vector3(this.Yandere.Hips.transform.position.x, base.transform.position.y, this.Yandere.Hips.transform.position.z) - base.transform.position);
      this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.Hips.transform.position.x, this.Yandere.transform.position.y, this.Hips.transform.position.z) - this.Yandere.transform.position);
      this.CharacterAnimation.CrossFade(this.SprayAnim);
      this.PepperSpray.SetActive(true);
      this.Distracted = true;
      this.Spraying = true;
      this.Alarmed = false;
      this.Routine = false;
      this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
      this.Yandere.YandereVision = false;
      this.Yandere.NearSenpai = false;
      this.Yandere.FollowHips = true;
      this.Yandere.Punching = false;
      this.Yandere.CanMove = false;
      this.Yandere.Sprayed = true;
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
      this.StudentManager.YandereDying = true;
      this.StudentManager.StopMoving();
      this.Yandere.Blur.blurIterations = 1;
      this.Yandere.Jukebox.Volume = 0f;
    }
  }

  // Token: 0x0600085A RID: 2138 RVA: 0x000913C4 File Offset: 0x0008F7C4
  private void DetermineCorpseLocation() {
    if (this.StudentManager.CorpseLocation.position == Vector3.zero) {
      this.StudentManager.CorpseLocation.position = this.StudentManager.Reporter.LastKnownCorpse;
      this.StudentManager.LowerCorpsePosition();
      this.StudentManager.CorpseGuardLocation[1].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, 1f);
      this.LookAway(this.StudentManager.CorpseGuardLocation[1], this.StudentManager.CorpseLocation);
      this.StudentManager.CorpseGuardLocation[2].position = this.StudentManager.CorpseLocation.position + new Vector3(1f, 0f, 0f);
      this.LookAway(this.StudentManager.CorpseGuardLocation[2], this.StudentManager.CorpseLocation);
      this.StudentManager.CorpseGuardLocation[3].position = this.StudentManager.CorpseLocation.position + new Vector3(0f, 0f, -1f);
      this.LookAway(this.StudentManager.CorpseGuardLocation[3], this.StudentManager.CorpseLocation);
      this.StudentManager.CorpseGuardLocation[4].position = this.StudentManager.CorpseLocation.position + new Vector3(-1f, 0f, 0f);
      this.LookAway(this.StudentManager.CorpseGuardLocation[4], this.StudentManager.CorpseLocation);
    }
    if (this.Teacher) {
      Debug.Log("A teacher has witnessed a corpse, and they're going to try to stop 1 meter in front of the corpse.");
      this.StudentManager.CorpseLocation.LookAt(new Vector3(base.transform.position.x, this.StudentManager.CorpseLocation.position.y, base.transform.position.z));
      this.StudentManager.CorpseLocation.Translate(this.StudentManager.CorpseLocation.forward);
      this.StudentManager.LowerCorpsePosition();
    }
  }

  // Token: 0x0600085B RID: 2139 RVA: 0x00091614 File Offset: 0x0008FA14
  private void LookAway(Transform T1, Transform T2) {
    T1.LookAt(T2);
    float y = T1.eulerAngles.y + 180f;
    T1.eulerAngles = new Vector3(T1.eulerAngles.x, y, T1.eulerAngles.z);
  }

  // Token: 0x0600085C RID: 2140 RVA: 0x00091668 File Offset: 0x0008FA68
  public void TurnToStone() {
    this.Cosmetic.RightEyeRenderer.material.mainTexture = this.Yandere.Stone;
    this.Cosmetic.LeftEyeRenderer.material.mainTexture = this.Yandere.Stone;
    this.Cosmetic.HairRenderer.material.mainTexture = this.Yandere.Stone;
    this.Cosmetic.RightEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
    this.Cosmetic.LeftEyeRenderer.material.color = new Color(1f, 1f, 1f, 1f);
    this.Cosmetic.HairRenderer.material.color = new Color(1f, 1f, 1f, 1f);
    this.MyRenderer.materials[0].mainTexture = this.Yandere.Stone;
    this.MyRenderer.materials[1].mainTexture = this.Yandere.Stone;
    this.MyRenderer.materials[2].mainTexture = this.Yandere.Stone;
    if (this.Teacher && this.Cosmetic.TeacherAccessories[8].activeInHierarchy) {
      this.MyRenderer.materials[3].mainTexture = this.Yandere.Stone;
    }
    if (this.PickPocket != null) {
      this.PickPocket.enabled = false;
      this.PickPocket.Prompt.Hide();
      this.PickPocket.Prompt.enabled = false;
    }
    this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
    UnityEngine.Object.Destroy(this.DetectionMarker.gameObject);
    AudioSource.PlayClipAtPoint(this.Yandere.Petrify, base.transform.position + new Vector3(0f, 1f, 0f));
    UnityEngine.Object.Instantiate<GameObject>(this.Yandere.Pebbles, this.Hips.position, Quaternion.identity);
    this.Pathfinding.enabled = false;
    this.ShoeRemoval.enabled = false;
    this.CharacterAnimation.Stop();
    this.Prompt.enabled = false;
    this.SpeechLines.Stop();
    this.Prompt.Hide();
    base.enabled = false;
  }

  // Token: 0x0400155A RID: 5466
  public Quaternion targetRotation;

  // Token: 0x0400155B RID: 5467
  public DetectionMarkerScript DetectionMarker;

  // Token: 0x0400155C RID: 5468
  public ShoulderCameraScript ShoulderCamera;

  // Token: 0x0400155D RID: 5469
  public StudentManagerScript StudentManager;

  // Token: 0x0400155E RID: 5470
  public CameraEffectsScript CameraEffects;

  // Token: 0x0400155F RID: 5471
  public ChangingBoothScript ChangingBooth;

  // Token: 0x04001560 RID: 5472
  public DialogueWheelScript DialogueWheel;

  // Token: 0x04001561 RID: 5473
  public WitnessCameraScript WitnessCamera;

  // Token: 0x04001562 RID: 5474
  public StudentScript DistractionTarget;

  // Token: 0x04001563 RID: 5475
  public CookingEventScript CookingEvent;

  // Token: 0x04001564 RID: 5476
  public EventManagerScript EventManager;

  // Token: 0x04001565 RID: 5477
  public GradingPaperScript GradingPaper;

  // Token: 0x04001566 RID: 5478
  public ClubManagerScript ClubManager;

  // Token: 0x04001567 RID: 5479
  public LightSwitchScript LightSwitch;

  // Token: 0x04001568 RID: 5480
  public MovingEventScript MovingEvent;

  // Token: 0x04001569 RID: 5481
  public ShoeRemovalScript ShoeRemoval;

  // Token: 0x0400156A RID: 5482
  public StruggleBarScript StruggleBar;

  // Token: 0x0400156B RID: 5483
  public ToiletEventScript ToiletEvent;

  // Token: 0x0400156C RID: 5484
  public DynamicGridObstacle Obstacle;

  // Token: 0x0400156D RID: 5485
  public PhoneEventScript PhoneEvent;

  // Token: 0x0400156E RID: 5486
  public PickpocketScript PickPocket;

  // Token: 0x0400156F RID: 5487
  public ReputationScript Reputation;

  // Token: 0x04001570 RID: 5488
  public Renderer SmartPhoneScreen;

  // Token: 0x04001571 RID: 5489
  public StudentScript HuntTarget;

  // Token: 0x04001572 RID: 5490
  public StudentScript MyTeacher;

  // Token: 0x04001573 RID: 5491
  public BoneSetsScript BoneSets;

  // Token: 0x04001574 RID: 5492
  public CosmeticScript Cosmetic;

  // Token: 0x04001575 RID: 5493
  public SubtitleScript Subtitle;

  // Token: 0x04001576 RID: 5494
  public DynamicBone OsanaHairL;

  // Token: 0x04001577 RID: 5495
  public DynamicBone OsanaHairR;

  // Token: 0x04001578 RID: 5496
  public WeaponScript MyWeapon;

  // Token: 0x04001579 RID: 5497
  public StudentScript Partner;

  // Token: 0x0400157A RID: 5498
  public RagdollScript Ragdoll;

  // Token: 0x0400157B RID: 5499
  public YandereScript Yandere;

  // Token: 0x0400157C RID: 5500
  public BrokenScript Broken;

  // Token: 0x0400157D RID: 5501
  public RagdollScript Corpse;

  // Token: 0x0400157E RID: 5502
  public PoliceScript Police;

  // Token: 0x0400157F RID: 5503
  public PromptScript Prompt;

  // Token: 0x04001580 RID: 5504
  public AIPath Pathfinding;

  // Token: 0x04001581 RID: 5505
  public ClockScript Clock;

  // Token: 0x04001582 RID: 5506
  public RadioScript Radio;

  // Token: 0x04001583 RID: 5507
  public JsonScript JSON;

  // Token: 0x04001584 RID: 5508
  public Renderer Tears;

  // Token: 0x04001585 RID: 5509
  public Rigidbody MyRigidbody;

  // Token: 0x04001586 RID: 5510
  public Collider MyCollider;

  // Token: 0x04001587 RID: 5511
  public CharacterController MyController;

  // Token: 0x04001588 RID: 5512
  public Animation CharacterAnimation;

  // Token: 0x04001589 RID: 5513
  public Projector LiquidProjector;

  // Token: 0x0400158A RID: 5514
  public float VisionFOV;

  // Token: 0x0400158B RID: 5515
  public float VisionDistance;

  // Token: 0x0400158C RID: 5516
  public ParticleSystem PepperSprayEffect;

  // Token: 0x0400158D RID: 5517
  public ParticleSystem BloodFountain;

  // Token: 0x0400158E RID: 5518
  public ParticleSystem VomitEmitter;

  // Token: 0x0400158F RID: 5519
  public ParticleSystem SpeechLines;

  // Token: 0x04001590 RID: 5520
  public ParticleSystem ChalkDust;

  // Token: 0x04001591 RID: 5521
  public ParticleSystem Hearts;

  // Token: 0x04001592 RID: 5522
  public Texture KokonaPhoneTexture;

  // Token: 0x04001593 RID: 5523
  public Texture MidoriPhoneTexture;

  // Token: 0x04001594 RID: 5524
  public Texture OsanaPhoneTexture;

  // Token: 0x04001595 RID: 5525
  public Texture RedBookTexture;

  // Token: 0x04001596 RID: 5526
  public Texture BloodTexture;

  // Token: 0x04001597 RID: 5527
  public Texture WaterTexture;

  // Token: 0x04001598 RID: 5528
  public Texture GasTexture;

  // Token: 0x04001599 RID: 5529
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x0400159A RID: 5530
  public Renderer BookRenderer;

  // Token: 0x0400159B RID: 5531
  public Transform CurrentDestination;

  // Token: 0x0400159C RID: 5532
  public Transform TeacherTalkPoint;

  // Token: 0x0400159D RID: 5533
  public Transform LeftMiddleFinger;

  // Token: 0x0400159E RID: 5534
  public Transform CleaningSpot;

  // Token: 0x0400159F RID: 5535
  public Transform Distraction;

  // Token: 0x040015A0 RID: 5536
  public Transform ItemParent;

  // Token: 0x040015A1 RID: 5537
  public Transform MyReporter;

  // Token: 0x040015A2 RID: 5538
  public Transform WitnessPOV;

  // Token: 0x040015A3 RID: 5539
  public Transform RightDrill;

  // Token: 0x040015A4 RID: 5540
  public Transform LeftDrill;

  // Token: 0x040015A5 RID: 5541
  public Transform RightHand;

  // Token: 0x040015A6 RID: 5542
  public Transform LeftHand;

  // Token: 0x040015A7 RID: 5543
  public Transform MeetSpot;

  // Token: 0x040015A8 RID: 5544
  public Transform MyLocker;

  // Token: 0x040015A9 RID: 5545
  public Transform Eyes;

  // Token: 0x040015AA RID: 5546
  public Transform Head;

  // Token: 0x040015AB RID: 5547
  public Transform Hips;

  // Token: 0x040015AC RID: 5548
  public Transform Neck;

  // Token: 0x040015AD RID: 5549
  public Transform Seat;

  // Token: 0x040015AE RID: 5550
  public ParticleSystem[] LiquidEmitters;

  // Token: 0x040015AF RID: 5551
  public ParticleSystem[] FireEmitters;

  // Token: 0x040015B0 RID: 5552
  public ScheduleBlock[] ScheduleBlocks;

  // Token: 0x040015B1 RID: 5553
  public Transform[] Destinations;

  // Token: 0x040015B2 RID: 5554
  public OutlineScript[] Outlines;

  // Token: 0x040015B3 RID: 5555
  public GameObject[] Chopsticks;

  // Token: 0x040015B4 RID: 5556
  public string[] AnimationNames;

  // Token: 0x040015B5 RID: 5557
  public GameObject[] Bones;

  // Token: 0x040015B6 RID: 5558
  public Transform[] Skirt;

  // Token: 0x040015B7 RID: 5559
  public Transform[] Arm;

  // Token: 0x040015B8 RID: 5560
  [SerializeField]
  private List<int> VisibleCorpses = new List<int>();

  // Token: 0x040015B9 RID: 5561
  [SerializeField]
  private int[] CorpseLayers = new int[]
  {
    11,
    14
  };

  // Token: 0x040015BA RID: 5562
  [SerializeField]
  private LayerMask Mask;

  // Token: 0x040015BB RID: 5563
  public StudentActionType[] Actions;

  // Token: 0x040015BC RID: 5564
  public StudentActionType[] OriginalActions;

  // Token: 0x040015BD RID: 5565
  public AudioClip MurderSuicideKiller;

  // Token: 0x040015BE RID: 5566
  public AudioClip MurderSuicideVictim;

  // Token: 0x040015BF RID: 5567
  public AudioClip MurderSuicideSounds;

  // Token: 0x040015C0 RID: 5568
  public AudioClip PepperSpraySFX;

  // Token: 0x040015C1 RID: 5569
  public AudioClip BurningClip;

  // Token: 0x040015C2 RID: 5570
  public AudioClip[] FemaleAttacks;

  // Token: 0x040015C3 RID: 5571
  public AudioClip[] MaleAttacks;

  // Token: 0x040015C4 RID: 5572
  public SphereCollider HipCollider;

  // Token: 0x040015C5 RID: 5573
  public Collider RightHandCollider;

  // Token: 0x040015C6 RID: 5574
  public Collider LeftHandCollider;

  // Token: 0x040015C7 RID: 5575
  public Collider NotFaceCollider;

  // Token: 0x040015C8 RID: 5576
  public Collider PantyCollider;

  // Token: 0x040015C9 RID: 5577
  public Collider SkirtCollider;

  // Token: 0x040015CA RID: 5578
  public Collider FaceCollider;

  // Token: 0x040015CB RID: 5579
  public Collider NEStairs;

  // Token: 0x040015CC RID: 5580
  public Collider NWStairs;

  // Token: 0x040015CD RID: 5581
  public Collider SEStairs;

  // Token: 0x040015CE RID: 5582
  public Collider SWStairs;

  // Token: 0x040015CF RID: 5583
  public GameObject BloodSprayCollider;

  // Token: 0x040015D0 RID: 5584
  public GameObject EmptyGameObject;

  // Token: 0x040015D1 RID: 5585
  public GameObject StabBloodEffect;

  // Token: 0x040015D2 RID: 5586
  public GameObject RightEmptyEye;

  // Token: 0x040015D3 RID: 5587
  public GameObject LeftEmptyEye;

  // Token: 0x040015D4 RID: 5588
  public GameObject AnimatedBook;

  // Token: 0x040015D5 RID: 5589
  public GameObject BloodyScream;

  // Token: 0x040015D6 RID: 5590
  public GameObject ChaseCamera;

  // Token: 0x040015D7 RID: 5591
  public GameObject DeathScream;

  // Token: 0x040015D8 RID: 5592
  public GameObject BloodEffect;

  // Token: 0x040015D9 RID: 5593
  public GameObject PepperSpray;

  // Token: 0x040015DA RID: 5594
  public GameObject BloodSpray;

  // Token: 0x040015DB RID: 5595
  public GameObject SmartPhone;

  // Token: 0x040015DC RID: 5596
  public GameObject MainCamera;

  // Token: 0x040015DD RID: 5597
  public GameObject OccultBook;

  // Token: 0x040015DE RID: 5598
  public GameObject AlarmDisc;

  // Token: 0x040015DF RID: 5599
  public GameObject Character;

  // Token: 0x040015E0 RID: 5600
  public GameObject Cigarette;

  // Token: 0x040015E1 RID: 5601
  public GameObject Countdown;

  // Token: 0x040015E2 RID: 5602
  public GameObject EventBook;

  // Token: 0x040015E3 RID: 5603
  public GameObject OsanaHair;

  // Token: 0x040015E4 RID: 5604
  public GameObject HealthBar;

  // Token: 0x040015E5 RID: 5605
  public GameObject Earpiece;

  // Token: 0x040015E6 RID: 5606
  public GameObject Scrubber;

  // Token: 0x040015E7 RID: 5607
  public GameObject Armband;

  // Token: 0x040015E8 RID: 5608
  public GameObject BookBag;

  // Token: 0x040015E9 RID: 5609
  public GameObject Lighter;

  // Token: 0x040015EA RID: 5610
  public GameObject MyPaper;

  // Token: 0x040015EB RID: 5611
  public GameObject Eraser;

  // Token: 0x040015EC RID: 5612
  public GameObject Giggle;

  // Token: 0x040015ED RID: 5613
  public GameObject Marker;

  // Token: 0x040015EE RID: 5614
  public GameObject Weapon;

  // Token: 0x040015EF RID: 5615
  public GameObject Bento;

  // Token: 0x040015F0 RID: 5616
  public GameObject Paper;

  // Token: 0x040015F1 RID: 5617
  public GameObject Phone;

  // Token: 0x040015F2 RID: 5618
  public GameObject Note;

  // Token: 0x040015F3 RID: 5619
  public GameObject Pen;

  // Token: 0x040015F4 RID: 5620
  public GameObject Lid;

  // Token: 0x040015F5 RID: 5621
  public bool TargetedForDistraction;

  // Token: 0x040015F6 RID: 5622
  public bool OriginallyTeacher;

  // Token: 0x040015F7 RID: 5623
  public bool WitnessedCorpse;

  // Token: 0x040015F8 RID: 5624
  public bool WitnessedMurder;

  // Token: 0x040015F9 RID: 5625
  public bool YandereInnocent;

  // Token: 0x040015FA RID: 5626
  public bool FocusOnYandere;

  // Token: 0x040015FB RID: 5627
  public bool PinDownWitness;

  // Token: 0x040015FC RID: 5628
  public bool RepeatReaction;

  // Token: 0x040015FD RID: 5629
  public bool WitnessedBlood;

  // Token: 0x040015FE RID: 5630
  public bool YandereVisible;

  // Token: 0x040015FF RID: 5631
  public bool FleeWhenClean;

  // Token: 0x04001600 RID: 5632
  public bool MurderSuicide;

  // Token: 0x04001601 RID: 5633
  public bool BoobsResized;

  // Token: 0x04001602 RID: 5634
  public bool CheckingNote;

  // Token: 0x04001603 RID: 5635
  public bool ClubActivity;

  // Token: 0x04001604 RID: 5636
  public bool Complimented;

  // Token: 0x04001605 RID: 5637
  public bool Electrocuted;

  // Token: 0x04001606 RID: 5638
  public bool HoldingHands;

  // Token: 0x04001607 RID: 5639
  public bool PlayingAudio;

  // Token: 0x04001608 RID: 5640
  public bool StopRotating;

  // Token: 0x04001609 RID: 5641
  public bool TurnOffRadio;

  // Token: 0x0400160A RID: 5642
  public bool Electrified;

  // Token: 0x0400160B RID: 5643
  public bool ClubAttire;

  // Token: 0x0400160C RID: 5644
  public bool Confessing;

  // Token: 0x0400160D RID: 5645
  public bool Distracted;

  // Token: 0x0400160E RID: 5646
  public bool LewdPhotos;

  // Token: 0x0400160F RID: 5647
  public bool InDarkness;

  // Token: 0x04001610 RID: 5648
  public bool SwitchBack;

  // Token: 0x04001611 RID: 5649
  public bool BatheFast;

  // Token: 0x04001612 RID: 5650
  public bool Depressed;

  // Token: 0x04001613 RID: 5651
  public bool DiscCheck;

  // Token: 0x04001614 RID: 5652
  public bool DressCode;

  // Token: 0x04001615 RID: 5653
  public bool Drownable;

  // Token: 0x04001616 RID: 5654
  public bool EndSearch;

  // Token: 0x04001617 RID: 5655
  public bool KnifeDown;

  // Token: 0x04001618 RID: 5656
  public bool Phoneless;

  // Token: 0x04001619 RID: 5657
  public bool Attacked;

  // Token: 0x0400161A RID: 5658
  public bool Gossiped;

  // Token: 0x0400161B RID: 5659
  public bool Pushable;

  // Token: 0x0400161C RID: 5660
  public bool Splashed;

  // Token: 0x0400161D RID: 5661
  public bool Tranquil;

  // Token: 0x0400161E RID: 5662
  public bool WalkBack;

  // Token: 0x0400161F RID: 5663
  public bool Alarmed;

  // Token: 0x04001620 RID: 5664
  public bool BadTime;

  // Token: 0x04001621 RID: 5665
  public bool Drowned;

  // Token: 0x04001622 RID: 5666
  public bool Forgave;

  // Token: 0x04001623 RID: 5667
  public bool Indoors;

  // Token: 0x04001624 RID: 5668
  public bool InEvent;

  // Token: 0x04001625 RID: 5669
  public bool Nemesis;

  // Token: 0x04001626 RID: 5670
  public bool OnPhone;

  // Token: 0x04001627 RID: 5671
  public bool Private;

  // Token: 0x04001628 RID: 5672
  public bool Reacted;

  // Token: 0x04001629 RID: 5673
  public bool SawMask;

  // Token: 0x0400162A RID: 5674
  public bool Spawned;

  // Token: 0x0400162B RID: 5675
  public bool Started;

  // Token: 0x0400162C RID: 5676
  public bool Suicide;

  // Token: 0x0400162D RID: 5677
  public bool Teacher;

  // Token: 0x0400162E RID: 5678
  public bool Witness;

  // Token: 0x0400162F RID: 5679
  public bool Bloody;

  // Token: 0x04001630 RID: 5680
  public bool CanTalk = true;

  // Token: 0x04001631 RID: 5681
  public bool Emetic;

  // Token: 0x04001632 RID: 5682
  public bool Lethal;

  // Token: 0x04001633 RID: 5683
  public bool Routine = true;

  // Token: 0x04001634 RID: 5684
  public bool GoAway;

  // Token: 0x04001635 RID: 5685
  public bool Grudge;

  // Token: 0x04001636 RID: 5686
  public bool Pushed;

  // Token: 0x04001637 RID: 5687
  public bool Warned;

  // Token: 0x04001638 RID: 5688
  public bool Alone;

  // Token: 0x04001639 RID: 5689
  public bool Eaten;

  // Token: 0x0400163A RID: 5690
  public bool Hurry;

  // Token: 0x0400163B RID: 5691
  public bool Rival;

  // Token: 0x0400163C RID: 5692
  public bool Slave;

  // Token: 0x0400163D RID: 5693
  public DeathType DeathType;

  // Token: 0x0400163E RID: 5694
  public bool Halt;

  // Token: 0x0400163F RID: 5695
  public bool Lost;

  // Token: 0x04001640 RID: 5696
  public bool Male;

  // Token: 0x04001641 RID: 5697
  public bool Rose;

  // Token: 0x04001642 RID: 5698
  public bool Safe;

  // Token: 0x04001643 RID: 5699
  public bool Stop;

  // Token: 0x04001644 RID: 5700
  public bool Fed;

  // Token: 0x04001645 RID: 5701
  public bool Gas;

  // Token: 0x04001646 RID: 5702
  public bool Shy;

  // Token: 0x04001647 RID: 5703
  public bool Wet;

  // Token: 0x04001648 RID: 5704
  public bool Won;

  // Token: 0x04001649 RID: 5705
  public bool DK;

  // Token: 0x0400164A RID: 5706
  public bool CameraReacting;

  // Token: 0x0400164B RID: 5707
  public bool UsingRigidbody;

  // Token: 0x0400164C RID: 5708
  public bool Investigating;

  // Token: 0x0400164D RID: 5709
  public bool Distracting;

  // Token: 0x0400164E RID: 5710
  public bool HitReacting;

  // Token: 0x0400164F RID: 5711
  public bool PinningDown;

  // Token: 0x04001650 RID: 5712
  public bool Struggling;

  // Token: 0x04001651 RID: 5713
  public bool Following;

  // Token: 0x04001652 RID: 5714
  public bool Reporting;

  // Token: 0x04001653 RID: 5715
  public bool Guarding;

  // Token: 0x04001654 RID: 5716
  public bool Ignoring;

  // Token: 0x04001655 RID: 5717
  public bool Spraying;

  // Token: 0x04001656 RID: 5718
  public bool Vomiting;

  // Token: 0x04001657 RID: 5719
  public bool Burning;

  // Token: 0x04001658 RID: 5720
  public bool Fleeing;

  // Token: 0x04001659 RID: 5721
  public bool Hunting;

  // Token: 0x0400165A RID: 5722
  public bool Leaving;

  // Token: 0x0400165B RID: 5723
  public bool Meeting;

  // Token: 0x0400165C RID: 5724
  public bool Shoving;

  // Token: 0x0400165D RID: 5725
  public bool Talking;

  // Token: 0x0400165E RID: 5726
  public bool Waiting;

  // Token: 0x0400165F RID: 5727
  public bool Dying;

  // Token: 0x04001660 RID: 5728
  public float DistanceToDestination;

  // Token: 0x04001661 RID: 5729
  public float DistanceToPlayer;

  // Token: 0x04001662 RID: 5730
  public float TargetDistance;

  // Token: 0x04001663 RID: 5731
  public float InvestigationTimer;

  // Token: 0x04001664 RID: 5732
  public float CameraPoseTimer;

  // Token: 0x04001665 RID: 5733
  public float DistractTimer;

  // Token: 0x04001666 RID: 5734
  public float ReactionTimer;

  // Token: 0x04001667 RID: 5735
  public float WalkBackTimer;

  // Token: 0x04001668 RID: 5736
  public float ElectroTimer;

  // Token: 0x04001669 RID: 5737
  public float ThreatTimer;

  // Token: 0x0400166A RID: 5738
  public float GoAwayTimer;

  // Token: 0x0400166B RID: 5739
  public float PatrolTimer;

  // Token: 0x0400166C RID: 5740
  public float IgnoreTimer;

  // Token: 0x0400166D RID: 5741
  public float ReportTimer;

  // Token: 0x0400166E RID: 5742
  public float SplashTimer;

  // Token: 0x0400166F RID: 5743
  public float AlarmTimer;

  // Token: 0x04001670 RID: 5744
  public float BatheTimer;

  // Token: 0x04001671 RID: 5745
  public float CleanTimer;

  // Token: 0x04001672 RID: 5746
  public float RadioTimer;

  // Token: 0x04001673 RID: 5747
  public float StuckTimer;

  // Token: 0x04001674 RID: 5748
  public float MeetTimer;

  // Token: 0x04001675 RID: 5749
  public float TalkTimer;

  // Token: 0x04001676 RID: 5750
  public float WaitTimer;

  // Token: 0x04001677 RID: 5751
  public float OriginalYPosition;

  // Token: 0x04001678 RID: 5752
  public float PreviousEyeShrink;

  // Token: 0x04001679 RID: 5753
  public float PhotoPatience;

  // Token: 0x0400167A RID: 5754
  public float PreviousAlarm;

  // Token: 0x0400167B RID: 5755
  public float RepDeduction;

  // Token: 0x0400167C RID: 5756
  public float BreastSize;

  // Token: 0x0400167D RID: 5757
  public float Hesitation;

  // Token: 0x0400167E RID: 5758
  public float PendingRep;

  // Token: 0x0400167F RID: 5759
  public float Perception = 1f;

  // Token: 0x04001680 RID: 5760
  public float EyeShrink;

  // Token: 0x04001681 RID: 5761
  public float MeetTime;

  // Token: 0x04001682 RID: 5762
  public float Paranoia;

  // Token: 0x04001683 RID: 5763
  public float RepLoss;

  // Token: 0x04001684 RID: 5764
  public float Health = 100f;

  // Token: 0x04001685 RID: 5765
  public float Alarm;

  // Token: 0x04001686 RID: 5766
  public int InvestigationPhase;

  // Token: 0x04001687 RID: 5767
  public int MurderSuicidePhase;

  // Token: 0x04001688 RID: 5768
  public int CameraReactPhase;

  // Token: 0x04001689 RID: 5769
  public int SplashPhase;

  // Token: 0x0400168A RID: 5770
  public int BathePhase;

  // Token: 0x0400168B RID: 5771
  public int VomitPhase;

  // Token: 0x0400168C RID: 5772
  public int ClubPhase;

  // Token: 0x0400168D RID: 5773
  public int TaskPhase;

  // Token: 0x0400168E RID: 5774
  public int ReadPhase;

  // Token: 0x0400168F RID: 5775
  public int PinPhase;

  // Token: 0x04001690 RID: 5776
  public int Phase;

  // Token: 0x04001691 RID: 5777
  public int MurdersWitnessed;

  // Token: 0x04001692 RID: 5778
  public PersonaType OriginalPersona;

  // Token: 0x04001693 RID: 5779
  public int WeaponWitnessed;

  // Token: 0x04001694 RID: 5780
  public int MurderReaction;

  // Token: 0x04001695 RID: 5781
  public int GossipBonus;

  // Token: 0x04001696 RID: 5782
  public StudentInteractionType Interaction;

  // Token: 0x04001697 RID: 5783
  public float RepRecovery;

  // Token: 0x04001698 RID: 5784
  public int CleaningRole;

  // Token: 0x04001699 RID: 5785
  public int DeathCause;

  // Token: 0x0400169A RID: 5786
  public int Schoolwear;

  // Token: 0x0400169B RID: 5787
  public int SkinColor = 3;

  // Token: 0x0400169C RID: 5788
  public int Patience = 5;

  // Token: 0x0400169D RID: 5789
  public int Pestered;

  // Token: 0x0400169E RID: 5790
  public int RepBonus;

  // Token: 0x0400169F RID: 5791
  public int Strength;

  // Token: 0x040016A0 RID: 5792
  public int Concern;

  // Token: 0x040016A1 RID: 5793
  public int Crush;

  // Token: 0x040016A2 RID: 5794
  public StudentWitnessType PreviouslyWitnessed;

  // Token: 0x040016A3 RID: 5795
  public StudentWitnessType Witnessed;

  // Token: 0x040016A4 RID: 5796
  public GameOverType GameOverCause;

  // Token: 0x040016A5 RID: 5797
  public string CurrentAnim = string.Empty;

  // Token: 0x040016A6 RID: 5798
  public string RivalPrefix = string.Empty;

  // Token: 0x040016A7 RID: 5799
  public string RandomAnim = string.Empty;

  // Token: 0x040016A8 RID: 5800
  public string Accessory = string.Empty;

  // Token: 0x040016A9 RID: 5801
  public string Hairstyle = string.Empty;

  // Token: 0x040016AA RID: 5802
  public string Name = string.Empty;

  // Token: 0x040016AB RID: 5803
  public string OriginalWalkAnim = string.Empty;

  // Token: 0x040016AC RID: 5804
  public string WalkAnim = string.Empty;

  // Token: 0x040016AD RID: 5805
  public string RunAnim = string.Empty;

  // Token: 0x040016AE RID: 5806
  public string SprintAnim = string.Empty;

  // Token: 0x040016AF RID: 5807
  public string IdleAnim = string.Empty;

  // Token: 0x040016B0 RID: 5808
  public string Nod1Anim = string.Empty;

  // Token: 0x040016B1 RID: 5809
  public string Nod2Anim = string.Empty;

  // Token: 0x040016B2 RID: 5810
  public string DefendAnim = string.Empty;

  // Token: 0x040016B3 RID: 5811
  public string DeathAnim = string.Empty;

  // Token: 0x040016B4 RID: 5812
  public string ScaredAnim = string.Empty;

  // Token: 0x040016B5 RID: 5813
  public string EvilWitnessAnim = string.Empty;

  // Token: 0x040016B6 RID: 5814
  public string LookDownAnim = string.Empty;

  // Token: 0x040016B7 RID: 5815
  public string PhoneAnim = string.Empty;

  // Token: 0x040016B8 RID: 5816
  public string AngryFaceAnim = string.Empty;

  // Token: 0x040016B9 RID: 5817
  public string InspectAnim = string.Empty;

  // Token: 0x040016BA RID: 5818
  public string GuardAnim = string.Empty;

  // Token: 0x040016BB RID: 5819
  public string CallAnim = string.Empty;

  // Token: 0x040016BC RID: 5820
  public string CounterAnim = string.Empty;

  // Token: 0x040016BD RID: 5821
  public string PushedAnim = string.Empty;

  // Token: 0x040016BE RID: 5822
  public string GameAnim = string.Empty;

  // Token: 0x040016BF RID: 5823
  public string BentoAnim = string.Empty;

  // Token: 0x040016C0 RID: 5824
  public string EatAnim = string.Empty;

  // Token: 0x040016C1 RID: 5825
  public string DrownAnim = string.Empty;

  // Token: 0x040016C2 RID: 5826
  public string WetAnim = string.Empty;

  // Token: 0x040016C3 RID: 5827
  public string SplashedAnim = string.Empty;

  // Token: 0x040016C4 RID: 5828
  public string StripAnim = string.Empty;

  // Token: 0x040016C5 RID: 5829
  public string ParanoidAnim = string.Empty;

  // Token: 0x040016C6 RID: 5830
  public string GossipAnim = string.Empty;

  // Token: 0x040016C7 RID: 5831
  public string SadSitAnim = string.Empty;

  // Token: 0x040016C8 RID: 5832
  public string BrokenAnim = string.Empty;

  // Token: 0x040016C9 RID: 5833
  public string BrokenSitAnim = string.Empty;

  // Token: 0x040016CA RID: 5834
  public string BrokenWalkAnim = string.Empty;

  // Token: 0x040016CB RID: 5835
  public string FistAnim = string.Empty;

  // Token: 0x040016CC RID: 5836
  public string AttackAnim = string.Empty;

  // Token: 0x040016CD RID: 5837
  public string SuicideAnim = string.Empty;

  // Token: 0x040016CE RID: 5838
  public string RelaxAnim = string.Empty;

  // Token: 0x040016CF RID: 5839
  public string SitAnim = string.Empty;

  // Token: 0x040016D0 RID: 5840
  public string ShyAnim = string.Empty;

  // Token: 0x040016D1 RID: 5841
  public string StalkAnim = string.Empty;

  // Token: 0x040016D2 RID: 5842
  public string ClubAnim = string.Empty;

  // Token: 0x040016D3 RID: 5843
  public string StruggleAnim = string.Empty;

  // Token: 0x040016D4 RID: 5844
  public string StruggleWonAnim = string.Empty;

  // Token: 0x040016D5 RID: 5845
  public string StruggleLostAnim = string.Empty;

  // Token: 0x040016D6 RID: 5846
  public string SocialSitAnim = string.Empty;

  // Token: 0x040016D7 RID: 5847
  public string CarryAnim = string.Empty;

  // Token: 0x040016D8 RID: 5848
  public string ActivityAnim = string.Empty;

  // Token: 0x040016D9 RID: 5849
  public string GrudgeAnim = string.Empty;

  // Token: 0x040016DA RID: 5850
  public string SadFaceAnim = string.Empty;

  // Token: 0x040016DB RID: 5851
  public string CowardAnim = string.Empty;

  // Token: 0x040016DC RID: 5852
  public string EvilAnim = string.Empty;

  // Token: 0x040016DD RID: 5853
  public string SocialReportAnim = string.Empty;

  // Token: 0x040016DE RID: 5854
  public string SocialFearAnim = string.Empty;

  // Token: 0x040016DF RID: 5855
  public string SocialTerrorAnim = string.Empty;

  // Token: 0x040016E0 RID: 5856
  public string BuzzSawDeathAnim = string.Empty;

  // Token: 0x040016E1 RID: 5857
  public string SwingDeathAnim = string.Empty;

  // Token: 0x040016E2 RID: 5858
  public string CyborgDeathAnim = string.Empty;

  // Token: 0x040016E3 RID: 5859
  public string WalkBackAnim = string.Empty;

  // Token: 0x040016E4 RID: 5860
  public string PatrolAnim = string.Empty;

  // Token: 0x040016E5 RID: 5861
  public string RadioAnim = string.Empty;

  // Token: 0x040016E6 RID: 5862
  public string BookSitAnim = string.Empty;

  // Token: 0x040016E7 RID: 5863
  public string BookReadAnim = string.Empty;

  // Token: 0x040016E8 RID: 5864
  public string LovedOneAnim = string.Empty;

  // Token: 0x040016E9 RID: 5865
  public string CuddleAnim = string.Empty;

  // Token: 0x040016EA RID: 5866
  public string VomitAnim = string.Empty;

  // Token: 0x040016EB RID: 5867
  public string WashFaceAnim = string.Empty;

  // Token: 0x040016EC RID: 5868
  public string EmeticAnim = string.Empty;

  // Token: 0x040016ED RID: 5869
  public string BurningAnim = string.Empty;

  // Token: 0x040016EE RID: 5870
  public string JojoReactAnim = string.Empty;

  // Token: 0x040016EF RID: 5871
  public string TeachAnim = string.Empty;

  // Token: 0x040016F0 RID: 5872
  public string LeanAnim = string.Empty;

  // Token: 0x040016F1 RID: 5873
  public string DeskTextAnim = string.Empty;

  // Token: 0x040016F2 RID: 5874
  public string CarryShoulderAnim = string.Empty;

  // Token: 0x040016F3 RID: 5875
  public string ReadyToFightAnim = string.Empty;

  // Token: 0x040016F4 RID: 5876
  public string SearchPatrolAnim = string.Empty;

  // Token: 0x040016F5 RID: 5877
  public string DiscoverPhoneAnim = string.Empty;

  // Token: 0x040016F6 RID: 5878
  public string WaitAnim = string.Empty;

  // Token: 0x040016F7 RID: 5879
  public string ShoveAnim = string.Empty;

  // Token: 0x040016F8 RID: 5880
  public string SprayAnim = string.Empty;

  // Token: 0x040016F9 RID: 5881
  public string SithReactAnim = string.Empty;

  // Token: 0x040016FA RID: 5882
  public string EatVictimAnim = string.Empty;

  // Token: 0x040016FB RID: 5883
  public string[] CleanAnims;

  // Token: 0x040016FC RID: 5884
  public string[] CameraAnims;

  // Token: 0x040016FD RID: 5885
  public string[] SocialAnims;

  // Token: 0x040016FE RID: 5886
  public string[] CowardAnims;

  // Token: 0x040016FF RID: 5887
  public string[] EvilAnims;

  // Token: 0x04001700 RID: 5888
  public string[] HeroAnims;

  // Token: 0x04001701 RID: 5889
  public string[] TaskAnims;

  // Token: 0x04001702 RID: 5890
  public int ClubMemberID;

  // Token: 0x04001703 RID: 5891
  public int ConfessPhase = 1;

  // Token: 0x04001704 RID: 5892
  public int ReportPhase;

  // Token: 0x04001705 RID: 5893
  public int RadioPhase = 1;

  // Token: 0x04001706 RID: 5894
  public int StudentID;

  // Token: 0x04001707 RID: 5895
  public int PatrolID;

  // Token: 0x04001708 RID: 5896
  public int CleanID;

  // Token: 0x04001709 RID: 5897
  public PersonaType Persona;

  // Token: 0x0400170A RID: 5898
  public int Class;

  // Token: 0x0400170B RID: 5899
  public ClubType Club;

  // Token: 0x0400170C RID: 5900
  public int ID;

  // Token: 0x0400170D RID: 5901
  public Vector3 LastKnownCorpse;

  // Token: 0x0400170E RID: 5902
  public Vector3 DistractionSpot;

  // Token: 0x0400170F RID: 5903
  public Vector3 RightEyeOrigin;

  // Token: 0x04001710 RID: 5904
  public Vector3 LeftEyeOrigin;

  // Token: 0x04001711 RID: 5905
  public Vector3 LastPosition;

  // Token: 0x04001712 RID: 5906
  public Vector3 BurnTarget;

  // Token: 0x04001713 RID: 5907
  public Transform RightBreast;

  // Token: 0x04001714 RID: 5908
  public Transform LeftBreast;

  // Token: 0x04001715 RID: 5909
  public Transform RightEye;

  // Token: 0x04001716 RID: 5910
  public Transform LeftEye;

  // Token: 0x04001717 RID: 5911
  public int Frame;

  // Token: 0x04001718 RID: 5912
  private float MaxSpeed = 10f;

  // Token: 0x04001719 RID: 5913
  private const string RIVAL_PREFIX = "Rival ";

  // Token: 0x0400171A RID: 5914
  public Transform DefaultTarget;

  // Token: 0x0400171B RID: 5915
  public Transform GushTarget;

  // Token: 0x0400171C RID: 5916
  public bool Gush;

  // Token: 0x0400171D RID: 5917
  public float LookSpeed = 2f;

  // Token: 0x0400171E RID: 5918
  public LowPolyStudentScript LowPoly;

  // Token: 0x0400171F RID: 5919
  public Texture[] SocksTextures;

  // Token: 0x04001720 RID: 5920
  public GameObject JojoHitEffect;

  // Token: 0x04001721 RID: 5921
  public GameObject[] ElectroSteam;

  // Token: 0x04001722 RID: 5922
  public GameObject[] CensorSteam;

  // Token: 0x04001723 RID: 5923
  public Texture NudeTexture;

  // Token: 0x04001724 RID: 5924
  public Mesh BaldNudeMesh;

  // Token: 0x04001725 RID: 5925
  public Mesh NudeMesh;

  // Token: 0x04001726 RID: 5926
  public Mesh SchoolSwimsuit;

  // Token: 0x04001727 RID: 5927
  public Mesh GymUniform;

  // Token: 0x04001728 RID: 5928
  public Texture UniformTexture;

  // Token: 0x04001729 RID: 5929
  public Texture SwimsuitTexture;

  // Token: 0x0400172A RID: 5930
  public Texture GymTexture;

  // Token: 0x0400172B RID: 5931
  public bool AoT;

  // Token: 0x0400172C RID: 5932
  public Texture TitanBodyTexture;

  // Token: 0x0400172D RID: 5933
  public Texture TitanFaceTexture;

  // Token: 0x0400172E RID: 5934
  public bool Spooky;

  // Token: 0x0400172F RID: 5935
  public Mesh JudoGiMesh;

  // Token: 0x04001730 RID: 5936
  public Texture JudoGiTexture;

  // Token: 0x04001731 RID: 5937
  public Mesh NoArmsNoTorso;

  // Token: 0x04001732 RID: 5938
  public GameObject RiggedAccessory;

  // Token: 0x04001733 RID: 5939
  public int CoupleID;
}