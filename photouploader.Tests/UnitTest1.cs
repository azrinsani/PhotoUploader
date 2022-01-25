using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace photouploader.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task TestUpload(bool emptyObject)
        {
            List<PhotoVM> photos;
            if (emptyObject) photos = null;
            else
            {
                var fullPath = createNewTempFile();
                photos = new List<PhotoVM>
                {
                    new(fullPath)
                };
            }

            var appService = new AppService();
            try
            {
                await appService.Upload(photos);
                Assert.True(true);
            }
            catch
            {
                Assert.True(emptyObject);
            }
        }
        
        
        private string createNewTempFile()
        {
            string fileName;
            bool bCollisions;
            do {
                fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".tmp");
                try
                {
                    using (new FileStream(fileName, FileMode.CreateNew)) { }
                    bCollisions = false;
                }
                catch (IOException)
                {
                    bCollisions = true;
                }
            }
            while (bCollisions);
            return fileName;
        }

    }
}