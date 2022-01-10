using UnityEngine;

namespace Kayac
{
    public class WeakEncrypter
    {
        // Methods
        public static System.Exception Save(object obj, string key, string path)
        {
            return Kayac.WeakEncrypter.Save(text:  UnityEngine.JsonUtility.ToJson(obj:  obj), key:  key, path:  path);
        }
        public static System.Exception Save<T>(T obj, string key, string path)
        {
            return Kayac.WeakEncrypter.Save(text:  UnityEngine.JsonUtility.ToJson(obj:  obj), key:  key, path:  path);
        }
        public static System.Exception Load<T>(string key, string path, out T objOut)
        {
            var val_3;
            string val_1 = 0;
            objOut = 0;
            if((Kayac.WeakEncrypter.Load(key:  key, path:  path, textOut: out  val_1)) != null)
            {
                    return (System.Exception)val_3;
            }
            
            val_3 = 0;
            objOut = val_1;
            return (System.Exception)val_3;
        }
        public static System.Exception Save(string text, string key, string path)
        {
            System.IO.File.WriteAllBytes(path:  path, bytes:  Kayac.WeakEncrypter.Encrypt(text:  text, key:  key));
            return 0;
        }
        public static System.Exception Load(string key, string path, out string textOut)
        {
            var val_4;
            textOut = 0;
            System.Byte[] val_1 = System.IO.File.ReadAllBytes(path:  path);
            if(val_1 == null)
            {
                goto label_1;
            }
            
            string val_2 = Kayac.WeakEncrypter.Decrypt(encrypted:  val_1, key:  key);
            if(val_2 == null)
            {
                goto label_2;
            }
            
            val_4 = 0;
            textOut = val_2;
            return (System.Exception)val_4;
            label_1:
            val_4 = 0;
            return (System.Exception)val_4;
            label_2:
            System.Exception val_3 = null;
            val_4 = val_3;
            val_3 = new System.Exception(message:  "hash value not match.");
            return (System.Exception)val_4;
        }
        public static byte[] Encrypt(string text, string key)
        {
            System.Array val_9;
            byte val_10;
            val_9 = System.Text.Encoding.UTF8;
            if(key == null)
            {
                goto label_2;
            }
            
            if((val_1.dataItem << 32) < 1)
            {
                goto label_5;
            }
            
            var val_11 = 0;
            do
            {
                System.Text.Encoding val_4 = System.Text.Encoding.UTF8 + (0 << );
                bool val_10 = val_1.m_deserializedFromEverett + 0;
                val_10 = ((val_2 + (0) << ).m_deserializedFromEverett) ^ val_10;
                m_value = val_10;
                val_11 = val_11 + 1;
                val_10 = (0 * 137) + val_10;
                var val_7 = ((0 + 1) >= val_2.dataItem) ? 0 : (0 + 1);
            }
            while(val_11 < (long)val_1.dataItem);
            
            goto label_10;
            label_2:
            UnityEngine.Debug.LogWarning(message:  "WeakEncrypter.Encrypt() : no key. return plain text.");
            return (System.Byte[])val_9;
            label_5:
            val_10 = 0;
            label_10:
            System.Globalization.CodePageDataItem val_8 = val_1.dataItem + 4;
            byte[] val_9 = new byte[0];
            val_9[0] = 0;
            val_9[0] = 0;
            val_9[0] = 0;
            val_9[0] = val_10;
            System.Array.Copy(sourceArray:  val_9, sourceIndex:  0, destinationArray:  val_9, destinationIndex:  4, length:  val_1.dataItem);
            val_9 = val_9;
            return (System.Byte[])val_9;
        }
        private static uint UpdateHash(uint prev, byte newByte)
        {
            prev = (prev * 137) + newByte;
            return (uint)prev;
        }
        public static string Decrypt(byte[] encrypted, string key)
        {
            var val_14;
            System.Exception val_15;
            int val_17;
            byte val_18;
            var val_19;
            var val_20;
            var val_23;
            val_15 = encrypted;
            if((val_15 == null) || (encrypted.Length < 4))
            {
                goto label_17;
            }
            
            System.Text.Encoding val_1 = System.Text.Encoding.UTF8;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(key == null)
            {
                goto label_4;
            }
            
            val_17 = encrypted.Length;
            val_18 = val_15[0];
            val_14 = val_1;
            val_19 = new byte[0];
            if(encrypted.Length < 5)
            {
                goto label_9;
            }
            
            int val_3 = encrypted.Length & 4294967295;
            do
            {
                if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
                System.Text.Encoding val_4 = val_14 + (0 << );
                byte val_17 = val_15[0];
                bool val_18 = (val_1 + (0) << ).m_deserializedFromEverett;
                val_20 = val_17 + (0 * 137);
                val_18 = val_18 ^ val_17;
                val_19[0] = val_18;
                var val_7 = 36 + 1;
                var val_8 = ((0 + 1) >= val_1.dataItem) ? 0 : (0 + 1);
            }
            while((36 - 31) < (encrypted.Length << ));
            
            goto label_16;
            label_4:
            val_17 = val_15;
            val_19 = ???;
            val_15 = ???;
            val_18 = ???;
            val_14 = ???;
            goto typeof(System.Text.Encoding).__il2cppRuntimeField_320;
            label_9:
            val_20 = 0;
            label_16:
            if(val_20 == W9)
            {
                    System.Text.Encoding val_9 = System.Text.Encoding.UTF8;
                if(val_19 == 0)
            {
                    throw new NullReferenceException();
            }
            
                var val_10 = (val_19 + 24) - 4;
                return (string)val_23;
            }
            
            label_17:
            val_23 = 0;
            return (string)val_23;
        }
        public WeakEncrypter()
        {
        
        }
    
    }

}
