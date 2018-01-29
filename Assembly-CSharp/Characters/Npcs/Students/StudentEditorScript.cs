using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000098 RID: 152
public class StudentEditorScript : MonoBehaviour {

  // Token: 0x06000260 RID: 608 RVA: 0x00031DA8 File Offset: 0x000301A8
  private void Awake() {
    Dictionary<string, object>[] array = EditorManagerScript.DeserializeJson("Students.json");
    this.students = new StudentEditorScript.StudentData[array.Length];
    for (int i = 0; i < this.students.Length; i++) {
      this.students[i] = StudentEditorScript.StudentData.Deserialize(array[i]);
    }
    Array.Sort<StudentEditorScript.StudentData>(this.students, (StudentEditorScript.StudentData a, StudentEditorScript.StudentData b) => a.id - b.id);
    for (int j = 0; j < this.students.Length; j++) {
      StudentEditorScript.StudentData studentData = this.students[j];
      UILabel uilabel = UnityEngine.Object.Instantiate<UILabel>(this.studentLabelTemplate, this.listLabelsOrigin);
      uilabel.text = "(" + studentData.id.ToString() + ") " + studentData.name;
      Transform transform = uilabel.transform;
      transform.localPosition = new Vector3(transform.localPosition.x + (float)(uilabel.width / 2), transform.localPosition.y - (float)(j * uilabel.height), transform.localPosition.z);
      uilabel.gameObject.SetActive(true);
    }
    this.studentIndex = 0;
    this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
    this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
  }

  // Token: 0x06000261 RID: 609 RVA: 0x00031F18 File Offset: 0x00030318
  private void OnEnable() {
    this.promptBar.Label[0].text = string.Empty;
    this.promptBar.Label[1].text = "Back";
    this.promptBar.UpdateButtons();
  }

  // Token: 0x06000262 RID: 610 RVA: 0x00031F54 File Offset: 0x00030354
  private static ScheduleBlock[] DeserializeScheduleBlocks(Dictionary<string, object> dict) {
    string[] array = TFUtils.LoadString(dict, "ScheduleTime").Split(new char[]
    {
      '_'
    });
    string[] array2 = TFUtils.LoadString(dict, "ScheduleDestination").Split(new char[]
    {
      '_'
    });
    string[] array3 = TFUtils.LoadString(dict, "ScheduleAction").Split(new char[]
    {
      '_'
    });
    ScheduleBlock[] array4 = new ScheduleBlock[array.Length];
    for (int i = 0; i < array4.Length; i++) {
      array4[i] = new ScheduleBlock(float.Parse(array[i]), array2[i], array3[i]);
    }
    return array4;
  }

  // Token: 0x06000263 RID: 611 RVA: 0x00031FF4 File Offset: 0x000303F4
  private static string GetStudentText(StudentEditorScript.StudentData data) {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(string.Concat(new object[]
    {
      data.name,
      " (",
      data.id,
      "):\n"
    }));
    stringBuilder.Append("- Gender: " + ((!data.isMale) ? "Female" : "Male") + "\n");
    stringBuilder.Append("- Class: " + data.attendanceInfo.classNumber + "\n");
    stringBuilder.Append("- Seat: " + data.attendanceInfo.seatNumber + "\n");
    stringBuilder.Append("- Club: " + data.attendanceInfo.club + "\n");
    stringBuilder.Append("- Persona: " + data.personality.persona + "\n");
    stringBuilder.Append("- Crush: " + data.personality.crush + "\n");
    stringBuilder.Append("- Breast size: " + data.cosmetics.breastSize + "\n");
    stringBuilder.Append("- Strength: " + data.stats.strength + "\n");
    stringBuilder.Append("- Hairstyle: " + data.cosmetics.hairstyle + "\n");
    stringBuilder.Append("- Color: " + data.cosmetics.color + "\n");
    stringBuilder.Append("- Eyes: " + data.cosmetics.eyes + "\n");
    stringBuilder.Append("- Stockings: " + data.cosmetics.stockings + "\n");
    stringBuilder.Append("- Accessory: " + data.cosmetics.accessory + "\n");
    stringBuilder.Append("- Schedule blocks: ");
    foreach (ScheduleBlock scheduleBlock in data.scheduleBlocks) {
      stringBuilder.Append(string.Concat(new object[]
      {
        "[",
        scheduleBlock.time,
        ", ",
        scheduleBlock.destination,
        ", ",
        scheduleBlock.action,
        "]"
      }));
    }
    stringBuilder.Append("\n");
    stringBuilder.Append("- Info: \"" + data.info + "\"\n");
    return stringBuilder.ToString();
  }

  // Token: 0x06000264 RID: 612 RVA: 0x000322CC File Offset: 0x000306CC
  private void HandleInput() {
    bool buttonDown = Input.GetButtonDown("B");
    if (buttonDown) {
      this.mainPanel.gameObject.SetActive(true);
      this.studentPanel.gameObject.SetActive(false);
    }
    int num = 0;
    int num2 = this.students.Length - 1;
    bool tappedUp = this.inputManager.TappedUp;
    bool tappedDown = this.inputManager.TappedDown;
    if (tappedUp) {
      this.studentIndex = ((this.studentIndex <= num) ? num2 : (this.studentIndex - 1));
    } else if (tappedDown) {
      this.studentIndex = ((this.studentIndex >= num2) ? num : (this.studentIndex + 1));
    }
    bool flag = tappedUp || tappedDown;
    if (flag) {
      this.bodyLabel.text = StudentEditorScript.GetStudentText(this.students[this.studentIndex]);
    }
  }

  // Token: 0x06000265 RID: 613 RVA: 0x000323B5 File Offset: 0x000307B5
  private void Update() {
    this.HandleInput();
  }

  // Token: 0x040007F6 RID: 2038
  [SerializeField]
  private UIPanel mainPanel;

  // Token: 0x040007F7 RID: 2039
  [SerializeField]
  private UIPanel studentPanel;

  // Token: 0x040007F8 RID: 2040
  [SerializeField]
  private UILabel bodyLabel;

  // Token: 0x040007F9 RID: 2041
  [SerializeField]
  private Transform listLabelsOrigin;

  // Token: 0x040007FA RID: 2042
  [SerializeField]
  private UILabel studentLabelTemplate;

  // Token: 0x040007FB RID: 2043
  [SerializeField]
  private PromptBarScript promptBar;

  // Token: 0x040007FC RID: 2044
  private StudentEditorScript.StudentData[] students;

  // Token: 0x040007FD RID: 2045
  private int studentIndex;

  // Token: 0x040007FE RID: 2046
  private InputManagerScript inputManager;

  // Token: 0x02000099 RID: 153
  private class StudentAttendanceInfo {

    // Token: 0x06000268 RID: 616 RVA: 0x000323D4 File Offset: 0x000307D4
    public static StudentEditorScript.StudentAttendanceInfo Deserialize(Dictionary<string, object> dict) {
      return new StudentEditorScript.StudentAttendanceInfo {
        classNumber = TFUtils.LoadInt(dict, "Class"),
        seatNumber = TFUtils.LoadInt(dict, "Seat"),
        club = TFUtils.LoadInt(dict, "Club")
      };
    }

    // Token: 0x04000800 RID: 2048
    public int classNumber;

    // Token: 0x04000801 RID: 2049
    public int seatNumber;

    // Token: 0x04000802 RID: 2050
    public int club;
  }

  // Token: 0x0200009A RID: 154
  private class StudentPersonality {

    // Token: 0x0600026A RID: 618 RVA: 0x00032424 File Offset: 0x00030824
    public static StudentEditorScript.StudentPersonality Deserialize(Dictionary<string, object> dict) {
      return new StudentEditorScript.StudentPersonality {
        persona = (PersonaType)TFUtils.LoadInt(dict, "Persona"),
        crush = TFUtils.LoadInt(dict, "Crush")
      };
    }

    // Token: 0x04000803 RID: 2051
    public PersonaType persona;

    // Token: 0x04000804 RID: 2052
    public int crush;
  }

  // Token: 0x0200009B RID: 155
  private class StudentStats {

    // Token: 0x0600026C RID: 620 RVA: 0x00032464 File Offset: 0x00030864
    public static StudentEditorScript.StudentStats Deserialize(Dictionary<string, object> dict) {
      return new StudentEditorScript.StudentStats {
        strength = TFUtils.LoadInt(dict, "Strength")
      };
    }

    // Token: 0x04000805 RID: 2053
    public int strength;
  }

  // Token: 0x0200009C RID: 156
  private class StudentCosmetics {

    // Token: 0x0600026E RID: 622 RVA: 0x00032494 File Offset: 0x00030894
    public static StudentEditorScript.StudentCosmetics Deserialize(Dictionary<string, object> dict) {
      return new StudentEditorScript.StudentCosmetics {
        breastSize = TFUtils.LoadFloat(dict, "BreastSize"),
        hairstyle = TFUtils.LoadString(dict, "Hairstyle"),
        color = TFUtils.LoadString(dict, "Color"),
        eyes = TFUtils.LoadString(dict, "Eyes"),
        stockings = TFUtils.LoadString(dict, "Stockings"),
        accessory = TFUtils.LoadString(dict, "Accessory")
      };
    }

    // Token: 0x04000806 RID: 2054
    public float breastSize;

    // Token: 0x04000807 RID: 2055
    public string hairstyle;

    // Token: 0x04000808 RID: 2056
    public string color;

    // Token: 0x04000809 RID: 2057
    public string eyes;

    // Token: 0x0400080A RID: 2058
    public string stockings;

    // Token: 0x0400080B RID: 2059
    public string accessory;
  }

  // Token: 0x0200009D RID: 157
  private class StudentData {

    // Token: 0x06000270 RID: 624 RVA: 0x00032518 File Offset: 0x00030918
    public static StudentEditorScript.StudentData Deserialize(Dictionary<string, object> dict) {
      return new StudentEditorScript.StudentData {
        id = TFUtils.LoadInt(dict, "ID"),
        name = TFUtils.LoadString(dict, "Name"),
        isMale = (TFUtils.LoadInt(dict, "Gender") == 1),
        attendanceInfo = StudentEditorScript.StudentAttendanceInfo.Deserialize(dict),
        personality = StudentEditorScript.StudentPersonality.Deserialize(dict),
        stats = StudentEditorScript.StudentStats.Deserialize(dict),
        cosmetics = StudentEditorScript.StudentCosmetics.Deserialize(dict),
        scheduleBlocks = StudentEditorScript.DeserializeScheduleBlocks(dict),
        info = TFUtils.LoadString(dict, "Info")
      };
    }

    // Token: 0x0400080C RID: 2060
    public int id;

    // Token: 0x0400080D RID: 2061
    public string name;

    // Token: 0x0400080E RID: 2062
    public bool isMale;

    // Token: 0x0400080F RID: 2063
    public StudentEditorScript.StudentAttendanceInfo attendanceInfo;

    // Token: 0x04000810 RID: 2064
    public StudentEditorScript.StudentPersonality personality;

    // Token: 0x04000811 RID: 2065
    public StudentEditorScript.StudentStats stats;

    // Token: 0x04000812 RID: 2066
    public StudentEditorScript.StudentCosmetics cosmetics;

    // Token: 0x04000813 RID: 2067
    public ScheduleBlock[] scheduleBlocks;

    // Token: 0x04000814 RID: 2068
    public string info;
  }
}