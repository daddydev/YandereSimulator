using UnityEngine;

// Token: 0x020001B2 RID: 434
public class ShoulderCameraScript : MonoBehaviour {

  // Token: 0x06000794 RID: 1940 RVA: 0x00072CEC File Offset: 0x000710EC
  private void LateUpdate() {
    if (!this.PauseScreen.Show) {
      if (this.OverShoulder) {
        if (this.RPGCamera.enabled) {
          this.ShoulderFocus.position = this.RPGCamera.cameraPivot.position;
          this.LastPosition = base.transform.position;
          this.RPGCamera.enabled = false;
        }
        base.transform.position = Vector3.Lerp(base.transform.position, this.ShoulderPOV.position, Time.deltaTime * 10f);
        this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * this.Height, Time.deltaTime * 10f);
        base.transform.LookAt(this.ShoulderFocus);
      } else if (this.AimingCamera) {
        base.transform.position = this.CameraPOV.position;
        base.transform.LookAt(this.CameraFocus);
      } else if (this.Noticed) {
        if (this.NoticedTimer == 0f) {
          base.GetComponent<Camera>().cullingMask &= -8193;
          StudentScript component = this.Yandere.Senpai.GetComponent<StudentScript>();
          if (component.Teacher) {
            this.NoticedHeight = 1.6f;
            this.NoticedLimit = 6;
          } else if (component.Witnessed == StudentWitnessType.Stalking) {
            this.NoticedHeight = 1.481275f;
            this.NoticedLimit = 7;
          } else {
            this.NoticedHeight = 1.375f;
            this.NoticedLimit = 6;
          }
          this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward + Vector3.up * this.NoticedHeight;
          this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight);
          this.NoticedFocus.position = base.transform.position + base.transform.forward;
          this.NoticedSpeed = 10f;
        }
        this.NoticedTimer += Time.deltaTime;
        if (this.Phase == 1) {
          this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight, Time.deltaTime * 10f);
          this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * -0.075f);
          if (this.NoticedTimer > 1f && !this.Spoken && !this.Yandere.Senpai.GetComponent<StudentScript>().Teacher) {
            this.Yandere.Senpai.GetComponent<StudentScript>().DetermineSenpaiReaction();
            this.Spoken = true;
          }
          if (this.NoticedTimer > (float)this.NoticedLimit || this.Skip) {
            this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(false);
            base.GetComponent<Camera>().cullingMask |= 8192;
            this.Yandere.Subtitle.UpdateLabel(SubtitleType.YandereWhimper, 1, 3.5f);
            this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward + Vector3.up * 1.375f;
            this.NoticedPOV.LookAt(this.Yandere.transform.position + Vector3.up * 1.375f);
            this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 1.375f;
            base.transform.position = this.NoticedPOV.position;
            this.NoticedTimer = (float)this.NoticedLimit;
            this.Phase = 2;
          }
        } else if (this.Phase == 2) {
          this.Yandere.EyeShrink += Time.deltaTime * 0.25f;
          this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
          if (this.NoticedTimer > (float)(this.NoticedLimit + 4)) {
            this.NoticedPOV.Translate(Vector3.back * 2f);
            this.NoticedPOV.transform.position = new Vector3(this.NoticedPOV.transform.position.x, this.Yandere.transform.position.y + 1f, this.NoticedPOV.transform.position.z);
            this.NoticedSpeed = 1f;
            this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
            this.HeartbrokenCamera.SetActive(true);
            this.Yandere.Collapse = true;
            this.Phase = 3;
          }
        } else if (this.Phase == 3) {
          this.NoticedFocus.transform.position = new Vector3(this.NoticedFocus.transform.position.x, Mathf.Lerp(this.NoticedFocus.transform.position.y, this.Yandere.transform.position.y + 1f, Time.deltaTime), this.NoticedFocus.transform.position.z);
        }
        base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
        base.transform.LookAt(this.NoticedFocus);
      } else if (this.Scolding) {
        if (this.Timer == 0f) {
          this.NoticedHeight = 1.6f;
          this.NoticedPOV.position = this.Teacher.position + this.Teacher.forward + Vector3.up * this.NoticedHeight;
          this.NoticedPOV.LookAt(this.Teacher.position + Vector3.up * this.NoticedHeight);
          this.NoticedFocus.position = this.Teacher.position + Vector3.up * this.NoticedHeight;
          this.NoticedSpeed = 10f;
        }
        base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
        base.transform.LookAt(this.NoticedFocus);
        this.Timer += Time.deltaTime;
        if (this.Timer > 6f) {
          this.Portal.ClassDarkness.enabled = true;
          this.Portal.Transition = true;
          this.Portal.FadeOut = true;
        }
        if (this.Timer > 7f) {
          this.Scolding = false;
          this.Timer = 0f;
        }
      } else if (this.Counter) {
        if (this.Timer == 0f) {
          this.StruggleFocus.position = base.transform.position + base.transform.forward;
          this.StrugglePOV.position = base.transform.position;
        }
        base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
        base.transform.LookAt(this.StruggleFocus);
        this.Timer += Time.deltaTime;
        if (this.Timer > 0.5f && this.Phase < 2) {
          this.Yandere.CameraEffects.MurderWitnessed();
          this.Yandere.Jukebox.GameOver();
          this.Phase++;
        }
        if (this.Timer > 1.4f && this.Phase < 3) {
          this.Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherAttackReaction, 1, 4f);
          this.Phase++;
        }
        if (this.Timer > 6f && this.Yandere.Armed) {
          this.Yandere.EquippedWeapon.Drop();
        }
        if (this.Timer > 6.66666f && this.Phase < 4) {
          base.GetComponent<AudioSource>().PlayOneShot(this.Slam);
          this.Phase++;
        }
        if (this.Timer > 10f && this.Phase < 5) {
          this.HeartbrokenCamera.SetActive(true);
          this.Phase++;
        }
        if (this.Timer < 5f) {
          this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * 1.4f, Time.deltaTime);
          this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.5f, 1.4f, 0.3f), Time.deltaTime);
        } else if (this.Timer < 10f) {
          if (this.Timer < 6.5f) {
            this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 1.5f, Time.deltaTime);
          } else {
            this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 0f, Time.deltaTime * 0.428571433f);
          }
          base.transform.Translate(Vector3.back * Time.deltaTime * 10f * this.PullBackTimer);
          this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.114666663f, -0.84f), Time.deltaTime);
          this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.6f, 0.114666663f, -0.84f), Time.deltaTime);
        } else {
          this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.3f, -0.4f), Time.deltaTime);
          this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(1.05f, 0.3f, -0.4f), Time.deltaTime);
        }
      } else if (this.Struggle) {
        base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
        base.transform.LookAt(this.StruggleFocus);
        if (this.Yandere.Lost) {
          this.StruggleFocus.localPosition = Vector3.MoveTowards(this.StruggleFocus.localPosition, this.LossFocus, Time.deltaTime);
          this.StrugglePOV.localPosition = Vector3.MoveTowards(this.StrugglePOV.localPosition, this.LossPOV, Time.deltaTime);
          if (this.Timer == 0f) {
            AudioSource component2 = base.GetComponent<AudioSource>();
            component2.clip = this.StruggleLose;
            component2.Play();
          }
          this.Timer += Time.deltaTime;
          if (this.Timer < 3f) {
            base.transform.Translate(Vector3.back * (Time.deltaTime * 10f * this.Timer * (3f - this.Timer)));
          } else if (!this.HeartbrokenCamera.activeInHierarchy) {
            this.HeartbrokenCamera.SetActive(true);
            this.Yandere.Jukebox.GameOver();
            base.enabled = false;
          }
        }
      } else if (this.Yandere.Attacked) {
        this.Focus.transform.parent = null;
        this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime);
        base.transform.LookAt(this.Focus);
      } else if (this.LookDown) {
        this.Timer += Time.deltaTime;
        if (this.Timer < 5f) {
          base.transform.position = Vector3.Lerp(base.transform.position, this.Yandere.Hips.position + Vector3.up * 3f + Vector3.right * 0.1f, Time.deltaTime * this.Timer);
          this.Focus.transform.parent = null;
          this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime * this.Timer);
          base.transform.LookAt(this.Focus);
        } else if (!this.HeartbrokenCamera.activeInHierarchy) {
          this.HeartbrokenCamera.SetActive(true);
          this.Yandere.Jukebox.GameOver();
          base.enabled = false;
        }
      } else if (this.Summoning) {
        if (this.Phase == 1) {
          this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 1.7f + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f;
          this.NoticedFocus.position = base.transform.position + base.transform.forward;
          this.NoticedSpeed = 10f;
          this.Phase++;
        } else if (this.Phase == 2) {
          this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
          this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.transform.position + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f, Time.deltaTime * 10f);
          this.Timer += Time.deltaTime;
          if (this.Timer > 2f) {
            this.Yandere.Stand.Spawn();
            this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 2f + Vector3.up * 2.4f;
            this.Timer = 0f;
            this.Phase++;
          }
        } else if (this.Phase == 3) {
          this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
          this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 2.4f;
          this.Yandere.Stand.Stand.SetActive(true);
          this.Timer += Time.deltaTime;
          if (this.Timer > 5f) {
            this.Phase++;
          }
        } else if (this.Phase == 4) {
          this.Yandere.Stand.transform.localPosition = new Vector3(this.Yandere.Stand.transform.localPosition.x, 0f, this.Yandere.Stand.transform.localPosition.z);
          this.Yandere.Jukebox.PlayJojo();
          this.Yandere.Talking = true;
          this.Summoning = false;
          this.Timer = 0f;
          this.Phase = 1;
        }
        base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
        base.transform.LookAt(this.NoticedFocus);
      } else if ((this.Yandere.Talking || this.Yandere.Won) && !this.RPGCamera.enabled) {
        this.Timer += Time.deltaTime;
        if (this.Timer < 0.5f) {
          base.transform.position = Vector3.Lerp(base.transform.position, this.LastPosition, Time.deltaTime * 10f);
          if (this.Yandere.Talking) {
            this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * 10f);
            base.transform.LookAt(this.ShoulderFocus);
          } else {
            this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * 10f);
            base.transform.LookAt(this.StruggleFocus);
          }
        } else {
          this.RPGCamera.enabled = true;
          this.Yandere.MyController.enabled = true;
          this.Yandere.Talking = false;
          this.Yandere.CanMove = true;
          this.Yandere.Pursuer = null;
          this.Yandere.Chased = false;
          this.Yandere.Won = false;
          this.Timer = 0f;
        }
      }
    }
  }

  // Token: 0x0400134B RID: 4939
  public PauseScreenScript PauseScreen;

  // Token: 0x0400134C RID: 4940
  public YandereScript Yandere;

  // Token: 0x0400134D RID: 4941
  public RPG_Camera RPGCamera;

  // Token: 0x0400134E RID: 4942
  public PortalScript Portal;

  // Token: 0x0400134F RID: 4943
  public GameObject HeartbrokenCamera;

  // Token: 0x04001350 RID: 4944
  public Transform Smartphone;

  // Token: 0x04001351 RID: 4945
  public Transform Teacher;

  // Token: 0x04001352 RID: 4946
  public Transform ShoulderFocus;

  // Token: 0x04001353 RID: 4947
  public Transform ShoulderPOV;

  // Token: 0x04001354 RID: 4948
  public Transform CameraFocus;

  // Token: 0x04001355 RID: 4949
  public Transform CameraPOV;

  // Token: 0x04001356 RID: 4950
  public Transform NoticedFocus;

  // Token: 0x04001357 RID: 4951
  public Transform NoticedPOV;

  // Token: 0x04001358 RID: 4952
  public Transform StruggleFocus;

  // Token: 0x04001359 RID: 4953
  public Transform StrugglePOV;

  // Token: 0x0400135A RID: 4954
  public Transform Focus;

  // Token: 0x0400135B RID: 4955
  public Vector3 LastPosition;

  // Token: 0x0400135C RID: 4956
  public Vector3 TeacherLossFocus;

  // Token: 0x0400135D RID: 4957
  public Vector3 TeacherLossPOV;

  // Token: 0x0400135E RID: 4958
  public Vector3 LossFocus;

  // Token: 0x0400135F RID: 4959
  public Vector3 LossPOV;

  // Token: 0x04001360 RID: 4960
  public bool AimingCamera;

  // Token: 0x04001361 RID: 4961
  public bool OverShoulder;

  // Token: 0x04001362 RID: 4962
  public bool DoNotMove;

  // Token: 0x04001363 RID: 4963
  public bool Summoning;

  // Token: 0x04001364 RID: 4964
  public bool LookDown;

  // Token: 0x04001365 RID: 4965
  public bool Scolding;

  // Token: 0x04001366 RID: 4966
  public bool Struggle;

  // Token: 0x04001367 RID: 4967
  public bool Counter;

  // Token: 0x04001368 RID: 4968
  public bool Noticed;

  // Token: 0x04001369 RID: 4969
  public bool Spoken;

  // Token: 0x0400136A RID: 4970
  public bool Skip;

  // Token: 0x0400136B RID: 4971
  public AudioClip StruggleLose;

  // Token: 0x0400136C RID: 4972
  public AudioClip Slam;

  // Token: 0x0400136D RID: 4973
  public float NoticedHeight;

  // Token: 0x0400136E RID: 4974
  public float NoticedTimer;

  // Token: 0x0400136F RID: 4975
  public float NoticedSpeed;

  // Token: 0x04001370 RID: 4976
  public float Height;

  // Token: 0x04001371 RID: 4977
  public float PullBackTimer;

  // Token: 0x04001372 RID: 4978
  public float Timer;

  // Token: 0x04001373 RID: 4979
  public int NoticedLimit;

  // Token: 0x04001374 RID: 4980
  public int Phase;
}