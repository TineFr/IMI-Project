using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces
{
    public interface IImageService
    {
        Task<Stream> SelectImage();
    }
}
