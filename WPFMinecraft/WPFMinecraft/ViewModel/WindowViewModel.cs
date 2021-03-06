﻿using DALMinecraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFMinecraft.ViewModel
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region Private Member

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 900;
        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 600;

        /// <summary>
        /// The size of ther resize border around the window
        /// </summary>
        //public int ResizeBorder { get; set; } = 6;
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The inner content of the main window
        /// </summary>
        //public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless { get { return (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked); } }

        /// <summary>
        /// The current page of the application
        /// </summary>

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Home;

        /// <summary>
        /// The current data from database for the application
        /// </summary>
        public int ServerId { get; set; } = -1;
        public int WorldId { get; set; } = -1;
        public int PlayerId { get; set; } = -1;
        public int InventoryId { get; set; } = -1;

        #endregion

        #region Commands

        /// <summary>
        /// Command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }
        /// <summary>
        /// Command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }
        /// <summary>
        /// Command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }
        /// <summary>
        /// Command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }
        /// <summary>
        /// Command to go back a page
        /// </summary>
        public ICommand PreviousPageCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
            PreviousPageCommand = new RelayCommand(() => PreviousPage());

            // Fix window resize issue
            var resizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            resizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }

        #endregion

        #region Private Helpers
        
        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        /// <summary>
        /// If the window resizes to a special position (docked or maximized)
        /// this will update all required property change events to set the borders and radius values
        /// </summary>
        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        private void PreviousPage()
        {
            switch (CurrentPage)
            {
                case ApplicationPage.ServerManagement:
                    CurrentPage = ApplicationPage.Home;
                    break;

                case ApplicationPage.PlayerManagement:
                    if(ServerId ==-1)
                        CurrentPage = ApplicationPage.Home;
                    else
                        CurrentPage = ApplicationPage.Settings;
                    break;

                case ApplicationPage.Settings:
                    CurrentPage = ApplicationPage.ServerManagement;
                    break;

                case ApplicationPage.MoreOption:
                    CurrentPage = ApplicationPage.Settings;
                    break;

                case ApplicationPage.GameRule:
                    CurrentPage = ApplicationPage.Settings;
                    break;

                case ApplicationPage.Player:
                    CurrentPage = ApplicationPage.PlayerManagement;
                    break;

                case ApplicationPage.InventoryManager:
                    CurrentPage = ApplicationPage.Inventory;
                    break;

                case ApplicationPage.Inventory:
                    CurrentPage = ApplicationPage.Player;
                    break;

                case ApplicationPage.Advancements:
                    CurrentPage = ApplicationPage.Player;
                    break;

                case ApplicationPage.Effects:
                    CurrentPage = ApplicationPage.Player;
                    break;

                case ApplicationPage.Recipes:
                    CurrentPage = ApplicationPage.Player;
                    break;

                default:
                    CurrentPage = ApplicationPage.Home;
                    break;
            }
        }
        #endregion
    }
}
