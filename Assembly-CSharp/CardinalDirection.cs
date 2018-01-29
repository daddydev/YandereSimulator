// Token: 0x020001F2 RID: 498
public static class CardinalDirection {

  // Token: 0x060008DE RID: 2270 RVA: 0x0009E576 File Offset: 0x0009C976
  public static Direction Reversed(Direction direction) {
    if (direction == Direction.North) {
      return Direction.South;
    }
    if (direction == Direction.East) {
      return Direction.West;
    }
    if (direction == Direction.South) {
      return Direction.North;
    }
    return Direction.East;
  }

  // Token: 0x060008DF RID: 2271 RVA: 0x0009E593 File Offset: 0x0009C993
  public static Direction LeftPerp(Direction direction) {
    if (direction == Direction.North) {
      return Direction.West;
    }
    if (direction == Direction.East) {
      return Direction.North;
    }
    if (direction == Direction.South) {
      return Direction.East;
    }
    return Direction.South;
  }

  // Token: 0x060008E0 RID: 2272 RVA: 0x0009E5B0 File Offset: 0x0009C9B0
  public static Direction RightPerp(Direction direction) {
    if (direction == Direction.North) {
      return Direction.East;
    }
    if (direction == Direction.East) {
      return Direction.South;
    }
    if (direction == Direction.South) {
      return Direction.West;
    }
    return Direction.North;
  }
}