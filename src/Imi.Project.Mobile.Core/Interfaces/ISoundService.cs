using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces
{
    public interface ISoundService
    {
        Task PlayBirdSound(string sound);

        void StopSound();
    }
}
