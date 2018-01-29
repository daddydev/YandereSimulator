using UnityEngine;

// Token: 0x020000CD RID: 205
public class GiggleScript : MonoBehaviour {

  // Token: 0x0600030A RID: 778 RVA: 0x00039B40 File Offset: 0x00037F40
  private void Start() {
    float num = 500f * (2f - SchoolGlobals.SchoolAtmosphere);
    base.transform.localScale = new Vector3(num, base.transform.localScale.y, num);
  }

  // Token: 0x0600030B RID: 779 RVA: 0x00039B84 File Offset: 0x00037F84
  private void Update() {
    if (this.Frame > 0) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
    this.Frame++;
  }

  // Token: 0x0600030C RID: 780 RVA: 0x00039BAC File Offset: 0x00037FAC
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == 9 && !this.Distracted) {
      this.Student = other.gameObject.GetComponent<StudentScript>();
      if (this.Student != null && this.Student.Giggle == null && !this.Student.YandereVisible && !this.Student.Alarmed && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Investigating && !this.Student.InEvent && !this.Student.Following && !this.Student.Confessing && !this.Student.Meeting && !this.Student.TurnOffRadio && !this.Student.Fleeing && !this.Student.Distracting && !this.Student.GoAway && !this.Student.FocusOnYandere && this.Student.Actions[this.Student.Phase] != StudentActionType.Teaching && this.Student.Actions[this.Student.Phase] != StudentActionType.SitAndTakeNotes && this.Student.Routine) {
        this.Student.Character.GetComponent<Animation>().CrossFade(this.Student.IdleAnim);
        this.Giggle = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, new Vector3(base.transform.position.x, this.Student.transform.position.y, base.transform.position.z), Quaternion.identity);
        this.Student.Giggle = this.Giggle;
        if (this.Student.Pathfinding != null && !this.Student.Nemesis) {
          this.Student.Pathfinding.canSearch = false;
          this.Student.Pathfinding.canMove = false;
          this.Student.InvestigationPhase = 0;
          this.Student.InvestigationTimer = 0f;
          this.Student.Investigating = true;
          this.Student.DiscCheck = true;
          this.Student.Routine = false;
          this.Student.ReadPhase = 0;
          this.Student.OccultBook.SetActive(false);
          this.Student.SmartPhone.SetActive(false);
          this.Student.Phone.SetActive(false);
          this.Student.Pen.SetActive(false);
        }
        this.Distracted = true;
      }
    }
  }

  // Token: 0x040009A7 RID: 2471
  public GameObject EmptyGameObject;

  // Token: 0x040009A8 RID: 2472
  public GameObject Giggle;

  // Token: 0x040009A9 RID: 2473
  public StudentScript Student;

  // Token: 0x040009AA RID: 2474
  public bool Distracted;

  // Token: 0x040009AB RID: 2475
  public int Frame;
}