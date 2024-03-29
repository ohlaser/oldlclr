﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;


namespace oldlclr
{
    public class Status : IDisposable, ICloneable
    {
        /// <summary>
        /// Intanciate receiver in process heap
        /// </summary>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_create")]
        static extern IntPtr CreateI();

        /// <summary>
        /// Increment reference count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_retain")]
        static extern uint Retain(IntPtr objPtr);

        /// <summary>
        /// Decrement reference count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_release")]
        static extern uint Release(IntPtr objPtr);


        /// <summary>
        /// Set started time of processing
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_set_started_time_of_processing")]
        static extern int SetStartedTimeOfProcessing(IntPtr objPtr, IntPtr strPtr);

        /// <summary>
        /// Get started time of processing
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_get_started_time_of_processing")]
        static extern IntPtr GetStartedTimeOfProcessing(IntPtr objPtr);



        /// <summary>
        /// Set started time of loading
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_set_started_time_of_loading")]
        static extern int SetStartedTimeOfLoading(IntPtr objPtr, IntPtr strPtr);

        /// <summary>
        /// Get started time of loading
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_get_started_time_of_loading")]
        static extern IntPtr GetStartedTimeOfLoading(IntPtr objPtr);




        /// <summary>
        /// Set finished time of processing
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_set_finished_time_of_processing")]
        static extern int SetFinishedTimeOfProcessing(IntPtr objPtr, IntPtr strPtr);

        /// <summary>
        /// Get finished time of processing
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_get_finished_time_of_processing")]
        static extern IntPtr GetFinishedTimeOfProcessing(IntPtr objPtr);



        /// <summary>
        /// Set finished time of loading
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_set_finished_time_of_loading")]
        static extern int SetFinishedTimeOfLoading(IntPtr objPtr, IntPtr strPtr);

        /// <summary>
        /// Get data name
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_get_data_name")]
        static extern IntPtr GetDataName(IntPtr objPtr);



        /// <summary>
        /// Set data name
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_set_data_name")]
        static extern int SetDataName(IntPtr objPtr, IntPtr strPtr);


        /// <summary>
        /// Get finished time of loading
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_get_finished_time_of_loading")]
        static extern IntPtr GetFinishedTimeOfLoading(IntPtr objPtr);


        /// <summary>
        /// Set processed count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_set_processed_count")]
        static extern int SetProcessedCount(IntPtr objPtr, uint processedCount);

        /// <summary>
        /// Get processed count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>          
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_get_processed_count")]
        static extern int GetProcessedCount(IntPtr objPtr, out uint processedCount);




        /// <summary>
        /// Set processed count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_set_processing_status")]
        static extern int SetStatusCode(IntPtr objPtr, int statusCode);

        /// <summary>
        /// Get processed count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_get_processing_status")]
        static extern int GetStatusCode(IntPtr objPtr, ref int statusCode);


        /// <summary>
        /// To json string
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_receiver_hdlr_status_to_json")]
        static extern IntPtr ToJsonStr(IntPtr objPtr);




        /// <summary>
        /// date time format
        /// </summary>
        static string DateTimeFormat
        {
            get
            {
                string result;
                result = null;

                result = "yyyy-MM-dd HH:mm:ss";

                return result;
            }
        }

        /// <summary>
        /// Laser processed count
        /// </summary>
        
        public uint ProcessedCount
        {
            get
            {
                uint result;
                result = 0;
                GetProcessedCount(ObjectPtr, out result);
                return result;
            }
            set
            {
                SetProcessedCount(ObjectPtr, value);
            }
        }

        /// <summary>
        /// StatusCode
        /// </summary>
        public StatusCode Code
        {
            get
            {
                return GetStatusCode();
            }
            set
            {
                SetStatusCode(value);
            }
        }

        /// <summary>
        /// Native object pointer
        /// </summary>
        private IntPtr ObjectPtrValue;

        /// <summary>
        /// Native Object pointer
        /// </summary>
        
        public IntPtr ObjectPtr
        {
            get
            {
                return ObjectPtrValue;
            }
        }

        private bool disposedValue;

        /// <summary>
        /// constructor
        /// </summary>
        public Status()
        {
            AttachRef(CreateI());
        }

       

        /// <summary>
        /// destructor
        /// </summary>
        ~Status()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        /// <summary>
        ///  bind this and objPtr
        /// </summary>
        /// <param name="objPtr"></param>
        public void Attach(IntPtr objPtr)
        {
            if (IntPtr.Zero != objPtr)
            {
                Retain(objPtr);
            }
            AttachRef(objPtr);
        }

        /// <summary>
        /// bind this and objPtr(Native object pointer)
        /// </summary>
        /// <param name="objPtr"></param>
        public void AttachRef(IntPtr objPtr)
        {
            if (IntPtr.Zero != ObjectPtr)
            {
                Release(ObjectPtr);
            }
            ObjectPtrValue = objPtr;
        }

        object ICloneable.Clone()
        {
            Status result;
            result = (Status)this.MemberwiseClone();

            Retain(result.ObjectPtr);

            return result;

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                Attach(IntPtr.Zero);

                disposedValue = true;
            }
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// set started time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetStartedTimeOfProcessing(Str timeOfProcessing)
        {
            if (timeOfProcessing != null)
            {
                SetStartedTimeOfProcessing(ObjectPtr, timeOfProcessing.ObjectPtr);
            }
        }

        /// <summary>
        /// set started time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetStartedTimeOfProcessing(string timeOfProcessing)
        {
            if (timeOfProcessing != null)
            {
                Str strObj;
                strObj = new Str(timeOfProcessing);
                SetStartedTimeOfProcessing(strObj);
                strObj.Dispose();
            }
        }

        /// <summary>
        /// set started time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetStartedTimeOfProcessing(DateTime timeOfProcessing)
        {
            SetStartedTimeOfProcessing(timeOfProcessing.ToString(DateTimeFormat));
        }
        /// <summary>
        /// set started time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetStartedTimeOfProcessing(DateTime? timeOfProcessing)
        {
            if (timeOfProcessing != null)
            {
                SetStartedTimeOfProcessing((DateTime)timeOfProcessing);
            }
        }

        /// <summary>
        /// set started time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetStartedTimeOfLoading(Str timeOfLoading)
        {
            if (timeOfLoading != null)
            {
                SetStartedTimeOfLoading(ObjectPtr, timeOfLoading.ObjectPtr);
            }
        }

        /// <summary>
        /// set started time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetStartedTimeOfLoading(string timeOfLoading)
        {
            if (timeOfLoading != null)
            {
                Str strObj;
                strObj = new Str(timeOfLoading);
                SetStartedTimeOfLoading(strObj);
                strObj.Dispose();
            }
        }

        /// <summary>
        /// set started time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetStartedTimeOfLoading(DateTime timeOfLoading)
        {
            SetStartedTimeOfLoading(timeOfLoading.ToString(DateTimeFormat));
        }

        /// <summary>
        /// set started time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetStartedTimeOfLoading(DateTime? timeOfLoading)
        {
            if (timeOfLoading != null)
            {
                SetStartedTimeOfLoading((DateTime)timeOfLoading);
            }
        }

        /// <summary>
        /// set finished time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetFinishedTimeOfLoading(Str timeOfLoading)
        {
            if (timeOfLoading != null)
            {
                SetFinishedTimeOfLoading(ObjectPtr, timeOfLoading.ObjectPtr);
            }
        }

        /// <summary>
        /// set finished time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetFinishedTimeOfLoading(string timeOfLoading)
        {
            if (timeOfLoading != null)
            {
                Str strObj;
                strObj = new Str(timeOfLoading);
                SetFinishedTimeOfLoading(strObj);
                strObj.Dispose();
            }
        }

        /// <summary>
        /// set finished time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetFinishedTimeOfLoading(DateTime timeOfLoading)
        {
            SetFinishedTimeOfLoading(timeOfLoading.ToString(DateTimeFormat));
        }

        /// <summary>
        /// set finished time of loading
        /// </summary>
        /// <param name="timeOfLoading"></param>
        public void SetFinishedTimeOfLoading(DateTime? timeOfLoading)
        {
            if (timeOfLoading != null)
            {
                SetFinishedTimeOfLoading((DateTime)timeOfLoading);
            }
        }

        /// <summary>
        /// set finished time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetFinishedTimeOfProcessing(Str timeOfProcessing)
        {
            if (timeOfProcessing != null)
            {
                SetFinishedTimeOfProcessing(ObjectPtr, timeOfProcessing.ObjectPtr);
            }
        }


        /// <summary>
        /// set data name
        /// </summary>
        /// <param name="dataName"></param>
        public void SetDataName(Str dataName)
        {
            if (dataName != null)
            {
                SetDataName(ObjectPtr, dataName.ObjectPtr);
            }
        }

        /// <summary>
        /// set data name
        /// </summary>
        /// <param name="dataName"></param>
        public void SetDataName(string dataName)
        {
            if (dataName != null)
            {
                Str strObj;
                strObj = new Str(dataName);
                SetDataName(strObj);
                strObj.Dispose();
            }
        }


        /// <summary>
        /// set finished time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetFinishedTimeOfProcessing(string timeOfProcessing)
        {
            if (timeOfProcessing != null)
            {
                Str strObj;
                strObj = new Str(timeOfProcessing);
                SetFinishedTimeOfProcessing(strObj);
                strObj.Dispose();
            }
        }

        /// <summary>
        /// set finished time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetFinishedTimeOfProcessing(DateTime timeOfProcessing)
        {
            SetFinishedTimeOfProcessing(timeOfProcessing.ToString(DateTimeFormat));
        }

        /// <summary>
        /// set finished time of processing
        /// </summary>
        /// <param name="timeOfProcessing"></param>
        public void SetFinishedTimeOfProcessing(DateTime? timeOfProcessing)
        {
            if (timeOfProcessing != null)
            {
                SetFinishedTimeOfProcessing((DateTime)timeOfProcessing);
            }
        }

        /// <summary>
        /// set status code
        /// </summary>
        /// <param name="code"></param>
        public void SetStatusCode(StatusCode code)
        {
            SetStatusCode(ObjectPtr, (int)code);
        }


        /// <summary>
        /// get status code
        /// </summary>
        /// <returns></returns>
        public StatusCode GetStatusCode()
        {
            StatusCode result;
            int code;
            code = 0;
            GetStatusCode(ObjectPtr, ref code);
            result = (StatusCode)code;
            return result;
        }

        /// <summary>
        /// to json string
        /// </summary>
        /// <returns></returns>
        public Str ToJsonStr()
        {
            Str result;
            IntPtr jsonPtr;
            result = null;
            jsonPtr = ToJsonStr(ObjectPtr);
            if (IntPtr.Zero != jsonPtr)
            {
                result = new Str(jsonPtr);
            }
            return result;
        }

        /// <summary>
        /// to json
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            string result;
            result = null;

            Str jsonStr;
            jsonStr = ToJsonStr();
            if (jsonStr != null)
            {

                result = jsonStr.GetContentsAsString();
                jsonStr.Dispose();
            }

            return result;
        }

    }
}
