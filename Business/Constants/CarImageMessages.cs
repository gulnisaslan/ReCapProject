using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class CarImageMessages
    {
        public  static string CarImageListed;
        public static string CarImageAdded = "Image Added" ;
        public static string CarImageDontAdd = "Image Deleted";

        public static string CarImageUpdate { get; internal set; }
        public static string ImageCountError { get; internal set; }
        public static string ImageCountSuccess { get; internal set; }
        public static string ImageLimitExpiredForCar { get; internal set; }
        public static string ValidImageFileTypes { get; internal set; }
    }
}
