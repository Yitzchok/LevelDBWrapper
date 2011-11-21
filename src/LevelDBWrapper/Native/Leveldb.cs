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

    public class Leveldb
    {
        public static Status DestroyDB(string name, Options options)
        {
            Status ret = new Status(LeveldbPINVOKE.DestroyDB(name, Options.getCPtr(options)), true);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Status RepairDB(string dbname, Options options)
        {
            Status ret = new Status(LeveldbPINVOKE.RepairDB(dbname, Options.getCPtr(options)), true);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Snapshot getSnapshotValue(SWIGTYPE_p_p_leveldb__Snapshot p)
        {
            IntPtr cPtr = LeveldbPINVOKE.getSnapshotValue(SWIGTYPE_p_p_leveldb__Snapshot.getCPtr(p));
            Snapshot ret = (cPtr == IntPtr.Zero) ? null : new Snapshot(cPtr, false);
            return ret;
        }

    }

}