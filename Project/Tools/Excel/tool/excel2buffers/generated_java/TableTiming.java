// automatically generated by the FlatBuffers compiler, do not modify

import java.nio.*;
import java.lang.*;
import java.util.*;
import com.google.flatbuffers.*;

@SuppressWarnings("unused")
public final class TableTimingRowData extends Table {
  public static void ValidateVersion() { Constants.FLATBUFFERS_1_12_0(); }
  public static TableTimingRowData getRootAsTableTimingRowData(ByteBuffer _bb) { return getRootAsTableTimingRowData(_bb, new TableTimingRowData()); }
  public static TableTimingRowData getRootAsTableTimingRowData(ByteBuffer _bb, TableTimingRowData obj) { _bb.order(ByteOrder.LITTLE_ENDIAN); return (obj.__assign(_bb.getInt(_bb.position()) + _bb.position(), _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __reset(_i, _bb); }
  public TableTimingRowData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public short Id() { int o = __offset(4); return o != 0 ? bb.getShort(o + bb_pos) : 0; }
  public String Name() { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; }
  public ByteBuffer NameAsByteBuffer() { return __vector_as_bytebuffer(6, 1); }
  public ByteBuffer NameInByteBuffer(ByteBuffer _bb) { return __vector_in_bytebuffer(_bb, 6, 1); }
  public short Type() { int o = __offset(8); return o != 0 ? bb.getShort(o + bb_pos) : 0; }

  public static int createTableTimingRowData(FlatBufferBuilder builder,
      short Id,
      int NameOffset,
      short Type) {
    builder.startTable(3);
    TableTimingRowData.addName(builder, NameOffset);
    TableTimingRowData.addType(builder, Type);
    TableTimingRowData.addId(builder, Id);
    return TableTimingRowData.endTableTimingRowData(builder);
  }

  public static void startTableTimingRowData(FlatBufferBuilder builder) { builder.startTable(3); }
  public static void addId(FlatBufferBuilder builder, short Id) { builder.addShort(0, Id, 0); }
  public static void addName(FlatBufferBuilder builder, int NameOffset) { builder.addOffset(1, NameOffset, 0); }
  public static void addType(FlatBufferBuilder builder, short Type) { builder.addShort(2, Type, 0); }
  public static int endTableTimingRowData(FlatBufferBuilder builder) {
    int o = builder.endTable();
    return o;
  }

  public static final class Vector extends BaseVector {
    public Vector __assign(int _vector, int _element_size, ByteBuffer _bb) { __reset(_vector, _element_size, _bb); return this; }

    public TableTimingRowData get(int j) { return get(new TableTimingRowData(), j); }
    public TableTimingRowData get(TableTimingRowData obj, int j) {  return obj.__assign(__indirect(__element(j), bb), bb); }
  }
}

@SuppressWarnings("unused")
public final class TableTiming extends Table {
  public static void ValidateVersion() { Constants.FLATBUFFERS_1_12_0(); }
  public static TableTiming getRootAsTableTiming(ByteBuffer _bb) { return getRootAsTableTiming(_bb, new TableTiming()); }
  public static TableTiming getRootAsTableTiming(ByteBuffer _bb, TableTiming obj) { _bb.order(ByteOrder.LITTLE_ENDIAN); return (obj.__assign(_bb.getInt(_bb.position()) + _bb.position(), _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __reset(_i, _bb); }
  public TableTiming __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public TableTimingRowData datalist(int j) { return datalist(new TableTimingRowData(), j); }
  public TableTimingRowData datalist(TableTimingRowData obj, int j) { int o = __offset(4); return o != 0 ? obj.__assign(__indirect(__vector(o) + j * 4), bb) : null; }
  public int datalistLength() { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; }
  public TableTimingRowData.Vector datalistVector() { return datalistVector(new TableTimingRowData.Vector()); }
  public TableTimingRowData.Vector datalistVector(TableTimingRowData.Vector obj) { int o = __offset(4); return o != 0 ? obj.__assign(__vector(o), 4, bb) : null; }

  public static int createTableTiming(FlatBufferBuilder builder,
      int datalistOffset) {
    builder.startTable(1);
    TableTiming.addDatalist(builder, datalistOffset);
    return TableTiming.endTableTiming(builder);
  }

  public static void startTableTiming(FlatBufferBuilder builder) { builder.startTable(1); }
  public static void addDatalist(FlatBufferBuilder builder, int datalistOffset) { builder.addOffset(0, datalistOffset, 0); }
  public static int createDatalistVector(FlatBufferBuilder builder, int[] data) { builder.startVector(4, data.length, 4); for (int i = data.length - 1; i >= 0; i--) builder.addOffset(data[i]); return builder.endVector(); }
  public static void startDatalistVector(FlatBufferBuilder builder, int numElems) { builder.startVector(4, numElems, 4); }
  public static int endTableTiming(FlatBufferBuilder builder) {
    int o = builder.endTable();
    return o;
  }

  public static final class Vector extends BaseVector {
    public Vector __assign(int _vector, int _element_size, ByteBuffer _bb) { __reset(_vector, _element_size, _bb); return this; }

    public TableTiming get(int j) { return get(new TableTiming(), j); }
    public TableTiming get(TableTiming obj, int j) {  return obj.__assign(__indirect(__element(j), bb), bb); }
  }
}
