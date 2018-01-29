using System;
using System.Xml.Serialization;

// Token: 0x020001A1 RID: 417
[XmlRoot]
[Serializable]
public class SaveFileData {

  // Token: 0x04001295 RID: 4757
  public ApplicationSaveData applicationData = new ApplicationSaveData();

  // Token: 0x04001296 RID: 4758
  public ClassSaveData classData = new ClassSaveData();

  // Token: 0x04001297 RID: 4759
  public ClubSaveData clubData = new ClubSaveData();

  // Token: 0x04001298 RID: 4760
  public CollectibleSaveData collectibleData = new CollectibleSaveData();

  // Token: 0x04001299 RID: 4761
  public ConversationSaveData conversationData = new ConversationSaveData();

  // Token: 0x0400129A RID: 4762
  public DateSaveData dateData = new DateSaveData();

  // Token: 0x0400129B RID: 4763
  public DatingSaveData datingData = new DatingSaveData();

  // Token: 0x0400129C RID: 4764
  public EventSaveData eventData = new EventSaveData();

  // Token: 0x0400129D RID: 4765
  public GameSaveData gameData = new GameSaveData();

  // Token: 0x0400129E RID: 4766
  public HomeSaveData homeData = new HomeSaveData();

  // Token: 0x0400129F RID: 4767
  public MissionModeSaveData missionModeData = new MissionModeSaveData();

  // Token: 0x040012A0 RID: 4768
  public OptionSaveData optionData = new OptionSaveData();

  // Token: 0x040012A1 RID: 4769
  public PlayerSaveData playerData = new PlayerSaveData();

  // Token: 0x040012A2 RID: 4770
  public PoseModeSaveData poseModeData = new PoseModeSaveData();

  // Token: 0x040012A3 RID: 4771
  public SaveFileSaveData saveFileData = new SaveFileSaveData();

  // Token: 0x040012A4 RID: 4772
  public SchemeSaveData schemeData = new SchemeSaveData();

  // Token: 0x040012A5 RID: 4773
  public SchoolSaveData schoolData = new SchoolSaveData();

  // Token: 0x040012A6 RID: 4774
  public SenpaiSaveData senpaiData = new SenpaiSaveData();

  // Token: 0x040012A7 RID: 4775
  public StudentSaveData studentData = new StudentSaveData();

  // Token: 0x040012A8 RID: 4776
  public TaskSaveData taskData = new TaskSaveData();

  // Token: 0x040012A9 RID: 4777
  public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}