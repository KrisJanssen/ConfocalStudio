using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Gemini.Framework;
using Gemini.Modules.ErrorList;
using Gemini.Modules.Inspector;
using Gemini.Modules.Output;
using Gemini.Modules.Toolbox;
using Gemini.Modules.UndoRedo;


namespace ConfocalStudio.Modules.Startup
{
    using System.Reflection;

    using Gemini.Framework.Services;
    using System.Windows;

    /// <summary>
    /// The module.
    /// </summary>
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        /// <summary>
        /// The resource manager handles resource location for us.
        /// </summary>
        private readonly IResourceManager resourceManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class, importing an <see cref="IResourceManager"/>.
        /// </summary>
        /// <param name="resourceManager">
        /// The resource manager.
        /// </param>
        [ImportingConstructor]
        public Module(IResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        /// <summary>
        /// Gets the default tools, i.e those that will be made visual by default.
        /// Reconstruction of the Mainwindow persisted state takes precedence over this.
        /// </summary>
        public override IEnumerable<Type> DefaultTools
        {
            get
            {
                yield return typeof(IErrorList);
                yield return typeof(IHistoryTool);
                yield return typeof(IInspectorTool);
                yield return typeof(IOutput);
                yield return typeof(IToolbox);
            }
        }

        /// <summary>
        /// Initialize the module by setting global properties of the application.
        /// </summary>
        public override void Initialize()
        {
            MainWindow.WindowState = WindowState.Maximized;
            MainWindow.Title = "Confocal Studio";
            MainWindow.Icon = resourceManager.GetBitmap("Resources/AppIcon.ico",
                Assembly.GetExecutingAssembly().GetAssemblyName());

            Shell.ShowFloatingWindowsInTaskbar = true;

            Shell.StatusBar.AddItem("Ready", new GridLength(1, GridUnitType.Star));

        }
    }
}