/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 1.3.40
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace Native
{

    using System;
    using System.Runtime.InteropServices;

    public class DBWriteBatch : IDisposable
    {
        private HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal DBWriteBatch(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(DBWriteBatch obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~DBWriteBatch()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        LeveldbPINVOKE.delete_DBWriteBatch(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public void Put(string key, string value)
        {
            LeveldbPINVOKE.DBWriteBatch_Put(swigCPtr, key, value);
        }

        public void Delete(string key)
        {
            LeveldbPINVOKE.DBWriteBatch_Delete(swigCPtr, key);
        }

        public void Clear()
        {
            LeveldbPINVOKE.DBWriteBatch_Clear(swigCPtr);
        }

        public DBWriteBatch()
            : this(LeveldbPINVOKE.new_DBWriteBatch(), true)
        {
        }

    }

}
