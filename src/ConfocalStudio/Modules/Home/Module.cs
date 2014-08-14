namespace ConfocalStudio.Modules.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    using ConfocalStudio.Modules.Home.ViewModels;

    using Gemini.Framework;
    using Gemini.Framework.Results;
    using Gemini.Modules.MainMenu.Models;
    using Gemini.Modules.PropertyGrid;

    /// <summary>
    /// The Home Module exists mainly for demonstraion purposes.
    /// It displays a nice welcome message and demonstrates how to hook up to the 
    /// IPropertyGrid import.
    /// </summary>
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        /// <summary>
        /// The _property grid.
        /// </summary>
        [Import]
        private IPropertyGrid propertyGrid;

        /// <summary>
        /// Gets the default documents.
        /// </summary>
        public override IEnumerable<IDocument> DefaultDocuments
        {
            get
            {
                yield return IoC.Get<HomeViewModel>();
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        public override void Initialize()
        {
            this.MainMenu.Find(KnownMenuItemNames.View).Add(new MenuItem("Home", this.OpenHome));
        }

        /// <summary>
        /// The post initialize.
        /// </summary>
        public override void PostInitialize()
        {
            this.propertyGrid.SelectedObject = IoC.Get<HomeViewModel>();
            this.Shell.OpenDocument(IoC.Get<HomeViewModel>());
        }

        /// <summary>
        /// The open home.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<IResult> OpenHome()
        {
            yield return Show.Document<HomeViewModel>();
        }
    }
}