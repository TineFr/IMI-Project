using Imi.Project.WPF.Core.Models;

namespace Imi.Project.WPF.ViewModels
{
    public class BirdDetailViewModel
    {
        private BirdModel bird;

        public BirdModel Bird
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

        public BirdDetailViewModel(BirdModel bird)
        {
            Bird = bird;
            Image = null;
            Image = Bird?.Image;
        }



    }
}
