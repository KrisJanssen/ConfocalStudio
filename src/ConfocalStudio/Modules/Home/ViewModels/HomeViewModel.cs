namespace ConfocalStudio.Modules.Home.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Media;

    using Gemini.Framework;

    /// <summary>
    /// The home view model.
    /// </summary>
    [DisplayName("Home View Model")]
    [Export(typeof(HomeViewModel))]
    public class HomeViewModel : Document
    {
        /// <summary>
        /// The background.
        /// </summary>
        private Color background;

        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        public Color Background
        {
            get
            {
                return this.background;
            }

            set
            {
                this.background = value;
                this.NotifyOfPropertyChange(() => this.Background);
            }
        }

        /// <summary>
        /// The foreground.
        /// </summary>
        private Color foreground;

        /// <summary>
        /// Gets or sets the foreground.
        /// </summary>
        public Color Foreground
        {
            get
            {
                return this.foreground;
            }

            set
            {
                this.foreground = value;
                this.NotifyOfPropertyChange(() => this.Foreground);
            }
        }

        /// <summary>
        /// The text alignment.
        /// </summary>
        private TextAlignment textAlignment;

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        [DisplayName("Text Alignment")]
        public TextAlignment TextAlignment
        {
            get
            {
                return this.textAlignment;
            }
            set
            {
                this.textAlignment = value;
                this.NotifyOfPropertyChange(() => this.TextAlignment);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        public HomeViewModel()
        {
            this.DisplayName = "Home";
            this.Background = Colors.CornflowerBlue;
            this.Foreground = Colors.White;
            this.TextAlignment = TextAlignment.Center;
        }
    }
}