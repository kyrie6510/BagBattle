// automatically generated by the FlatBuffers compiler, do not modify

import java.nio.*;
import java.lang.*;
import java.util.*;
import com.google.flatbuffers.*;

@SuppressWarnings("unused")
public final class TablePropItemRowData extends Table {
  public static void ValidateVersion() { Constants.FLATBUFFERS_1_12_0(); }
  public static TablePropItemRowData getRootAsTablePropItemRowData(ByteBuffer _bb) { return getRootAsTablePropItemRowData(_bb, new TablePropItemRowData()); }
  public static TablePropItemRowData getRootAsTablePropItemRowData(ByteBuffer _bb, TablePropItemRowData obj) { _bb.order(ByteOrder.LITTLE_ENDIAN); return (obj.__assign(_bb.getInt(_bb.position()) + _bb.position(), _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __reset(_i, _bb); }
  public TablePropItemRowData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public short Id() { int o = __offset(4); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public String Name() { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; }
  public ByteBuffer NameAsByteBuffer() { return __vector_as_bytebuffer(6, 1); }
  public ByteBuffer NameInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 6, 1); }
  public short PropType() { int o = __offset(8); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public int ItemGridType(int j) { int o = __offset(10); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int ItemGridTypeLength() { int o = __offset(10); return o != 0 ? __vector_len(o) : 0; }
  public IntVector ItemGridTypeVector() { return ItemGridTypeVector(new IntVector()); }
  public IntVector ItemGridTypeVector(IntVector obj) { int o = __offset(10); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer ItemGridTypeAsByteBuffer() { return __vector_as_bytebuffer(10, 4); }
  public ByteBuffer ItemGridTypeInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 10, 4); }
  public float Power() { int o = __offset(12); return o != 0 ? bb.getFloat(o + bb_pos) : 0.0f; }
  public int Rate() { int o = __offset(14); return o != 0 ? bb.getInt(o + bb_pos) : 0; }
  public float Interval() { int o = __offset(16); return o != 0 ? bb.getFloat(o + bb_pos) : 0.0f; }
  public int Damage(int j) { int o = __offset(18); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int DamageLength() { int o = __offset(18); return o != 0 ? __vector_len(o) : 0; }
  public IntVector DamageVector() { return DamageVector(new IntVector()); }
  public IntVector DamageVector(IntVector obj) { int o = __offset(18); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer DamageAsByteBuffer() { return __vector_as_bytebuffer(18, 4); }
  public ByteBuffer DamageInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 18, 4); }
  public short Cost() { int o = __offset(20); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public short Width() { int o = __offset(22); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public short Height() { int o = __offset(24); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public int TarStarType(int j) { int o = __offset(26); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int TarStarTypeLength() { int o = __offset(26); return o != 0 ? __vector_len(o) : 0; }
  public IntVector TarStarTypeVector() { return TarStarTypeVector(new IntVector()); }
  public IntVector TarStarTypeVector(IntVector obj) { int o = __offset(26); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer TarStarTypeAsByteBuffer() { return __vector_as_bytebuffer(26, 4); }
  public ByteBuffer TarStarTypeInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 26, 4); }
  public int ExTarStarId(int j) { int o = __offset(28); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int ExTarStarIdLength() { int o = __offset(28); return o != 0 ? __vector_len(o) : 0; }
  public IntVector ExTarStarIdVector() { return ExTarStarIdVector(new IntVector()); }
  public IntVector ExTarStarIdVector(IntVector obj) { int o = __offset(28); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer ExTarStarIdAsByteBuffer() { return __vector_as_bytebuffer(28, 4); }
  public ByteBuffer ExTarStarIdInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 28, 4); }
  public int ListenTarget(int j) { int o = __offset(30); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int ListenTargetLength() { int o = __offset(30); return o != 0 ? __vector_len(o) : 0; }
  public IntVector ListenTargetVector() { return ListenTargetVector(new IntVector()); }
  public IntVector ListenTargetVector(IntVector obj) { int o = __offset(30); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer ListenTargetAsByteBuffer() { return __vector_as_bytebuffer(30, 4); }
  public ByteBuffer ListenTargetInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 30, 4); }
  public int ListenType(int j) { int o = __offset(32); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int ListenTypeLength() { int o = __offset(32); return o != 0 ? __vector_len(o) : 0; }
  public IntVector ListenTypeVector() { return ListenTypeVector(new IntVector()); }
  public IntVector ListenTypeVector(IntVector obj) { int o = __offset(32); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer ListenTypeAsByteBuffer() { return __vector_as_bytebuffer(32, 4); }
  public ByteBuffer ListenTypeInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 32, 4); }
  public int ListenValue(int j) { int o = __offset(34); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int ListenValueLength() { int o = __offset(34); return o != 0 ? __vector_len(o) : 0; }
  public IntVector ListenValueVector() { return ListenValueVector(new IntVector()); }
  public IntVector ListenValueVector(IntVector obj) { int o = __offset(34); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer ListenValueAsByteBuffer() { return __vector_as_bytebuffer(34, 4); }
  public ByteBuffer ListenValueInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 34, 4); }
  public int EffectId(int j) { int o = __offset(36); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int EffectIdLength() { int o = __offset(36); return o != 0 ? __vector_len(o) : 0; }
  public IntVector EffectIdVector() { return EffectIdVector(new IntVector()); }
  public IntVector EffectIdVector(IntVector obj) { int o = __offset(36); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer EffectIdAsByteBuffer() { return __vector_as_bytebuffer(36, 4); }
  public ByteBuffer EffectIdInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 36, 4); }
  public int EffectOfListen(int j) { int o = __offset(38); return o != 0 ? bb.getInt(__vector(o) + j * 4) : 0; }
  public int EffectOfListenLength() { int o = __offset(38); return o != 0 ? __vector_len(o) : 0; }
  public IntVector EffectOfListenVector() { return EffectOfListenVector(new IntVector()); }
  public IntVector EffectOfListenVector(IntVector obj) { int o = __offset(38); return o != 0 ? obj.__assign(__vector(o), bb) : null; }
  public ByteBuffer EffectOfListenAsByteBuffer() { return __vector_as_bytebuffer(38, 4); }
  public ByteBuffer EffectOfListenInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 38, 4); }
  public short UIWidth() { int o = __offset(40); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public short UIHeight() { int o = __offset(42); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public String EffectDes() { int o = __offset(44); return o != 0 ? __string(o + bb_pos) : null; }
  public ByteBuffer EffectDesAsByteBuffer() { return __vector_as_bytebuffer(44, 1); }
  public ByteBuffer EffectDesInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 44, 1); }
  public String TexturePath() { int o = __offset(46); return o != 0 ? __string(o + bb_pos) : null; }
  public ByteBuffer TexturePathAsByteBuffer() { return __vector_as_bytebuffer(46, 1); }
  public ByteBuffer TexturePathInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 46, 1); }

  public static int createTablePropItemRowData(FlatBufferBuilder builder,
      short Id,
      int NameOffset,
      short PropType,
      int ItemGridTypeOffset,
      float Power,
      int Rate,
      float Interval,
      int DamageOffset,
      short Cost,
      short Width,
      short Height,
      int TarStarTypeOffset,
      int ExTarStarIdOffset,
      int ListenTargetOffset,
      int ListenTypeOffset,
      int ListenValueOffset,
      int EffectIdOffset,
      int EffectOfListenOffset,
      short UIWidth,
      short UIHeight,
      int EffectDesOffset,
      int TexturePathOffset) {
    builder.startTable(22);
    TablePropItemRowData.addTexturePath(builder, TexturePathOffset);
    TablePropItemRowData.addEffectDes(builder, EffectDesOffset);
    TablePropItemRowData.addEffectOfListen(builder, EffectOfListenOffset);
    TablePropItemRowData.addEffectId(builder, EffectIdOffset);
    TablePropItemRowData.addListenValue(builder, ListenValueOffset);
    TablePropItemRowData.addListenType(builder, ListenTypeOffset);
    TablePropItemRowData.addListenTarget(builder, ListenTargetOffset);
    TablePropItemRowData.addExTarStarId(builder, ExTarStarIdOffset);
    TablePropItemRowData.addTarStarType(builder, TarStarTypeOffset);
    TablePropItemRowData.addDamage(builder, DamageOffset);
    TablePropItemRowData.addInterval(builder, Interval);
    TablePropItemRowData.addRate(builder, Rate);
    TablePropItemRowData.addPower(builder, Power);
    TablePropItemRowData.addItemGridType(builder, ItemGridTypeOffset);
    TablePropItemRowData.addName(builder, NameOffset);
    TablePropItemRowData.addUIHeight(builder, UIHeight);
    TablePropItemRowData.addUIWidth(builder, UIWidth);
    TablePropItemRowData.addHeight(builder, Height);
    TablePropItemRowData.addWidth(builder, Width);
    TablePropItemRowData.addCost(builder, Cost);
    TablePropItemRowData.addPropType(builder, PropType);
    TablePropItemRowData.addId(builder, Id);
    return TablePropItemRowData.endTablePropItemRowData(builder);
  }

  public static void startTablePropItemRowData(FlatBufferBuilder builder) { builder.startTable(22); }
  public static void addId(FlatBufferBuilder builder, short Id) { builder.addShort(0, Id, 0); }
  public static void addName(FlatBufferBuilder builder, int NameOffset) { builder.addOffset(1, NameOffset, 0); }
  public static void addPropType(FlatBufferBuilder builder, short PropType) { builder.addShort(2, PropType, 0); }
  public static void addItemGridType(FlatBufferBuilder builder, int ItemGridTypeOffset) { builder.addOffset(3, ItemGridTypeOffset, 0); }
  public static int createItemGridTypeVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startItemGridTypeVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addPower(FlatBufferBuilder builder, float Power) { builder.addFloat(4, Power, 0.0f); }
  public static void addRate(FlatBufferBuilder builder, int Rate) { builder.addInt(5, Rate, 0); }
  public static void addInterval(FlatBufferBuilder builder, float Interval) { builder.addFloat(6, Interval, 0.0f); }
  public static void addDamage(FlatBufferBuilder builder, int DamageOffset) { builder.addOffset(7, DamageOffset, 0); }
  public static int createDamageVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startDamageVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addCost(FlatBufferBuilder builder, short Cost) { builder.addShort(8, Cost, 0); }
  public static void addWidth(FlatBufferBuilder builder, short Width) { builder.addShort(9, Width, 0); }
  public static void addHeight(FlatBufferBuilder builder, short Height) { builder.addShort(10, Height, 0); }
  public static void addTarStarType(FlatBufferBuilder builder, int TarStarTypeOffset) { builder.addOffset(11, TarStarTypeOffset, 0); }
  public static int createTarStarTypeVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startTarStarTypeVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addExTarStarId(FlatBufferBuilder builder, int ExTarStarIdOffset) { builder.addOffset(12, ExTarStarIdOffset, 0); }
  public static int createExTarStarIdVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startExTarStarIdVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addListenTarget(FlatBufferBuilder builder, int ListenTargetOffset) { builder.addOffset(13, ListenTargetOffset, 0); }
  public static int createListenTargetVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startListenTargetVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addListenType(FlatBufferBuilder builder, int ListenTypeOffset) { builder.addOffset(14, ListenTypeOffset, 0); }
  public static int createListenTypeVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startListenTypeVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addListenValue(FlatBufferBuilder builder, int ListenValueOffset) { builder.addOffset(15, ListenValueOffset, 0); }
  public static int createListenValueVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startListenValueVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addEffectId(FlatBufferBuilder builder, int EffectIdOffset) { builder.addOffset(16, EffectIdOffset, 0); }
  public static int createEffectIdVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startEffectIdVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addEffectOfListen(FlatBufferBuilder builder, int EffectOfListenOffset) { builder.addOffset(17, EffectOfListenOffset, 0); }
  public static int createEffectOfListenVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addInt(data[i]); return builder.endVector(); }
  public static void startEffectOfListenVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static void addUIWidth(FlatBufferBuilder builder, short UIWidth) { builder.addShort(18, UIWidth, 0); }
  public static void addUIHeight(FlatBufferBuilder builder, short UIHeight) { builder.addShort(19, UIHeight, 0); }
  public static void addEffectDes(FlatBufferBuilder builder, int EffectDesOffset) { builder.addOffset(20, EffectDesOffset, 0); }
  public static void addTexturePath(FlatBufferBuilder builder, int TexturePathOffset) { builder.addOffset(21, TexturePathOffset, 0); }
  public static int endTablePropItemRowData(FlatBufferBuilder builder) {
    int o = builder.endTable();
    return o;
  }

  public static final class Vector extends BaseVector {
    public Vector __assign(int _vector, int _element_size, ByteBuffer _bb) { __reset(_vector, _element_size, _bb); return this; }

    public TablePropItemRowData get(int j) { return get(new TablePropItemRowData(), j); }
    public TablePropItemRowData get(TablePropItemRowData obj, int j) {  return obj.__assign(__indirect(__element(j), bb), bb); }
  }
}

@SuppressWarnings("unused")
public final class TablePropItem extends Table {
  public static void ValidateVersion() { Constants.FLATBUFFERS_1_12_0(); }
  public static TablePropItem getRootAsTablePropItem(ByteBuffer _bb) { return getRootAsTablePropItem(_bb, new TablePropItem()); }
  public static TablePropItem getRootAsTablePropItem(ByteBuffer _bb, TablePropItem obj) { _bb.order(ByteOrder.LITTLE_ENDIAN); return (obj.__assign(_bb.getInt(_bb.position()) + _bb.position(), _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __reset(_i, _bb); }
  public TablePropItem __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public TablePropItemRowData datalist(int j) { return datalist(new TablePropItemRowData(), j); }
  public TablePropItemRowData datalist(TablePropItemRowData obj, int j) { int o = __offset(4); return o != 0 ? obj.__assign(__indirect(__vector(o) + j * 4), bb) : null; }
  public int datalistLength() { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; }
  public TablePropItemRowData.Vector datalistVector() { return datalistVector(new TablePropItemRowData.Vector()); }
  public TablePropItemRowData.Vector datalistVector(TablePropItemRowData.Vector obj) { int o = __offset(4); return o != 0 ? obj.__assign(__vector(o), 4, bb) : null; }

  public static int createTablePropItem(FlatBufferBuilder builder,
      int datalistOffset) {
    builder.startTable(1);
    TablePropItem.addDatalist(builder, datalistOffset);
    return TablePropItem.endTablePropItem(builder);
  }

  public static void startTablePropItem(FlatBufferBuilder builder) { builder.startTable(1); }
  public static void addDatalist(FlatBufferBuilder builder, int datalistOffset) { builder.addOffset(0, datalistOffset, 0); }
  public static int createDatalistVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addOffset(data[i]); return builder.endVector(); }
  public static void startDatalistVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static int endTablePropItem(FlatBufferBuilder builder) {
    int o = builder.endTable();
    return o;
  }

  public static final class Vector extends BaseVector {
    public Vector __assign(int _vector, int _element_size, ByteBuffer _bb) { __reset(_vector, _element_size, _bb); return this; }

    public TablePropItem get(int j) { return get(new TablePropItem(), j); }
    public TablePropItem get(TablePropItem obj, int j) {  return obj.__assign(__indirect(__element(j), bb), bb); }
  }
}

