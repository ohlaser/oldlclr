﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace oldlclr
{
    /// <summary>
    /// HARUKA data link client 
    /// </summary>
    public class Client
        : ICloneable, IDisposable
    {

        /// <summary>
        /// Intanciate client in process heap
        /// </summary>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_client_create")]
        static extern IntPtr CreateI();

        /// <summary>
        /// Increment reference count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_client_retain")]
        static extern uint Retain(IntPtr objPtr);

        /// <summary>
        /// Decrement reference count
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_client_release")]
        static extern uint Release(IntPtr objPtr);

        /// <summary>
        /// get data link reciever status
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_client_get_receiver_status")]
        static extern IntPtr GetStatus(IntPtr objPtr);


        /// <summary>
        /// get data link reciever status
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_client_load_data")]
        static extern int LoadData(IntPtr objPtr, byte[] data, uint dataLength, byte[] cStrName);


        /// <summary>
        /// connect data link reciever
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_client_connect")]
        static extern int Connect(IntPtr objPtr);

        /// <summary>
        /// disconnect data link reciever
        /// </summary>
        /// <param name="objPtr"></param>
        /// <returns></returns>
        [DllImport("oldl", EntryPoint = "oldl_client_disconnect")]
        static extern int Disconnect(IntPtr objPtr);


        /// <summary>
        /// generate name
        /// </summary>
        /// <returns></returns>
        static string GenerateDataName()
        {
            string result;
            result = null;

            string df;
            df = "yyyy-MM-dd-HH-mm-ss";

            string dataName;
            dataName = string.Format(df, DateTime.Now);

            result = string.Format("{0}.pdf", dataName);

            return result;

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




        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// constructor 
        /// </summary>
        public Client()
        {
            AttachRef(CreateI());
        }
        ~Client()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
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

        public object Clone()
        {
            Client result;
            result = (Client)base.MemberwiseClone();
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
        /// get data link server status
        /// </summary>
        /// <returns></returns>
        public Status GetStatus()
        {
            Status result;

            IntPtr statusPtr;
            statusPtr = IntPtr.Zero;

            result = null;
            statusPtr = GetStatus(ObjectPtr);
            if (statusPtr != IntPtr.Zero)
            {
                result = new Status();
                result.AttachRef(statusPtr);
            }

            return result;
        }


        /// <summary>
        /// send data to data server(Laser processing application)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public bool LoadData(byte[] data, string dataName)
        {
            bool result;

            result = false;


            if (dataName == null)
            {
                dataName = GenerateDataName();
            }

            byte[] dataNameByteArray;
            dataNameByteArray = System.Text.Encoding.UTF8.GetBytes(dataName);

            byte[] dataNameByteArray1 = new byte[dataNameByteArray.Length + 1];
            Array.Copy(dataNameByteArray, dataNameByteArray1, dataNameByteArray.Length);
            dataNameByteArray1[dataNameByteArray.Length] = 0;

            int state;
            state = LoadData(ObjectPtr, data, (uint)data.Length, dataNameByteArray1);

            result = state == 0;


            return result;
        }


        /// <summary>
        /// connect to data link reciever
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            int state;
            state = Connect(ObjectPtr);
            bool result;
            result = state == 0;
            return result;
        }

        /// <summary>
        /// disconnect from data link reciever.
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            int state;
            state = Disconnect(ObjectPtr);
            bool result;
            result = state == 0;
            return result;
        }

    }
}
