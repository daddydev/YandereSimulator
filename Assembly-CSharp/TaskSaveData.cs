using System;
using System.Collections.Generic;

// Token: 0x0200019F RID: 415
[Serializable]
public class TaskSaveData {

  // Token: 0x06000750 RID: 1872 RVA: 0x0006F0F4 File Offset: 0x0006D4F4
  public static TaskSaveData ReadFromGlobals() {
    TaskSaveData taskSaveData = new TaskSaveData();
    foreach (int num in TaskGlobals.KeysOfKittenPhoto()) {
      if (TaskGlobals.GetKittenPhoto(num)) {
        taskSaveData.kittenPhoto.Add(num);
      }
    }
    foreach (int num2 in TaskGlobals.KeysOfTaskStatus()) {
      taskSaveData.taskStatus.Add(num2, TaskGlobals.GetTaskStatus(num2));
    }
    return taskSaveData;
  }

  // Token: 0x06000751 RID: 1873 RVA: 0x0006F17C File Offset: 0x0006D57C
  public static void WriteToGlobals(TaskSaveData data) {
    foreach (int photoID in data.kittenPhoto) {
      TaskGlobals.SetKittenPhoto(photoID, true);
    }
    foreach (KeyValuePair<int, int> keyValuePair in data.taskStatus) {
      TaskGlobals.SetTaskStatus(keyValuePair.Key, keyValuePair.Value);
    }
  }

  // Token: 0x04001291 RID: 4753
  public IntHashSet kittenPhoto = new IntHashSet();

  // Token: 0x04001292 RID: 4754
  public IntAndIntDictionary taskStatus = new IntAndIntDictionary();
}