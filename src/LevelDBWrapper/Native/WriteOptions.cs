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

    public class WriteOptions : IDisposable
    {
        private HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal WriteOptions(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(WriteOptions obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~WriteOptions()
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
                        LeveldbPINVOKE.delete_WriteOptions(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public WriteOptions()
            : this(LeveldbPINVOKE.new_WriteOptions(), true)
        {
        }

        public bool sync
        {
            set
            {
                LeveldbPINVOKE.WriteOptions_sync_set(swigCPtr, value);
            }
            get
            {
                bool ret = LeveldbPINVOKE.WriteOptions_sync_get(swigCPtr);
                return ret;
            }
        }

    }

}
