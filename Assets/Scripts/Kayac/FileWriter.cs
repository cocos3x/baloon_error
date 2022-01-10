using UnityEngine;

namespace Kayac
{
    public class FileWriter
    {
        // Fields
        private System.Collections.Generic.Queue<Kayac.FileWriter.Item> queue;
        
        // Methods
        public FileWriter()
        {
            this.queue = new System.Collections.Generic.Queue<Item>();
        }
        public void SaveAsync(string path, string text, System.Action<System.Exception> onComplete)
        {
            this.SaveAsync(path:  path, bytes:  System.Text.Encoding.UTF8, onComplete:  onComplete);
        }
        public void SaveAsync(string path, byte[] bytes, System.Action<System.Exception> onComplete)
        {
            .path = path;
            .bytes = bytes;
            .onComplete = onComplete;
            this.queue.Enqueue(item:  new FileWriter.Item());
            if(this.queue != 1)
            {
                    return;
            }
            
            this.Process();
        }
        public static void LoadBinaryAsync(string path, System.Action<byte[], System.Exception> onComplete)
        {
            System.Runtime.CompilerServices.AsyncVoidMethodBuilder val_1 = System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Create();
        }
        private void Process()
        {
            System.Runtime.CompilerServices.AsyncVoidMethodBuilder val_1 = System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Create();
        }
    
    }

}
