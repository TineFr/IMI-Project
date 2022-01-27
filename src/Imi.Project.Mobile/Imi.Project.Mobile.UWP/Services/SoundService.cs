using Imi.Project.Mobile.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(Imi.Project.Mobile.UWP.Services.SoundService))]
namespace Imi.Project.Mobile.UWP.Services
{
    public class SoundService : ISoundService
    {
        MediaElement element;
        public async Task PlayBirdSound(string sound)
        {
            Windows.Storage.StorageFile file;
            element = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package
                .Current.InstalledLocation.GetFolderAsync("Assets");
            try
            {
                file = await folder.GetFileAsync(sound);
            }
            catch (Exception ex)
            {
                file = await folder.GetFileAsync("crickets.mp3");
            }
            var stream = await file.OpenReadAsync();
            element.SetSource(stream, file.ContentType);
            element.Play();
        }

        public void StopSound()
        {
            element.Stop();

        }
    }
}
