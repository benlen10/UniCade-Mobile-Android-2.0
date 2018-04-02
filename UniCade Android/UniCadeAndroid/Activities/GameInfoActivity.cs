﻿using Android.App;
using System.IO;
using System;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using UniCadeAndroid.Constants;

namespace UniCadeAndroid.Activities
{
    [Activity(Label = "Game Info")]
    public class GameInfoActivity : Activity
    {

		#region Private Instance Variables

        private TextView _titleTextView;

        private TextView _consoleTextView;

        private TextView _publisherTextView;

        private TextView _criticScoreTextView;

        private TextView _playersTextView;

        private TextView _esrbRatingTextView;

        private TextView _esrbDescriptorsTextView;

        private TextView _releaseDateTextView;

        private TextView _launchCountTextView;

        private TextView _descriptionTextView;

        private Button _rescrapeGameButton;

        private Button _rescrapeConsoleButton;

        private Button _saveInfoButton;

        private Button _closeInfoButton;

        private Button _refreshInfoButton;

        private ImageView _boxFrontImageView;

        private ImageView _boxBackImageView;

        private ImageView _screenshotImageView;

        private ImageView _esrbLogoImageView;

		#endregion

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			// Set the view
			SetContentView(Resource.Layout.GameInfoView);

			FindElementsById();

			CreateEventHandlers();

            RefreshsGameInfo();

            PopulateGameImages();
        }

        private void RefreshsGameInfo()
        {
            _titleTextView.Text = "Title: " + MainActivity.CurrentGame.Title;
            _consoleTextView.Text = "Console: " + MainActivity.CurrentGame.ConsoleName;
            _publisherTextView.Text = "Publisher: " + MainActivity.CurrentGame.PublisherName;
            _criticScoreTextView.Text = "Critic Score: " + MainActivity.CurrentGame.CriticReviewScore;
            _playersTextView.Text = "Player Count: " + MainActivity.CurrentGame.SupportedPlayerCount;
            _esrbRatingTextView.Text = "ESRB Rating: " + MainActivity.CurrentGame.EsrbRating.GetStringValue();
            _esrbDescriptorsTextView.Text = "ESRB Descriptors: " + MainActivity.CurrentGame.GetEsrbDescriptorsString();
            _launchCountTextView.Text = "Launch Count: " + MainActivity.CurrentGame.GetLaunchCount().ToString();
            _releaseDateTextView.Text = "Release Date: " + MainActivity.CurrentGame.ReleaseDate;
            _descriptionTextView.Text = "Description:" + MainActivity.CurrentGame.Description;
        }

		protected void ShowInputDialog(string title, Action<string> handlerFunction)
		{

			EditText editText = new EditText(this);
			AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);
			dialogBuilder.SetTitle(title);
			dialogBuilder.SetPositiveButton("Enter", (senderAlert, args) =>
			{
				handlerFunction(editText.Text);
			});

			dialogBuilder.SetNegativeButton("Cancel", (senderAlert, args) =>
			{

			});
			dialogBuilder.SetView(editText);
			dialogBuilder.Show();
		}


		private void PopulateGameImages()
        {
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path;
            string imagePath = sdCardPath + ConstPaths.GameImagesPath + MainActivity.CurrentGame.ConsoleName + "/" + MainActivity.CurrentGame.Title + "_BoxFront.jpg";
            if (File.Exists(imagePath))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(imagePath);
                _boxFrontImageView.SetImageBitmap(bitmap);
            }

            imagePath = sdCardPath + ConstPaths.GameImagesPath + MainActivity.CurrentGame.ConsoleName + "/" + MainActivity.CurrentGame.Title + "_BoxBack.jpg";
            if (File.Exists(imagePath))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(imagePath);
                _boxBackImageView.SetImageBitmap(bitmap);
            }

            imagePath = sdCardPath + ConstPaths.GameImagesPath + MainActivity.CurrentGame.ConsoleName + "/" + MainActivity.CurrentGame.Title + "_Screenshot.jpg";
            if (File.Exists(imagePath))
            {
                Bitmap bitmap = BitmapFactory.DecodeFile(imagePath);
                _screenshotImageView.SetImageBitmap(bitmap);
            }

            _esrbLogoImageView.SetImageURI(Backend.Utilties.GetEsrbLogoImage(MainActivity.CurrentGame.EsrbRating));
        }

        private void SaveGameInfo()
        {
            MainActivity.CurrentGame.PublisherName = _publisherTextView.Text;
            MainActivity.CurrentGame.CriticReviewScore = _criticScoreTextView.Text;
            MainActivity.CurrentGame.SupportedPlayerCount = _playersTextView.Text;
            MainActivity.CurrentGame.ReleaseDate = _releaseDateTextView.Text;
            MainActivity.CurrentGame.Description = _descriptionTextView.Text;
            //TODO: Properly save ESRB info
        }


        private void FindElementsById()
        {
            _titleTextView = FindViewById<TextView>(Resource.Id.TitleTextView);
            _consoleTextView = FindViewById<TextView>(Resource.Id.ConsoleTextView);
            _publisherTextView = FindViewById<TextView>(Resource.Id.PublisherTextView);
            _criticScoreTextView = FindViewById<TextView>(Resource.Id.CriticScoreTextView);
            _playersTextView = FindViewById<TextView>(Resource.Id.PlayersTextView);
            _esrbRatingTextView = FindViewById<TextView>(Resource.Id.EsrbRatingTextView);
            _esrbDescriptorsTextView = FindViewById<TextView>(Resource.Id.EsrbDescriptorsTextView);
            _releaseDateTextView = FindViewById<TextView>(Resource.Id.ReleaseDateTextView);
            _descriptionTextView = FindViewById<TextView>(Resource.Id.DescriptonTextView);
            _rescrapeGameButton = FindViewById<Button>(Resource.Id.RescrapeGameButton);
            _rescrapeConsoleButton = FindViewById<Button>(Resource.Id.RescrapeConsoleButton);
            _saveInfoButton = FindViewById<Button>(Resource.Id.SaveButton);
            _closeInfoButton = FindViewById<Button>(Resource.Id.CloseButton);
            _refreshInfoButton = FindViewById<Button>(Resource.Id.RefreshButton);
            _boxFrontImageView = FindViewById<ImageView>(Resource.Id.BoxFrontImageView);
            _boxBackImageView = FindViewById<ImageView>(Resource.Id.BoxBackImageView);
            _screenshotImageView = FindViewById<ImageView>(Resource.Id.ScreenshotImageView);
            _esrbLogoImageView = FindViewById<ImageView>(Resource.Id.EsrbLogoImageView);
        }

        private void CreateEventHandlers(){

            _publisherTextView.Click += (sender, e) =>
			{

			};

            _criticScoreTextView.Click += (sender, e) =>
			{

			};

            _playersTextView.Click += (sender, e) =>
			{

			};

            _esrbRatingTextView.Click += (sender, e) =>
			{

			};

            _esrbDescriptorsTextView.Click += (sender, e) =>
			{

			};

            _releaseDateTextView.Click += (sender, e) =>
			{

			};

            _descriptionTextView.Click += (sender, e) =>
			{

			};
            
            _boxFrontImageView.Click += (sender, e) =>
            {
                //TODO: Expand box front image
            };

            _boxBackImageView.Click += (sender, e) =>
            {
                //TODO: Expand box back image
            };

            _screenshotImageView.Click += (sender, e) =>
            {
                //TODO: Expand screenshot image
            };

            _rescrapeGameButton.Click += (sender, e) =>
            {
                //TODO: 
            };

            _rescrapeConsoleButton.Click += (sender, e) =>
            {
                //TODO: 
            };

            _saveInfoButton.Click += (sender, e) =>
            {
               SaveGameInfo();
            };

            _closeInfoButton.Click += (sender, e) =>
            {
                Finish();
            };

            _refreshInfoButton.Click += (sender, e) =>
            {
                //TODO: 
            };

        }
    }
}
