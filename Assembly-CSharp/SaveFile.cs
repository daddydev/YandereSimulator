using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020001A2 RID: 418
[Serializable]
public class SaveFile {

  // Token: 0x06000756 RID: 1878 RVA: 0x0006F376 File Offset: 0x0006D776
  public SaveFile(int index) {
    this.data = new SaveFileData();
    this.index = index;
  }

  // Token: 0x06000757 RID: 1879 RVA: 0x0006F390 File Offset: 0x0006D790
  private SaveFile(SaveFileData data, int index) {
    this.data = data;
    this.index = index;
  }

  // Token: 0x170000E1 RID: 225
  // (get) Token: 0x06000758 RID: 1880 RVA: 0x0006F3A6 File Offset: 0x0006D7A6
  public SaveFileData Data {
    get {
      return this.data;
    }
  }

  // Token: 0x06000759 RID: 1881 RVA: 0x0006F3AE File Offset: 0x0006D7AE
  public static string GetSaveFolderPath(int index) {
    return Path.Combine(SaveFile.SavesPath, "Save" + index.ToString());
  }

  // Token: 0x0600075A RID: 1882 RVA: 0x0006F3D1 File Offset: 0x0006D7D1
  private static string GetFullSaveFileName(int index) {
    return Path.Combine(SaveFile.GetSaveFolderPath(index), SaveFile.SaveName);
  }

  // Token: 0x170000E2 RID: 226
  // (get) Token: 0x0600075B RID: 1883 RVA: 0x0006F3E3 File Offset: 0x0006D7E3
  private static bool SavesFolderExists {
    get {
      return Directory.Exists(SaveFile.SavesPath);
    }
  }

  // Token: 0x0600075C RID: 1884 RVA: 0x0006F3EF File Offset: 0x0006D7EF
  public static bool SaveFolderExists(int index) {
    return Directory.Exists(SaveFile.GetSaveFolderPath(index));
  }

  // Token: 0x0600075D RID: 1885 RVA: 0x0006F3FC File Offset: 0x0006D7FC
  public static bool Exists(int index) {
    return File.Exists(SaveFile.GetFullSaveFileName(index));
  }

  // Token: 0x0600075E RID: 1886 RVA: 0x0006F40C File Offset: 0x0006D80C
  public static SaveFile Load(int index) {
    SaveFile result;
    try {
      string s = File.ReadAllText(SaveFile.GetFullSaveFileName(index));
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
      MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
      SaveFileData saveFileData = (SaveFileData)xmlSerializer.Deserialize(stream);
      result = new SaveFile(saveFileData, index);
    } catch (Exception ex) {
      Debug.LogError(string.Concat(new string[]
      {
        "Loading save file ",
        index.ToString(),
        " failed (",
        ex.ToString(),
        ")."
      }));
      result = null;
    }
    return result;
  }

  // Token: 0x0600075F RID: 1887 RVA: 0x0006F4C0 File Offset: 0x0006D8C0
  public static void Delete(int index) {
    try {
      string fullSaveFileName = SaveFile.GetFullSaveFileName(index);
      File.Delete(fullSaveFileName);
    } catch (Exception ex) {
      Debug.LogError(string.Concat(new string[]
      {
        "Deleting save file ",
        index.ToString(),
        " failed (",
        ex.ToString(),
        ")."
      }));
    }
  }

  // Token: 0x06000760 RID: 1888 RVA: 0x0006F538 File Offset: 0x0006D938
  public void Save() {
    try {
      if (!SaveFile.SavesFolderExists) {
        Directory.CreateDirectory(SaveFile.SavesPath);
      }
      if (!SaveFile.SaveFolderExists(this.index)) {
        Directory.CreateDirectory(SaveFile.GetSaveFolderPath(this.index));
      }
      string fullSaveFileName = SaveFile.GetFullSaveFileName(this.index);
      if (!SaveFile.Exists(this.index)) {
        FileStream fileStream = File.Create(fullSaveFileName);
        fileStream.Dispose();
      }
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
      using (XmlWriter xmlWriter = XmlWriter.Create(fullSaveFileName, new XmlWriterSettings {
        Indent = true,
        IndentChars = "\t"
      })) {
        xmlSerializer.Serialize(xmlWriter, this.data);
      }
    } catch (Exception ex) {
      Debug.LogError(string.Concat(new string[]
      {
        "Saving save file ",
        this.index.ToString(),
        " failed (",
        ex.ToString(),
        ")."
      }));
    }
  }

  // Token: 0x06000761 RID: 1889 RVA: 0x0006F668 File Offset: 0x0006DA68
  public void ReadFromGlobals() {
    this.data.applicationData = ApplicationSaveData.ReadFromGlobals();
    this.data.classData = ClassSaveData.ReadFromGlobals();
    this.data.clubData = ClubSaveData.ReadFromGlobals();
    this.data.collectibleData = CollectibleSaveData.ReadFromGlobals();
    this.data.conversationData = ConversationSaveData.ReadFromGlobals();
    this.data.dateData = DateSaveData.ReadFromGlobals();
    this.data.datingData = DatingSaveData.ReadFromGlobals();
    this.data.eventData = EventSaveData.ReadFromGlobals();
    this.data.gameData = GameSaveData.ReadFromGlobals();
    this.data.homeData = HomeSaveData.ReadFromGlobals();
    this.data.missionModeData = MissionModeSaveData.ReadFromGlobals();
    this.data.optionData = OptionSaveData.ReadFromGlobals();
    this.data.playerData = PlayerSaveData.ReadFromGlobals();
    this.data.poseModeData = PoseModeSaveData.ReadFromGlobals();
    this.data.saveFileData = SaveFileSaveData.ReadFromGlobals();
    this.data.schemeData = SchemeSaveData.ReadFromGlobals();
    this.data.schoolData = SchoolSaveData.ReadFromGlobals();
    this.data.senpaiData = SenpaiSaveData.ReadFromGlobals();
    this.data.studentData = StudentSaveData.ReadFromGlobals();
    this.data.taskData = TaskSaveData.ReadFromGlobals();
    this.data.yanvaniaData = YanvaniaSaveData.ReadFromGlobals();
  }

  // Token: 0x06000762 RID: 1890 RVA: 0x0006F7C8 File Offset: 0x0006DBC8
  public void WriteToGlobals() {
    ApplicationSaveData.WriteToGlobals(this.data.applicationData);
    ClassSaveData.WriteToGlobals(this.data.classData);
    ClubSaveData.WriteToGlobals(this.data.clubData);
    CollectibleSaveData.WriteToGlobals(this.data.collectibleData);
    ConversationSaveData.WriteToGlobals(this.data.conversationData);
    DateSaveData.WriteToGlobals(this.data.dateData);
    DatingSaveData.WriteToGlobals(this.data.datingData);
    EventSaveData.WriteToGlobals(this.data.eventData);
    GameSaveData.WriteToGlobals(this.data.gameData);
    HomeSaveData.WriteToGlobals(this.data.homeData);
    MissionModeSaveData.WriteToGlobals(this.data.missionModeData);
    OptionSaveData.WriteToGlobals(this.data.optionData);
    PlayerSaveData.WriteToGlobals(this.data.playerData);
    PoseModeSaveData.WriteToGlobals(this.data.poseModeData);
    SaveFileSaveData.WriteToGlobals(this.data.saveFileData);
    SchemeSaveData.WriteToGlobals(this.data.schemeData);
    SchoolSaveData.WriteToGlobals(this.data.schoolData);
    SenpaiSaveData.WriteToGlobals(this.data.senpaiData);
    StudentSaveData.WriteToGlobals(this.data.studentData);
    TaskSaveData.WriteToGlobals(this.data.taskData);
    YanvaniaSaveData.WriteToGlobals(this.data.yanvaniaData);
  }

  // Token: 0x040012AA RID: 4778
  [SerializeField]
  private SaveFileData data;

  // Token: 0x040012AB RID: 4779
  [SerializeField]
  private int index;

  // Token: 0x040012AC RID: 4780
  private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "Saves");

  // Token: 0x040012AD RID: 4781
  private static readonly string SaveName = "Save.txt";
}