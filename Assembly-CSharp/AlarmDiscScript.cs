using UnityEngine;

// Token: 0x0200002C RID: 44
public class AlarmDiscScript : MonoBehaviour {

  // Token: 0x060000A4 RID: 164 RVA: 0x0000B914 File Offset: 0x00009D14
  private void Start() {
    Vector3 localScale = base.transform.localScale;
    localScale.x *= 2f - SchoolGlobals.SchoolAtmosphere;
    localScale.z = localScale.x;
    base.transform.localScale = localScale;
  }

  // Token: 0x060000A5 RID: 165 RVA: 0x0000B960 File Offset: 0x00009D60
  private void Update() {
    if (this.Frame > 0) {
      UnityEngine.Object.Destroy(base.gameObject);
    } else if (!this.NoScream) {
      if (!this.Long) {
        if (this.Originator != null) {
          this.Male = this.Originator.Male;
        }
        if (!this.Male) {
          this.PlayClip(this.FemaleScreams[UnityEngine.Random.Range(0, this.FemaleScreams.Length)], base.transform.position);
        } else {
          this.PlayClip(this.MaleScreams[UnityEngine.Random.Range(0, this.MaleScreams.Length)], base.transform.position);
        }
      } else if (!this.Male) {
        this.PlayClip(this.LongFemaleScreams[UnityEngine.Random.Range(0, this.LongFemaleScreams.Length)], base.transform.position);
      } else {
        this.PlayClip(this.LongMaleScreams[UnityEngine.Random.Range(0, this.LongMaleScreams.Length)], base.transform.position);
      }
    }
    this.Frame++;
  }

  // Token: 0x060000A6 RID: 166 RVA: 0x0000BA8C File Offset: 0x00009E8C
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9) {
      this.Student = other.gameObject.GetComponent<StudentScript>();
      if (this.Student != null && this.Student.enabled) {
        UnityEngine.Object.Destroy(this.Student.Giggle);
        this.Student.InvestigationTimer = 0f;
        this.Student.InvestigationPhase = 0;
        this.Student.Investigating = false;
        this.Student.DiscCheck = false;
        if (!this.Radio) {
          if (this.Student != this.Originator && !this.Student.TurnOffRadio && this.Student.Alive && !this.Student.Pushed && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.CheckingNote && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.FocusOnYandere) {
            if (this.Student.Male) {
            }
            this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.LeanAnim);
            if (this.Originator != null) {
              if (this.Originator.WitnessedMurder) {
                this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.Yandere.transform.position.y, base.transform.position.z);
              } else if (this.Originator.Corpse == null) {
                this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
              } else {
                this.Student.DistractionSpot = new Vector3(this.Originator.Corpse.transform.position.x, this.Student.transform.position.y, this.Originator.Corpse.transform.position.z);
              }
            } else {
              this.Student.DistractionSpot = new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z);
            }
            this.Student.DiscCheck = true;
            if (this.Shocking) {
              this.Student.Hesitation = 0.5f;
            }
            this.Student.Alarm = 200f;
          }
        } else if (!this.Student.Nemesis && this.Student.Alive && !this.Student.Dying && !this.Student.Alarmed && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.InEvent && !this.Student.Following && !this.Student.Distracting && this.Student.Actions[this.Student.Phase] != StudentActionType.Teaching && this.Student.Actions[this.Student.Phase] != StudentActionType.SitAndTakeNotes && !this.Student.GoAway && this.Student.Routine && !this.Student.CheckingNote && this.Student.CharacterAnimation != null && this.SourceRadio.Victim == null) {
          this.Student.CharacterAnimation.CrossFade(this.Student.LeanAnim);
          this.Student.Pathfinding.canSearch = false;
          this.Student.Pathfinding.canMove = false;
          this.Student.Radio = this.SourceRadio;
          this.Student.TurnOffRadio = true;
          this.Student.Routine = false;
          this.Student.GoAway = false;
          this.Student.OccultBook.SetActive(false);
          this.Student.Pen.SetActive(false);
          this.Student.SpeechLines.Stop();
          this.Student.RadioTimer = 0f;
          this.Student.ReadPhase = 0;
          this.SourceRadio.Victim = this.Student;
        }
      }
    }
  }

  // Token: 0x060000A7 RID: 167 RVA: 0x0000C018 File Offset: 0x0000A418
  private void PlayClip(AudioClip clip, Vector3 pos) {
    GameObject gameObject = new GameObject("TempAudio");
    gameObject.transform.position = pos;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    UnityEngine.Object.Destroy(gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = 5f;
    audioSource.maxDistance = 10f;
    audioSource.spatialBlend = 1f;
    audioSource.volume = 0.5f;
    if (this.Student != null) {
      this.Student.DeathScream = gameObject;
    }
  }

  // Token: 0x04000175 RID: 373
  public AudioClip[] LongFemaleScreams;

  // Token: 0x04000176 RID: 374
  public AudioClip[] LongMaleScreams;

  // Token: 0x04000177 RID: 375
  public AudioClip[] FemaleScreams;

  // Token: 0x04000178 RID: 376
  public AudioClip[] MaleScreams;

  // Token: 0x04000179 RID: 377
  public StudentScript Originator;

  // Token: 0x0400017A RID: 378
  public RadioScript SourceRadio;

  // Token: 0x0400017B RID: 379
  public StudentScript Student;

  // Token: 0x0400017C RID: 380
  public bool NoScream;

  // Token: 0x0400017D RID: 381
  public bool Shocking;

  // Token: 0x0400017E RID: 382
  public bool Radio;

  // Token: 0x0400017F RID: 383
  public bool Male;

  // Token: 0x04000180 RID: 384
  public bool Long;

  // Token: 0x04000181 RID: 385
  public int Frame;
}