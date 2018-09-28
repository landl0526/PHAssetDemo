using Foundation;
using Photos;
using System;
using System.IO;
using UIKit;

namespace PHAssetDemo
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnClick(UIKit.UIButton sender)
        {
            PHFetchResult fetchResults = PHAsset.FetchAssets(PHAssetMediaType.Image, null);

            for (int i = 0; i < fetchResults.Count; i++)
            {
                //fetching Result
                PHAsset phAsset = (PHAsset)fetchResults[i];
                String fileName = (NSString)phAsset.ValueForKey((NSString)"filename");
                PHImageManager.DefaultManager.RequestImageData(phAsset, null, (data, dataUti, orientation, info) =>
                {
                    var path = (info?[(NSString)@"PHImageFileURLKey"] as NSUrl).FilePathUrl.Path;
                    //Stream stream = System.IO.OpenRead((String)path);

                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                });
            }
        }
    }
}