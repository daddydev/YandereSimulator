using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200011B RID: 283
public class JsonScript : MonoBehaviour {

  // Token: 0x06000579 RID: 1401 RVA: 0x0004B1A0 File Offset: 0x000495A0
  private void Start() {
    this.students = StudentJson.LoadFromJson(StudentJson.FilePath);
    if (SceneManager.GetActiveScene().name == "SchoolScene") {
      this.topics = TopicJson.LoadFromJson(TopicJson.FilePath);
      StudentManagerScript studentManagerScript = UnityEngine.Object.FindObjectOfType<StudentManagerScript>();
      this.ReplaceDeadTeachers(studentManagerScript.FirstNames, studentManagerScript.LastNames);
    } else if (SceneManager.GetActiveScene().name == "CreditsScene") {
      this.credits = CreditJson.LoadFromJson(CreditJson.FilePath);
    }
  }

  // Token: 0x170000D3 RID: 211
  // (get) Token: 0x0600057A RID: 1402 RVA: 0x0004B232 File Offset: 0x00049632
  public StudentJson[] Students {
    get {
      return this.students;
    }
  }

  // Token: 0x170000D4 RID: 212
  // (get) Token: 0x0600057B RID: 1403 RVA: 0x0004B23A File Offset: 0x0004963A
  public CreditJson[] Credits {
    get {
      return this.credits;
    }
  }

  // Token: 0x170000D5 RID: 213
  // (get) Token: 0x0600057C RID: 1404 RVA: 0x0004B242 File Offset: 0x00049642
  public TopicJson[] Topics {
    get {
      return this.topics;
    }
  }

  // Token: 0x0600057D RID: 1405 RVA: 0x0004B24C File Offset: 0x0004964C
  private void ReplaceDeadTeachers(string[] firstNames, string[] lastNames) {
    for (int i = 90; i < 101; i++) {
      if (StudentGlobals.GetStudentDead(i)) {
        StudentGlobals.SetStudentReplaced(i, true);
        StudentGlobals.SetStudentDead(i, false);
        string value = firstNames[UnityEngine.Random.Range(0, firstNames.Length)] + " " + lastNames[UnityEngine.Random.Range(0, lastNames.Length)];
        StudentGlobals.SetStudentName(i, value);
        StudentGlobals.SetStudentBustSize(i, UnityEngine.Random.Range(1f, 1.5f));
        StudentGlobals.SetStudentHairstyle(i, UnityEngine.Random.Range(1, 8).ToString());
        float r = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);
        StudentGlobals.SetStudentColor(i, new Color(r, g, b));
        r = UnityEngine.Random.Range(0f, 1f);
        g = UnityEngine.Random.Range(0f, 1f);
        b = UnityEngine.Random.Range(0f, 1f);
        StudentGlobals.SetStudentEyeColor(i, new Color(r, g, b));
        StudentGlobals.SetStudentAccessory(i, UnityEngine.Random.Range(1, 7).ToString());
      }
    }
    for (int j = 90; j < 101; j++) {
      if (StudentGlobals.GetStudentReplaced(j)) {
        StudentJson studentJson = this.students[j];
        studentJson.Name = StudentGlobals.GetStudentName(j);
        studentJson.BreastSize = StudentGlobals.GetStudentBustSize(j);
        studentJson.Hairstyle = StudentGlobals.GetStudentHairstyle(j);
        studentJson.Accessory = StudentGlobals.GetStudentAccessory(j);
        if (j == 97) {
          studentJson.Accessory = "7";
        }
        if (j == 90) {
          studentJson.Accessory = "8";
        }
      }
    }
  }

  // Token: 0x04000CFC RID: 3324
  [SerializeField]
  private StudentJson[] students;

  // Token: 0x04000CFD RID: 3325
  [SerializeField]
  private CreditJson[] credits;

  // Token: 0x04000CFE RID: 3326
  [SerializeField]
  private TopicJson[] topics;
}