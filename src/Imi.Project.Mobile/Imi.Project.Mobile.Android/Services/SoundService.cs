using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Imi.Project.Mobile.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Imi.Project.Mobile.Droid.Services.SoundService))]
namespace Imi.Project.Mobile.Droid.Services
{
    public class SoundService : ISoundService
    {
        private MediaPlayer _mediaPlayer;

        public Task PlayBirdSound(string sound)
        {
            _mediaPlayer = MediaPlayer
                .Create(global::Android.App.Application.Context, GetSound(sound)); 
            _mediaPlayer.Start();
            return Task.Delay(0);

        }

        public void StopSound()
        {
            _mediaPlayer.Stop();

        }

        public int GetSound(string sound)
        {
            int resource = 0;
            switch (sound)
            {
                case "cockatiel.mp3":
                    resource= Resource.Raw.cockatiel;
                    break;

                case "budgerigar.mp3":
                    resource = Resource.Raw.budgie;
                    break;

                default:
                    resource = Resource.Raw.crickets;
                    break;
            }
            return resource;
        }
    }
}