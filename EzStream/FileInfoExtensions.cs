﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace EzStreaming
{
    public static class FileInfoExtensions
    {
        public static void CopyTo(this FileInfo file, FileInfo destination, Action<int> progressCallback)
        {
            const int bufferSize = 1024 * 1024;  //1MB
            byte[] buffer = new byte[bufferSize], buffer2 = new byte[bufferSize];
            bool swap = false;
            int progress = 0, reportedProgress = 0, read = 0;
            long len = file.Length;
            float flen = len;
            Task writer = null;

            using (var source = file.OpenRead())
            using (var dest = destination.OpenWrite())
            {
                dest.SetLength(source.Length);
                for (long size = 0; size < len; size += read)
                {
                    if ((progress = ((int)((size / flen) * 100))) != reportedProgress)
                        progressCallback(reportedProgress = progress);
                    read = source.Read(swap ? buffer : buffer2, 0, bufferSize);
                    writer?.Wait();  // if < .NET4 // if (writer != null) writer.Wait(); 
                    writer = dest.WriteAsync(swap ? buffer : buffer2, 0, read);
                    swap = !swap;
                }
                writer?.Wait();  //Fixed - Thanks @sam-hocevar
            }
        }
    }
}
