using Imi.Project.WPF.Models.Birds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Imi.Project.WPF.ViewModels
{
    public class BirdDetailViewModel
    {
        private BirdApiResponse bird;

        public BirdApiResponse Bird
        {
            get { return bird; }
            set { bird = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public BirdDetailViewModel(BirdApiResponse bird)
        {
            Bird = bird;
            Image = null;
            Image = Bird?.Image;
        }



    }
}
