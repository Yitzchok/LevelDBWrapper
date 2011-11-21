/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 1.3.40
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace LevelDBWrapper.Native {

using System;
using System.Runtime.InteropServices;

public class DBTable : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DBTable(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(DBTable obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~DBTable() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LeveldbPINVOKE.delete_DBTable(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public static DBTable open(Options options, string filename, long fileSize) {
    IntPtr cPtr = LeveldbPINVOKE.DBTable_open(Options.getCPtr(options), filename, fileSize);
    DBTable ret = (cPtr == IntPtr.Zero) ? null : new DBTable(cPtr, false);
    if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public DBIterator newIterator(ReadOptions opts) {
    IntPtr cPtr = LeveldbPINVOKE.DBTable_newIterator(swigCPtr, ReadOptions.getCPtr(opts));
    DBIterator ret = (cPtr == IntPtr.Zero) ? null : new DBIterator(cPtr, false);
    if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
